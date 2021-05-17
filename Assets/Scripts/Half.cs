using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Half : MonoBehaviour
{

    public int timeRemaining = 2;
    public Raycasting raycast;
    GameObject gameobj;
    GameObject window;
    GameObject myParent;

    void Start()
    {
        print("Start");
        GameObject obj = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
        raycast = obj.GetComponent<Raycasting>();
        gameobj = raycast.getobj();
    }

    void countDown()
    {
        timeRemaining--;
        print(timeRemaining);
        if (timeRemaining <= 0)
        {
            doThis(gameobj);

            //reset timer
            CancelInvoke("countDown");
            timeRemaining = 5;
            print("timer reset");

        }
    }

    void doThis(GameObject gameobject)
    {
        window = Instantiate(Resources.Load("WindowHalf", typeof(GameObject))) as GameObject;

        window.transform.position = new Vector3(0, 0, 0);
        window.transform.rotation = Quaternion.Euler(0, 0, 0);

        myParent = new GameObject();

        window.transform.parent = myParent.transform;
        myParent.transform.position = gameobj.transform.position;
        myParent.transform.rotation = gameobj.transform.rotation;
        myParent.transform.localScale = gameobj.transform.localScale;

        gameobj.SetActive(false);
        //window = Instantiate(Resources.Load("Window", typeof(GameObject))) as GameObject;
        //window.transform = gameobj.transform;
        //print("HERE");
        //Component[] allChildren = gameobject.GetComponentsInChildren(typeof(Component), true);
        //foreach (Component child in allChildren)
        //{
        //    if (child.name == "wall")
        //    {
        //        child.GetComponent<Renderer>().material.color = Color.red;
        //    }
        //}
        print("FINISHED COUNTDOWN");
    }

    //call when cursr is over button
    public void MouseOver()
    {
        InvokeRepeating("countDown", 1, 1);
    }

    //call if cursor leaves button
    public void MouseOut()
    {
        //reset timer
        CancelInvoke("countDown");
        timeRemaining = 2;
    }

    // Use this for initialization


    //// Update is called once per frame
    //void Update () {

    //}
}
