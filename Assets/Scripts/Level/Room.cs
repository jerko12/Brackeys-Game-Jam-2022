using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Vector2Int gridPosition;
    public List<Vector2Int> FakePositions;
    public List<Door> doors;
    public HallwaySettings hallwayStyle;
    public int HallwayNumber = 0;
   

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
    public void SetHallwayNumber(int _number)
    {
        HallwayNumber = _number;
    }

    public void PlaceHallway(Door door)
    {
        Vector2Int goalPosition = gridPosition + door.additiveDoorLocation;
        switch (LevelManager.GetDirectionFromQuaternion(door.transform.rotation))
        {
            case LevelManager.direction.forward: goalPosition += Vector2Int.up;break;
            case LevelManager.direction.backward: goalPosition += Vector2Int.down;break;
            case LevelManager.direction.left: goalPosition += Vector2Int.left;break;
            case LevelManager.direction.right: goalPosition += Vector2Int.right;break;
        }

        LevelManager.Instance.layout.PlaceHallway(HallwayNumber + 1, hallwayStyle, gridPosition + door.additiveDoorLocation, door.transform.rotation);
    }

    public void Reset()
    {
        LevelManager.Instance.layout.grid[gridPosition.x][gridPosition.y].type = GridPoint.gridType.air;
        Destroy(this.gameObject);
    }


}
