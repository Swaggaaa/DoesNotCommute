using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour {

    public GameObject winPanel;
    public GameObject lostPanel;

	// Use this for initialization
	void Start () {
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
	}

    // Update is called once per frame
    void Update ()
    {
		if (GlobalValues.Lost)
        { 
            lostPanel.SetActive(true);
            Color color = lostPanel.GetComponent<Image>().color;
            lostPanel.GetComponent<Image>().CrossFadeColor(new Color(color.r, color.g, color.b, 0.61f), 2.0f, false, true);
        }
	}
}
