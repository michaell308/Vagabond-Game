using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour {
	public Transform drawBridge;
	public GameObject leverFlip;
	private float dBPos;
	public bool extendBridge;
	public bool retractBridge;
	public bool hitLever;
	public bool hitLeverFlip;
	private bool right;
	private bool left;
	private bool up;
	private bool down;
	public AudioClip leverSound;
	public AudioClip dBInSound;
	public AudioClip dBOutSound;
	//private float volume = 0.3f;
	
	// Use this for initialization
	void Start () {
		//tag based on direction of drawbridge movement
		if (this.tag == "lever") { //right
			right = true;
		}
		if (this.tag == "leverFlip") {
			left = true;
		}
		if (this.tag == "leverUp") { //up
			up = true;
		}
		if (this.tag == "leverFlipUp") {
			down = true;
		}
		if (this.tag == "leverLeft") { //left
			left = true;
		}
		if (this.tag == "leverLeftFlip") {
			right = true;
		}
		if (this.tag == "leverDown") { //down
			down = true;
		}
		if (this.tag == "leverDownFlip") {
			up = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!PauseMenu.paused) {
			if (hitLever && dBPos == 0 && !hitLeverFlip && (right || up)) {
				///extendBridge if hitLever with hookShot
				extendBridge = true;
				AudioSource.PlayClipAtPoint(dBOutSound, transform.position,Player.volume);
				//play leverSound if lever is hit
				AudioSource.PlayClipAtPoint(leverSound, transform.position,Player.volume);
				//change appropriate sprites and colliders
				SpriteRenderer leverSprite2 = leverFlip.GetComponent<SpriteRenderer>();
				leverSprite2.enabled = true;
				SpriteRenderer leverSprite1 = this.GetComponent<SpriteRenderer>();
				leverSprite1.enabled = false;
				PolygonCollider2D leverCollider1 = this.GetComponent<PolygonCollider2D>();
				leverCollider1.enabled = false;
				PolygonCollider2D leverCollider2 = leverFlip.GetComponent<PolygonCollider2D>();
				leverCollider2.enabled = true;
			}
		if (extendBridge) {
			dBPos += 0.001f;
			if (dBPos >= .15f) {
				//limit for drawBridge length extending
				dBPos = .15f;
				extendBridge = false;
				hitLever = false;
				//set hitLever false in leverFlip gameObject (prevents spamming/breaking of drawbridge)
				var leverScript = leverFlip.GetComponent<Lever>();
				leverScript.hitLever = false;
			}
			if (right) {
				//set newPosition of drawBridge
				Vector3 newPosition = new Vector3(drawBridge.position.x+dBPos,drawBridge.position.y,drawBridge.position.z);
				drawBridge.position = newPosition;
				if (!extendBridge) {
					//reset dBPos after extendBridge is finished extending
					dBPos = 0;
				}
			}
			if (up) {
				//similar to right
				Vector3 newPosition = new Vector3(drawBridge.position.x,drawBridge.position.y+dBPos,drawBridge.position.z);
				drawBridge.position = newPosition;
				if (!extendBridge) {
					dBPos = 0;
				}
			}
		}


			if (hitLeverFlip && dBPos == 0 && !hitLever && (left || down)) {
				//similar to extendBridge
				AudioSource.PlayClipAtPoint(leverSound, transform.position,Player.volume);
				AudioSource.PlayClipAtPoint(dBInSound, transform.position,Player.volume);
				retractBridge = true;
				SpriteRenderer leverSprite2 = leverFlip.GetComponent<SpriteRenderer>();
				leverSprite2.enabled = true;
				SpriteRenderer leverSprite1 = this.GetComponent<SpriteRenderer>();
				leverSprite1.enabled = false;
				PolygonCollider2D leverCollider1 = this.GetComponent<PolygonCollider2D>();
				leverCollider1.enabled = false;
				PolygonCollider2D leverCollider2 = leverFlip.GetComponent<PolygonCollider2D>();
				leverCollider2.enabled = true;
			}
			if (retractBridge) {
				dBPos -= 0.001f;
				if (dBPos <= -0.15f) {
					//limit for drawBridge length retracting
					dBPos = -0.15f;
					retractBridge = false;
					hitLeverFlip = false;
					//set hitLeverFlip false in lever gameObject (prevents spamming/breaking of drawbridge)
					var leverScript = leverFlip.GetComponent<Lever>();
					leverScript.hitLeverFlip = false;
					
					
				}
				if (left) {
					//similar to right
					Vector3 newPosition = new Vector3(drawBridge.position.x+dBPos,drawBridge.position.y,drawBridge.position.z);
					drawBridge.position = newPosition;
					if (!retractBridge) {
						dBPos = 0;
					}
				}
				if (down) {
					//similar to right
					Vector3 newPosition = new Vector3(drawBridge.position.x,drawBridge.position.y+dBPos,drawBridge.position.z);
					drawBridge.position = newPosition;
					if (!retractBridge) {
						dBPos = 0;
					}
				}
			}
		}
	}
	void OnCollisionStay2D(Collision2D other) {
		if (other.gameObject.tag == "Player") {
			if(Input.GetKeyDown(KeyCode.E)) {
				if (dBPos == 0 && !left && !down) {
					var leverScript = leverFlip.GetComponent<Lever>();
					if (!leverScript.retractBridge) {
						AudioSource.PlayClipAtPoint(leverSound, transform.position,Player.volume);
						//if you collide w/ lever and hit e, you extend bridge
						extendBridge = true;
						AudioSource.PlayClipAtPoint(dBOutSound, transform.position,Player.volume);
						//change appropriate sprites and colliders
						PolygonCollider2D leverCollider1 = this.GetComponent<PolygonCollider2D>();
						leverCollider1.enabled = false;
						PolygonCollider2D leverCollider2 = leverFlip.GetComponent<PolygonCollider2D>();
						leverCollider2.enabled = true;
						SpriteRenderer leverSprite2 = leverFlip.GetComponent<SpriteRenderer>();
						leverSprite2.enabled = true;
						SpriteRenderer leverSprite1 = this.GetComponent<SpriteRenderer>();
						leverSprite1.enabled = false;
					}
				}
				if (dBPos == 0 && !right && !up) {
					var leverScript = leverFlip.GetComponent<Lever>();
					if (!leverScript.extendBridge) {
						AudioSource.PlayClipAtPoint(leverSound, transform.position,Player.volume);
						//if you collide w/ lever and hit e, you retract bridge
						retractBridge = true;
						AudioSource.PlayClipAtPoint(dBInSound, transform.position,Player.volume);
						//change appropriate sprites and colliders
						PolygonCollider2D leverCollider1 = this.GetComponent<PolygonCollider2D>();
						leverCollider1.enabled = false;
						PolygonCollider2D leverCollider2 = leverFlip.GetComponent<PolygonCollider2D>();
						leverCollider2.enabled = true;
						SpriteRenderer leverSprite2 = leverFlip.GetComponent<SpriteRenderer>();
						leverSprite2.enabled = true;
						SpriteRenderer leverSprite1 = this.GetComponent<SpriteRenderer>();
						leverSprite1.enabled = false;
					}
					
				}
			}
		}
	}
}
