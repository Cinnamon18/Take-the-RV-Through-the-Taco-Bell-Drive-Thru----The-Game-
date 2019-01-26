using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneTransition {
	public static void LoadScene(string scene) {
		
		SceneManager.LoadScene(scene);
	}
}
