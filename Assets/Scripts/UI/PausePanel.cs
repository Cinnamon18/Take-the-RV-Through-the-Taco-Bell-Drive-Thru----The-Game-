using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public Button continueButton;
    public Button startOverButton;
    public Button mainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        continueButton.Select();
        continueButton.onClick.AddListener(continueGame);
        startOverButton.onClick.AddListener(startOver);
        mainMenuButton.onClick.AddListener(mainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void continueGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

	void startOver()
    {
        Time.timeScale = 1;
        StartCoroutine(SceneTransition.LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
	void mainMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(SceneTransition.LoadScene(0));
    }
    void OnEnable()
    {
        continueButton.OnSelect(null);
    }
}
