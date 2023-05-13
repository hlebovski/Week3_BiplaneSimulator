using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject CoinPrefab;
	public GameObject BombPrefab;
	public GameObject SupplyPrefab;
	private Vector3 SpawnCoinPosition;
	private Vector3 SpawnBombPosition;
	private Vector3 SpawnSupplyPosition;
	public int CoinCount;
	public int BombCount;
	public int SupplyCount;

	public float YBoundaryValue;
	public float ZBoundaryValue;

	void Awake() {
		SpawnCoins();
		SpawnBombs();
		SpawnSupply();
	}

    void Update()
    {

    }
	private void SpawnCoins() {
		for (int i = 0; i < CoinCount; i++) {
			SpawnCoinPosition = new Vector3(0f, Random.Range(-YBoundaryValue, YBoundaryValue), Random.Range(-ZBoundaryValue, ZBoundaryValue));
			GameObject newCoin = Instantiate(CoinPrefab, SpawnCoinPosition, CoinPrefab.transform.rotation);
		}

	}
	private void SpawnBombs() {
		for (int i = 0; i < BombCount; i++) {
			SpawnBombPosition = new Vector3(0f, Random.Range(-YBoundaryValue, YBoundaryValue), Random.Range(-ZBoundaryValue, ZBoundaryValue));
			GameObject newBomb = Instantiate(BombPrefab, SpawnBombPosition, transform.rotation);
		}
	}
	private void SpawnSupply() {
		for (int i = 0; i < SupplyCount; i++) {
			SpawnSupplyPosition = new Vector3(0f, Random.Range(-YBoundaryValue, YBoundaryValue), Random.Range(-ZBoundaryValue, ZBoundaryValue));
			GameObject newHealth = Instantiate(SupplyPrefab, SpawnSupplyPosition, transform.rotation);
		}
	}

}
