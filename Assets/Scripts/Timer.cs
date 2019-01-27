using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public static readonly int[] sceneTimes = { 0, 20, 35, 999 };

	public TextMeshProUGUI timerTxt;
	public float timeLeft;
	public bool hasTime;
	public GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;

    void Start() {
		timeLeft = sceneTimes[SceneManager.GetActiveScene().buildIndex];
		hasTime = true;
		StartCoroutine("CountDown");
		Time.timeScale = 1;
	}

	// Update is called once per frame
	void Update() {
		// Debug.Log(timeLeft);
		float t = timeLeft;


		string min = ((int)t / 60).ToString();
		string sec = (t % 60).ToString("00");

		timerTxt.text = min + ":" + sec;

	}

	IEnumerator CountDown() {
		while (hasTime) {
			yield return new WaitForSeconds(1);
			timeLeft--;

			if (timeLeft == 0) {
				if (!gameOverPanel.activeInHierarchy && !pausePanel.activeInHierarchy) {
					GameObject.FindWithTag("Goal").GetComponent<GoalCollider>().ascend();
					Time.timeScale = 0;
					GameOver();
				}
				hasTime = false;
				//Application.Quit();
			}
		}
	}

	public void GameOver() {
		gameOverPanel.SetActive(true);

	}
}
