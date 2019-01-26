using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
	public GameObject gameOverTxt;
	public Button returnToMenu;

    public void EndState()
    {
		gameOverTxt.SetActive(true);
		returnToMenu.gameObject.SetActive(true);

	}

    // Update is called once per frame
    void Update()
    {
		returnToMenu.onClick.AddListener(RetOnClick);
    }

	void RetOnClick()
	{
		
	}
}
