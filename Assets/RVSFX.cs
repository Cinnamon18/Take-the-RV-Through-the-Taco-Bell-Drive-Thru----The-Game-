using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RVSFX : MonoBehaviour
{

    private AudioSource engineSource;
    private AudioSource accSource;
    private AudioSource honkSource;

    public AudioClip engineRunning;
    public AudioClip engineAcceleration;
    public AudioClip honk;

    private float engineVolume;
    private float accVolume;
    private float honkVolume;

    private float volumeScale;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        engineSource = transform.GetChild(0).GetComponent<AudioSource>();
        accSource = transform.GetChild(1).GetComponent<AudioSource>();
        honkSource = transform.GetChild(2).GetComponent<AudioSource>();
        
        accSource.clip = engineAcceleration;
        honkSource.clip = honk;

        engineVolume = engineSource.volume;
        accVolume = accSource.volume;
        honkVolume = honkSource.volume;

        engineSource.volume = 0;
        accSource.volume = 0;
        honkSource.volume = 0;
        volumeScale = 0;

        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            volumeScale += (Time.deltaTime / 3);
            volumeScale = Mathf.Clamp(volumeScale, 0, 1);
            engineSource.volume = volumeScale * engineVolume;
            accSource.volume = volumeScale * accVolume;
            honkSource.volume = volumeScale * honkVolume;
        }
        
    }
}
