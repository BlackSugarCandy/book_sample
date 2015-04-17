using UnityEngine;
using System.Collections;

public class UserSingleton : MonoBehaviour {

	public long UserID;
	public string FacebookID;
	public string AccessToken;
	public string FacebookAccessToken;

	
	//Singleton Member And Method
	static UserSingleton _instance;
	public static UserSingleton Instance {
		get {
			if( ! _instance ) {
				GameObject container = new GameObject("UserSingleton");
				_instance = container.AddComponent( typeof( UserSingleton ) ) as UserSingleton;

				DontDestroyOnLoad( container );
			}
			
			return _instance;
		}
	}
}

