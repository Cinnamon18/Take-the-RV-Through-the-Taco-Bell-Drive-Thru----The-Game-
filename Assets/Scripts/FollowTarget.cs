using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform targetToFollow;

    // Start is called before the first frame update
    void Start()
    {
        targetToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetToFollow.position;
        //transform.rotation = targetToFollow.rotation;
    }
}
