using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Stage1 : Stage
{
    private static Stage1 stage;

    // Singleton
    public static Stage1 Instance
    {
        get
        {
            if (stage == null)
            {
                stage = new Stage1();
            }

            return stage;
        }
    }

    private Stage1()
    {

    }

    //Ugly, should be calculated
    private readonly Vector3 cameraCenterStage = new Vector3(-7f, 23f, -15f);

    private readonly List<Vector3> beginPositions = new List<Vector3>
    {
        new Vector3(2.35f, 0.25f, -8f),
        new Vector3(2.35f, 0.25f, -2f),
        new Vector3(2.35f, 0.25f, -26f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-14f, 0.25f, -0.3f),
        new Vector3(-16f, 0.25f, -8f),
        new Vector3(-16f, 0.25f, -12f),
        new Vector3(-16f, 0.25f, -16f),
        new Vector3(-16f, 0.25f, -22f),
        new Vector3(-14f, 0.25f, -30f),
        new Vector3(-14f, 0.25f, -23f),
        new Vector3(-10f, 0.25f, -25f),
        new Vector3(-10f, 0.25f, -19f)
    };

    private readonly List<Vector3> beginRotations = new List<Vector3>
    {
        new Vector3(0f, -90f, 0f),
        new Vector3(0f, -90f, 0f),
        new Vector3(0f, -90f, 0f),
        new Vector3(0f, -180f, 0f),
        new Vector3(0f, -180f, 0f),
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 90f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, 0f, 0f),
        new Vector3(0f, -180f, 0f)
    };

    private readonly List<Vector3> endPositions = new List<Vector3>
    {
        new Vector3(-14f, 0.25f, -0.3f),
        new Vector3(2.35f, 0.25f, -2f),
        new Vector3(-16f, 0.25f, -12f),
        new Vector3(2.35f, 0.25f, -26f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-16f, 0.25f, -8f),
        new Vector3(-10f, 0.25f, -25f),
        new Vector3(-14f, 0.25f, -23f),
        new Vector3(-16f, 0.25f, -22f),
        new Vector3(-10f, 0.25f, -19f),
        new Vector3(2.35f, 0.25f, -8f),
        new Vector3(-14f, 0.25f, -30f),
        new Vector3(-16f, 0.25f, -16f),
    };

    private readonly List<Vector3> coinPositions = new List<Vector3>
    {
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f),
        new Vector3(-6f, 0.25f, -0.3f)
    };

    private readonly List<GameObject> cars = new List<GameObject>
    {
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab"),
        AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Cars/Car1-blue.prefab")
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
}
