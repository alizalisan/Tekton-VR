using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    public GameObject canvas;
    public KeyCode key;
	// Use this for initialization
	void Start () {
       // OVRTouchpad.Create();
      //  OVRTouchpad.TouchHandler += HandleTouchHandler;

        canvas = GameObject.Find("Notif");
    }
	
    void OnTriggerEnter(Collider collider)
    {
      //  canvas.transform.localPosition= new Vector3(0, 0, 2);
        
           // canvas.transform.localPosition = new Vector3(0, 1000, 2);
            print("here");
            GameObject c = transform.Find("Wall_C").gameObject;
            c.SetActive(true);
      
    }

    void OnTriggerExit(Collider collider)
    {
        canvas.transform.localPosition = new Vector3(0, 1000, 2);
    }

    void update()
    { 
        if (Input.GetKeyDown(key))
        {
            //canvas.transform.localPosition = new Vector3(0, 1000, 2);
            print("here");
            GameObject c = transform.Find("Wall_C").gameObject;
            c.SetActive(true);
        }
    }
    //void HandleTouchHandler(object sender, System.EventArgs e)
    //{
    //    OVRTouchpad.TouchArgs touchArgs = (OVRTouchpad.TouchArgs)e;
    //    if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Down)
    //    {
    //    }
    //    if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Up)
    //    {
    //        canvas.SetActive(false);
    //        GameObject c = transform.Find("Wall_C").gameObject;
    //        c.SetActive(true);

    //    }
    //    if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Left)
    //    {
    //    }
    //    if (touchArgs.TouchType == OVRTouchpad.TouchEvent.Right)
    //    {
    //    }
    //}
}
