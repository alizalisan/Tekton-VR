using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour {

    public int timeRemaining = 2;
    public Raycasting raycast;
    GameObject gameobj;

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
            Component[] allChildren = gameobj.GetComponentsInChildren(typeof(Component), true);
            foreach (Component child in allChildren)
            {
               
                print("Name:" + child.name);
            }

            doThis(gameobj);

            //reset timer
            CancelInvoke("countDown");
            timeRemaining = 2;
            print("timer reset");

        }
    }

    void doThis(GameObject gameobject)
    {
        print("HERE");
        Component[] allChildren = gameobject.GetComponentsInChildren(typeof(Component), true);
        foreach (Component child in allChildren)
        {
            if (child.name == "Wall_C")
            {
                child.gameObject.SetActive(false);
            }
            if (child.name == "Wall_C (1)")
            {
                child.gameObject.SetActive(false);
            }
            if (child.name == "Door_C")
            {
                child.gameObject.SetActive(false);
            }
            if (child.name == "Door_C (1)")
            {
                child.gameObject.SetActive(false);
            }
            if (child.name == "Win_C")
            {
                child.gameObject.SetActive(false);
            }
            if (child.name == "Win_C (1)")
            {
                child.gameObject.SetActive(false);
            }

            if (child.name == "Palette")
            {
                child.gameObject.SetActive(true);
            }
            if (child.name == "Palette (1)")
            {
                child.gameObject.SetActive(true);
            }
            if (child.name == "WinSize")
            {
                child.gameObject.SetActive(true);
            }
            if (child.name == "WinSize (1)")
            {
                child.gameObject.SetActive(true);
            }
        }
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
