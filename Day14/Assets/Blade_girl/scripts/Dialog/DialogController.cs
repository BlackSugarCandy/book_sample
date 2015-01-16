using UnityEngine;
using System;
using System.Collections;

public class DialogController : MonoBehaviour
{
	protected Camera Camera { get; private set; }
	protected UICamera UICamera { get; private set; }
	protected UIPanel mPanel { get; private set; }

	public Transform window;
	
	public bool Visible 
	{
		get
		{
			return Camera.enabled;
		}

		private set
		{
			if( Camera != null )
				Camera.enabled = value;
			if( UICamera != null )
				UICamera.enabled = value;
		}
	}

	public virtual void Awake()
	{
		Camera = GetComponent<Camera>();
		UICamera = GetComponent<UICamera>();
		mPanel = transform.FindChild("Panel").GetComponent<UIPanel>();
	}

	public virtual void Start()
	{

	}

	IEnumerator OnEnter(Action callback)
	{		
		Visible = true;

		if( callback != null ) {
			callback();
		}
		yield break;
	}

	IEnumerator OnExit(Action callback)
	{
		Visible = false;

		if( callback != null ) {
			callback();
		}
		yield break;
	}

    public virtual void Build(DialogData data)
    {
        
    }

    public void Show(Action callback)
    {
		StartCoroutine ( OnEnter( callback ) );
    }

    public void Close(Action callback)
    {
		StartCoroutine ( OnExit( callback ) );
    }
}
