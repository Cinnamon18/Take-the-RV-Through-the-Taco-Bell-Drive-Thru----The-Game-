using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{

    public WheelCollider wheelCollider;

    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = transform.rotation * Quaternion.AngleAxis(wheelCollider.steerAngle + 5, Vector3.up);
    }
}
