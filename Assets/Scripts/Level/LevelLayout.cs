using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLayout : MonoBehaviour
{

    public Vector2Int GridSize = new Vector2Int(5, 5);
    public Vector2Int ResetHallwayLocation = new Vector2Int(26, 25);
    public List<Vector2Int> roomLocations;
    public List<Vector2Int> resetLocations;
    public float gridDistance = 3;
    public GridPoint[][] grid;

    public HallwaySettings hallway;
    
    private void Awake()
    {
        Setup();
        PlaceGrid();
        SetRoomLocations();
        SetResetLocations();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlaceHallway(Random.Range(1,7), 0, 0,Quaternion.LookRotation(Vector3.back,Vector3.up));
        //PlaceHallway(2, 1, 2);
        //PlaceHallway(1, 2, 2);
    }

    public void Setup()
    {
        grid = new GridPoint[GridSize.x][];
        for (int i = 0; i < GridSize.x; i++)
        {
            grid[i] = new  GridPoint[GridSize.y];
        }
    }

    public void PlaceGrid()
    {
        for (int x = 0; x < grid.Length; x++)
        {
            for (int y = 0; y < grid[x].Length; y++)
            {
                GameObject gridpointobject = new GameObject("Gridpoint " + x + " " + y);
                Vector3 xLocation = transform.right * (x * gridDistance - (grid.Length / 2) * gridDistance);
                Vector3 yLocation = transform.forward * (y * gridDistance - (grid[x].Length / 2) * gridDistance);
                gridpointobject.transform.position = transform.position + xLocation + yLocation;
                GridPoint gridPoint = gridpointobject.AddComponent<GridPoint>();
                grid[x][y] = gridPoint;
            }
        }
    }

    public void PlaceHallway(int _index, int x, int y, Quaternion rotation)
    {
        if (x < 0 || x > grid.Length || y < 0 || y > grid[x].Length) return;

        if (grid[x][y].type == GridPoint.gridType.air)
        {
            GameObject _hallway = Instantiate(hallway.GetHallway(_index), grid[x][y].transform);
            _hallway.transform.rotation = rotation;
            _hallway.transform.localPosition = Vector3.zero;
            if (_hallway.TryGetComponent(out Room _hall))
            {
                _hall.gridPosition = new Vector2Int(x, y);
            }
            grid[x][y].type = GridPoint.gridType.hallway1;
        }


        if (grid[x][y].type == GridPoint.gridType.end)
        {

        }

    }

    public void PlaceHallway(int _index, HallwaySettings hallwayStyle, Vector2Int startLocation, Quaternion rotation)
    {

        Vector2Int goalLocation = startLocation;
        LevelManager.direction direction = LevelManager.GetDirectionFromQuaternion(rotation);
        switch (direction)
        {
            case LevelManager.direction.forward: goalLocation += Vector2Int.up; break;
            case LevelManager.direction.backward: goalLocation += Vector2Int.down; break;
            case LevelManager.direction.left: goalLocation += Vector2Int.left; break;
            case LevelManager.direction.right: goalLocation += Vector2Int.right; break;
        }


        // PLACING A HALLWAY
        if (grid[goalLocation.x][goalLocation.y].type == GridPoint.gridType.air)
        {
            GameObject _hallway = Instantiate(hallwayStyle.GetHallway(_index), grid[goalLocation.x][goalLocation.y].transform);
            _hallway.transform.rotation = rotation;
            _hallway.transform.localPosition = Vector3.zero;
            if (_hallway.TryGetComponent(out Room _hall))
            {
                _hall.gridPosition = goalLocation;
            }
            grid[goalLocation.x][goalLocation.y].type = GridPoint.gridType.hallway1;
            return;
        }

        // RESETTING TO HALLWAY
        if (grid[goalLocation.x][goalLocation.y].type == GridPoint.gridType.end)
        {
            Debug.Log("RESET " + direction);
            Vector3 playerPlacementDirection = PlayerManager.Instance.player.transform.position - grid[startLocation.x][startLocation.y].transform.position;
            Quaternion playerPlacementRotation = CameraManager.Instance.rig.transform.rotation;

            Quaternion rotator = Quaternion.Euler(0,180,0);

            switch (LevelManager.GetDirectionFromQuaternion(rotation))
            {
                case LevelManager.direction.forward: rotator = Quaternion.Euler(0, 270, 0); break;
                case LevelManager.direction.backward: rotator = Quaternion.Euler(0, 90, 0); break;
                case LevelManager.direction.left: rotator = Quaternion.Euler(0,0,0);break;
                case LevelManager.direction.right:;break;
            }

            playerPlacementDirection = rotator * playerPlacementDirection;
            playerPlacementRotation =  playerPlacementRotation * rotator;

            PlayerManager.Instance.Teleport(grid[ResetHallwayLocation.x][ResetHallwayLocation.y].transform.position + playerPlacementDirection,rotator);

            //GameObject _hallway = Instantiate(hallwayStyle.GetHallway(1), grid[(grid.Length/2)+1][grid[x].Length/2].transform);
            //_hallway.transform.rotation = Quaternion.Euler(0, 90, 0);
            //_hallway.transform.localPosition = Vector3.zero;
        }
    }

    public void SetRoomLocations()
    {
        foreach(Vector2Int roomLocation in roomLocations)
        {
            grid[roomLocation.x][roomLocation.y].type = GridPoint.gridType.room;
        }
    }

    public void SetResetLocations()
    {
        foreach (Vector2Int resetLocation in resetLocations)
        {
            grid[resetLocation.x][resetLocation.y].type = GridPoint.gridType.end;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
