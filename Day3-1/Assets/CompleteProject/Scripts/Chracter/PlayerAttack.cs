using UnityEngine;
using System.Collections;
using System;

namespace CompleteProject
{
	public class PlayerAttack : MonoBehaviour {

		public int NormalDamage = 10;
		public int SkillDamage = 30;
		public int DashDamage = 30;

		public NormalTarget normalTarget;
		public SkillTarget skillTarget;

		public void NormalAttack()
		{
			Debug.Log ("NormalAttack");

			foreach(Collider one in normalTarget.targetList){
				try{
					EnemyHealth enemy = one.GetComponent<EnemyHealth>();

					if(enemy != null){
						
						StartCoroutine(enemy.StartDamage(NormalDamage, transform.position, 0.5f, 0.5f));

					}
				}catch(MissingReferenceException e)
				{
					normalTarget.targetList.Remove(one);
				}
			}

		}

		public void DashAttack()
		{
			Debug.Log ("DashAttack");
			
			foreach(Collider one in skillTarget.targetList){
				try{
					EnemyHealth enemy = one.GetComponent<EnemyHealth>();
					
					if(enemy != null){
						
						StartCoroutine(enemy.StartDamage(DashDamage, transform.position, 1f, 2f));
						
					}
				}catch(MissingReferenceException e)
				{
					skillTarget.targetList.Remove(one);
				}
			}
		}


		public void SkillAttack()
		{
			Debug.Log ("SkillAttack");
			
			foreach(Collider one in skillTarget.targetList){
				try{
					EnemyHealth enemy = one.GetComponent<EnemyHealth>();
					
					if(enemy != null){

						StartCoroutine(enemy.StartDamage(SkillDamage, transform.position, 1f, 2f));

					}
				}catch(MissingReferenceException e)
				{
					skillTarget.targetList.Remove(one);
				}
			}
		}
	}

}