using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField] private float rotatingPeriod = 100f;
    [SerializeField] private Transform CoinMesh;

	public AudioClip audioClip;

	void Start() {
        
    }

    void Update() {
		CoinMesh.Rotate(0, rotatingPeriod * Time.deltaTime, 0);
    }

	private void OnTriggerEnter(Collider other) {
		Player player = other.gameObject.GetComponent<Player>();

		if (player) {
			player.PickUp();
			AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);

			Destroy(gameObject);

		}
	}

}
