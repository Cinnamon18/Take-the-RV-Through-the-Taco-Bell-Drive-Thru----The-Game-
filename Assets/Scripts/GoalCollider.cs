using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalCollider : MonoBehaviour {

    private bool levelWon;

    private void Start()
    {
        levelWon = false;
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider hitObj) {
		if (hitObj.gameObject.tag == "Player") {
            levelWon = true;
            int levelBuildIndex = SceneManager.GetActiveScene().buildIndex;
            LevelSelection.CompleteLevel(levelBuildIndex);
			StartCoroutine(SceneTransition.LoadScene(levelBuildIndex + 1));
		}
	}

    public bool Won() { return levelWon; }
    
	public void ascend() {
        GetComponent<Rigidbody>().velocity += 3 * transform.up; ;		
		GetComponent<BoxCollider>().enabled = false;
	}

}
