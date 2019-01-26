using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	public Text timerTxt;
	public float timeLeft;
	
	
	void Start()
    {
		StartCoroutine("CountDown");
		Time.timeScale = 1;
	}

    // Update is called once per frame
    void Update()
    {
		float t = timeLeft;


		string min = ((int)t / 60).ToString();
		string sec = (t % 60).ToString("00");

		timerTxt.text = min + ":" + sec;
		if (timeLeft <= 0)
		{
			GameObject pUI = GameObject.Find("Player HUD");
			GameOver gOver = pUI.GetComponent<GameOver>();
			gOver.EndState();
			//Application.Quit();
		}
	}

	IEnumerator CountDown()
	{
		while (true)
		{
			yield return new WaitForSeconds (1);
			timeLeft--;
		}
	}
}
