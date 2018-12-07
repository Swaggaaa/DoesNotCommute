using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnter : MonoBehaviour {

    private bool triggered = false;
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

        if (other.transform.IsChildOf(GlobalValues.CurrentCar.transform) && !triggered)
        {
            triggered = true;
            EventManager.Trigger("NewCar");
        }
    }
}
