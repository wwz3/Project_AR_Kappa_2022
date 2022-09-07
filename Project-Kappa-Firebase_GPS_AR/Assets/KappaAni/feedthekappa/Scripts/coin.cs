
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using OnefallGames;
using UnityEngine.UI;

public class coin : MonoBehaviour
{

    Text coinsTxt;
    //public static int coinAmount = 9999999;
    // Use this for initialization
    void Start()
    {
       coinsTxt = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {

        coinsTxt.text = CoinManager.Instance.Coins.ToString();

    }

 
}

