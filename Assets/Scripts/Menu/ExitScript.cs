using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ExitListener);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ExitListener()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
