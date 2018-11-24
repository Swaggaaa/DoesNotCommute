using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour {

    public AudioMixer audioMixer;
    public string variableName;
	// Use this for initialization
	void Start () {
        Slider slider = gameObject.GetComponent<Slider>();

        slider.onValueChanged.AddListener(SetVolume);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetVolume(float volume)
    {
        audioMixer.SetFloat(variableName, Mathf.Log10(volume) * 20);
    }
}
