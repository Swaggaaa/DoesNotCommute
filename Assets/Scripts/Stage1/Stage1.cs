using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class Stage1
{
    private static readonly List<Vector3> beginPositions = new List<Vector3>
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

    private static readonly List<Vector3> beginRotations = new List<Vector3>
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

    private static readonly List<Vector3> endPositions = new List<Vector3>
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

    private static readonly List<GameObject> cars = new List<GameObject>
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

    public static List<Vector3> BeginPositions
    {
        get
        {
            return beginPositions;
        }
    }

    public static List<Vector3> BeginRotations
    {
        get
        {
            return beginRotations;
        }
    }

    public static List<Vector3> EndPositions
    {
        get
        {
            return endPositions;
        }
    }

    public static List<GameObject> Cars
    {
        get
        {
            return cars;
        }
    }
}
