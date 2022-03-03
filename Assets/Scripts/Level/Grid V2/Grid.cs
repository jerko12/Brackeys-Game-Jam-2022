using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tdaf.grid
{
    [ExecuteInEditMode]
    public class Grid : MonoBehaviour
    {
        public Dictionary<Vector3Int, GridPoint> gridPoints = new Dictionary<Vector3Int, GridPoint>();
        public Vector3Int gridSize = new Vector3Int(5,1,5);
        public float gridpointDistance = 3.0f;

        private void Update()
        {
            SetupGrid();
            SetGridPointLocations();
        }

        public void SetupGrid()
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                for (int y = 0; y < gridSize.y; y++)
                {
                    for (int z = 0; z < gridSize.z; z++)
                    {
                        CreateGridPoint(new Vector3Int(x, y, z));
                    }
                }
            }
        }

        public void CreateGridPoint(Vector3Int gridPointLocation)
        {
            if (gridPoints.ContainsKey(gridPointLocation)) return;
            //if (gridPoints[gridPointLocation] != null) return;

            GameObject gridPointObject = new GameObject();
            GridPoint gridPoint = gridPointObject.AddComponent<GridPoint>();
            gridPoint.location = gridPointLocation;
            gridPoint.name = "Grid point [" + gridPointLocation.x + "," + gridPointLocation.y + "," + gridPointLocation.z + "]";
            gridPoint.transform.parent = transform;
            gridPoints.Add(gridPointLocation,gridPoint);
        }

        public void SetGridPointLocations()
        {
            foreach (KeyValuePair<Vector3Int, GridPoint> GridPointPositionPair in gridPoints)
            {
                GridPointPositionPair.Value.transform.position = (Vector3)GridPointPositionPair.Key * gridpointDistance;
            }
        }
    }
}