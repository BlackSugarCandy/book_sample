using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Text;

public class HTTPClient : MonoBehaviour {
	
	public bool DebugMode = true;
	
	static GameObject _container;
	static GameObject Container {
		get {
			return _container;
		}
	}
	
	static HTTPClient _instance;
	public static HTTPClient Instance {
		get {
			if( ! _instance ) {
				_container = new GameObject();
				_container.name = "HTTPClient";
				_instance = _container.AddComponent( typeof(HTTPClient) ) as HTTPClient;
			}
			
			return _instance;
		}
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public WWW BuildWWWGET(string url, Dictionary<string, string> parameter) {
		StringBuilder stringBuilder = new StringBuilder (url);
		if (parameter.Count > 0) {
			stringBuilder.Append("?");
			foreach (KeyValuePair<string, string> arg in parameter) { 
				stringBuilder.Append(arg.Key);
				stringBuilder.Append("=");
				stringBuilder.Append(arg.Value);
				stringBuilder.Append("&");
			}
			stringBuilder.Remove( stringBuilder.Length - 1, 1 );
		}
		
		WWW www = new WWW( stringBuilder.ToString() );
		return www;
	}
	
	public WWW BuildWWWPOST(string url, Dictionary<string, string> parameter) {
		WWWForm form = new WWWForm(); 
		foreach (KeyValuePair<string, string> post_arg in parameter) { 
			form.AddField(post_arg.Key, post_arg.Value); 	
		}
		
		WWW www = new WWW( url, form );
		return www;
	}
	
	public IEnumerator GET(string url, Dictionary<string, string> parameter, HTTPResponse response) {
		HTTPRequest req = new HTTPRequest();
		req.WWW = BuildWWWGET( url, parameter );
		req.Callback = delegate(WWW obj) {
			response.Content = obj.text;
		};
		
		yield return StartCoroutine( WaitForRequest( req ) );
	}
	
	public void GET(string url, Dictionary<string, string> parameter, Action<WWW> callback) {
		HTTPRequest req = new HTTPRequest();
		req.WWW = BuildWWWGET( url, parameter );
		req.Callback = callback;
		
		StartCoroutine( WaitForRequest( req ) );
	}
	
	public void POST(string url, Dictionary<string, string> parameter, Action<WWW> callback) {
		HTTPRequest req = new HTTPRequest();
		req.WWW = BuildWWWPOST( url, parameter );
		req.Callback = callback;
		
		StartCoroutine( WaitForRequest( req ) );
	}
	
	private IEnumerator WaitForRequest(HTTPRequest req)
	{
		WWW www = req.WWW;
		yield return www;
		
		req.Callback( req.WWW );
	}
	
	public class HTTPRequest {
		public WWW WWW { get; set; }
		public Action<WWW> Callback { get; set; }
	}
	
	public class HTTPResponse {
		public string Content { get; set; }
	}
}
