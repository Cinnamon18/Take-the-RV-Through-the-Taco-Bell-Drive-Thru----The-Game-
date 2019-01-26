using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RVController : MonoBehaviour
{

    public float maxSpeed;
    public float maxAcceleration;
    public float turnRate;

    Rigidbody rigidbody;
    float mass;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        mass = rigidbody.mass;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if (xAxis != 0) {

        }
        if (yAxis != 0) {
            Vector3 forwardForce = transform.forward * Time.deltaTime * maxAcceleration * yAxis * mass;
            Debug.Log(forwardForce);
            rigidbody.AddForce(forwardForce);

            if (rigidbody.velocity.magnitude > maxSpeed) {
                rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;// new Vector3();
            }
        }
        
    }

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "obstacle") {
			//TODO the fun effects
		}
	}
}
