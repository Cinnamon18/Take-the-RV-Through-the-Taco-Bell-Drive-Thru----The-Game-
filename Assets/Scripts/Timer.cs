using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
	public TextMeshProUGUI timerTxt;
	public float timeLeft;
	public bool hasTime;
    public GameObject gameOverPanel;


    void Start()
    {
		hasTime = true;
		StartCoroutine("CountDown");
		Time.timeScale = 1;
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(timeLeft);
		float t = timeLeft;


		string min = ((int)t / 60).ToString();
		string sec = (t % 60).ToString("00");

		timerTxt.text = min + ":" + sec;
		
	}

	IEnumerator CountDown()
	{
		while (hasTime)
		{
			yield return new WaitForSeconds (1);
			timeLeft--;

			if (timeLeft == 0)
			{
                if (!gameOverPanel.activeInHierarchy)
                {
                    Time.timeScale = 0;
                    gameOverPanel.SetActive(true);
                }
                hasTime = false;
				//Application.Quit();
			}
		}
	}
}
