using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enter_AR_Scene : MonoBehaviour
{
    public static Enter_AR_Scene instance;

    private void Awake()
    {
        instance = this;
    }

    public void returnScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void returnFirstScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        //connectBtn.SetActive(false);
        //disconnectBtn.SetActive(true);
    }
}
