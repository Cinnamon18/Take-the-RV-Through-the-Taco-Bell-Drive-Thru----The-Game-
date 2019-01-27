using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceGravityController : MonoBehaviour
{

    public bool useSpaceGravity;
    public float gravityStrength;
    Rigidbody rigidbody;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    float awayFromGroundTime = 0;
    bool awayFromGround = false;
    public float timeBeforeFailAfterOffCourse = 3;
    void Update() {
        if (awayFromGround) {
            awayFromGroundTime += Time.deltaTime;

            if (awayFromGroundTime > timeBeforeFailAfterOffCourse) {
                // Game Over
                GameObject.FindObjectOfType<Timer>().GameOver();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (useSpaceGravity) {

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.up * -1, out hit, 10f)) {
                // ground found below;
                Debug.DrawRay(transform.position, transform.up * -1 * hit.distance, Color.yellow);
                Physics.gravity = hit.normal * -1;
                awayFromGround = false;
                awayFromGroundTime = 0;
            }

            //transform.position += Vector3.down * 2 * Time.deltaTime;
            //rigidbody.AddForce(Vector3.down * rigidbody.mass * gravityStrength);
        }
    }
}
