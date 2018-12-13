using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour {

    public GameObject winPanel;
    public GameObject lostPanel;
    public GameObject bloodPanel;
    public Text speedometer;
    public Slider healthSlider;
    public GameObject gpsArrow;

	// Use this for initialization
	void Start () {
        winPanel.SetActive(false);
        lostPanel.SetActive(false);
	}

    void OnEnable()
    {
        EventManager.StartListener("Won", Won);
        EventManager.StartListener("Lost", Lost);
        EventManager.StartListener("ChickenDie", ChickenDie);
    }

    void OnDisable()
    {
        EventManager.StopListener("Won", Won);
        EventManager.StopListener("Lost", Lost);
        EventManager.StopListener("ChickenDie", ChickenDie);
    }

    private void Won()
    {
        winPanel.SetActive(true);
        StartCoroutine(FadePanel(winPanel));
    }

    private void Lost()
    {
        lostPanel.SetActive(true);
        StartCoroutine(FadePanel(lostPanel));
    }

    private void ChickenDie()
    {
        bloodPanel.SetActive(true);
        Color color = bloodPanel.GetComponent<Image>().color;
        bloodPanel.GetComponentInChildren<Image>().color = new Color(color.r, color.g, color.b, 0.6f);
        StartCoroutine(FadeOutBlood());
    }

    private IEnumerator FadeOutBlood()
    {
        yield return new WaitForSeconds(1f);
        Color color = bloodPanel.GetComponentInChildren<Image>().color;
        float elapsedTime = 0f;

        while (elapsedTime < 2f)
        {
            bloodPanel.GetComponentInChildren<Image>().color = new Color(color.r, color.g, color.b, Mathf.Lerp(0.6f, 0f, elapsedTime / 2f));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        bloodPanel.SetActive(false);
    }

    private IEnumerator FadePanel(GameObject panel)
    {
        Color color = panel.GetComponent<Image>().color;
        float elapsedTime = 0f;
        while (elapsedTime < 2f)
        {
            panel.GetComponent<Image>().color = new Color(color.r, color.g, color.b, Mathf.Lerp(color.a, 0.6f, elapsedTime / 2f));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }

    // Update is called once per frame
    void Update ()
    {
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
