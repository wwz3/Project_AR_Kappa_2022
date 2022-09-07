using System.Collections;
using System.Collections.Generic;
using ArduinoBluetoothAPI;
using Proyecto26;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AR_Controller : MonoBehaviour
{
    public static float x;

    public static string converting_data;

    public static float converted_data;

    public static string time;

    public static AR_Controller instance;

    public static float upper;

    public static float lower;

    private Animator anim;

    public User user;

    //public GameObject player;
    //public Animator anim;
    //int health = Animator.StringToHash("isHealthy");
    //int sick = Animator.StringToHash("isSick");
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        user = new User();

        user.setTeamName(TextController.TeamName1);
        user.setLocation();     

        anim = GetComponent<Animator>();

        converting_data = NewARBT.msg;
        converted_data = float.Parse(converting_data);
        x = converted_data - 10f;
        //x = 2000.56f;
        //x = 500.36f;
        time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy   HH:mm:ss");

        upper = TextController.upperlimit;
        lower = TextController.lowerlimit;
    }

    public void SubmitData()
    {
        PostToDatabase();
    }

    private void Update()
    {

        converting_data = NewARBT.msg;
        converted_data = float.Parse(converting_data);
        x = converted_data - 10f;

        time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy   HH:mm:ss");

        user.setTimeVal(time, converting_data);

        upper = TextController.upperlimit;
        lower = TextController.lowerlimit;

        if (x > upper)
        {
            anim.SetTrigger("win");
            //player.GetComponent<Animator>().SetTrigger("win");
        }
        else if (x <= upper && x > lower)
        {
            anim.SetTrigger("tired");
            // player.GetComponent<Animator>().SetTrigger("tired");
        }
        else if (x <= lower)
        {
            anim.SetTrigger("dead");
            //player.GetComponent<Animator>().SetTrigger("dead");
        }
    }

    public void quitGame()
    {
        Debug.Log("Quit!"); //test if app quits
        Application.Quit(); //happens in real app but not in unity
    }

    private void PostToDatabase()
    {
        RestClient.Post(url: "https://project-kappa-ar-default-rtdb.asia-southeast1.firebasedatabase.app/" + "Project Kappa Firebase - " + TextController.TeamName1 +
            ".json",
            user);
        //RestClient.Post(url: "https://projectkappa-firebase-default-rtdb.asia-southeast1.firebasedatabase.app/" + "Project Kappa-Firebase" + TeamName1 + ".json", user);
        //RestClient.Put(url: "https://projectkappa-firebase-default-rtdb.asia-southeast1.firebasedatabase.app/" + TeamName1 + ".json", user);
    }
}
