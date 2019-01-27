using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CollisionTypes;
using System;
using UnityEngine.Rendering.PostProcessing;

[System.Serializable]
public class AxleInfo {
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor;
	public bool steering;
}

public class RVController : MonoBehaviour {

    public float debugLimit;

	public List<AxleInfo> axleInfos;
	public float maxMotorTorque;
	public float maxSteeringAngle;

	public float maxWheelSpeed;
	public bool enableFastStop;

    private RVVFX vfx;

	private CollisionDetector collDetect;
	public AnimationCurve drivingBadnessDecay;
	public float drivingBadness; //Scales from 0 to 100;

	private GameObject mainCamera;

	Bloom bloom;
	ChromaticAberration ca;
	Grain grain;
	MotionBlur motionBlur;
	Vignette vin;

	void Awake() {
		mainCamera = GameObject.FindWithTag("MainCamera");
		// somewhere during initializing
		PostProcessVolume volume = mainCamera.GetComponent<PostProcessVolume>();
		volume.profile.TryGetSettings<Bloom>(out bloom);
		volume.profile.TryGetSettings<ChromaticAberration>(out ca);
		volume.profile.TryGetSettings<Grain>(out grain);
		volume.profile.TryGetSettings<MotionBlur>(out motionBlur);
		volume.profile.TryGetSettings<Vignette>(out vin);
	}

	void Start() {
		collDetect = new CollisionDetector(this);
        vfx = GetComponentInChildren<RVVFX>();
	}

	void Update() {
		drivingBadness -= Time.deltaTime * drivingBadnessDecay.Evaluate(drivingBadness);
		drivingBadness = Math.Max(0, drivingBadness);

		messWithPP();
	}

	// finds the corresponding visual wheel
	// correctly applies the transform
	public void ApplyLocalPositionToVisuals(WheelCollider collider) {
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

	public void FixedUpdate() {

		float xAxis;
		float yAxis;

        if (GameObject.FindGameObjectWithTag("goal").GetComponent<GoalCollider>().Won() || !GameObject.FindObjectOfType<Timer>().hasTime)
        {
            xAxis = 0;
            yAxis = 0;
        }
        else
        {

            xAxis = Input.GetAxis("Horizontal");
            yAxis = Input.GetAxis("Vertical");
        }

        float steering = maxSteeringAngle * xAxis;
		float motorInput = maxMotorTorque * yAxis;
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

					axleInfo.leftWheel.brakeTorque = 500000;
					axleInfo.rightWheel.brakeTorque = 500000;
					// If the player isn't inputting, we slow down quickly
				} else {

					axleInfo.leftWheel.brakeTorque = 0;
					axleInfo.rightWheel.brakeTorque = 0;
				}
			}

			ApplyLocalPositionToVisuals(axleInfo.leftWheel);
			ApplyLocalPositionToVisuals(axleInfo.rightWheel);
		}

		if (Input.GetKeyDown(KeyCode.P)) {
			InputManager.ToggleControllerInputEnabled();
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "obstacle") {
			CollisionType colType = collDetect.getCollisionType(collision);
			drivingBadness += colType.collBadness;
			Audio.playSfx(colType.getRandomSfx());

			TextBubbleSpwnScrn dialogCanvas = GameObject.FindObjectOfType<TextBubbleSpwnScrn>();
			dialogCanvas.SpawnDialogsAccordingToBadnessMeter(drivingBadness, colType);
		}
	}

	void messWithPP() {
		// Debug.Log(drivingBadness);
		bloom.intensity.value = 7.5f + (drivingBadness / 12f);
		ca.intensity.value = 0.1f + (drivingBadness / 80);
		grain.intensity.value = 0f + (drivingBadness / 140);
		grain.size.value = 0.3f + (drivingBadness / 50);
		motionBlur.shutterAngle.value = 0f + (drivingBadness * 1.5f);
		vin.intensity.value = 0f + (drivingBadness / 180);

	}
}
