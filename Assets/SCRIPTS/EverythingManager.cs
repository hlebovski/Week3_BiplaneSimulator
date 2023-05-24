using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EverythingManager : MonoBehaviour {

	[SerializeField] int CoinCount;
	[SerializeField] int BombCount;
	[SerializeField] int SupplyCount;
	[SerializeField] int HealthPoints;

	[SerializeField] int BoundX;
	[SerializeField] int BoundY;
	[SerializeField] int BoundGround;

	public GameObject CoinPrefab;
	public GameObject BombPrefab;
	public GameObject SupplyPrefab;

	public Text UICoinCount;
	public Text UIHealthCount;
	public Text UIMessage;

	private int CollectedCoin = 0;
	private float Step = 10f;
	public Vector3Int SpawnPosition = new Vector3Int(0, 20 ,0);

	void Start() {

	}

	private void Awake() {
		SpawnPlayer();
		SpawnCoins();
		SpawnBombs();
		SpawnSupply();
	}

	void Update() {

		UICoinCount.text = CollectedCoin.ToString();
		UIHealthCount.text = Player.Health.ToString();

		if (Player.Health <= 0) GameOver();

	}

	public void PickUpCoin() {
		CollectedCoin++;
		if (CollectedCoin>= CoinCount + 15) {
			Win();
		}

	}


	public void Win() {
			UIMessage.text = "You win!";
			Invoke("Restart", 3f);
	}
	public void GameOver() {
		UIMessage.text = "Game over";
		Invoke("Restart", 3f);
	}

	public void Restart() {
		CollectedCoin = 0;
		Player.Health = HealthPoints;
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}




	public void SpawnPlayer() {
		Player player = FindObjectOfType<Player>();
		player.GetComponent<Transform>().position = SpawnPosition;
	}
	private void SpawnCoins() {
		for (int i = 0; i < CoinCount; i++) {
			GameObject newCoin = Instantiate(CoinPrefab, new Vector3(Random.Range(-BoundX, BoundX) * Step, Random.Range(BoundGround, BoundY) * Step, 0f), transform.rotation);
		}
	}
	private void SpawnBombs() {
		for (int i = 0; i < BombCount; i++) {
			GameObject newBomb = Instantiate(BombPrefab, new Vector3(Random.Range(-BoundX, BoundX) * Step, Random.Range(BoundGround, BoundY) * 7f, 0f), transform.rotation);
		}
	}
	private void SpawnSupply() {
		for (int i = 0; i < SupplyCount; i++) {
			GameObject newSupply = Instantiate(SupplyPrefab, new Vector3(Random.Range(-BoundX, BoundX) * (Step + 1f), Random.Range(BoundGround, BoundY) * (Step + 1f), 0f), transform.rotation);
		}
	}

}
