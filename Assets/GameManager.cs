using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static readonly int[] sceneTimes = { 0, 20, 35, 999 };

	private float time;
	private float timeLimit;
	private Timer timer;
	public GoalCollider gC;

	// Start is called before the first frame update
	void Start() {
		// gameObject.gameObject.AddComponent<Timer>();
		int sceneInd = SceneManager.GetActiveScene().buildIndex;
		timer.timeLeft = sceneTimes[sceneInd];
	}

	// Update is called once per frame
	void Update() {
		if (timer.timeLeft == 0) {
			//TODO display game over
		}

		if (gC.hitPlayer) {
			StartCoroutine(SceneTransition.LoadScene(SceneManager.GetActiveScene().buildIndex));
		}

	}
}
