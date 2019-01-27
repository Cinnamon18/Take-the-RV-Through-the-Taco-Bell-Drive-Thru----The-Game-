using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBody : MonoBehaviour
{
	public GameObject objToRotate;
	private float i;

    void Start()
    {
		i = objToRotate.transform.localRotation.z;

	}

    // Update is called once per frame
    void Update()
    {
		i = (i + 1) % 360;
		objToRotate.transform.Rotate(0, 0, i); 
	}
}
