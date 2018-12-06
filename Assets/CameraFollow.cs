using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        EventManager.StartListener("NewCarCamera", updateTarget);
        offset = new Vector3(4f, 5f, 0f);
    }
	
	void FixedUpdate () {
        if (!GlobalValues.currentCar)
            return;

        Vector3 targetCam = GlobalValues.currentCar.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCam, 5f * Time.deltaTime);
        transform.LookAt(GlobalValues.currentCar.transform);
	}

    private void updateTarget()
    {
        GameObject car = GlobalValues.currentCar;
        transform.position = car.transform.position - offset;
    }
}
