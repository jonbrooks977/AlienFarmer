using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {
	
	public int roundCount = 0;
	public int enemiesRemaining = 10;
	
	[SerializeField]
	private Text textNotice;
	
	[SerializeField]
	private int roundTimer;
	
	[SerializeField]
	private GameObject[] enemySpawns;
	
	private int enemiesPerSpawner;

	void Start()
	{
		roundCount++;
		StartCoroutine(RoundCountdown());
	}
	
	public void DoStart()
	{
		roundCount++;
		StartCoroutine(RoundCountdown());
	}
	
	IEnumerator RoundCountdown()
	{
		textNotice.text = "Round " + roundCount + " starting in 5 seconds!";
		enemiesRemaining = roundCount * 10;
		enemiesPerSpawner = enemiesRemaining / enemySpawns.Length;
		Debug.Log("Starting RoundCountdown. Wait 5 Seconds.");
		yield return new WaitForSeconds(5);
		StartRound();
		textNotice.text = "Round "+ roundCount + " has begun!";
		yield return new WaitForSeconds(2);
		textNotice.text = null;
	}
	
	void StartRound()
	{
		Debug.Log("Round Started with " + enemiesRemaining + " enemies.");
		for (int i = 0; i < enemySpawns.Length; i++)
        {
			//Debug.Log("Enemies Spawning.");
            enemySpawns[i].GetComponent<spawnHandler>().Spawn(enemiesPerSpawner);
        }
	}
	
	
}
