using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public Button tryAgainButton;
    public Button mainMenuButton;
    // Start is called before the first frame update
    void Start()
    {
        tryAgainButton.onClick.AddListener(tryAgain);
        mainMenuButton.onClick.AddListener(mainMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void mainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

	void tryAgain()
    {

    }
}
