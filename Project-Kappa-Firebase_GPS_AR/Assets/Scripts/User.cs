using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class User
{
    public string Location;
    public string Team;
    public string Time;
    public string Value;

    //DateTime now = DateTime.Now;

    public void setTeamName(string nameeeeee)
    {
        Team = "\"" + nameeeeee + "\"";
    }

    public void setTimeVal(string timeee, string valueee)
    {
        Time = "\"" + timeee + "\"";
        Value = "\"" + valueee + "\"";
    }

    public void setLocation()
    {
        Location = "\"" + NativeGPSPlugin.GetLatitude().ToString() + " , " + NativeGPSPlugin.GetLongitude().ToString() + "\"";
    }

    public User()
    {
        // if(NativeGPSPlugin.GetLatitude().ToString() != null)
        // {
        //Location = "\"" + NativeGPSPlugin.GetLatitude().ToString() + " , " + NativeGPSPlugin.GetLongitude().ToString() + "\"";
        // }
        // else
        // {
        //     Location = "\"" + "No location provided." + "\"";
        // }
        //Location = "\"" + TextController.location1 + "\"";
        // Location = "\"" + NativeGPSUI.sb.ToString() + "\"";

        //Team = "\"" + TextController.TeamName1 + "\"";

        //Time = "\"" + TextController.Date_Day_Name1 + "\\/" + TextController.Date_Month_Name1 + "\\/" + TextController.Date_Year_Name1 + " " + TextController.Time_Name1 + "\"";
        
        //Time = "\"" + AR_Controller.time + "\"";
        //Value = "\"" + AR_Controller.converted_data + "\"";
  
        Location = "";
        Team = "";
        Time = "";
        Value = "";
    }
}
