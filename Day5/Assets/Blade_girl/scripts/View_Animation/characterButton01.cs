using UnityEngine;
using System.Collections;

public class characterButton01 : MonoBehaviour {

	public GameObject frog;
	public GameObject GUI01;
	public GameObject GUI02;
	public GUISkin customSkin;

	
	
	private Rect FpsRect ;
	private string frpString;


	

	void Start () 
	{
	
			}
	
 void OnGUI() 
	{
		GUI.skin = customSkin;

		GUI.Box (new Rect (0, 0, 880, 156),"");
		
		if (GUI.Button(new Rect(30, 20, 70, 30),"Jump01")){
		 frog.animation.wrapMode= WrapMode.Loop;
		  	frog.animation.CrossFade("BG_Jump01");
	  }
		if (GUI.Button(new Rect(105, 20, 70, 30),"JumpAttack")){
		 frog.animation.wrapMode= WrapMode.Loop;
		  	frog.animation.CrossFade("BG_JumpAttack");
	  }

		if (GUI.Button(new Rect(180, 20, 70, 30),"Sliding")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Sliding");
		}

		if (GUI.Button(new Rect(255, 20, 70, 30),"Sleep")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Sleep");
		}
		if (GUI.Button(new Rect(330, 20, 70, 30),"Stun")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Stun");
		}


		if (GUI.Button(new Rect(405, 20, 70, 30),"Down")){
		 frog.animation.wrapMode= WrapMode.Once;
		  	frog.animation.CrossFade("BG_Down");
	  }

		if (GUI.Button(new Rect(480, 20, 70, 30),"Up")){
			frog.animation.wrapMode= WrapMode.Once;
			frog.animation.CrossFade("BG_Up");
		}

		if (GUI.Button(new Rect(555, 20, 70, 30),"PickUp")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Pickup");
		}

		if (GUI.Button(new Rect(630, 20, 70, 30),"Damage")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Damage");
		}

		

		if (GUI.Button(new Rect(705, 20, 70, 30),"Death")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Death");
		}

		if (GUI.Button(new Rect(780, 20, 70, 30),"GangnamStyle")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_GangnamStyle");
		}

		//--------------------------------------------------------------

		if (GUI.Button(new Rect(790, 160, 30, 30),"1")){

			GUI01.SetActive(true);
			GUI02.SetActive(false);

		}

		if (GUI.Button(new Rect(825, 160, 30, 30),"2")){

			GUI01.SetActive(false);
			GUI02.SetActive(true);
			
		}


	    
				if (GUI.Button (new Rect (20, 580, 140, 40), "Ver 2.6")) {
						frog.animation.wrapMode = WrapMode.Loop;
						frog.animation.CrossFade ("BG_Idle");
				}

	
		
 }
	
	// Update is called once per frame
	void Update () 
	{
		
	
	if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

	}





	
}
