using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour {

    public GameObject winPanel;
    public GameObject lostPanel;
    public Text speedometer;
    public Slider healthSlider;
    public GameObject gpsArrow;

	// Use this for initialization
	void Start () {
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
	}

    // Update is called once per frame
    void Update ()
    {
		if (GlobalValues.Lost)
        { 
            lostPanel.SetActive(true);
            Color color = lostPanel.GetComponent<Image>().color;
            lostPanel.GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.Lerp(color.a, 0.6f, 2.0f * Time.deltaTime));
        }
        else if (GlobalValues.Won)
        {
            winPanel.SetActive(true);
            Color color = winPanel.GetComponent<Image>().color;
            winPanel.GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.Lerp(color.a, 0.6f, 2.0f * Time.deltaTime));
        }

        if (GlobalValues.CurrentCar != null)
        {
            speedometer.text = (GlobalValues.CurrentCar.GetComponent<Rigidbody>().velocity.magnitude * 10f).ToString("0.0") + " u/s";
            healthSlider.value = GlobalValues.CurrentCar.GetComponent<PlayerController>().HealthNormalized;
        }
        else
        {
            speedometer.text = "0 u/s";
            healthSlider.value = 0f;
        }

        GameObject ring = GameObject.FindGameObjectsWithTag("Ring")
            .Where(r => r.name.Contains("Green"))
            .FirstOrDefault();

        if (ring != null)
        {
            gpsArrow.transform.LookAt(new Vector3(ring.transform.position.x, gpsArrow.transform.position.y, ring.transform.position.z));
        }
	}
}
