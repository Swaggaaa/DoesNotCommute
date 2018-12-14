using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(PlayCredits());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene");
        }
	}

    private IEnumerator PlayCredits()
    {
        yield return new WaitForSeconds(60f);

        SceneManager.LoadScene("MenuScene");
    }
}
