using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gotoarscene : MonoBehaviour
{

    public int num;
    //public string levelToLoad;

    // Use this for initialization
    void Update()
    {

    }
    void OnCollisionEnter(Collision plyr)
    {
        if (plyr.gameObject.name == "KappaH")
        {

            {
                Debug.Log("Collision trigger");
                SceneManager.LoadScene(num);
                Debug.Log("Scene changed to " + num);
            }
        }
    }

}