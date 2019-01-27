using System.Collections;
using System.Collections.Generic;
using CollisionTypes;
using UnityEngine;

public class CollisionDetector {

	public RVController rv;

	public CollisionDetector(RVController rv) {
		this.rv = rv;
	}

	public CollisionType getCollisionType(Collision collision) {
		Debug.DrawRay(rv.transform.position, rv.transform.position + collision.relativeVelocity, Color.green, 1);
		Debug.DrawRay(rv.transform.position, rv.transform.position + collision.GetContact(0).normal, Color.red, 1);

		Vector3 normal = collision.GetContact(0).normal;
		Vector3 negVelo = collision.relativeVelocity;
		float angle = Vector3.Angle(normal, negVelo);

		if (collision.relativeVelocity.magnitude < 1.5) {
			return new Tap();
		} else {
			if (angle <= 60) {
				return new Big();
			} else {
				return new Scrape();
			}
		}
	}
}
