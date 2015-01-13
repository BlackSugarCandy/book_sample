﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class Stick : MonoBehaviour {

	#region Input-controller variables
	
	private RectTransform _button;

	private RectTransform _buttonFrame;
	
	private int _touchId = -1;

	private Vector3 _startPos = Vector3.zero;
		
	private float _dragRadius = 0.0f;

	private MineBot _player;

	private bool _buttonPressed = false;

	private static bool _isMoving = false;
	
	#endregion
		
	void Awake() {
		
	}
	
	// Use this for initialization
	void Start () {

		_player = GameObject.FindWithTag("Player").GetComponent<MineBot>();
		_button = this.transform.parent.FindChild("_stick").GetComponent<RectTransform>();
		_buttonFrame = this.transform.parent.FindChild("_stickFrame").GetComponent<RectTransform>();

		_startPos = _buttonFrame.position;

		_dragRadius = _buttonFrame.rect.width / 2.0f;
						
	}
	
	public void ButtonDown()
	{
		_buttonPressed = true;
	}

	public void ButtonUp()
	{
		_buttonPressed = false;

		HandleInput(_startPos);

	}

	public void AttackDown()
	{
		Debug.Log ("AttackDown");
		_player.OnAttackDown();
	}

	public void AttackUp()
	{
		Debug.Log ("AttackUp");
		_player.OnAttackUp();
	}

	
	public void SkillDown()
	{
		Debug.Log ("SkillDown");
		_player.OnSkillDown();
	}
	
	public void SkillUp()
	{
		Debug.Log ("SkillUp");
		_player.OnSkillUp();
	}

	void FixedUpdate()
	{
		HandleTouchInput();
		
		#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER

		HandleInput(Input.mousePosition);
		
		#endif
			
	}

	/// <summary>
	/// Is stick currently moving?
	/// </summary>
	/// <value><c>true</c> if is moving; otherwise, <c>false</c>.</value>
	public static bool IsMoving
	{
		get{ return _isMoving; }
	}





	#region User Input
	
	void HandleTouchInput ()
	{
		int i = 0;

		// We have touch-input (mobile)
		if(Input.touchCount > 0)
		{
			foreach(Touch touch in Input.touches)
			{
				i++;

				Vector3 touchPos = new Vector3(touch.position.x, touch.position.y);
				
				if(touch.phase == TouchPhase.Began)
				{
					if(touch.position.x <= (_buttonFrame.anchoredPosition.x + _buttonFrame.sizeDelta.x))
					{
						_touchId = i;
					}

				}
				
				if(touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
				{
					if(_touchId == i)
					{
						HandleInput(touchPos);
					}
				}
				
				if(touch.phase == TouchPhase.Ended)
				{
					if(_touchId == i)
					{
						_touchId = -1;
					}
				}

			}
		}
	}

	void HandleInput (Vector3 input)
	{
		if(_buttonPressed)
		{
			Vector3 differenceVector = (input - _startPos);

			if (differenceVector.sqrMagnitude >
			    _dragRadius * _dragRadius)
			{
				differenceVector.Normalize();

				_button.position = _startPos +
					differenceVector * _dragRadius;
			}
			else
			{
				_button.position = input;
			}
		}
		else
		{
			_button.position = _startPos;
		}

		
		Vector3 diff = _button.position - _startPos;
		
		
		float distance = Vector3.Distance(_button.position, _startPos);
		
		distance /= (_buttonFrame.sizeDelta.x / 2.0f);
		
		_isMoving = distance > 0.0f;
		
		Vector2 normDiff = new Vector3(diff.x / _dragRadius, diff.y / _dragRadius);


		if(_player != null)
		{
			_player.OnStickChanged(distance, normDiff);
		}
	}
		
	#endregion



}
