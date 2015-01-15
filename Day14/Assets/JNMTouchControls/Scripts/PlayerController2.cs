using System;
using UnityEngine;
using System.Collections;

/// <summary>
/// Player controller sample implementation of IPlayer-baseclass
/// </summary>
public class PlayerController2 : IPlayer
{
	/// <summary>
	/// The rotation speed of the Camera
	/// </summary>
	public float RotationSpeed = 12.0f;

	/// <summary>
	/// The move speed of the character
	/// </summary>
	public float MoveSpeed = 7.0f;

	/// <summary>
	/// The transform (model) of the character
	/// </summary>
	public Transform PlayerTransform;

	/// <summary>
	/// The animator of the character
	/// </summary>
	private Animator _animator;

	/// <summary>
	/// The rigidbody of the character we use for move and rotate.
	/// another approach is to use a CharacterController. If you use 
	/// a character controller you can replace the move and rotate calls 
	/// to the rigidbody.
	/// </summary>
	private Rigidbody _rigidbody;

	/// <summary>
	/// Get the rigidbody of the character and the Animator
	/// </summary>
    void Start()
    {
		_rigidbody = GetComponent<Rigidbody>();

		_animator = PlayerTransform.gameObject.GetComponent<Animator>();

    }

	/// <summary>
	/// Sample implementation to apply gravity if the character is not grounded.
	/// There are better implementations e.g. calculating the difference to the floor
	/// but these are more expensive regarding performance.
	/// </summary>
	void ApplyGravity ()
	{
		if(_rigidbody.position.y >= 0.2f)
		{
			Vector3 v = _rigidbody.velocity;
			v.y = -3.0f;
			_rigidbody.velocity = v;
		}
	}



	void Update()
	{
		#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER

		// In Standalone and editor we can test the Jump-action with space key
		if(Input.GetKeyDown(KeyCode.Space))
		{
			DoJump();
		}
		#endif
	}

	/// <summary>
	/// Raises the stick changed event when 
	/// the position of the virtual joystick has changed
	/// </summary>
	/// <param name="distance">of the change</param>
	/// <param name="stickPos">Stick position (coordinates)</param>
	public override void OnStickChanged(float distance, Vector2 stickPos)
	{
		var movement = new Vector3(
			stickPos.x,
			0,
			stickPos.y);

		float speed = distance;

		// We have an animator so let's apply the states Run and Jump
		// by defining the parameters Jump and MoveSpeed
		if (_animator)
		{
			AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);			
		
			if(speed >= 0.3f)
			{

				_animator.SetBool("Jump", false);
				_animator.SetFloat("MoveSpeed", speed);

				movement *=speed;
							
				_rigidbody.MovePosition(PlayerTransform.position + (movement * MoveSpeed * Time.deltaTime));

				if(!stateInfo.IsName("Jump"))
				{
					ApplyGravity();
				}
			}
			else
			{
				_animator.SetFloat("MoveSpeed", 0.0f);
			}
		}
		DoRotation(movement); 
	}

	/// <summary>
	/// Does the jump-animation
	/// </summary>
	public void DoJump()
	{
		if (_animator)
		{
			_animator.SetBool("Jump", true);
		}
	}

	/// <summary>
	/// Does the rotation
	/// </summary>
	/// <param name="direction">Direction of the rotation</param>
    public void DoRotation(Vector3 direction)
    {
        StopCoroutine("RotateCoroutine");
        StartCoroutine("RotateCoroutine", direction);
    }

    IEnumerator RotateCoroutine(Vector3 direction)
    {
        if (direction == Vector3.zero) yield break;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        do
        {
            PlayerTransform.rotation = Quaternion.Lerp(PlayerTransform.rotation, lookRotation, Time.deltaTime * RotationSpeed);
            yield return null;
        }
        while ((direction - PlayerTransform.forward).sqrMagnitude > 0.2f);
    }

}
