using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	[SerializeField] Transform rocketTarget;
	[SerializeField] float rocketSpeed = 10f;

	public AudioClip audioClip;

	void Start() {
		
	}

    void Update() {
		transform.LookAt(rocketTarget);
		transform.position = Vector3.MoveTowards(transform.position, rocketTarget.position, rocketSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter(Collider other) {

	}

	private void OnCollisionEnter(Collision collision) {

		Player player = collision.gameObject.GetComponent<Player>();

		if (player) {
			player.Explode(2, player.gameObject.transform.position - transform.position);
		} else {
			Destroy(collision.gameObject);
		}
		AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
		Destroy(transform.gameObject);

	}

}
