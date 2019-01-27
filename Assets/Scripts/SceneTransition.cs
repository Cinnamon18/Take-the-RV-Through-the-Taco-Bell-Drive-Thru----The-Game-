using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class SceneTransition : MonoBehaviour {

	private static GameObject sceneTransitionCanvas;
	private static AnimationCurve currentTransCurve;
	public AnimationCurve animCurve;

	private static readonly float TRANSITION_TIME = 2f;
	private static readonly string[] LEVEL_NAMES = { "", "Taco Bell", "RV Graveyard", "Taco Hell", "Elevation", "Moon Base", ""};

	void Awake() {

		MusicPlayer.Create();

		sceneTransitionCanvas = Resources.Load<GameObject>("SceneTransitionCanvas");
		if (currentTransCurve == null) {
			SceneTransition.currentTransCurve = animCurve;
		}

		StartCoroutine(FadeIn());
	}

	public static IEnumerator LoadScene(int sceneIdx) {
		if (sceneTransitionCanvas == null) {
			throw new UnityException("Please make sure you've assigned a scenetransitioncanvas to the scene transition mb at some point.");
		}

		GameObject sceneTransCan = Object.Instantiate(sceneTransitionCanvas);
		RectTransform mask = sceneTransCan.transform.GetChild(0).gameObject.GetComponent<RectTransform>();

		yield return SceneTransition.Lerp(SceneTransition.TRANSITION_TIME, progress => {
			float scaler = 1 - currentTransCurve.Evaluate(progress);
			mask.sizeDelta = new Vector2(scaler * 1600, scaler * 900);
		});

		yield return new WaitForSeconds(0.1f);
		SceneManager.LoadScene(sceneIdx);
	}

	public static IEnumerator FadeIn() {
		if (SceneManager.GetActiveScene().buildIndex < LEVEL_NAMES.Length) {

			GameObject sceneTransCan = Object.Instantiate(sceneTransitionCanvas);
			RectTransform mask = sceneTransCan.transform.GetChild(0).gameObject.GetComponent<RectTransform>();
			Text text = sceneTransCan.GetComponentInChildren<Text>();

			int idx = SceneManager.GetActiveScene().buildIndex;
			if (SceneTransition.LEVEL_NAMES[idx] == "") {
				text.text = "";
			} else {
				text.text = "Level " + idx + ":\n\n" + SceneTransition.LEVEL_NAMES[idx];

				// Play music associated with the level
				MusicPlayer.PlaySongForLevel(SceneTransition.LEVEL_NAMES[idx]);
			}

			yield return SceneTransition.Lerp(SceneTransition.TRANSITION_TIME, progress => {
				text.fontSize = (int)(Mathf.Lerp(5, 120, currentTransCurve.Evaluate(progress)));
			});

			if (SceneTransition.LEVEL_NAMES[idx] != "") {
				yield return new WaitForSecondsRealtime(1);
			}

			yield return SceneTransition.Lerp(SceneTransition.TRANSITION_TIME, progress => {
				float scaler = currentTransCurve.Evaluate(progress);
				mask.sizeDelta = new Vector2(scaler * 1600, scaler * 900);
			});

			Object.Destroy(sceneTransCan);
		}
	}

	public static IEnumerator Lerp(float duration, Action<float> perStep) {
		float timer = 0;
		while ((timer += Time.unscaledDeltaTime) < duration) {
			perStep(timer / duration);
			yield return null;
		}
		perStep(1);
	}
}
