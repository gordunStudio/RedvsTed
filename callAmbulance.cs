using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callAmbulance : MonoBehaviour {
	// to call for ambulance
	public		Renderer	ambulance;
	public		bool		hitPerson = false;
	private		bool		sirenaBool= false;
	public		AudioSource	sonidoSirena;
	public		AudioSource	comentarista;

	private		bool		winCondition = true;
	public		Renderer	KOSprite;
	public		Renderer	PerfectSprite;
	public		Renderer	YouWinSprite;
	public		Renderer	JailSprite;
	public		Renderer	handcuffSprite;

	public 		AudioClip	KOClip;
	public 		AudioClip	PerfectClip;
	public 		AudioClip	YouWinClip;
	public 		AudioClip	JailSClip;

	public		GameObject	avTed;

	public		bool 		canWin = true;
	// Use this for initialization
	void Start () {
		ambulance = GetComponent<Renderer> ();
		ambulance.enabled = false;

		KOSprite.enabled = false;	
		PerfectSprite.enabled = false;	
		YouWinSprite.enabled = false;
		JailSprite.enabled = false;
		handcuffSprite.enabled = false;

		sirenaBool = true;
		AudioSource sonidoSirena = GetComponent<AudioSource>();
		AudioSource comentarista = GetComponent<AudioSource>();
		AudioClip sirena;


	}
	
	// Update is called once per frame
	void Update () {
		if (canWin) {
			if (hitPerson) {
				ambulance.enabled = true;
				// move ambulance
				transform.position = Vector2.MoveTowards (new Vector2 (transform.position.x, transform.position.y), new Vector2 (12, -0.6f), 4 * Time.deltaTime);
			}

			if (transform.position.x > 11) {
				if (winCondition) {
					StartCoroutine (YouWin ());
				}
				sonidoSirena.Stop ();
			}

			if (hitPerson && sirenaBool) {
				StartCoroutine (LaSirena ());
			}
		}
	}

	IEnumerator LaSirena(){
		sirenaBool = false;
		yield return new WaitForSeconds(0.5f);
		sonidoSirena.Play();
		yield return new WaitForSeconds(sonidoSirena.clip.length);
	}

	IEnumerator YouWin(){
		avTed.GetComponent<blowUp> ().canWin = false;
		winCondition = false;


		comentarista.clip = KOClip;
		comentarista.Play ();
		KOSprite.enabled = true;
		yield return new WaitForSeconds(0.9f);
		KOSprite.enabled = false;
		yield return new WaitForSeconds(0.8f);

		comentarista.clip = PerfectClip;
		comentarista.Play ();
		PerfectSprite.enabled = true;
		yield return new WaitForSeconds(1.0f);
		PerfectSprite.enabled = false;
		yield return new WaitForSeconds(0.8f);

		comentarista.clip = YouWinClip;
		comentarista.Play ();
		YouWinSprite.enabled = true;
		yield return new WaitForSeconds(0.4f);
		YouWinSprite.enabled = false;
		yield return new WaitForSeconds(0.4f);

		YouWinSprite.enabled = true;
		yield return new WaitForSeconds(0.4f);
		YouWinSprite.enabled = false;
		yield return new WaitForSeconds(0.4f);

		YouWinSprite.enabled = true;
		yield return new WaitForSeconds(0.4f);
		YouWinSprite.enabled = false;
		yield return new WaitForSeconds(0.4f);

		comentarista.clip = JailSClip;
		comentarista.Play ();
		JailSprite.enabled = true;
		handcuffSprite.enabled = true;
	}
}
