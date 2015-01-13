using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class InputController : MonoBehaviour {


	#region Input-controller variables

	public Camera UICamera;

	public UISprite _button;

	public UISprite _buttonFrame;
	
	private int _touchId = -1;

	private Vector3 _startPos = Vector3.zero;
		
	private float _dragRadius = 0.0f;

	private IPlayer _player;

	private bool _buttonPressed = false;

	private static bool _isMoving = false;
	
	public float x, y;
	
	public bool attack;
	
	#endregion
		
	void Awake() {
		_instance = this;
	}
	
	// Use this for initialization
	void Start () {

		_startPos = _buttonFrame.transform.localPosition;

		_dragRadius = _buttonFrame.width / 2.0f;
						
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
					if(touch.position.x <= (_buttonFrame.transform.localPosition.x + _buttonFrame.width / 2f))
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
		input = input * 2;
		if(_buttonPressed)
		{
			Debug.Log ("input " + input.x + " / " + input.y + " / " + input.z);
			Ray ray = UICamera.ScreenPointToRay(input);
			RaycastHit hit ;
			if(Physics.Raycast(ray, out hit))
			{

				Debug.Log ("hit" + hit.transform.name);
				Debug.Log ((hit.point).ToString());
			}
			Vector3 differenceVector = (input - _startPos);

			if (differenceVector.sqrMagnitude >
			    _dragRadius * _dragRadius)
			{
				differenceVector.Normalize();

				_button.transform.localPosition = _startPos +
					differenceVector * _dragRadius;
			}
			else
			{
				_button.transform.localPosition = input;
			}
		}
		else
		{
			_button.transform.localPosition = _startPos;
		}
		
		Vector3 diff = _button.transform.localPosition - _startPos;		
		
		float distance = Vector3.Distance(_button.transform.localPosition, _startPos);
		
		distance /= (_buttonFrame.width / 2.0f);
		
		_isMoving = distance > 0.0f;
		
		Vector2 normDiff = new Vector3(diff.x / _dragRadius, diff.y / _dragRadius);

		x = normDiff.x;
		y = normDiff.y;

	}

		
	#endregion

	public void AttackDown()
	{
		attack = true;

	}

	public void AttackUp()
	{
		attack = false;
	}

	//Singleton Member And Method
	static InputController _instance;    
	public static InputController Instance {
		get {            
			if( ! _instance ) {
				GameObject container = new GameObject("InputController");
				_instance = container.AddComponent( typeof( InputController ) ) as InputController;
			}            
			return _instance;
		}    
	}


}
