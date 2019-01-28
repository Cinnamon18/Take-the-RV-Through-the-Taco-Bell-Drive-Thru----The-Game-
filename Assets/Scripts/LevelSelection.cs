using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {
	public Button levelOneButton;
    public Button playButton;
    public Button creditsButton;
    public Button backButton;
    public Button lsBackButton;
    public GameObject earth;
    public GameObject rvImage;
    public GameObject splash;
    public GameObject creditsPanel;
	public RectTransform rv;
	public int sceneIndex;
	public Vector3 target;
	public bool rvMoving;
	private int rvSpeed;

	private bool transitioning;
	// Start is called before the first frame update
	void Start() {
		rvMoving = false;
		rvSpeed = 3;
        playButton.onClick.AddListener(delegate { transitionToLevel(1); });
        creditsButton.onClick.AddListener(transitionToCredits);
        backButton.onClick.AddListener(transitionToSplash);
        lsBackButton.onClick.AddListener(transitionToSplash);
        levelOneButton.onClick.AddListener(delegate { transitionToLevel(1); });
        earth.SetActive(false);
        rvImage.SetActive(false);
        creditsPanel.SetActive(false);
        levelOneButton.gameObject.SetActive(false);
        backButton.gameObject.SetActive(false);
        lsBackButton.gameObject.SetActive(false);
        splash.SetActive(true);
        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
		MusicPlayer.PlaySongForLevel("");
        playButton.Select();
	}

	void Update() {
		if (rvMoving) {
			float step = 400 * Time.deltaTime;
			rv.position = Vector3.MoveTowards(rv.position, target, step);
			if (rv.position == target && !transitioning) {
				transitioning = true;
				StartCoroutine(SceneTransition.LoadScene(sceneIndex));
			}
		} else {
			rv.rotation = Quaternion.Euler(0f, 0f, 15 * Mathf.Sin(Time.time * rvSpeed));
		}
	}

	void transitionToLevel(int levelNo) {
		rvMoving = true;
		sceneIndex = levelNo;
		switch (levelNo) {
			case 1:
				StartCoroutine(SceneTransition.LoadScene(sceneIndex));
				break;
			default:
				Debug.Log("Default");
				break;
		}
	}

	void transitionToPlay()
    {
        splash.SetActive(false);
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);

        lsBackButton.gameObject.SetActive(true);
        earth.SetActive(true);
        rvImage.SetActive(true);
        levelOneButton.gameObject.SetActive(true);
        levelOneButton.Select();
    }
	void transitionToCredits()
    {
        splash.SetActive(false);
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);

        creditsPanel.SetActive(true);
        backButton.gameObject.SetActive(true);
        backButton.Select();
    }
	void transitionToSplash()
    {
        creditsPanel.SetActive(false);
        backButton.gameObject.SetActive(false);
        lsBackButton.gameObject.SetActive(false);
        earth.SetActive(false);
        rvImage.SetActive(false);
        levelOneButton.gameObject.SetActive(false);

        splash.SetActive(true);
        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        playButton.Select();
    }
}
