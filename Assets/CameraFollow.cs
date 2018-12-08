using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private Vector3 offset;

    void OnEnable()
    {
        EventManager.StartListener("NewCarCamera", UpdateTarget);
        EventManager.StartListener("RespawnCarCamera", RespawnTarget);
    }

    void OnDisable()
    {
        EventManager.StopListener("NewCarCamera", UpdateTarget);
        EventManager.StopListener("RespawnCarCamera", RespawnTarget);
    }

    // Use this for initialization
    void Start () {
        offset = new Vector3(4f, 10f, 0f);
    }
	
	void FixedUpdate () {
        if (!GlobalValues.CurrentCar || !GlobalValues.Running)
            return;

        Vector3 targetCam = GlobalValues.CurrentCar.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCam, 5f * Time.deltaTime);
        transform.LookAt(GlobalValues.CurrentCar.transform);
	}

    private void UpdateTarget()
    {
        StartCoroutine(PreviewMap());
    }

    private void RespawnTarget()
    {
        StartCoroutine(PreviewCar());
    }

    IEnumerator PreviewMap()
    {
        float elapsedTime = 0f;
        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Quaternion startRotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z, transform.rotation.w);

        while (elapsedTime < 5f)
        {
            transform.position = Vector3.Lerp(startPosition, GlobalValues.CurrentStage.CameraCenterStage, elapsedTime / 3f);
            transform.rotation = Quaternion.Lerp(startRotation, Quaternion.LookRotation(Vector3.down, Vector3.left), elapsedTime / 3f);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        yield return StartCoroutine(PreviewCar());
        EventManager.Trigger("StartPlay");
    }

    IEnumerator PreviewCar()
    {
        GameObject.FindGameObjectWithTag("Arrow").GetComponentInChildren<Renderer>().enabled = true;

        float elapsedTime = 0f;
        Vector3 startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        while (elapsedTime < 3)
        {
            transform.position = Vector3.Lerp(startPosition, GlobalValues.CurrentCar.transform.position + offset, elapsedTime / 2f);
            transform.LookAt(GlobalValues.CurrentCar.transform);
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        GlobalValues.Running = true;
    }
}
