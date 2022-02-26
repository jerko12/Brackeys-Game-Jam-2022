using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    //rooms
    //halways
    //layout
    public LevelLayout layout;
    public override void Awake()
    {
        base.Awake();
        layout = GetComponent<LevelLayout>();
    }

    

    

    public enum direction
    {
        forward,
        backward,
        left,
        right
    }

    public static direction GetDirectionFromQuaternion(Quaternion rotation)
    {
        Vector3 _direction = rotation * Vector3.forward;

        direction currentDirection = direction.forward;

        float forwardAngle = Vector3.Angle(Vector3.forward, _direction);
        float backwardAngle = Vector3.Angle(Vector3.back, _direction);
        float leftAngle = Vector3.Angle(Vector3.left, _direction);
        float rightAngle = Vector3.Angle(Vector3.right, _direction);

        float currentAngle = forwardAngle;

        if (backwardAngle < currentAngle) { currentAngle = backwardAngle; currentDirection = direction.backward; }
        if (leftAngle < currentAngle) { currentAngle = leftAngle; currentDirection = direction.left; }
        if (rightAngle < currentAngle) { currentAngle = rightAngle; currentDirection = direction.right; }

        return currentDirection;
    }
}
