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
			StartCoroutine(SceneTransition.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
		}
	}

    public bool Won() { return levelWon; }
    
	public void ascend() {
		GetComponent<BoxCollider>().enabled = false;
		GetComponent<Rigidbody>().velocity += new Vector3(0, 3, 0);		
	}

}
