using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashSound : MonoBehaviour {

    public AudioClip shootSound;

    private AudioSource source;

	void Awake ()
    {
        source = GetComponent<AudioSource>();
	}

    private void OnCollisionEnter(Collision collision)
    {
        source.PlayOneShot(shootSound, 1F);    
    }
}
