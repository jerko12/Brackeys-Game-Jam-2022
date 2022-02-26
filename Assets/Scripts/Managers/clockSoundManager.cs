using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockSoundManager : MonoBehaviour
{
    public AudioSource tickSound;
    public AudioSource tockSound;

    public void PlayTick()
    {
        tickSound.Play();
    }
    
    public void PlayTock()
    {
        tockSound.Play();
    }
}
