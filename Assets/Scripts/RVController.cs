using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

[System.Serializable]
public class AxleInfo {
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor;
    public bool steering;
}

public class RVController : MonoBehaviour {

    bool controlEnabled = true;

    public List<AxleInfo> axleInfos; 
    public float maxMotorTorque;
    public float maxSteeringAngle;

    public float maxWheelSpeed;
    public bool enableFastStop;
    public WinPanel winPanel;
     
    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0) {
            return;
        }
     
        Transform visualWheel = collider.transform.GetChild(0);
     
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
     
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
     
    public void FixedUpdate()
    {
        float xAxis     = controlEnabled ? Input.GetAxis("Horizontal")  : 0;
        float yAxis     = controlEnabled ? Input.GetAxis("Vertical")    : 0;
        float steering  = maxSteeringAngle  * xAxis;
        float motorInput= maxMotorTorque    * yAxis;
        //float motorInput= Mathf.Min(maxMotorTorque    * yAxis, maxWheelSpeed);
     
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                float motorVal = motorInput;


                axleInfo.leftWheel.motorTorque = motorInput;
                axleInfo.rightWheel.motorTorque = motorInput;

            }
            
            if (enableFastStop) {
                if (yAxis == 0) {

                    axleInfo.leftWheel.brakeTorque  = 500000;
                    axleInfo.rightWheel.brakeTorque = 500000;
                    // If the player isn't inputting, we slow down quickly
                    Debug.Log("Stopping");
                } else {
                    
                    axleInfo.leftWheel.brakeTorque = 0;
                    axleInfo.rightWheel.brakeTorque = 0;
                }
            }

            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "obstacle") {
			//TODO the fun effects
		}
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Goal") {
            Debug.Log("You did it!");
            controlEnabled = false;
            StartCoroutine(FinishLevel());
        }
    }

    IEnumerator FinishLevel() {

        WinPanel winPanelInst = GameObject.Instantiate(winPanel, GameObject.Find("Canvas").transform);
        winPanelInst.MovePanelOntoScreen();
        
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main");
    }
}
