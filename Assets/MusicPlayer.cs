using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour {
	public Dictionary<string, AudioClip> levelsAndSongs;

	public MusicPlayer playerPrefab;

	AudioSource source;
	string currentLevel;

	static MusicPlayer singleton;

	public static MusicPlayer GetInstance() { return singleton; }

	public static void Create() {
		if (singleton == null) {

			GameObject newPlayer = GameObject.Instantiate(new GameObject());
			newPlayer.AddComponent<MusicPlayer>();
			singleton = newPlayer.GetComponent<MusicPlayer>();
		}
	}

	void Initialize() {

		DontDestroyOnLoad(this);
		levelsAndSongs = new Dictionary<string, AudioClip>();
		source = GetComponent<AudioSource>();
		singleton = this;

		levelsAndSongs.Add("", Resources.Load<AudioClip>("Audio/Music/Dave Rodgers - Beat Of The Rising Sun"));
		levelsAndSongs.Add("Taco Bell", Resources.Load<AudioClip>("Audio/Music/DEJAVU"));
		levelsAndSongs.Add("RV Graveyard", Resources.Load<AudioClip>("Audio/Music/M.o.v.e - Around The World"));
		levelsAndSongs.Add("Elevation", Resources.Load<AudioClip>("Audio/Music/Manuel - Gas Gas Gas"));
		levelsAndSongs.Add("Taco Hell", Resources.Load<AudioClip>("Audio/Music/Max Coveri - Running In The 90's"));
		levelsAndSongs.Add("Moon Base", Resources.Load<AudioClip>("Audio/Music/The Spiders From Mars - Fly To Me To The Moon & Back"));
		levelsAndSongs.Add("Game Complete", Resources.Load<AudioClip>("Audio/Music/Audio/Music/Dave Rodgers - Beat Of The Rising Sun"));
	}

	void Awake() {
		if (singleton) {
			Destroy(this);
		} else {
			Initialize();
		}
	}

	// Start is called before the first frame update
	void Start() {
	}

	public static void PlaySongForLevel(string levelName) {

		if (levelName == singleton.currentLevel) return;

		if (singleton.levelsAndSongs == null || singleton.levelsAndSongs.Count == 0) {
			singleton.Initialize();
		}
		singleton.currentLevel = levelName;
		singleton.source.clip = singleton.levelsAndSongs[levelName];
		singleton.source.loop = true;
		singleton.source.Play();
	}
}
