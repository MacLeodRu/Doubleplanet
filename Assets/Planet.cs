using System;
using UnityEngine;


class Planet
{
    public double mass;
    public Vec3 p;
    public Vec3 pos;

    const double scale = 1e10;

    public Vector3 GetScaledPos()
    {
        var scaledPos = pos / scale;
        return new Vector3(Convert.ToSingle(scaledPos.x),
            Convert.ToSingle(scaledPos.y),
            Convert.ToSingle(scaledPos.z));
    }
}
