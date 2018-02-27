using UnityEngine;

public class Weapon
{
	public GameObject graphics;
	public int weaponDamage;
	public int maxAmmo;
	public weaponType type;
	
	public enum weaponType{
		shotgun,
		rifle,
		pistol
	}
}
