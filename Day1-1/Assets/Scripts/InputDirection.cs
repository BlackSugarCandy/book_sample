﻿using UnityEngine;
using System.Collections;

public class InputDirection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPress(bool _pressed)
	{
		if(_pressed){
			InputController.Instance.ButtonDown();
		}else{
			InputController.Instance.ButtonUp();
		}


	}
}
