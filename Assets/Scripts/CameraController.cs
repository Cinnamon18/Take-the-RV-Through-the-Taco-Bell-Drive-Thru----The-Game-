﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform targetToFollow;

    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        targetToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetToFollow.rotation, .5f);
    }

    private void LateUpdate()
    {
        float dt = 60f * Time.deltaTime;
        transform.position = Vector3.Lerp(transform.position, targetToFollow.position, dt * followSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetToFollow.rotation, dt * .05f);
    }
}
