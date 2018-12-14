using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
    
	public void ExitGame () {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
