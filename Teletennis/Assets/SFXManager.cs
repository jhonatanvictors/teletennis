using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    
    public AudioSource Audio;

    public AudioClip Click;

    public static SFXManager sfxInstance;
    
    // Start is called before the first frame update
    private void Awake() {
        if (sfxInstance != null && sfxInstance != this){
            Destroy(this.gameObject);
            return;
        }

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}

//SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Click);