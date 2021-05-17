using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ControllerPosition : MonoBehaviour {


    // Use this for initialization
    String CoordStr;
    void Start () {
        //Intent call ---------------------------------
        //Debug.Log("Getting Intent...");
        //AndroidJavaClass pluginClass = new AndroidJavaClass("digital.haa.plugin.MainActivity");
        //Debug.Log("pluginClass : " + pluginClass);

        //CoordStr = pluginClass.CallStatic<string>("GetSessionId");

        //-----------------------
        TextAsset txt = (TextAsset)Resources.Load("Tekton", typeof(TextAsset));
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
        float Ax = 0, Ay = 0;

        string[] walls1 = text[current_index].Split(':');
        current_index++;
        string[] doors1 = text[current_index].Split(':');

        //Excluding the first token (no. of doors) and last token(next line)
        string[] doors = new string[doors1.Length - 2];
        for (int i = 1; i < (doors1.Length - 1); i++)
        {
            doors[i - 1] = doors1[i];
        }

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
                break;
            }
            break;
        }

        transform.position = new Vector3(Ax, 12.2f, Ay - 20f);
        //transform.position = new Vector3 (130.9674f, 12.2f, 84.9f);
        transform.rotation = Quaternion.Euler(0, 269.9f, 0);
    }
	
	// Update is called once per frame
	void Update () {

	}
}
