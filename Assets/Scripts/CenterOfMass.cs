using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMass : MonoBehaviour {

	public Transform CenterOfMassTransform;

	private void Awake() {
			GetComponent<Rigidbody>().centerOfMass = Vector3.Scale(CenterOfMassTransform.localPosition, transform.localScale);
	}

	void Update() {
        
    }

}
