using UnityEngine;
using System.Collections;

public class characterButton : MonoBehaviour {

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
		
		if (GUI.Button(new Rect(30, 20, 70, 30),"Idle")){
		 frog.animation.wrapMode= WrapMode.Loop;
		  	frog.animation.CrossFade("BG_Idle");
	  }
		if (GUI.Button(new Rect(105, 20, 70, 30),"Walk")){
		 frog.animation.wrapMode= WrapMode.Loop;
		  	frog.animation.CrossFade("BG_Walk");
	  }

		if (GUI.Button(new Rect(180, 20, 70, 30),"L_Walk")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_L_Walk");
		}

		if (GUI.Button(new Rect(255, 20, 70, 30),"R_Walk")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_R_Walk");
		}
		if (GUI.Button(new Rect(330, 20, 70, 30),"B_Walk")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_B_Walk");
		}


		if (GUI.Button(new Rect(405, 20, 70, 30),"Talk")){
		 frog.animation.wrapMode= WrapMode.Loop;
		  	frog.animation.CrossFade("BG_Talk");
	  }

		if (GUI.Button(new Rect(480, 20, 70, 30),"Talk01")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Talk01");
		}

		if (GUI.Button(new Rect(555, 20, 70, 30),"Run")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Run");
		}

		if (GUI.Button(new Rect(630, 20, 70, 30),"L_Run")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_L_Run");
		}

		
		if (GUI.Button(new Rect(705, 20, 70, 30),"R_Run")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_R_Run");

		}

		if (GUI.Button(new Rect(780, 20, 70, 30),"B_Run")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_B_Run");
		}

		if (GUI.Button(new Rect(30, 60, 70, 30),"Jump")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Jump");
		}

		if (GUI.Button(new Rect(105, 60, 70, 30),"DrawBlade")){
			frog.animation.wrapMode= WrapMode.Once;
			frog.animation.CrossFade("BG_DrawBlade");
		}

		if (GUI.Button(new Rect(180, 60, 70, 30),"PutBlade")){
			frog.animation.wrapMode= WrapMode.Once;
			frog.animation.CrossFade("BG_PutBlade");
		}
		if (GUI.Button(new Rect(255, 60, 70, 30),"AtkStandy")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_AttackStandy");
		}

		if (GUI.Button(new Rect(330, 60, 70, 30),"Attack00")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Attack00");
		}

		if (GUI.Button(new Rect(405, 60, 70, 30),"Attack01")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Attack01");
		}

		if (GUI.Button(new Rect(480, 60, 70, 30),"Block")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Block");
		}

		if (GUI.Button(new Rect(555, 60, 70, 30),"BlockAttack")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_BlockAttack");
		}

		if (GUI.Button(new Rect(630, 60, 70, 30),"Combo1_1")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Combo1_1");
		}

		if (GUI.Button(new Rect(705, 60, 70, 30),"Combo1_2")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Combo1_2");
		}

		if (GUI.Button(new Rect(780, 60, 70, 30),"Combo1_3")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Combo1_3");
		}

		if (GUI.Button(new Rect(30, 100, 70, 30),"Kick")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Kick");
		}

		if (GUI.Button(new Rect(105, 100, 70, 30),"Skill")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Skill");
		}

		if (GUI.Button(new Rect(180, 100, 70, 30),"M_Avoid")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_M_Avoid");
		}

		if (GUI.Button(new Rect(255, 100, 70, 30),"L_Avoid")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_L_Avoid");
		}

		if (GUI.Button(new Rect(330, 100, 70, 30),"R_Avoid")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_R_Avoid");
		}

		if (GUI.Button(new Rect(405, 100, 70, 30),"Buff")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Buff");
		}

		if (GUI.Button(new Rect(480, 100, 70, 30),"Run01")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_Run01");
		}

		if (GUI.Button(new Rect(555, 100, 70, 30),"RunAttack")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_RunAttack");
		}

		if (GUI.Button(new Rect(630, 100, 70, 30),"L_Run01")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_L_Run01");
		}

		if (GUI.Button(new Rect(705, 100, 70, 30),"R_Run01")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_R_Run01");
		}

		if (GUI.Button(new Rect(780, 100, 70, 30),"R_Run01")){
			frog.animation.wrapMode= WrapMode.Loop;
			frog.animation.CrossFade("BG_B_Run01");
		}
		//---------------------------------------------------------

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
