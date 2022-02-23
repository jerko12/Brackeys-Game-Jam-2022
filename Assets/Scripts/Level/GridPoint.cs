using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPoint : MonoBehaviour
{
    public enum gridType
    {
        air,
        room,
        hallway1,
        hallway2,
        hallway3,
        hallway4,
        hallway5,
        hallway6,
        hallway7,
        hallway8,
        end
    }

    public gridType type;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        if (type == gridType.hallway1 || type == gridType.hallway2 || type == gridType.hallway3 || type == gridType.hallway4 || type == gridType.hallway5 || type == gridType.hallway6 || type == gridType.hallway7 || type == gridType.hallway8) Gizmos.color = Color.yellow;
        if (type == gridType.end) Gizmos.color = Color.red;

        Gizmos.DrawSphere(transform.position, .2f);
    }
}
