using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	[SerializeField] private float _rotationSpeed = 100f;

	void Update() {
		transform.Rotate(transform.up, _rotationSpeed * Time.deltaTime);
	}

}
