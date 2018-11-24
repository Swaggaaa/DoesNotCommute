using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackScript : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject previousPanel;

    // Use this for initialization
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(settingsListener);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void settingsListener()
    {
        previousPanel.transform.position = settingsPanel.transform.position;
        settingsPanel.transform.position = new Vector3(100f, 100f, 100f);

    }
}
