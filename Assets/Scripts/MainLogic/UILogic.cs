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
            lostPanel.GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.Lerp(color.a, 0.6f, 2.0f * Time.deltaTime));
        }
        else if (GlobalValues.Won)
        {
            winPanel.SetActive(true);
            Color color = winPanel.GetComponent<Image>().color;
            winPanel.GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.Lerp(color.a, 0.6f, 2.0f * Time.deltaTime));
        }
	}
}
