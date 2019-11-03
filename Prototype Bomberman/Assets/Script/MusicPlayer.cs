using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    FMOD.Studio.EventInstance GameplayMusic;

    // Start is called before the first frame update
    void Start()
    {
        GameplayMusic = FMODUnity.RuntimeManager.CreateInstance("event:/Music/GameplayMusic");
        GameplayMusic.start();
        GameplayMusic.release();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        GameplayMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
