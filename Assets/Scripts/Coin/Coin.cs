using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private bool disappearing = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0f, 35 * Time.deltaTime, 0f));

        if (disappearing)
        {
            MeshRenderer[] renderers = GetComponentsInChildren<MeshRenderer>();

            foreach (var renderer in renderers)
            {
                Color color = renderer.material.color;
                renderer.material.color = new Color(color.r, color.g, color.b, Mathf.Lerp(color.a, 0.0f, 2.0f * Time.deltaTime));
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        GlobalValues.TimeLeft += 10.0f;
        GetComponent<Collider>().enabled = false;
        GetComponent<Animator>().Play("PickUpCoin");
        disappearing = true;
    }

    public void Destroy()
    {
       Destroy(gameObject);
    }
}
