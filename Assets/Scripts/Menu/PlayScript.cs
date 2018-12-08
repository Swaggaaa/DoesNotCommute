﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour {


    private bool playPressed;
    public Camera mainCamera;
    private Vector3 tvPosition;

	// Use this for initialization
	void Start () {
        playPressed = false;
        tvPosition = transform.position;
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(PlayListener);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator PlayGame()
    {
        playPressed = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Stage1");
    }

    void PlayListener()
    {
        StartCoroutine(PlayGame());
    }

    void LateUpdate()
    {
        if (playPressed)
        {
            // Hide the canvas containing the button
            transform.parent.transform.position = new Vector3(100f, 100f, 100f);
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, tvPosition, Time.deltaTime);
        }
    }
}
