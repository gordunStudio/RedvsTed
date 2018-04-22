using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blowUp : MonoBehaviour {
	// to kill player character
	public 		float			thrust;
	public 		Rigidbody2D 	rb;
	private 	bool			hitPerson = false;
	public		GameObject		ambulance;
	public		GameObject		weapon;
	public		Renderer		myLifebar;
	// to start level
	private	bool		StartCondition = true;

	public		Renderer	Round1Sprite;
	public		Renderer	ShootSprite;
	public		Renderer	freedomSprite;
	public		Renderer	YouWinSprite;
	private		bool		winConditionBool = true;

	public		AudioSource	comentarista;
	public 		AudioClip	freedomClip;
	public 		AudioClip	YouWinClip;
	public 		AudioClip	Round1Clip;
	public 		AudioClip	ShootClip;

	public		bool 		canWin = true;
	void Start()
	{
		
		rb = GetComponent<Rigidbody2D>();
		//myLifebar = GetComponent<Renderer> ();
		if (Round1Sprite) {
			Round1Sprite.enabled = false;
			ShootSprite.enabled = false;
			freedomSprite.enabled = false;
			YouWinSprite.enabled = false;
		}
	}

	void Update(){
		if (Round1Sprite) {
			if (StartCondition) {
				StartCoroutine (StartLevel ());
			}
			if (Time.timeSinceLevelLoad > 25 && winConditionBool && canWin) {
				StartCoroutine (WinLevel ());
				canWin = false;
				ambulance.GetComponent<callAmbulance> ().canWin = false;
			}
		}
	}

	void FixedUpdate()
	{
		if (hitPerson && canWin) {
			myLifebar.enabled = false;
			rb.AddForce (transform.right * thrust);
			rb.AddForce (transform.up * Mathf.Abs(thrust) * 2 * Random.value);
			rb.AddTorque(Mathf.Abs(thrust) * 2);
		}
	}

	void OnMouseDown()
	{
		if (Time.timeSinceLevelLoad > 5 && Time.timeSinceLevelLoad < 24) {
			hitPerson = true;
			ambulance.GetComponent<callAmbulance> ().hitPerson = true;
			weapon.GetComponent<MoveWeapon> ().hitPerson = true;
		}
	}

	IEnumerator StartLevel(){
		StartCondition = false;
		yield return new WaitForSeconds(1.8f);

		comentarista.clip = Round1Clip;
		comentarista.Play ();
		Round1Sprite.enabled = true;
		yield return new WaitForSeconds(Round1Clip.length);
		Round1Sprite.enabled = false;
		yield return new WaitForSeconds(1.2f);

		comentarista.clip = ShootClip;
		comentarista.Play ();
		ShootSprite.enabled = true;
		yield return new WaitForSeconds(1.2f);
		ShootSprite.enabled = false;
		yield return new WaitForSeconds(1.2f);
	}


	IEnumerator WinLevel(){
		winConditionBool = false;

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

		comentarista.clip = freedomClip;
		comentarista.Play ();
		freedomSprite.enabled = true;
	}
}
