using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDrown : MonoBehaviour {

    public AudioClip drownClip;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        Debug.Log(name);
        if (!GlobalValues.CurrentCar)
            return;

        if (other.transform.IsChildOf(GlobalValues.CurrentCar.transform))
        {
            StartCoroutine(CarDrown());
        }
    }

    private IEnumerator CarDrown()
    {
        float elapsedTime = 0f;
        GetComponent<AudioSource>().PlayOneShot(drownClip);

        while (elapsedTime < 0.5f)
        {
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        EventManager.Trigger("RespawnCar");
    }
}
