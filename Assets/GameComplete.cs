using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour
{
    public Button playAgainButton;
    // Start is called before the first frame update
    void Start()
    {
        playAgainButton.onClick.AddListener(transitionToMain);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	void transitionToMain()
    {
        StartCoroutine(SceneTransition.LoadScene(0));
    }
}
