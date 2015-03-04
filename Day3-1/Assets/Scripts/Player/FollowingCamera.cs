using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour
{
	public float distanceAway;			
	public float distanceUp;			
	public float smooth;				
	
	private GameObject hovercraft;		
	private Vector3 targetPosition;		
	
	public Transform follow;
	
	void Start(){

	}
	
	void LateUpdate ()
	{

		transform.position = follow.position + Vector3.up * distanceUp - Vector3.forward * distanceAway;
	}
}
