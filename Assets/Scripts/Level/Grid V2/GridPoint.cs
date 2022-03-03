using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tdaf.grid
{
    public class GridPoint : MonoBehaviour
    {
        public Vector3Int location;

        public enum gridPointType
        {
            air,
            room,
            hallway,
            reset
        }
        public gridPointType currentType = gridPointType.air;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnDrawGizmos()
        {
            if (currentType == gridPointType.room) Gizmos.color = new Color(0,1,0,.25f);
            if (currentType == gridPointType.hallway) Gizmos.color = new Color(0,0,1,.25f);
            if (currentType == gridPointType.reset) Gizmos.color = new Color(1,0,0,.25f);

            Gizmos.DrawSphere(transform.position, .1f);
            
            if(currentType != gridPointType.air)
            {
                Gizmos.DrawCube(transform.position,new Vector3(1.5f,.5f,1.5f));
            }
        }
    }
}