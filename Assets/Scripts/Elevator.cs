using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

	public Vector3 startPos;
	public Vector3 endPos;
	public float progress;
	public float speed;

	public AnimationCurve movementCurve;


	void Start()
    {

	}

    // Update is called once per frame
    void Update()
    {

		transform.position = Vector3.Lerp(startPos, endPos, movementCurve.Evaluate(progress));
		progress += Time.deltaTime * speed;
		if (progress > 1)
		{
			progress = 0;
		}
	
	}
}
