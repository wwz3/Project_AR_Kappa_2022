using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArduinoBluetoothAPI;

public class NewARBT : MonoBehaviour
{
    private BluetoothHelper helper;
    public GameObject connectBtn;
    // public GameObject disconnectBtn;
    //public GameObject led;

    public static string msg;

    public static NewARBT instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    public void Start()
    {
        //helper.Disconnect();
        BluetoothHelper.BLE = false;
        helper = BluetoothHelper.GetInstance();
        helper.OnConnected += OnConnected;
        helper.OnConnectionFailed += OnConnectionFailed;
        helper.OnDataReceived += OnDataReceived;
        //helper.setFixedLengthBasedStream(3); //data is received byte by byte
        string str = "\n";
        helper.setTerminatorBasedStream(str);
        helper.setDeviceName("HC-05");
        //led.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnConnected(BluetoothHelper helper)
    {
        Debug.Log("Connected to Bluetooth");
        helper.StartListening();
        connectBtn.SetActive(false);
        // disconnectBtn.SetActive(true);
        //led.GetComponent<Renderer>().material.color = Color.green;
    }

    public void OnConnectionFailed(BluetoothHelper helper)
    {
        Debug.Log("Failed to connect");
        // connectBtn.SetActive(true);
        // disconnectBtn.SetActive(false);
    }

    public void OnDataReceived(BluetoothHelper helper)
    {
        msg = helper.Read();
        //Debug.Log($"Reading");

        /*switch(msg)
        {
            case "1":
                led.GetComponent<Renderer>().material.color = Color.green;
                break;
            case "0":
                led.GetComponent<Renderer>().material.color = Color.red;
                break;
            default:
                Debug.Log($"Received unknown message [{msg}]");
                break;
        }*/
    }

    public void Connect()
    {
        helper.Connect();
    }

    public void Disconnect()
    {
        Debug.Log("Disconnected from Bluetooth");
        helper.Disconnect();
        // connectBtn.SetActive(true);
        // disconnectBtn.SetActive(false);
        //led.GetComponent<Renderer>().material.color = Color.red;
    }

    public void sendData(string d)
    {
        helper.SendData(d);
    }


    // Update is called once per frame
}
