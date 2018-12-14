using UnityEngine;

public class RotationLight : MonoBehaviour {

	void Update () {
        transform.Rotate(new Vector3(0f, Time.deltaTime * 400f, 0f));
	}
}
