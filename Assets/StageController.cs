using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageController : MonoBehaviour {

    public GameObject redRing;
    public GameObject greenRing;
    public GameObject coin;

    private int currentCarNum = -1;
    private List<GameObject> playedCars = new List<GameObject>();

    void OnEnable()
    {
        EventManager.StartListener("NewCar", SpawnCar);
        EventManager.StartListener("StartPlay", OnStartPlay);
    }

    void OnDisable()
    {
        EventManager.StopListener("NewCar", SpawnCar);
        EventManager.StopListener("StartPlay", OnStartPlay);
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
        currentCarNum++;
        GlobalValues.Running = false;
        StopAllCoroutines();
 
        RemoveExistingEntities();

        GameObject car = Instantiate(GlobalValues.CurrentStage.Cars[currentCarNum], GlobalValues.CurrentStage.BeginPositions[currentCarNum], Quaternion.identity);
        GlobalValues.CurrentCar = car;

        GameObject startPoint = Instantiate(redRing, GlobalValues.CurrentStage.BeginPositions[currentCarNum], Quaternion.identity);
        GameObject endPoint = Instantiate(greenRing, GlobalValues.CurrentStage.EndPositions[currentCarNum], Quaternion.identity);

        if (GlobalValues.CurrentStage.CoinPositions[currentCarNum] != Vector3.zero)
        {
            Instantiate(coin, GlobalValues.CurrentStage.CoinPositions[currentCarNum], Quaternion.identity);
        }

        startPoint.transform.Rotate(-90f, 0f, 0f);
        endPoint.transform.Rotate(-90f, 0f, 0f);
        car.transform.Rotate(GlobalValues.CurrentStage.BeginRotations[currentCarNum]);

        EventManager.Trigger("NewCarCamera");
    }

    void OnStartPlay()
    {
        GameObject[] rings = GameObject.FindGameObjectsWithTag("Ring");
        foreach (GameObject ring in rings)
        {
            if (ring.GetComponent<CapsuleCollider>() != null)
            {
                ring.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

        for (int i = 0; i < currentCarNum; ++i)
        {
            playedCars.Add(Instantiate(GlobalValues.CurrentStage.Cars[i], GlobalValues.CurrentStage.BeginPositions[i], Quaternion.identity));
        }

        StartCoroutine(RecordPath());

        for (int i = 0; i < currentCarNum; ++i)
        {
            StartCoroutine(PlayPath(i));
        }
    }

    IEnumerator RecordPath()
    {
        while (true)
        {
            GlobalValues.CurrentStage.RecordedPaths[currentCarNum].Add(
                new Path(GlobalValues.CurrentCar.transform.position, GlobalValues.CurrentCar.transform.rotation));

            yield return null;
        }
    }

    IEnumerator PlayPath(int carNum)
    {
        foreach (Path path in GlobalValues.CurrentStage.RecordedPaths[carNum])
        {
            playedCars[carNum].transform.position = path.Position;
            playedCars[carNum].transform.rotation = path.Rotation;

            yield return null;
        }

        playedCars[carNum].GetComponentInChildren<Collider>().enabled = false;

        MeshRenderer[] renderers = playedCars[carNum].GetComponentsInChildren<MeshRenderer>();

        foreach (var renderer in renderers)
        {
            renderer.material.shader = Shader.Find("Transparent/Diffuse");
            renderer.material.color = new Color(1f, 1f, 1f, 0.3f);
        }
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

        playedCars.Clear();
    }
}
