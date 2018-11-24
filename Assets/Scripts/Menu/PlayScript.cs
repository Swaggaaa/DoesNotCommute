using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayScript : MonoBehaviour {


	// Use this for initialization
	void Start () {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(playListener);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator playGame()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }

    void playListener()
    {
        StartCoroutine(playGame());
    }
}
