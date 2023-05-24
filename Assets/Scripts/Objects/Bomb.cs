using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {

	[SerializeField] private float rotatingPeriod = 100f;
	[SerializeField] private Transform BombMesh;

	public AudioClip audioClip;

	void Start() {

	}

    void Update() {
		BombMesh.Rotate(0, rotatingPeriod * Time.deltaTime, 0);
	}

	private void OnTriggerEnter(Collider other) {

	}

	private void OnCollisionEnter(Collision collision) {

		Player player = collision.gameObject.GetComponent<Player>();

		if (player) {
			player.Explode(1, player.gameObject.transform.position - transform.position);
			AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);

			Destroy(gameObject);

		}
	}

}
