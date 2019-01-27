
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelSystem : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy && !gameOverPanel.activeInHierarchy)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
        }
    }
}
