using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform playerTransform;
	private Vector3 _cameraPosition;

	public float YBoundaryValue;
	public float ZBoundaryValue;

	void Awake() {
		_cameraPosition.x = transform.position.x;
	}
    void Update() {

		if (playerTransform.position.y < YBoundaryValue & playerTransform.position.y > -YBoundaryValue) _cameraPosition.y = playerTransform.position.y;
		if (playerTransform.position.z < ZBoundaryValue & playerTransform.position.z > -ZBoundaryValue) _cameraPosition.z = playerTransform.position.z;

		transform.position = _cameraPosition;
	}
}
