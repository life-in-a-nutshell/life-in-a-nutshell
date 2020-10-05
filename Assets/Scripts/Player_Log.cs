using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Log : MonoBehaviour
{
    // Private VARS
    private List<string> Eventlog = new List<string>();

    public UI_Script UI;

    // Public VARS
    public int maxLines = 3;

    public void AddEvent(string eventString)
    {
        Eventlog.Add(eventString);

        if (Eventlog.Count >= maxLines)
            Eventlog.RemoveAt(0);

        UI.Log.text = ""; 

        foreach (string logEvent in Eventlog)
        {
            UI.Log.text += logEvent;
            UI.Log.text += "\n";
        }
    }
}
