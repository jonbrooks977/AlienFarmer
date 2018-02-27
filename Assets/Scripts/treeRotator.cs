using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeRotator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.rotation *= Quaternion.Euler(0, Random.Range(-45,45), 0);
	}
}
