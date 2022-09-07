using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArduinoBluetoothAPI;

public class Scaling : MonoBehaviour
{
    public static float dataIn;
    public static float newdata;
    public static string convertdata;

    public static float Rvalue;
    public static float Gvalue;
    public static float Bvalue;

    public Renderer myRenderer;
    public Color myColor;

    void Start()
    {
        //dataIn = Send_And_Receive_Data.pot;
        convertdata = BTCode.msg;
        dataIn = float.Parse(convertdata);
        newdata = dataIn * 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        //dataIn = Send_And_Receive_Data.pot;
        //newdata = dataIn * 2.5f;
        convertdata = BTCode.msg;
        dataIn = float.Parse(convertdata);
        newdata = dataIn * 2.5f;

        transform.localScale = new Vector3(newdata, 100f, 100f);

        if(dataIn >= 200f) 
        {
            if(dataIn >= 400f) 
            {
                myColor = new Color(0,255,0,255);
                myRenderer.material.color = myColor;
            }
            else
            {
                myColor = new Color(255,255,0,255);
                myRenderer.material.color = myColor;
            }
        }
        else
        {
            myColor = new Color(255,0,0,255);
            myRenderer.material.color = myColor;
        }
    }

}
