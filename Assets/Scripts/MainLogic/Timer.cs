using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    public UnityEngine.UI.Text timerText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GlobalValues.Running)
        {
            GlobalValues.TimeLeft -= Time.deltaTime;
        }

        if (GlobalValues.TimeLeft <= 0.0f)
        {
            GlobalValues.Running = false;
            GlobalValues.Lost = true;
            timerText.text = "0.0 :'(";
        }
        else
        {
            timerText.text = GlobalValues.TimeLeft.ToString("0.0");
        }
    }
}
