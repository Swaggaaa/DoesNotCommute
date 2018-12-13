using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public GameObject settingsPanel;
    public GameObject scenesPanel;

	// Use this for initialization
	void Start () {
        settingsPanel.transform.position = new Vector3(100f, 100f, 100f);
        scenesPanel.transform.position = new Vector3(100f, 100f, 100f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
