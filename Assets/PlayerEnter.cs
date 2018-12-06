using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (!GlobalValues.CurrentCar)
            return;

        if (other.transform.IsChildOf(GlobalValues.CurrentCar.transform))
        {
            GetComponent<Collider>().enabled = false;
            EventManager.Trigger("NewCar");
        }
    }
}
