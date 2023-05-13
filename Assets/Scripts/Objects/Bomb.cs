using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	[SerializeField] private float _rotationSpeed = 100f;

	void Update() {
		transform.Rotate(transform.up, _rotationSpeed * Time.deltaTime);
	}

}
