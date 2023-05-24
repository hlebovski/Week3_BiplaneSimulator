using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {

	[SerializeField] EverythingManager EverythingManager;
	[SerializeField] Transform Biplane;
	[SerializeField] Transform Propeller;

	[SerializeField] float forwardVelocity;
	[SerializeField] float upliftForce;
	[SerializeField] float angularVelocity;

	AudioSource audioSource;
	Rigidbody rigid;

	public AudioClip audioClip;
	public static int Health = 5;
	private bool _isDestroyed = false;
	private bool _isAudioActive = false;
	private bool _isUpsideDown;
	private float _angle;
	

	void Start() {
		rigid = GetComponent<Rigidbody>();
		audioSource= GetComponent<AudioSource>();
		_isDestroyed = false;
	}

	private void Update() {
		if (!_isDestroyed) {
			if (Input.GetKeyDown(KeyCode.Q)) _isUpsideDown = !_isUpsideDown;
			if (Input.GetKeyDown(KeyCode.E)) _isUpsideDown = !_isUpsideDown;
		}

		if (_isUpsideDown) {
			_angle = Mathf.MoveTowardsAngle(_angle, 180f, Time.deltaTime * 360f);
		} else {
			_angle = Mathf.MoveTowardsAngle(_angle, 0f, Time.deltaTime * 360f);
		}
		
		Biplane.localEulerAngles = new Vector3(_angle, 0f, 0f);

	}

	private void FixedUpdate() {

		float speedValue = Input.GetAxis("Vertical");
		float rotationValue = Input.GetAxis("Horizontal");

		if (!_isDestroyed) {

			if (speedValue > 0) {

				PlayAudio();
				Propeller.Rotate(0f, 0f, 75f * speedValue);

				Vector3 forwardForce = Vector3.right * speedValue * forwardVelocity;

				Vector3 liftUp;
				if (_isUpsideDown) {
					liftUp = Vector3.down * speedValue * forwardVelocity * upliftForce;
				} else { liftUp = Vector3.up * speedValue * forwardVelocity * upliftForce; }

				rigid.AddRelativeForce(forwardForce + liftUp, ForceMode.VelocityChange);
			} else {
				Propeller.Rotate(0f, 0f, 3f);
				DecreaseAudio();
			}

			float rotationResistance = Mathf.Clamp(1.1f - rigid.velocity.magnitude / 70, 0.5f, 1f);
			rigid.AddTorque(0f, 0f, -rotationValue * angularVelocity * rotationResistance, ForceMode.VelocityChange);
		} else {
			StopAudio();
		}
	}


	void PlayAudio() {
		if(!_isAudioActive) {
			_isAudioActive = true;
			audioSource.volume = 0.03f;
			audioSource.pitch = 1.0f;
			audioSource.Play();
		}
	}

	void DecreaseAudio() {
		if (_isAudioActive) {
			_isAudioActive = false;
			audioSource.volume = 0.02f;
			audioSource.pitch = 0.62f;
		}
	}

	void StopAudio() {
		if (_isAudioActive) {
			_isAudioActive = false;
			audioSource.Stop();
		}
	}


	public void Hit(int damage) {

		if (Health > 0) {
			Health -= damage;
			if (Health <= 0) {
				Health = 0;
				_isDestroyed = true;
				AudioSource.PlayClipAtPoint(audioClip, gameObject.transform.position);
			}
		}
	}

	public void Heal(int ammount) {
		Health += ammount;
	}

	public void Explode(int damage, Vector3 position) {

		Hit(damage);
		rigid.AddForceAtPosition(position * 200f * damage, transform.position);
		rigid.AddTorque(0f, 0f, 5f * damage, ForceMode.VelocityChange);
	}

	public void PickUp() {
		EverythingManager.PickUpCoin();
	}

	private void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "Ground") {
			if (collision.relativeVelocity.y > 15) Hit(1);
		}
		
	}

	private void OnTriggerEnter(Collider other) {

	}



}
