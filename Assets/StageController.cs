using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageController : MonoBehaviour {

    public GameObject redRing;
    public GameObject greenRing;

    private int currentCarNum = 0;

    void OnEnable()
    {
        EventManager.StartListener("NewCar", spawnCar);
    }

    void OnDisable()
    {
        EventManager.StopListener("NewCar", spawnCar);
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(startGame());
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator startGame()
    {
        yield return new WaitForSeconds(2f);
        EventManager.Trigger("NewCar");

        GlobalValues.Running = true;
    }

    void spawnCar()
    {
        GameObject startPoint = Instantiate(redRing, Stage1.BeginPositions[currentCarNum], Quaternion.identity);
        GameObject endPoint = Instantiate(greenRing, Stage1.EndPositions[currentCarNum], Quaternion.identity);
        GameObject car = Instantiate(Stage1.Cars[currentCarNum], startPoint.transform.position, Quaternion.identity);

        startPoint.transform.Rotate(-90f, 0f, 0f);
        endPoint.transform.Rotate(-90f, 0f, 0f);
        car.transform.Rotate(Stage1.BeginRotations[currentCarNum]);
        currentCarNum++;

        GlobalValues.currentCar = car;
        EventManager.Trigger("NewCarCamera");
    }
}
