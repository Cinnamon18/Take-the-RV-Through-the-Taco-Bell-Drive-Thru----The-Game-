using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

	public Vector2 xMinMax;
	public int xMag;
	public Vector2 yMinMax;
	public int yMag;	
	public Vector2 zMinMax;
	public int zMag;


	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= xMinMax.x)
		{
			Translate(Vector3.right, xMag);
		} else if (transform.position.x >= xMinMax.y)
		{
			Translate(Vector3.left, xMag);
		}

		if (transform.position.y <= yMinMax.x)
		{
			Translate(Vector3.up, yMag);
		}
		else if (transform.position.y >= yMinMax.y)
		{
			Translate(Vector3.down, yMag);
		}

		if (transform.position.z <= zMinMax.x)
		{
			Translate(Vector3.forward, yMag);
		}
		else if (transform.position.z >= yMinMax.y)
		{
			Translate(Vector3.back, yMag);
		}
	}

	private void Translate(Vector3 vHat, int mag)
	{
		transform.Translate(vHat * Time.deltaTime * mag);
	}
}
