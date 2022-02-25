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

    
}
