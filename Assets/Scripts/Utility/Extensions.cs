using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Vector3 RelativeVector(this Vector3 vector, Transform relativeTransform)
    {
        Vector3 relativeVector = Vector3.zero;
        relativeVector += relativeTransform.forward * vector.z;
        relativeVector += relativeTransform.right * vector.x;
        relativeVector += relativeTransform.up * vector.y;
        return new Vector3(relativeVector.x, relativeVector.y, relativeVector.z);
    }

    public static Vector3 RelativeVectorFlat(this Vector3 vector, Transform relativeTransform)
    {
        float magnitude = vector.magnitude;
        Vector3 relativeVector = Vector3.zero;
        relativeVector += relativeTransform.forward * vector.z;
        relativeVector += relativeTransform.right * vector.x;
        
        return new Vector3(relativeVector.x, 0, relativeVector.z).normalized * magnitude;
    }

    public static Vector2 RelativeVector(this Vector2 vector, Transform relativeTransform)
    {
        Vector3 relativeVector = Vector3.zero;
        relativeVector += relativeTransform.forward * vector.y;
        relativeVector += relativeTransform.right * vector.x;
        return new Vector2(relativeVector.x, relativeVector.z);
    }
}
