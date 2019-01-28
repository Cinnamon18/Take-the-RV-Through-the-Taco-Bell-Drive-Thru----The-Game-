using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBody : MonoBehaviour {
	public List<Collider> toDrops;
	void Start() {

	}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			foreach (Collider toDrop in toDrops) {
				if (toDrop.attachedRigidbody) {
					toDrop.attachedRigidbody.useGravity = true;
				}
			}
		}
	}
}
