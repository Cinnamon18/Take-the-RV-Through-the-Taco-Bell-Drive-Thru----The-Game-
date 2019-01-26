using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float time;
    private float timeLimit;
    private Timer timer;

    public GoalCollider gC;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.gameObject.AddComponent<Timer>();
        // int sceneInd = SceneManager.GetActiveScene().bulidIndex;
        // get time limit from list
        timer.timeLeft = 5;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
