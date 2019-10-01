using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    AudioSource source;
    bool muted;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        muted = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Mute"))
        {
            if(!muted)
            {
                source.volume = 0f;
                muted = true;
            }

            if(muted)
            {
                source.volume = 0.75f;
                muted = false;
            }
        }
    }
}
