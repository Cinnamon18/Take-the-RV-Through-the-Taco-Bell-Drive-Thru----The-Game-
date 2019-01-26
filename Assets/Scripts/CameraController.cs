using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform targetToFollow;
    public float followSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, targetToFollow.position, Time.deltaTime * followSpeed);
        //transform.rotation = Quaternion.Lerp(transform.rotation, targetToFollow.rotation, .5f);
    }
}
