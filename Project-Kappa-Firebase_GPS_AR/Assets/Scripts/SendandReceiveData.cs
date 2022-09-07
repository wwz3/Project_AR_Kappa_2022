using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendandReceiveData : MonoBehaviour
{
    public static int pot;

    // Start is called before the first frame update
    void Start()
    {
        SerialManagerScript.WhenReceiveDataCall += ReceiveData;    
    }

    private void ReceiveData(string incomingString)
    {
        int.TryParse(incomingString, out pot);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            SerialManagerScript.SendInfo("a");
        }

        if(Input.GetKeyDown(KeyCode.B))
        {
            SerialManagerScript.SendInfo("b");
        }
    }
}
