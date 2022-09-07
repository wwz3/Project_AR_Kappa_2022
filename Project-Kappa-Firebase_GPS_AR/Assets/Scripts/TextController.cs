using System.Collections;
using System.Collections.Generic;
using ArduinoBluetoothAPI;
using Proyecto26;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using System.Threading;
//using ArduinoBluetoothAPI;

public class TextController : MonoBehaviour
{
    public TextMeshProUGUI locationName;

    public static string location1;

    public TextMeshProUGUI TeamName;

    public static string TeamName1;

    public TextMeshProUGUI TimeDate_Name;

    public static string Date_Day_Name1;

    public static string Date_Month_Name1;

    public static string Date_Year_Name1;

    public static string Time_Name1;

    public TextMeshProUGUI ValueName;

    public static string ValueName1;

    public TMP_InputField location_inputfield;

    public TMP_InputField team_inputfield;

    public TMP_InputField date_Day_inputfield;

    public TMP_InputField date_Month_inputfield;

    public TMP_InputField date_Year_inputfield;

    public TMP_InputField time_inputfield;

    public TMP_InputField value_inputfield;

    public TMP_InputField date_time_inputfield;

    public TMP_InputField upperlimit_inputfield;

    public TMP_InputField lowerlimit_inputfield;

    public static float upperlimit;

    public static float lowerlimit;

    public static float dataIn;

    public static float newdata;

    public static string convertdata;

    public static TextController instance;

    public static string time;

    private BluetoothHelper helper;

    private void Awake()
    {
        instance = this;

        // DontDestroyOnLoad(this.connectBtn);
        // DontDestroyOnLoad(this.disconnectBtn);

        DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //convertdata = BTCode.msg;
        // dataIn = float.Parse(convertdata);
        // newdata = dataIn - 10f;

        //dataIn = BTCode.msg;
        //value_inputfield.text = newdata.ToString();

        time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy   HH:mm:ss");
        //date_time_inputfield.text = time;

        //SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    // {
    //     helper.Disconnect();
    // }

    public void Update()
    {   
        // convertdata = BTCode.msg;
        // dataIn = float.Parse(convertdata);
        // newdata = dataIn - 10f;

        //dataIn = BTCode.msg;
        //value_inputfield.text = newdata.ToString();

        time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy   HH:mm:ss");
        //date_time_inputfield.text = time;
    }

    public void StoreData()
    {
        locationName.text = "Location is " + location_inputfield.text;
        location1 = location_inputfield.text;

        TeamName.text = "Team is " + team_inputfield.text;
        TeamName1 = team_inputfield.text;

        TimeDate_Name.text = "Time & Date is " + date_Year_inputfield.text;
        //     "Time & Date is " +
        //     date_Day_inputfield.text +
        //     " " +
        //     date_Month_inputfield.text +
        //     " " +
        //     date_Year_inputfield.text +
        //     ", \n" +
        //     time_inputfield.text;
        // Date_Day_Name1 = date_Day_inputfield.text;
        // Date_Month_Name1 = date_Month_inputfield.text;
        // Date_Year_Name1 = date_Year_inputfield.text;
        // Time_Name1 = time_inputfield.text;

        ValueName.text = "Value is " + value_inputfield.text;
        ValueName1 = value_inputfield.text;

        // string activeScene = SceneManager.GetActiveScene().name;
        // PlayerPrefs.SetString("LevelSaved" , activeScene);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        //PostToDatabase();
    }

    public void saveData()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LevelSaved" , activeScene);
    }

    public void resetData()
    {
        locationName.text = "Location is -";
        location_inputfield.text = "";

        TeamName.text = "Team is -";
        team_inputfield.text = "Enter Team...";

        TimeDate_Name.text = "Time & Date is -";
        // date_Day_inputfield.text = "Day";
        // date_Month_inputfield.text = "Month";
        // date_Year_inputfield.text = "Year";
        // time_inputfield.text = "Time";

        //string time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy   HH:mm:ss");
        date_time_inputfield.text = "Date & Time";

        ValueName.text = "Value is -";
        value_inputfield.text = "Enter Value...";
    }

    public void DemoScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void ARScene()
    {
        TeamName.text = "Team is " + team_inputfield.text;
        TeamName1 = team_inputfield.text;

        upperlimit = float.Parse(upperlimit_inputfield.text);
        lowerlimit = float.Parse(lowerlimit_inputfield.text);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // private void PostToDatabase()
    // {
    //     User user = new User();
    //     RestClient.Post(url: "https://project-kappa-ar-default-rtdb.asia-southeast1.firebasedatabase.app/" +
    //         "Project Kappa Firebase - " +
    //         TeamName1 +
    //         ".json",
    //         user);
    //     //RestClient.Post(url: "https://projectkappa-firebase-default-rtdb.asia-southeast1.firebasedatabase.app/" + "Project Kappa-Firebase" + TeamName1 + ".json", user);
    //     //RestClient.Put(url: "https://projectkappa-firebase-default-rtdb.asia-southeast1.firebasedatabase.app/" + TeamName1 + ".json", user);
    // }

    // void OnDestroy()
    // {
    //     // Destroy(BTCode.connectBtn);
    //     // Destroy(BTCode.disconnectBtn);

    //     Destroy(date_time_inputfield);
    //     Destroy(value_inputfield);
    //     //Destroy(date_time_inputfield);
    // }
}
