using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour {

    private Pause pause;

    private void Start()
    {
        pause = GameObject.Find("GameLogic").GetComponent<Pause>();
    }

    public void ResumeGame()
    {
        pause.ResumeGame();
    }
}
