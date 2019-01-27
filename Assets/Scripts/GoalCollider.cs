using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCollider : MonoBehaviour {

	public bool hitPlayer;

	// Update is called once per frame
	void OnTriggerEnter(Collider hitObj) {
		if (hitObj.gameObject.tag == "Player") {
			hitPlayer = true;
		}
	}

}
