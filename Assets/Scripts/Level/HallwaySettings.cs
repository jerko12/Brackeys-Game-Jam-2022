using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Hallway", menuName = "HallwaySetup", order = 1)]
public class HallwaySettings : ScriptableObject
{
    public enum FacingDirecion
    {
        forward,
        backward,
        left,
        right
    }

    public GameObject hallway1;
    public GameObject hallway2;
    public GameObject hallway3;
    public GameObject hallway4;
    public GameObject hallway5;
    public GameObject hallway6;
    public GameObject hallway7;
    public GameObject hallway8;

    public GameObject GetHallway(int index)
    {
        switch (index)
        {
            case 1: return hallway1; break;
            case 2: return hallway2; break;
            case 3: return hallway3; break;
            case 4: return hallway4; break;
            case 5: return hallway5; break;
            case 6: return hallway6; break;
            case 7: return hallway7; break;
            case 8: return hallway8; break;
        
        }

        return null;
    }
}
