using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLayout : MonoBehaviour
{

    public Vector2Int GridSize = new Vector2Int(5, 5);
    public float gridDistance = 3;
    public GridPoint[][] grid;

    public HallwaySettings hallway;

    private void Awake()
    {
        Setup();
        PlaceGrid();
    }

    // Start is called before the first frame update
    void Start()
    {
        PlaceHallway(7, 0, 0,Quaternion.LookRotation(Vector3.back,Vector3.up));
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
        if (grid[x][y].type == GridPoint.gridType.air)
        {
            GameObject _hallway = Instantiate(hallway.GetHallway(_index), grid[x][y].transform);
            _hallway.transform.rotation = rotation;
            _hallway.transform.localPosition = Vector3.zero;
            if (_hallway.TryGetComponent(out Hallway _hall))
            {
                _hall.gridPosition = new Vector2Int(x, y);
            }
            grid[x][y].type = GridPoint.gridType.hallway1;
        }
        
        
    }

    public void PlaceHallway(int _index, HallwaySettings hallwayStyle, int x, int y, Quaternion rotation)
    {
        if (grid[x][y].type == GridPoint.gridType.air)
        {
            GameObject _hallway = Instantiate(hallwayStyle.GetHallway(_index), grid[x][y].transform);
            _hallway.transform.rotation = rotation;
            _hallway.transform.localPosition = Vector3.zero;
            if (_hallway.TryGetComponent(out Hallway _hall))
            {
                _hall.gridPosition = new Vector2Int(x, y);
            }
            grid[x][y].type = GridPoint.gridType.hallway1;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
