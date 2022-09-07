using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showText : MonoBehaviour
{

    public GameObject uiObject, uiObject2;
    void Start()
    {
        uiObject.SetActive(true);
        StartCoroutine("WaitForSec");
    }
   
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(uiObject2);
    }


}