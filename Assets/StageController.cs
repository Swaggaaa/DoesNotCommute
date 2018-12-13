using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour {

    public GameObject redRing;
    public GameObject greenRing;
    public GameObject coin;
    public GameObject enclosingTerrain;
    public AudioSource audioSource;
    public AudioClip startClip;
    public AudioClip wonClip;
    public AudioClip lostClip;
    public AudioClip chickenClip;
    public GameObject ducks;

    private int currentCarNum = -1;
    private List<GameObject> playedCars = new List<GameObject>();
    private GameObject flock;
    private bool direction = true;

    void OnEnable()
    {
        EventManager.StartListener("NewCar", SpawnCar);
        EventManager.StartListener("StartPlay", OnStartPlay);
        EventManager.StartListener("RespawnCar", RespawnCar);
        EventManager.StartListener("Running", Running);
        EventManager.StartListener("Won", Won);
        EventManager.StartListener("Lost", Lost);
        EventManager.StartListener("ChickenDie", ChickenDie);
    }

    void OnDisable()
    {
        EventManager.StopListener("NewCar", SpawnCar);
        EventManager.StopListener("StartPlay", OnStartPlay);
        EventManager.StopListener("RespawnCar", RespawnCar);
        EventManager.StopListener("Running", Running);
        EventManager.StopListener("Won", Won);
        EventManager.StopListener("Lost", Lost);
        EventManager.StopListener("ChickenDie", ChickenDie);
    }

    void Awake()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Stage1":
                GlobalValues.CurrentStage = Stage1.Instance;
                break;

            case "Stage2":
                GlobalValues.CurrentStage = Stage2.Instance;
                break;

            case "Stage3":
                GlobalValues.CurrentStage = Stage3.Instance;
                break;

            default:
                GlobalValues.CurrentStage = null;
                break;
        }
    }

    void Start()
    {
        SceneManager.activeSceneChanged += SceneManager_activeSceneChanged;
        DrawBoundingWater();
        SpawnDucks();
        EventManager.Trigger("NewCar");
    }

    private void ChickenDie()
    {
        audioSource.PlayOneShot(chickenClip, 1f);
    }

    private void SpawnDucks()
    {
        flock = Instantiate(ducks, GlobalValues.CurrentStage.DuckPath[0], Quaternion.identity);
        flock.transform.Rotate(0f, 180f, 0f);
    }

    // TODO: I don't like this
    private void SceneManager_activeSceneChanged(Scene oldScene, Scene newScene)
    {
        GlobalValues.Init();
        switch (newScene.name)
        {
            case "Stage1":
                GlobalValues.CurrentStage = Stage1.Instance;
                break;

            case "Stage2":
                GlobalValues.CurrentStage = Stage2.Instance;
                break;

            case "Stage3":
                GlobalValues.CurrentStage = Stage3.Instance;
                break;

            default:
                GlobalValues.CurrentStage = null;
                break;
        }
    }

    void Update ()
    {
        if (direction)
            flock.transform.position += (GlobalValues.CurrentStage.DuckPath[1] - GlobalValues.CurrentStage.DuckPath[0]) / 2000;
        else
            flock.transform.position += (GlobalValues.CurrentStage.DuckPath[0] - GlobalValues.CurrentStage.DuckPath[1]) / 2000;

        if ((Vector3.Distance(flock.transform.position, GlobalValues.CurrentStage.DuckPath[1]) <= 3f && direction) ||
            (Vector3.Distance(flock.transform.position, GlobalValues.CurrentStage.DuckPath[0]) <= 3f && !direction))
        {
            direction = !direction;
            flock.transform.Rotate(0f, 180f, 0f);
        }
    }

    void Running()
    {
        audioSource.PlayOneShot(startClip);
    }

    void Won()
    {
        GlobalValues.Won = true;
        StartCoroutine(LoadScene(GlobalValues.CurrentStage.NextStageName));
    }

    void Lost()
    {
        GameObject.Find("Background Music").GetComponent<AudioSource>().Stop();
        audioSource.PlayOneShot(lostClip);

        StartCoroutine(LoadScene(SceneManager.GetActiveScene().name));
    }

    IEnumerator LoadScene(string sceneName)
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(sceneName);
    }

    private void DrawBoundingWater()
    {
        Bounds bounds = GlobalValues.CurrentStage.Bounds;

        //Left
        for (int i = Mathf.RoundToInt(-1 * bounds.size.x / 2); i <= bounds.size.x; ++i)
        {
            for (int j = 0; j <= bounds.size.z / 2; ++j)
            {
                Instantiate(enclosingTerrain, new Vector3(bounds.min.x + i * 2f, bounds.min.y, bounds.min.z - j * 2f), Quaternion.Euler(-90f, 180f, -90f));
            }
        }

        //Up
        for (int i = 0; i <= bounds.size.x / 2; ++i)
        {
            for (int j = 0; j <= bounds.size.z / 2; ++j)
            {
                Instantiate(enclosingTerrain, new Vector3(bounds.min.x - i * 2f, bounds.min.y, bounds.min.z + j * 2f), Quaternion.Euler(-90f, 180f, -90f));
            }
        }

        //Right
        for (int i = Mathf.RoundToInt(-1 * bounds.size.x / 2); i <= bounds.size.x; ++i)
        {
            for (int j = 0; j <= bounds.size.z / 2; ++j)
            {
                Instantiate(enclosingTerrain, new Vector3(bounds.min.x + i * 2f, bounds.min.y, bounds.max.z + j * 2f), Quaternion.Euler(-90f, 180f, -90f));
            }
        }

        //Down
        for (int i = 0; i <= bounds.size.x / 2; ++i)
        {
            for (int j = 0; j <= bounds.size.z / 2; ++j)
            {
                Instantiate(enclosingTerrain, new Vector3(bounds.max.x + i * 2f, bounds.min.y, bounds.min.z + j * 2f), Quaternion.Euler(-90f, 180f, -90f));
            }
        }

    }

    void SpawnCar()
    {
        currentCarNum++;


        if (currentCarNum >= GlobalValues.CurrentStage.Cars.Count)
        {
            EventManager.Trigger("Won");
            return;
        }
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

    void RespawnCar()
    {
        GlobalValues.Running = false;

        Destroy(GlobalValues.CurrentCar);
        GameObject car = Instantiate(GlobalValues.CurrentStage.Cars[currentCarNum], GlobalValues.CurrentStage.BeginPositions[currentCarNum], Quaternion.identity);
        GlobalValues.CurrentCar = car;
        car.transform.Rotate(GlobalValues.CurrentStage.BeginRotations[currentCarNum]);

        EventManager.Trigger("RespawnCarCamera");
    }

    void OnStartPlay()
    {
        GlobalValues.Running = true;

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
            Debug.Log(currentCarNum, null);
            playedCars.Add(Instantiate(GlobalValues.CurrentStage.Cars[i], GlobalValues.CurrentStage.BeginPositions[i], Quaternion.identity));
            playedCars[i].GetComponentInChildren<Rigidbody>().useGravity = false;
            playedCars[i].GetComponentInChildren<Rigidbody>().isKinematic = true;

            AudioSource[] audios = playedCars[i].GetComponents<AudioSource>();
            foreach (var audio in audios)
            {
                audio.mute = true;
            }
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

            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator PlayPath(int carNum)
    {
        foreach (Path path in GlobalValues.CurrentStage.RecordedPaths[carNum])
        {
            playedCars[carNum].GetComponentInChildren<Rigidbody>().MovePosition(path.Position);
            playedCars[carNum].GetComponentInChildren<Rigidbody>().MoveRotation(path.Rotation);

            yield return new WaitForFixedUpdate();
        }

        Collider[] colliders = playedCars[carNum].GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }

        MeshRenderer[] renderers = playedCars[carNum].GetComponentsInChildren<MeshRenderer>();

        foreach (var renderer in renderers)
        {
            renderer.material.shader = Shader.Find("Transparent/Diffuse");
            renderer.material.color = new Color(1f, 1f, 1f, 0.3f);
        }

        Light[] lights = playedCars[carNum].GetComponentsInChildren<Light>();

        foreach (var light in lights)
        {
            light.enabled = false;
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
        GameObject.FindGameObjectWithTag("Arrow").GetComponentInChildren<Renderer>().enabled = false;
    }
}
