using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour {

	public Transform player;
	private UnityEngine.AI.NavMeshAgent agent;
	private GameObject manager;
	
	public int enemyHealth;
       
    void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
		player = GameObject.FindWithTag("Player").transform;
		manager = GameObject.FindWithTag("manager");
		enemyHealth = 20 + Mathf.RoundToInt(manager.GetComponent<gameManager>().roundCount * 1.5f);
		
    }
	void Update () 
	{
		agent.destination = player.position; 
	}
	
	public void ApplyDamage(int damage)
	{
		Debug.Log(damage + ": Damage " + "Health: " + enemyHealth);
		enemyHealth -= damage;
		
		if(enemyHealth <= 0)
		{
			Destroy(gameObject);
			Debug.Log("Enemy Killed.");
			manager.GetComponent<gameManager>().enemiesRemaining -= 1;
			
			if (manager.GetComponent<gameManager>().enemiesRemaining == 0)
			{
				manager.GetComponent<gameManager>().DoStart();
			}
		}
		player.GetComponent<playerMain>().score += 10;
	}
}
