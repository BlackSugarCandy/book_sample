using UnityEngine;
using System.Collections;

namespace CompleteProject
{
	public class EnemyMove : MonoBehaviour {
		
		Transform player;
		NavMeshAgent nav;

		void Awake () {
			
			player = GameObject.FindGameObjectWithTag ("Player").transform;
			nav = GetComponent <NavMeshAgent> ();

		}
		
		void Update () {
			if(nav.enabled){
				nav.SetDestination (player.position);
			}
		}

	}

}