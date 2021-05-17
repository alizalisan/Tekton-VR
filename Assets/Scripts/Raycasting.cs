using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Raycasting : MonoBehaviour
{

    public float distanceTosee;
    RaycastHit whatIhit;
    public GameObject notif;
    public int flag;
    Component[] allChildren;

    void Start()
    {
        OVRTouchpad.Create();
        notif = GameObject.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor/Notif");
        flag = 0;
        OVRTouchpad.TouchHandler += HandleTouchHandler;
    }

    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distanceTosee, Color.red);
        if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIhit, distanceTosee))
        {
            if (flag == 0)
            {
                notif.SetActive(true);
            }
            Debug.Log("Touched a " + whatIhit.collider.gameObject.name);
            allChildren = whatIhit.collider.gameObject.GetComponentsInChildren(typeof(Component), true);
        }
        else
        {
            notif.SetActive(false);
            flag = 0;
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
                //if (child.name == "Palette")
                //{
                //    child.gameObject.SetActive(false);
                //}
                //if (child.name == "Palette (1)")
                //{
                //    child.gameObject.SetActive(false);
                //}
                //if (child.name == "WinSize")
                //{
                //    child.gameObject.SetActive(false);
                //}
                //if (child.name == "WinSize (1)")
                //{
                //    child.gameObject.SetActive(false);
                //}
            }
        }
    }

    public GameObject getobj()
    {
        print("GETTING");
        return whatIhit.collider.gameObject;
    }

    void HandleTouchHandler(object sender, System.EventArgs e)
    {
        OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Down)
        {
            flag = 0;
            notif.SetActive(true);
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
                    child.gameObject.SetActive(false);
                }
                if (child.name == "Palette (1)")
                {
                    child.gameObject.SetActive(false);
                }
                if (child.name == "WinSize")
                {
                    child.gameObject.SetActive(false);
                }
                if (child.name == "WinSize (1)")
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        //    if (whatIhit.collider.gameObject.name == "Wall")
        //    {
        //        foreach (Component child in allChildren)
        //        {
        //            if (child.name == "Wall_C")
        //            {
        //                child.gameObject.SetActive(false);
        //            }
        //            if (child.name == "Wall_C (1)")
        //            {
        //                child.gameObject.SetActive(false);
        //            }
        //        }
        //    }
        //    else if (whatIhit.collider.gameObject.name == "Door")
        //    {
        //        foreach (Component child in allChildren)
        //        {
        //            if (child.name == "Door_C")
        //            {
        //                child.gameObject.SetActive(false);
        //            }
        //            if (child.name == "Door_C (1)")
        //            {
        //                child.gameObject.SetActive(false);
        //            }
        //        }
        //    }
        //    else if (whatIhit.collider.gameObject.name == "Window")
        //    {
        //        foreach (Component child in allChildren)
        //        {
        //            if (child.name == "Win_C")
        //            {
        //                child.gameObject.SetActive(false);
        //            }
        //            if (child.name == "Win_C (1)")
        //            {
        //                child.gameObject.SetActive(false);
        //            }
        //        }
        //    }
        //}
        if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Up)
        {
            flag = 1;
            notif.SetActive(false);
            if (whatIhit.collider.gameObject.name == "Wall(Clone)")
            {
                foreach (Component child in allChildren)
                {
                    if (child.name == "Wall_C")
                    {
                        child.gameObject.SetActive(true);
                    }
                    if (child.name == "Wall_C (1)")
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else if (whatIhit.collider.gameObject.name == "Door")
            {
                foreach (Component child in allChildren)
                {
                    if (child.name == "Door_C")
                    {
                        child.gameObject.SetActive(true);
                    }
                    if (child.name == "Door_C (1)")
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }
            else if (whatIhit.collider.gameObject.name == "Window(Clone)")
            {
                foreach (Component child in allChildren)
                {
                    if (child.name == "Win_C")
                    {
                        child.gameObject.SetActive(true);
                    }
                    if (child.name == "Win_C (1)")
                    {
                        child.gameObject.SetActive(true);
                    }
                }
            }
        }
        //    if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Left)
        //{
        //    //Menu_panel.SetActive(true);
        //    //Menu_panel.gameObject.transform.SetPositionAndRotation(Camera.main.transform.position + new Vector3(0, 0, 4.0f), Camera.main.transform.rotation);
        //}
        //if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Right)
        //{
        //    //Menu_panel.SetActive(false);
        //}
    }
}