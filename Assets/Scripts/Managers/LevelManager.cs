using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    //rooms
    //halways
    //layout
    public LevelLayout layout;
    private void Awake()
    {
        layout = GetComponentInChildren<LevelLayout>();
    }
}
