
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelSystem : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                Time.timeScale = 0;
                pausePanel.SetActive(true);
            }
        }
    }
}
