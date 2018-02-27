using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnHandler : MonoBehaviour {
	
	[SerializeField]
	private GameObject enemyPrefab;

	public void Spawn (int enemyCount) 
	{
		for (int i = 0; i < enemyCount; i++)
        {
			int randomBuffer = (Random.Range(5, 10));
			StartCoroutine(WaitThenSpawn(randomBuffer));
		}
	}
	
	IEnumerator WaitThenSpawn(int buffer)
	{
		yield return new WaitForSeconds(buffer);
		Instantiate(enemyPrefab, transform.position, Quaternion.identity);
	}
}
