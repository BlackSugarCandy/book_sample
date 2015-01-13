using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))] 
public class CtrlCharacter : MonoBehaviour {

	protected Animator avatar;

	public float speedWalk = 5.0f;
	public float speedRun = 10.0f;
	public float speedRotate = 50.0f;


	float axisV,axisH;
	float move,rotate;

	public bool isMove, isRun, isAttack;//애니메이터 파라미터에 전달할 값



	// Use this for initialization
	void Start () {

		avatar = GetComponent<Animator>();

	}
	
	// Update is called once per frames
	void Update () {

		GetInput ();

		SetTransform ();
		SetAnimation ();

	
	}

	void GetInput(){
		axisH = InputController.Instance.x;
		axisV = InputController.Instance.y;

		isAttack = InputController.Instance.attack;

		//axisV = Input.GetAxis ("Vertical");
		//axisH = Input.GetAxis ("Horizontal");
		
		
		if (axisV*axisV + axisH*axisH > 0) {
			isMove = true;
		} else {
			isMove = false;
		}

		//isRun = Input.GetKey (KeyCode.LeftShift);
	}


	//캐릭터의 위치와 회전을 변경하는 함수
	void SetTransform(){

		//if (isRun) {
			move = axisV * speedRun * Time.deltaTime;
		/*} else {
			move = axisV * speedWalk * Time.deltaTime * 0.5f;
		}*/

		rotate = axisH * speedRotate * Time.deltaTime;


		transform.Translate (Vector3.forward * move);
		transform.Rotate(Vector3.up * rotate);

	}

	void SetAnimation(){

		avatar.SetBool("move",	isMove);
		avatar.SetBool("run",	isRun);
		avatar.SetBool("attack", isAttack);


	}
}

	

