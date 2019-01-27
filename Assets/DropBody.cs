using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBody : MonoBehaviour
{
	public Collider toDrop;
	void Start()
	{

	}

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (toDrop.attachedRigidbody)
			{
				toDrop.attachedRigidbody.useGravity = true;
			}
		}
	}
}
