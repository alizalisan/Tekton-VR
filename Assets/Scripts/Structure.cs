using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class Structure : MonoBehaviour {

    // Use this for initialization
    String CoordStr;
    public GameObject Wall;
    void Start()
    {
        //Intent call ---------------------------------
        //Debug.Log("Getting Intent...");
        //AndroidJavaClass pluginClass = new AndroidJavaClass("digital.haa.plugin.MainActivity");
        //Debug.Log("pluginClass : " + pluginClass);

        //CoordStr = pluginClass.CallStatic<string>("GetSessionId");

        //-----------------------
        TextAsset txt = (TextAsset)Resources.Load("Tekton_sample600", typeof(TextAsset));
        string text1 = txt.text;

        //Get coords from Intent string
        //string text1 = CoordStr;

        string[] text = new string[10];
        int len = 0;

        using (StringReader reader = new StringReader(text1))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                text[len] = line;
                len++;
            }
        }

        int current_index = 0;

        float height = 18;

        //for ceiling and floor
        float maxX = 0;
        float maxZ = 0;
        float minX = float.MaxValue;
        float minZ = float.MaxValue;

        float x1 = 0, x2 = 0, x3 = 0, x4 = 0, z1 = 0, z2 = 0, z3 = 0, z4 = 0;

        //Split string on colons(:).This will separate all the words in a string
        string[] walls1 = text[current_index].Split(':');

        //Excluding the first token (no.of walls) and last token(next line)
        string[] walls = new string[walls1.Length - 2];
        for (int i = 1; i < (walls1.Length - 1); i++)
        {
            walls[i - 1] = walls1[i];
        }

        foreach (string word in walls)
        {
            string[] coords = word.Split(' ');
            for (int i = 0; i < coords.Length && (coords.Length > 1); i++)
            {
                if (i == 0)
                {
                    x1 = float.Parse(coords[i]);
                    x1 = x1 / 10;
                    x3 = x1;
                }
                else if (i == 1)
                {
                    z1 = float.Parse(coords[i]);
                    z1 = z1 / 10;
                    z2 = z1;
                }
                else if (i == 2)
                {
                    x4 = float.Parse(coords[i]);
                    x4 = x4 / 10;
                    x2 = x4;
                }
                else if (i == 3)
                {
                    z4 = int.Parse(coords[i]);
                    z4 = z4 / 10;
                    z3 = z4;
                }
            }

            float diffX = Math.Abs(x1 - x4);
            float diffZ = Math.Abs(z1 - z4);

            GameObject wall1 = Instantiate(Resources.Load("Wall", typeof(GameObject))) as GameObject;
            wall1.transform.position = new Vector3(0, 0, 0);
            wall1.transform.rotation = Quaternion.Euler(0, 0, 0);

            //Creating the parent game object
            GameObject myParentObject = new GameObject();
            myParentObject.name = "Wall";

            //Placing the parent game object to the top left corner of the child cube
            myParentObject.transform.position = new Vector3(-0.5F, -0.5F, 0.5F);

            //Makes the GameObject "myGameObject" the parent of the GameObject "wall1".
            wall1.transform.parent = myParentObject.transform;

            //determining length of the wall
            float scaleX = 0;

            //horizontal wall
            if (diffX > diffZ)
            {
                scaleX = diffX;
            }
            //vertical wall
            else
            {
                x2 = x4;
                z2 = z4;
                x3 = x1;
                z3 = z1;
                z1 = z2;
                z4 = z3;
                diffZ = Math.Abs(z1 - z4);
                scaleX = diffZ;
                myParentObject.transform.rotation = Quaternion.Euler(0, 90, 0);
            }

            myParentObject.transform.localScale = new Vector3(scaleX, height, 1);
            myParentObject.transform.position = new Vector3(x1, 0, z1);

            //getting coordinates for ceiling and floor
            if (maxX < x4)
            {
                maxX = x4;
            }
            if (maxZ < z1)
            {
                maxZ = z1;
            }
            if (z4 < minZ)
            {
                minZ = z4;
            }
            if (z1 < minZ)
            {
                minZ = z1;
            }
            if (x1 < minX)
            {
                minX = x1;
            }

        }

        float CeilScaleX = Math.Abs(maxX - minX);
        float CeilScaleZ = Math.Abs(maxZ - minZ);

        ////loop for creating ceiling and floor
        //for (int i = 0; i < 2; i++)
        //{
        //    //ceiling
        //    if (i == 0)
        //    {
        //        GameObject ceil = Instantiate(Resources.Load("Ceiling", typeof(GameObject))) as GameObject;
        //        ceil.transform.position = new Vector3(0, 0, 0);
        //        ceil.transform.rotation = Quaternion.Euler(0, 0, 0);

        //        GameObject myParent = new GameObject();
        //        myParent.transform.position = new Vector3(-0.5F, -0.5F, 0.5F);

        //        ceil.transform.parent = myParent.transform;

        //        myParent.name = "Ceiling";
        //        myParent.transform.position = new Vector3(minX, height, maxZ);
        //        myParent.transform.localScale = new Vector3(CeilScaleX, 0.5F, CeilScaleZ);
        //    }
        //    else
        //    {
        //        GameObject floor = Instantiate(Resources.Load("Floor", typeof(GameObject))) as GameObject;
        //        floor.transform.position = new Vector3(0, 0, 0);
        //        floor.transform.rotation = Quaternion.Euler(0, 0, 0);

        //        GameObject myParent1 = new GameObject();
        //        myParent1.transform.position = new Vector3(-0.5F, -0.5F, 0.5F);

        //        floor.transform.parent = myParent1.transform;

        //        myParent1.name = "Floor";
        //        myParent1.transform.position = new Vector3(minX, 0, maxZ);
        //        myParent1.transform.localScale = new Vector3(CeilScaleX, 0.1F, CeilScaleZ);
        //    }
        //}

        //creating doors
        float Ax = 0, Ay = 0, Bx = 0, By = 0, Cx = 0, Cy = 0;
   
        current_index++;
        string[] doors1 = text[current_index].Split(':');

        //Excluding the first token (no. of doors) and last token(next line)
        string[] doors = new string[doors1.Length - 2];
        for (int i = 1; i < (doors1.Length - 1); i++)
        {
            doors[i - 1] = doors1[i];
        }
        float doorHeight = 17;
        float doorThickness = 5;

        foreach (string word in doors)
        {
            string[] coords = word.Split(' ');
            for (int i = 0; i < coords.Length && (coords.Length > 1); i++)
            {
                if (i == 0)
                {
                    Ax = float.Parse(coords[i]);
                    Ax = Ax / 10;
                }
                else if (i == 1)
                {
                    Ay = float.Parse(coords[i]);
                    Ay = Ay / 10;
                }
                else if (i == 2)
                {
                    Bx = float.Parse(coords[i]);
                    Bx = Bx / 10;
                }
                else if (i == 3)
                {
                    By = float.Parse(coords[i]);
                    By = By / 10;
                }
                else if (i == 4)
                {
                    Cx = float.Parse(coords[i]);
                    Cx = Cx / 10;
                }
                else if (i == 5)
                {
                    Cy = float.Parse(coords[i]);
                    Cy = Cy / 10;
                }
            }

            GameObject door = Instantiate(Resources.Load("Door", typeof(GameObject))) as GameObject;
            door.transform.position = new Vector3(0, 0, 0);
            door.transform.rotation = Quaternion.Euler(0, 0, 0);

            GameObject pivot = new GameObject();
            pivot.name = "Door";

            float scale = 0;

            //Horizontal door
            if (Math.Abs(Ax - Bx) > Math.Abs(Ay - By))
            {
                scale = Math.Abs(Ax - Bx);
                //opening upwards
                if (Cy > By)
                {
                    if (Ax < Bx)
                    {
                        pivot.transform.position = new Vector3(0.5F, -0.5F, 0.5F);
                        door.transform.parent = pivot.transform;

                        pivot.transform.position = new Vector3(Bx, 0, By);
                    }
                    //change pivot
                    else
                    {
                        pivot.transform.position = new Vector3(0.5F, -0.5F, 0.5F);
                        door.transform.parent = pivot.transform;

                        pivot.transform.position = new Vector3(Ax, 0, Ay);
                    }
                    pivot.transform.localScale = new Vector3(scale, doorHeight, doorThickness);
                    
                    Animator anim = pivot.AddComponent<Animator>();
                    anim.runtimeAnimatorController = Resources.Load("Animations/New Game Object 1") as RuntimeAnimatorController;
                }
                //opening downwards
                else
                {
                    if (Bx < Ax)
                    {
                        pivot.transform.position = new Vector3(-0.5F, -0.5F, 0.5F);
                        door.transform.parent = pivot.transform;

                        pivot.transform.position = new Vector3(Bx, 0, By);
                    }
                    //change pivot
                    else
                    {
                        pivot.transform.position = new Vector3(-0.5F, -0.5F, 0.5F);
                        door.transform.parent = pivot.transform;

                        pivot.transform.position = new Vector3(Ax, 0, Ay);
                    }
                    pivot.transform.localScale = new Vector3(scale, doorHeight, doorThickness);
                    
                    Animator anim = pivot.AddComponent<Animator>();
                    anim.runtimeAnimatorController = Resources.Load("Animations/New Game Object 1") as RuntimeAnimatorController;
                }
            }
            //vertical door
            else
            {
                scale = Math.Abs(Ay - By);
                //opening towards right
                if (Cx > Bx)
                {
                    if (By < Ay)
                    {
                        pivot.transform.position = new Vector3(0.5F, -0.5F, 0.5F);
                        door.transform.parent = pivot.transform;

                        pivot.transform.position = new Vector3(Bx, 0, By);
                    }
                    //change pivot
                    else
                    {
                        pivot.transform.position = new Vector3(0.5F, -0.5F, 0.5F);
                        door.transform.parent = pivot.transform;

                        pivot.transform.position = new Vector3(Ax, 0, Ay);
                    }
                    pivot.transform.localScale = new Vector3(scale, doorHeight, doorThickness);
                    pivot.transform.rotation = Quaternion.Euler(0, 90, 0);
                    
                    Animator anim = pivot.AddComponent<Animator>();
                    anim.runtimeAnimatorController = Resources.Load("Animations/New Game Object 3") as RuntimeAnimatorController;
                }
                //opening left
                else
                {
                    if (By > Ay)
                    {
                        pivot.transform.position = new Vector3(-0.5F, -0.5F, 0.5F);
                        door.transform.parent = pivot.transform;

                        pivot.transform.position = new Vector3(Bx, 0, By);
                    }
                    //change pivot
                    else
                    {
                        pivot.transform.position = new Vector3(-0.5F, -0.5F, 0.5F);
                        door.transform.parent = pivot.transform;

                        pivot.transform.position = new Vector3(Ax, 0, Ay);
                    }
                    pivot.transform.localScale = new Vector3(scale, doorHeight, doorThickness);
                    pivot.transform.rotation = Quaternion.Euler(0, 90, 0);
                    
                    Animator anim = pivot.AddComponent<Animator>();
                    anim.runtimeAnimatorController = Resources.Load("Animations/New Game Object 3") as RuntimeAnimatorController;
                }
            }
            SphereCollider sphere = pivot.AddComponent<SphereCollider>();
            sphere.radius = 1;
            sphere.isTrigger = true;
            pivot.AddComponent<DoorScript>();
            AudioSource audio = pivot.AddComponent<AudioSource>();
            audio.clip = (AudioClip)Resources.Load("door-1-open");
            AudioSource audio1 = pivot.AddComponent<AudioSource>();
            audio1.clip = (AudioClip)Resources.Load("door-1-close");
        }

        //creating windows
        float A1x = 0, A1y = 0, B1x = 0, B1y = 0;
        current_index++;
        string[] windows1 = text[current_index].Split(':');

        //Excluding the first token (no. of windows) and last token(next line)
        string[] windows = new string[windows1.Length - 2];
        for (int i = 1; i < (windows1.Length - 1); i++)
        {
            windows[i - 1] = windows1[i];
        }
        float windowHeight = 19;

        foreach (string word in windows)
        {
            string[] coords = word.Split(' ');
            for (int i = 0; i < coords.Length && (coords.Length > 1); i++)
            {
                if (i == 0)
                {
                    A1x = float.Parse(coords[i]);
                    A1x = A1x / 10;
                }
                else if (i == 1)
                {
                    A1y = float.Parse(coords[i]);
                    A1y = A1y / 10;
                }
                else if (i == 2)
                {
                    B1x = float.Parse(coords[i]);
                    B1x = B1x / 10;
                }
                else if (i == 3)
                {
                    B1y = float.Parse(coords[i]);
                    B1y = B1y / 10;
                }
            }

            GameObject window = Instantiate(Resources.Load("Window", typeof(GameObject))) as GameObject;

            window.transform.position = new Vector3(0, 0, 0);
            window.transform.rotation = Quaternion.Euler(0, 0, 0);

            GameObject myParent = new GameObject();


            myParent.transform.position = new Vector3(-0.5F, -0.5F, 0.5F);
            window.transform.parent = myParent.transform;
            myParent.name = "Window";

            float scale;
            //Horizontal wall
            if (Math.Abs(A1x - B1x) > Math.Abs(A1y - B1y))
            {
                scale = Math.Abs(A1x - B1x);

                myParent.transform.localScale = new Vector3(scale, windowHeight, 1);
                myParent.transform.position = new Vector3(A1x, 0, A1y - 1);
            }
            else
            {
                scale = Math.Abs(A1y - B1y);
                myParent.transform.localScale = new Vector3(scale, windowHeight, 1);
                myParent.transform.rotation = Quaternion.Euler(0, 90, 0);
                myParent.transform.position = new Vector3(B1x, 0, B1y - 1);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}