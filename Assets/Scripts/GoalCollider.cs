using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalCollider : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter (Collider hitObj)
    {
		if (hitObj.gameObject.tag == "Player")
		{
			StartCoroutine(SceneTransition.LoadScene(0));
		}
	}

}
