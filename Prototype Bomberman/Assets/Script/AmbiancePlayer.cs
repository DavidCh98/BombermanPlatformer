using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbiancePlayer : MonoBehaviour
{

    FMOD.Studio.EventInstance Ambiance;

    // Start is called before the first frame update
    void Start()
    {
        Ambiance = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/JungleAmbiance");
        Ambiance.start();
        Ambiance.release();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        Ambiance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
