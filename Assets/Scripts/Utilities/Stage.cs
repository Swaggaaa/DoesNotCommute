using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage {

    public abstract List<Vector3> BeginPositions
    {
        get;
    }

    public abstract List<Vector3> BeginRotations
    {
        get;
    }

    public abstract List<Vector3> EndPositions
    {
        get;
    }

    public abstract List<Vector3> CoinPositions
    {
        get;
    }

    public abstract List<GameObject> Cars
    {
        get;
    }

    public abstract List<List<Path>> RecordedPaths
    {
        get;
    }

    public abstract Vector3 CameraCenterStage
    {
        get;
    }

    public abstract Bounds Bounds
    {
        get;
    }
}
