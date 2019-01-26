using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public Text timerTxt;
	private float startTime;
   
    void Start()
    {
		startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		float t = Time.time - startTime;

		string min = ((int)t / 60).ToString();
		string sec = (t % 60).ToString("f2");

		timerTxt.text = min + ":" + sec;
    }
}
