using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {
	public List<Button> levelButtons;
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
    static bool[] levelsAvailable;

	private bool transitioning;
	// Start is called before the first frame update
	void Start() {
		rvMoving = false;
		rvSpeed = 3;
        playButton.onClick.AddListener(transitionToPlay);
        creditsButton.onClick.AddListener(transitionToCredits);
        backButton.onClick.AddListener(transitionToSplash);
        lsBackButton.onClick.AddListener(transitionToSplash);

        // give level select buttons functionality
        int levelIndex = 1;
        foreach (Button button in levelButtons) {
            int tempLevelIndex = levelIndex;
            button.onClick.AddListener(delegate { transitionToLevel(tempLevelIndex); });
            levelIndex++;
        }

        if (levelsAvailable == null) {
            levelsAvailable = new bool[levelButtons.Count];
            levelsAvailable[0] = true;
        }


        earth.SetActive(false);
        rvImage.SetActive(false);
        creditsPanel.SetActive(false);
        SetLevelButtonsActive(false);
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

    void SetLevelButtonsActive(bool shouldBeActive) {

        int levelIndex = 0;
        foreach (Button levelButton in levelButtons) {
            levelButton.gameObject.SetActive((shouldBeActive && levelsAvailable[levelIndex++]));
        }
    }

	void transitionToLevel(int levelNo) {
		rvMoving = true;
		sceneIndex = levelNo;

        if (levelNo - 1 < levelButtons.Count) {
            target = levelButtons[levelNo - 1].transform.position;
        } else {
            Debug.Log("Default");
        }
	}

    // moves from title screen to level select
	void transitionToPlay()
    {
        splash.SetActive(false);
        playButton.gameObject.SetActive(false);
        creditsButton.gameObject.SetActive(false);

        lsBackButton.gameObject.SetActive(true);
        earth.SetActive(true);
        rvImage.SetActive(true);

        SetLevelButtonsActive(true);
        levelButtons[0].Select();
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
        SetLevelButtonsActive(false);

        splash.SetActive(true);
        playButton.gameObject.SetActive(true);
        creditsButton.gameObject.SetActive(true);
        playButton.Select();
    }

    public static void CompleteLevel(int levelBuildIndex) {
        if (levelBuildIndex < levelsAvailable.Length) {
            levelsAvailable[levelBuildIndex] = true;
        } else {
            // beat the last level
        }
    }
}
