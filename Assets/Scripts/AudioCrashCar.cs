using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCrashCar : MonoBehaviour {

    public AudioClip shootSound;

    private AudioSource source;

	void Awake ()
    {
        source = GetComponent<AudioSource>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.isTrigger)
            return;

        source.PlayOneShot(shootSound, 1F);    
    }
}
