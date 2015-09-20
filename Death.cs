using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
	public LayerMask deathLM;
	private float fallSpeed = 1.0f;
	private float constantSpeed = 5.0f;
	public static bool dead;
	private float fallRight;
	private float fallLeft;
	private float fallUp;
	private float fallDown;
	private bool trigger1;
	private bool trigger2;
	private bool trigger3;
	private bool trigger4;
	public static bool playerOnSB;
	public LayerMask sBLM;
	public AudioClip deathSound;
	private bool soundOfDeath;
	private bool soundOfDeath2;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(soundOfDeath);
		Vector3 playerLow = new Vector3 (transform.position.x,transform.position.y-2.7f,transform.position.z);
		
		RaycastHit2D rightSB = Physics2D.Raycast(transform.position, transform.right, .000001f, sBLM);
		RaycastHit2D leftSB = Physics2D.Raycast(transform.position, -transform.right, .000001f, sBLM);
		RaycastHit2D rightLowSB = Physics2D.Raycast(playerLow, transform.right, .000001f, sBLM);
		RaycastHit2D leftLowSB = Physics2D.Raycast(playerLow, -transform.right, .000001f, sBLM);
		RaycastHit2D upSB = Physics2D.Raycast(playerLow, transform.up,.00001f, sBLM);
		RaycastHit2D downSB = Physics2D.Raycast(transform.position, -transform.up, 2f, sBLM);

		RaycastHit2D right = Physics2D.Raycast(transform.position, transform.right, .000001f, deathLM);
		RaycastHit2D left = Physics2D.Raycast(transform.position, -transform.right, .000001f, deathLM);
		RaycastHit2D rightLow = Physics2D.Raycast(playerLow, transform.right, .000001f, deathLM);
		RaycastHit2D leftLow = Physics2D.Raycast(playerLow, -transform.right, .000001f, deathLM);
		RaycastHit2D up = Physics2D.Raycast(playerLow, transform.up, .00001f, deathLM);
		RaycastHit2D down = Physics2D.Raycast(transform.position, -transform.up, 2f, deathLM);
		Debug.DrawRay(transform.position,transform.right *000001f, Color.red, 10.0f);
		Debug.DrawRay(transform.position,-transform.right *000001f, Color.red, 10.0f);
		Debug.DrawRay(playerLow,transform.right *000001f, Color.red, 10.0f);
		Debug.DrawRay(playerLow,transform.right *000001f, Color.red, 10.0f);
		Debug.DrawRay(playerLow,transform.up *000001f, Color.red, 10.0f);
		Debug.DrawRay(transform.position,-transform.up *2f, Color.red, 10.0f);
		
		if ((rightSB || leftSB || upSB || downSB || rightLowSB || leftLowSB) && !dead) {
			playerOnSB = true;
		}
		else {
			playerOnSB = false;
		}
		if (dead) {
			Player.freeze = false;
			dead = false;
		}
		if (((!right && Player.facingRight) || (!left && Player.facingLeft)) && !Player.facingUp && !Player.facingDown) {
			dead = true;
			if (!soundOfDeath) {
				AudioSource.PlayClipAtPoint(deathSound, transform.position,Player.volume * 0.1f);
				soundOfDeath = true;	
			}	
			Player.freeze = true;
			playerOnSB = false;
			if (dead && !trigger1) {
				fallRight = transform.position.x+1.0f;
				trigger1 = true;
			}
			if (dead && !trigger2) {
				fallLeft = transform.position.x-1.0f;
				trigger2 = true;
					
			}
			if (Player.facingRight) {
				if (transform.position.x <= fallRight) {
					GetComponent<Rigidbody2D>().AddForce(Vector2.right * fallSpeed);
					GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
	
				}
				else {
					soundOfDeath = false;	
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
						transform.position = Vector3.zero;
						Player.goingRight = false;	
				}
			}
			if (Player.facingLeft) {
				if (transform.position.x >= fallLeft) {
					GetComponent<Rigidbody2D>().AddForce(-Vector2.right * fallSpeed);
					GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);	
				}
				else {
					soundOfDeath = false;	
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
						transform.position = Vector3.zero;
						Player.goingLeft = false;
				}
			}
		}
		if (((!down && Player.facingUp) || (!up && Player.facingDown)) && !Player.facingRight && !Player.facingLeft) {
			dead = true;
			if (!soundOfDeath) {
				AudioSource.PlayClipAtPoint(deathSound, transform.position,Player.volume *0.1f);
				soundOfDeath = true;	
			}
			Player.freeze = true;
			playerOnSB = false;
			if (dead && !trigger3) {
				fallUp = transform.position.y+1.0f;
				trigger3 = true;
				
			}
			if (dead && !trigger4) {
				fallDown = transform.position.y-3.0f;
				trigger4 = true;
				
			}
			if (Player.facingUp) {
				if (transform.position.y <= fallUp) {
					GetComponent<Rigidbody2D>().AddForce(Vector2.up * fallSpeed);
					GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				}
				else {
					soundOfDeath = false;	
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
						transform.position = Vector3.zero;
						Player.goingUp = false;
				}
			}
			if (Player.facingDown) {
				if (transform.position.y >= fallDown) {
					GetComponent<Rigidbody2D>().AddForce(-Vector2.up * fallSpeed);
					GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				}
				else {
					soundOfDeath = false;	
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
						transform.position = Vector3.zero;
						Player.goingDown = false;
				}
			}
			
		}
	}
}
