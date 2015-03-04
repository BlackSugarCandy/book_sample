using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NormalTarget : MonoBehaviour {

	public List<Collider> targetList;
	
	void Awake()
	{
		targetList = new List<Collider>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Normal Trigger Enter");
		targetList.Add(other);
	}
	
	void OnTriggerExit(Collider other)
	{
		Debug.Log ("Normal Trigger Exit");
		targetList.Remove(other);
	}

}
