using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoalCollider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollision (Collider hitObj)
    {
		if (hitObj.gameObject.tag.Equals("Player") == true)
		{
			SceneManager.LoadScene("Main");
		}
	}

    private void OnTriggerEnter(Collider other)
    {

    }
}
