using UnityEngine;
using System.Collections;

public class loadLevelbutton : MonoBehaviour {

	public Texture2D normalTex;
	public Texture2D hoverTex;

	public int loadLevel;






	private void OnMouseEnter ()
	{

		guiTexture.texture = hoverTex;
	}

	private void OnMouseExit ()
	{

		guiTexture.texture = normalTex;
	}


	private void OnMouseDown()
	{
		Application.LoadLevel(loadLevel);

	}







}
