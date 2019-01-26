using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
	public Button levelOneButton;

	// Start is called before the first frame update
	void Start()
    {
		levelOneButton.onClick.AddListener(delegate { transitionToLevel(1); });
    }

	void transitionToLevel(int levelNo)
	{
		switch (levelNo)
		{
			case 1:
				Debug.Log("Level 1");
				SceneManager.LoadScene("Level 1");
				break;
			default:
				Debug.Log("Default case");
				break;
		}
	}
    
}
