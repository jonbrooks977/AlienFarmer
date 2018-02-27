using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMain : MonoBehaviour 
{
	private int ammo = 100;
	public int health;
	public int score;
	
	[SerializeField]
	private Text textScore;
	
	[SerializeField]
	private Text textAmmo;
	
	[SerializeField]
	private Text textHealth;
	
	float damage = 10;
	RaycastHit hit;
	bool allowFire = true;
	
	IEnumerator WaitShoot()
	{
		allowFire = false;		
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		
		if ((Physics.Raycast(Camera.main.transform.position, transform.TransformDirection (Vector3.forward), out hit, 50))) 
		{
			ammo--;
			hit.transform.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
		yield return new WaitForSeconds(0.05f);
		allowFire = true;
	}
 
	void Update ()
	{
		
		textAmmo.text = "Ammo: " + ammo;
		textScore.text = "Points: " + score;
		textHealth.text = "Health: " + health;
     
		if ((Input.GetMouseButton(0)) && (ammo != 0) && allowFire)
		{
			StartCoroutine(WaitShoot());
		}
		
		if (Input.GetKeyDown("e"))
		{
				if ((Physics.Raycast(Camera.main.transform.position, transform.TransformDirection (Vector3.forward), out hit, 10))) 
				{
					string hitTag = hit.transform.tag;
					switch	(hitTag)
					{
						/*case "shotgun":
							score -= 200;
							ammo = 50;
							damage = 50;
							ChangeModel(hitTag);
							break;*/
							
						case "rifle":
							
							if(score >= 500)
								score -= 500;
							
							ammo = 100;
							damage = 5;
							ChangeModel(hitTag);
							break;	
							
						case "pistol":
							if(score >= 100)
								score -= 100;
							ammo = 50;
							damage = 15;
							ChangeModel(hitTag);
							break;	
					}
				}
		}
     
	}
	
	void ChangeModel(string weapon)
	{
	}
	
	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "stopper")
		{
			other.gameObject.SetActive(false);
			StartCoroutine(reactivate(other));
		}
	}

	IEnumerator reactivate(Collider other)
	{
		yield return new WaitForSeconds(2);
		other.gameObject.SetActive(true);
	}
}
