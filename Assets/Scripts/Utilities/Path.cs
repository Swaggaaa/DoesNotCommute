using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path {

	public Vector3 Position { get; set; }

    public Quaternion Rotation { get; set; }

    public Path(Vector3 position, Quaternion rotation)
    {
        this.Position = position;
        this.Rotation = rotation;
    }
}
