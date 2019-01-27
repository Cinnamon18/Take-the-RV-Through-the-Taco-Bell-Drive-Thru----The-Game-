using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelayTimer : MonoBehaviour
{
    private float timer;
    private float volume;
    public float delayLength;
    public float gradulity = 3;
    private AudioSource audioSource;
    private float audioSourceStartingVolume;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        volume = 0;
        audioSource = GetComponent<AudioSource>();
        audioSourceStartingVolume = audioSource.volume;
        audioSource.volume = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(volume);
        timer += Time.deltaTime;
        if (timer >= delayLength)
        {
            volume += Time.deltaTime * (1/gradulity);
            volume = Mathf.Clamp(volume, 0, 1);
            audioSource.volume = audioSourceStartingVolume * volume;
            
        }
        
    }
}
