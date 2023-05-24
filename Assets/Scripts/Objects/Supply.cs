using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : MonoBehaviour {

	[SerializeField] private float rotatingPeriod = 100f;
	[SerializeField] private Transform SupplyMesh;

	public AudioClip audioClip;

	void Start() {

	}

	void Update() {
		SupplyMesh.Rotate(0, rotatingPeriod * Time.deltaTime, 0);
	}

	private void OnTriggerEnter(Collider other) {

	}

	private void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "Ground") rotatingPeriod = 0;

		Player player = collision.gameObject.GetComponent<Player>();
		if (player) {
			player.Heal(1);
			AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);

			Destroy(gameObject);

		}
	}

}
