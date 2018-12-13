using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {

    public GameObject mainPanel;
    public GameObject settingsPanel;

    // Use this for initialization
    void Start() {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(settingsListener);
    }

    // Update is called once per frame
    void Update() {

    }

    void settingsListener()
    {
        settingsPanel.transform.position = mainPanel.transform.position;
        mainPanel.transform.position = new Vector3(100f, 100f, 100f);
    }
}
