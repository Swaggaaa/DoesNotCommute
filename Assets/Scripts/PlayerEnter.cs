using UnityEngine;

public class PlayerEnter : MonoBehaviour {

    public AudioClip goalClip;

    private bool triggered = false;
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

        if (other.transform.IsChildOf(GlobalValues.CurrentCar.transform) && !triggered)
        {
            GameObject.Find("Audio Source").GetComponent<AudioSource>().PlayOneShot(goalClip);
            triggered = true;
            EventManager.Trigger("NewCar");
        }
    }
}
