using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stage2 : Stage
{
    private static Stage2 stage;

    // Singleton
    public static Stage2 Instance
    {
        get
        {
            if (stage == null)
            {
                stage = new Stage2();
            }

            return stage;
        }
    }

    private Stage2()
    {

    }

    //Ugly, should be calculated
    private readonly Vector3 cameraCenterStage = new Vector3(7f, 17f, -12f);

    private readonly List<Vector3> beginPositions = new List<Vector3>
    {
        new Vector3(2f, 0.25f, -6f),
        new Vector3(2f, 0.25f, -8f),
        new Vector3(5f, 0.25f, -10f),
        new Vector3(0f, 0.25f, -14f),
        new Vector3(0f, 0.25f, -10f),
        new Vector3(12f, 0.25f, -8f),
        new Vector3(14f, 0.25f, -16f),
        new Vector3(0f, 0.25f, -18f),
        new Vector3(14f, 0.25f, -6f),
        new Vector3(14f, 0.25f, -12f),
        new Vector3(4f, 0.25f, -16f),
        new Vector3(0f, 0.25f, -16f),
        new Vector3(6f, 0.25f, -14f),
    };

    private readonly List<Vector3> beginRotations = new List<Vector3>
    {
        new Vector3(0f, 180f, 0f),
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 180f, 0f),
        new Vector3(0f, -90f, 0f),
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, -90f, 0f),
        new Vector3(0f, -90f, 0f),
        new Vector3(0f, -90f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 90f, 0f)
    };

    private readonly List<Vector3> endPositions = new List<Vector3>
    {
        new Vector3(0f, 0.25f, -18f),
        new Vector3(14f, 0.25f, -6f),
        new Vector3(14f, 0.25f, -12f),
        new Vector3(14f, 0.25f, -12f),
        new Vector3(14f, 0.25f, -12f),
        new Vector3(14f, 0.25f, -18f),
        new Vector3(0f, 0.25f, -18f),
        new Vector3(14f, 0.25f, -16f),
        new Vector3(2f, 0.25f, -8f),
        new Vector3(14f, 0.25f, -16f),
        new Vector3(0f, 0.25f, -14f),
        new Vector3(2f, 0.25f, -6f),
        new Vector3(14f, 0.25f, -12f),
    };

    private readonly List<Vector3> coinPositions = new List<Vector3>
    {
        new Vector3(),
        new Vector3(),
        new Vector3(8f, 0.5f, -10f),
        new Vector3(5f, 0.5f, -14f),
        new Vector3(),
        new Vector3(-8f, 0.5f, -11f),
        new Vector3(-4f, 0.25f, -16f),
        new Vector3(),
        new Vector3(),
        new Vector3(),
        new Vector3(),
        new Vector3(),
        new Vector3(-2f, 0.25f, -14f),
        new Vector3()
    };

    private readonly List<GameObject> cars = new List<GameObject>
    {
        Resources.Load<GameObject>("Cars/Car1-blue"),
        Resources.Load<GameObject>("Cars/Van"),
        Resources.Load<GameObject>("Cars/Car1-white"),
        Resources.Load<GameObject>("Cars/Car1-red"),
        Resources.Load<GameObject>("Cars/Police Car"),
        Resources.Load<GameObject>("Cars/Big Rig"),
        Resources.Load<GameObject>("Cars/Taxi"),
        Resources.Load<GameObject>("Cars/Car1-red"),
        Resources.Load<GameObject>("Cars/Car1-white"),
        Resources.Load<GameObject>("Cars/Van"),
        Resources.Load<GameObject>("Cars/Taxi"),
        Resources.Load<GameObject>("Cars/Police Car"),
    };

    private List<List<Path>> recordedPaths = new List<List<Path>>()
    {
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>(),
        new List<Path>()
    };

    private Bounds bounds = new Bounds(new Vector3(7f, 0f, -12f), new Vector3(18f, 0f, 16f));

    private string nextStageName = "Stage3";

    private List<Vector3> duckPath = new List<Vector3>()
    {
        new Vector3(-2f, 0f, -6f),
        new Vector3(-2f, 0f, -18f)
    };

    public override List<Vector3> BeginPositions
    {
        get
        {
            return beginPositions;
        }
    }

    public override List<Vector3> BeginRotations
    {
        get
        {
            return beginRotations;
        }
    }

    public override List<Vector3> EndPositions
    {
        get
        {
            return endPositions;
        }
    }

    public override List<Vector3> CoinPositions
    {
        get
        {
            return coinPositions;
        }
    }

    public override List<GameObject> Cars
    {
        get
        {
            return cars;
        }
    }

    public override Vector3 CameraCenterStage
    {
        get
        {
            return cameraCenterStage;
        }
    }

    public override List<List<Path>> RecordedPaths
    {
        get
        {
            return recordedPaths;
        }
    }

    public override Bounds Bounds
    {
        get
        {
            return bounds;
        }
    }

    public override string NextStageName
    {
        get
        {
            return nextStageName;
        }
    }

    public override List<Vector3> DuckPath
    {
        get
        {
            return duckPath;
        }
    }
}
