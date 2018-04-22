using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWeapon : MonoBehaviour {
	
	public float diferencia = 1.9f;
	public	Renderer bang0;
	public	Renderer bang1;
	public bool hitPerson;
	public AudioSource sonidoDisparo;
	private Renderer miRend;

	void Start () {
		bang0.enabled = false;
		bang1.enabled = false;
		AudioSource sonidoDisparo = GetComponent<AudioSource>();
		miRend = GetComponent<Renderer> ();
		miRend.enabled = false;
	}
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (Time.timeSinceLevelLoad > 4) {
			miRend.enabled = true;
		}

		this.transform.position = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + diferencia, this.transform.position.y);
		if (hitPerson) {
			StartCoroutine(disparo ());
		}
	}

	IEnumerator disparo(){
		hitPerson = false;
		sonidoDisparo.Play();
		bang0.enabled = true;
		bang1.enabled = true;
		yield return new WaitForSeconds(0.2f);
		bang0.enabled = false;
		yield return new WaitForSeconds(0.2f);
		bang1.enabled = false;
		yield return new WaitForSeconds(0.2f);
	}
}
