using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hallway : MonoBehaviour
{
    public Vector2Int gridPosition;
    public List<Door> doors;
    public HallwaySettings hallwayStyle;

    private void Awake()
    {
        foreach(Door door in doors)
        {
            door.onInteraction.AddListener(PlaceHallway);
            door.doorLocation = gridPosition;
        }
    }
    private void Start()
    {
        
    }

    public void PlaceHallway(Quaternion rotation)
    {
        Vector2Int goalPosition = gridPosition;
        switch (GetDirectionFromQuaternion(rotation))
        {
            case direction.forward: goalPosition += Vector2Int.up;break;
            case direction.backward: goalPosition += Vector2Int.down;break;
            case direction.left: goalPosition += Vector2Int.left;break;
            case direction.right: goalPosition += Vector2Int.right;break;
        }

        LevelManager.Instance.layout.PlaceHallway(7, goalPosition.x, goalPosition.y, rotation);
    }

    public enum direction
    {
        forward,
        backward,
        left,
        right
    }

    public direction GetDirectionFromQuaternion(Quaternion rotation)
    {
        Vector3 direction = rotation * Vector3.forward;

        direction currentDirection = Hallway.direction.forward;

        float forwardAngle = Vector3.Angle(Vector3.forward, direction);
        float backwardAngle = Vector3.Angle(Vector3.back, direction);
        float leftAngle = Vector3.Angle(Vector3.left, direction);
        float rightAngle = Vector3.Angle(Vector3.right, direction);

        float currentAngle = forwardAngle;
        
        if(backwardAngle < currentAngle) { currentAngle = backwardAngle; currentDirection = Hallway.direction.backward; }
        if(leftAngle < currentAngle) { currentAngle = leftAngle; currentDirection = Hallway.direction.left; }
        if(rightAngle < currentAngle) { currentAngle = rightAngle; currentDirection = Hallway.direction.right; }

        return currentDirection;
    }
}
