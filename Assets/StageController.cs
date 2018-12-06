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
        EventManager.StartListener("NewCar", SpawnCar);
    }

    void OnDisable()
    {
        EventManager.StopListener("NewCar", SpawnCar);
    }

    void Start ()
    {
        EventManager.Trigger("NewCar");
    }
	
	void Update ()
    {
		
	}

    void SpawnCar()
    {
        GlobalValues.Running = false;
 
        RemoveExistingEntities();

        GameObject startPoint = Instantiate(redRing, GlobalValues.CurrentStage.BeginPositions[currentCarNum], Quaternion.identity);
        GameObject endPoint = Instantiate(greenRing, GlobalValues.CurrentStage.EndPositions[currentCarNum], Quaternion.identity);
        GameObject car = Instantiate(GlobalValues.CurrentStage.Cars[currentCarNum], startPoint.transform.position, Quaternion.identity);

        startPoint.transform.Rotate(-90f, 0f, 0f);
        endPoint.transform.Rotate(-90f, 0f, 0f);
        car.transform.Rotate(GlobalValues.CurrentStage.BeginRotations[currentCarNum]);
        currentCarNum++;

        GlobalValues.CurrentCar = car;
        EventManager.Trigger("NewCarCamera");
    }

    private void RemoveExistingEntities()
    {
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        for (int i = 0; i < cars.Length; ++i)
        {
            Destroy(cars[i]);
        }

        GameObject[] rings = GameObject.FindGameObjectsWithTag("Ring");
        for (int i = 0; i < rings.Length; ++i)
        {
            Destroy(rings[i]);
        }

        GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
        for (int i = 0; i < coins.Length; ++i)
        {
            Destroy(coins[i]);
        }
    }
}
