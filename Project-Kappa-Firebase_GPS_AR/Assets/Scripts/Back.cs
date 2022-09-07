using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using ArduinoBluetoothAPI;

public class Back : MonoBehaviour
{
    public TextMeshProUGUI name;

    public TextMeshProUGUI location;

    public TextMeshProUGUI time;

    public TextMeshProUGUI value;

    public static Back instance;

    private void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        name.text = "Name is " + TextController.TeamName1;
        location.text = "Location is " + TextController.location1;
        time.text = "Date & Time is " + TextController.time;
            // "Time and Date is " +
            // TextController.Date_Day_Name1 +
            // "/" +
            // TextController.Date_Month_Name1 +
            // "/" +
            // TextController.Date_Year_Name1 +
            // "\n" +
            // TextController.Time_Name1;
        value.text = "Value is " + TextController.ValueName1;

        //BTCode.Disconnect();
    }

    public void returnScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

        if(PlayerPrefs.HasKey("LevelSaved"))
        {
            string leveltoload = PlayerPrefs.GetString("LevelSaved");
            SceneManager.LoadScene(leveltoload);
        }
    }

    public void arScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
