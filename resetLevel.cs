using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetLevel : MonoBehaviour {
	private Renderer miRenderer;
	// Use this for initialization
	void Start () {
		miRenderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnMouseDown()
	{
		if ( miRenderer.enabled == true )
		Application.LoadLevel(Application.loadedLevel);
	}
}
