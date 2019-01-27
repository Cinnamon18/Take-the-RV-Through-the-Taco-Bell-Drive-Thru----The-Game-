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
	private int xHat = 1;
	private int yHat = 1;
	private int zHat = 1;


	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x <= xMinMax.x)
		{
			xHat = 1;
		} else if (transform.position.x >= xMinMax.y)
		{
			xHat = -1;
		}

		if (transform.position.y <= yMinMax.x)
		{
			yHat = 1;
		}
		else if (transform.position.y >= yMinMax.y)
		{
			yHat = -1;
		}

		if (transform.position.z <= zMinMax.x)
		{
			zHat = 1;
		}
		else if (transform.position.z >= yMinMax.y)
		{
			zHat = -1;
		}

		Translate();
	}

	private void Translate()
	{
		transform.Translate(xHat * Time.deltaTime * xMag, yHat * Time.deltaTime * yMag, zHat * Time.deltaTime * zMag);
	}
}
