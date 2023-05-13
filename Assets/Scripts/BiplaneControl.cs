using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class BiplaneControl : MonoBehaviour {

	private Rigidbody _biplaneRigid;

	[SerializeField] float forwardSpeed;
	[SerializeField] float rotationSpeed;

	[SerializeField] private float _collectedCoins;

	void Awake() {
		_biplaneRigid = GetComponent<Rigidbody>();
		//_BiplaneBody.maxAngularVelocity = 20f;
	}


	void Update() {
		
	}

	void FixedUpdate() {

		AddForce();
		Rotate();

		//bool isEngineActive = Input.GetAxis("Vertical") > 0;

	}

	private void AddForce() {
		float speedValue = Input.GetAxis("Vertical");

		if (speedValue > 0) {
			Vector3 forwardForce = Vector3.forward * speedValue * forwardSpeed * Time.fixedDeltaTime;
			Vector3 liftForce = Vector3.up * speedValue * forwardSpeed / 3.2f * Time.fixedDeltaTime;
			_biplaneRigid.AddRelativeForce(forwardForce + liftForce, ForceMode.VelocityChange);
		}

	}

	private void Rotate() {
		float rotationValue = Input.GetAxis("Horizontal");
		//if (rotationValue !=0 ) {
			_biplaneRigid.AddRelativeTorque(Vector3.right * rotationValue * rotationSpeed * Time.fixedDeltaTime);
		//}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Coin>()) {
			_collectedCoins++;
			Destroy(other.gameObject);
		} else if (other.gameObject.GetComponent<Bomb>()) {
			Destroy(other.gameObject);
		} else if (other.gameObject.GetComponent<Supply>()) {
			Destroy(other.gameObject);
		}
	}

}

