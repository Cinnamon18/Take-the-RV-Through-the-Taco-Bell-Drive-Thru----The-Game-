using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    public Dictionary<string, AudioClip> levelsAndSongs;

    AudioSource source;
    string currentLevel;

    static MusicPlayer singleton;

    public static MusicPlayer GetInstance() {return singleton;}

    void Awake() {
        if (singleton) {
            Destroy(this);
        } else {
            DontDestroyOnLoad(this);
            levelsAndSongs = new Dictionary<string, AudioClip>();
            source = GetComponent<AudioSource>();
            singleton = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

        // "", "Taco Bell", "RV Graveyard", "Taco Hell", "Moon Base"
        levelsAndSongs.Add("",              Resources.Load<AudioClip>("Audio/Music/Dave Rodgers - Beat Of The Rising Sun"));
        levelsAndSongs.Add("Taco Bell",     Resources.Load<AudioClip>("Audio/Music/DEJAVU"));
        levelsAndSongs.Add("RV Graveyard",  Resources.Load<AudioClip>("Audio/Music/M.o.v.e - Around The World"));
        levelsAndSongs.Add("Taco Hell",     Resources.Load<AudioClip>("Audio/Music/Max Coveri - Running In The 90's"));
        levelsAndSongs.Add("Moon Base",     Resources.Load<AudioClip>("Audio/Music/The Spiders From Mars - Fly To Me To The Moon & Back"));
    }

    public static void PlaySongForLevel(string levelName) {

        if (levelName == singleton.currentLevel) return;

        singleton.currentLevel = levelName;
        singleton.source.clip = singleton.levelsAndSongs[levelName];
        singleton.source.loop = true;
        singleton.source.Play();
    }
}
