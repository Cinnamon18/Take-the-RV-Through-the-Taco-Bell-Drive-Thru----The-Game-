using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour {
	public Button levelOneButton;
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
		levelOneButton.onClick.AddListener(delegate { transitionToLevel(1); });
		MusicPlayer.PlaySongForLevel("");
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
				target = levelOneButton.transform.position;
				break;
			default:
				Debug.Log("Default");
				break;
		}
	}
}
