using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCrashCar : MonoBehaviour {

    public AudioClip crashSound;

    private AudioSource source;

	void Awake ()
    {
        source = GetComponent<AudioSource>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.isTrigger || (collision.gameObject.layer == LayerMask.NameToLayer("Street") &&
                ((Mathf.Abs(transform.localEulerAngles.x) < 90 || Mathf.Abs(transform.localEulerAngles.x) > 270) &&
                (Mathf.Abs(transform.localEulerAngles.z) < 75 || Mathf.Abs(transform.localEulerAngles.z) > 285))))
            return;

        source.PlayOneShot(crashSound, 1F);    
    }
}
