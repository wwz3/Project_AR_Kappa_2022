using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public int num;

    // Use this for initialization
    void Update()
    {
     
    }
    public void SceneChange()
    {
        SceneManager.LoadScene(num);
        Debug.Log("Scene changed to " + num);
    }
}