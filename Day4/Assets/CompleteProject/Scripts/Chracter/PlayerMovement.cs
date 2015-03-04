

using UnityEngine;
using System;
using System.Collections;
  


namespace CompleteProject
{
	[RequireComponent(typeof(Animator))]  
	public class PlayerMovement: MonoBehaviour {
		
		protected Animator avatar;
		protected PlayerAttack playerAttack;
		public float rotateSpeed = 1.0F;
		public float speed = 3.0F;
		public float DirectionDampTime = .25f;//rotate
		public bool useCurves;	//jump

		float lastAttackTime, lastSkillTime, lastDashTime;
		public bool attacking = false;
		public bool dashing = false;

		private AnimatorStateInfo currentBaseState;	
		private CapsuleCollider col;	// a reference to the current state of the animator, used for base layer

		static int jumpState = Animator.StringToHash("Base Layer.BG_Jump_Front");
		static int attack01State = Animator.StringToHash("Base Layer.BG_Attack01");

		void Start () 
		{
			avatar = GetComponent<Animator>();
			playerAttack = GetComponent<PlayerAttack>();
		}
	    
		
		float h, v;


		public void OnStickChanged(float distance, Vector2 stickPos)
		{
			h = stickPos.x;
			v = stickPos.y;
		}

		public void OnAttackDown()
		{
			attacking = true;
			avatar.SetBool("Combo", true);
			StartCoroutine(StartAttack());

		}

		public void OnAttackUp()
		{
			avatar.SetBool("Combo", false);
			attacking = false;
		}

		IEnumerator StartAttack()
		{
			if(Time.time - lastAttackTime> 1f){
				lastAttackTime = Time.time;
				while(attacking){
					avatar.SetTrigger("AttackStart");
					playerAttack.NormalAttack();
					yield return new WaitForSeconds(1f);
				}
			}

		}

		public void OnSkillDown()
		{

			if(Time.time - lastSkillTime > 2f)
			{
				avatar.SetBool("Skill", true);
				lastSkillTime = Time.time;
				playerAttack.SkillAttack();
			}

		}

		public void OnSkillUp()
		{
			avatar.SetBool("Skill", false);
		}

		public void OnDashDown ()
		{

			if(Time.time - lastDashTime > 2f){

				lastDashTime = Time.time;
				dashing = true;
				avatar.SetTrigger("Dash");
				playerAttack.DashAttack();

			}

		}
		
		public void OnDashUp ()
		{
			dashing = false;
		}

		void Update () 
		{
			currentBaseState = avatar.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation

			
			if(avatar)
			{
				bool k = Input.GetButton("Jump");

				float back = 1f;

				if(v<0f) back = -1f;

				avatar.SetFloat("Speed",back * (h*h+v*v));
				avatar.SetFloat("Direction", back * (Mathf.Atan2(h,v) * 180.0f / 3.14159f) );
	            avatar.SetBool("Jump", k);

			    Rigidbody rigidbody = GetComponent<Rigidbody>();

	            if(rigidbody)
	            {
	                Vector3 speed = rigidbody.velocity;
	                speed.x = 4 * h;
	                speed.z = 4 * v;
	                rigidbody.velocity = speed;
					transform.Rotate(0, h * rotateSpeed, 0);//rotate

					 if(currentBaseState.nameHash == jumpState)
					{
						//  ..and not still in transition..
						if(!avatar.IsInTransition(0))
						{
							if(useCurves)
								// ..set the collider height to a float curve in the clip called ColliderHeight
								col.height = avatar.GetFloat("ColliderHeight");
							
							// reset the Jump bool so we can jump again, and so that the state does not loop 
							avatar.SetBool("Jump", false);
						}
						
						// Raycast down from the center of the character.. 
						Ray ray = new Ray(transform.position + Vector3.up, -Vector3.up);
						RaycastHit hitInfo = new RaycastHit();
						
						if (Physics.Raycast(ray, out hitInfo))
						{
							// ..if distance to the ground is more than 1.75, use Match Target
							if (hitInfo.distance > 1.75f)
							{
								
								// MatchTarget allows us to take over animation and smoothly transition our character towards a location - the hit point from the ray.
								// Here we're telling the Root of the character to only be influenced on the Y axis (MatchTargetWeightMask) and only occur between 0.35 and 0.5
								// of the timeline of our animation clip
								avatar.MatchTarget(hitInfo.point, Quaternion.identity, AvatarTarget.Root, new MatchTargetWeightMask(new Vector3(0, 1, 0), 0), 0.35f, 0.5f);
							}
						}
					}


	            }
			
			}		
		}



		
	}
}