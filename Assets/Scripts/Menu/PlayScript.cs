using System.Collections;
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
        button.onClick.AddListener(playListener);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator playGame()
    {
        playPressed = true;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("SampleScene");
    }

    void playListener()
    {
        StartCoroutine(playGame());
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
