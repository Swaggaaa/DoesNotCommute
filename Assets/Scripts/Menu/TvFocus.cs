using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvFocus : MonoBehaviour {

    public GameObject tv;
    private Vector3 destPosition;

	void Start () {
        destPosition = tv.transform.position - new Vector3(0f, 0f, 0.8f);
	}
	
	void LateUpdate () {
        transform.position = Vector3.Lerp(transform.position, destPosition, Time.deltaTime * 0.7f);
	}
}
