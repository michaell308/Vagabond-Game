public class HookShot : MonoBehaviour {
	private Transform player;
	public static bool shooting = false;
	private float hookPos;
	public static bool missedHook;
	private float hookPosY;
	private float hookSpeed = 650.0f;
	private float constantSpeed = 10.0f;
	private float originalX;
	public static bool hitSomething = false;
	private float originalY;
	private float reelSpeed = 650.0f;
	private float constantRSpeed = 100.0f;
	private float hookLength = 10f; //need to change chainSpace and chainSpaceBack if changing this
	private bool hitPlayer;
	private float chainLength = 2f;
	private float chainLengthY = 2.0f;
	private GameObject[] middleChains;
	private bool chainSwitch;
	private bool chainDSwitch;
	private int i = 0;	//adds and removes chains
	private int j = 0;	//removes chains
	private int numChains = 9;
	private float chainSpace = 0.95f;
	private float chainSpaceBack = 0.1f;
	public AudioClip hitSound;
	private bool dontDouble;
	private bool dontDouble2;
	
	
	// Use this for initialization
	void Start () {
		//SET NUMBER OF CHAINS IN HOOKSHOT
		middleChains = new GameObject[numChains];
		shooting = false; //need these for reset after going to start menu (mH)
		missedHook = false; 
		player = GameObject.FindWithTag("Player").transform;
		//SET HOOKSHOT DIRECTION/ROTATION BASED ON WHAT DIRECTION PLAYER IS FACING
		if (Player.facingRight) {
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			Vector3 rightPos = new Vector3(player.position.x+2.0f,player.position.y,0);
			transform.position = rightPos;
			transform.rotation = Quaternion.Euler(0,0,0);
			Player.freeze = false;
		}
		if (Player.facingLeft) {
			if (!shooting && !hitSomething && !missedHook) {
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				Vector3 leftPos = new Vector3(player.position.x-2.0f,player.position.y,0);
				transform.position = leftPos;
				transform.rotation = Quaternion.Euler(0,180,0);
				Player.freeze = false;
			}
		}
		if (Player.facingUp) {
			if (!shooting && !hitSomething && !missedHook) {
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				Vector3 upPos = new Vector3(player.position.x,player.position.y+2.0f,0);
				transform.position = upPos;
				//put hookShot behind player if shooting up
				GetComponent<SpriteRenderer>().sortingOrder = 1;
				transform.rotation = Quaternion.Euler(0,0,90);
				Player.freeze = false;
			}
		}
		if (Player.facingDown) {
			if (!shooting && !hitSomething && !missedHook) {
				GetComponent<Rigidbody2D>().velocity = Vector2.zero;
				Vector3 downPos = new Vector3(player.position.x,player.position.y-2.0f,0);
				transform.position = downPos;
				transform.rotation = Quaternion.Euler(0,0,-90);
				Player.freeze = false;
			}
		}

	}
	//FixedUpdate used to give chains time to update
	void FixedUpdate () {
		Debug.Log(shooting);
		//Constant checks to stop a bug
		if (Player.facingRight) {
			if ((transform.position.x-originalX) <= -0.1f ) { // .1f for leeway (forces hookshot while moving)
				shooting = false;
			}
		}
		if (Player.facingLeft) {
			if ((transform.position.x-originalX) >= 0.1f ) {
				shooting = false;
			}
		}
		if (Player.facingUp) {
			if ((transform.position.y-originalY) <= -0.1f ) {
				shooting = false;
			}
		}
		if (Player.facingDown) {
			if ((transform.position.y-originalY) >= 0.1f ) {
				shooting = false;
			}
		}
		//LAUNCHED HOOKSHOT FROM PLAYER SCRIPT
		if (Player.hitSpace && !shooting && !missedHook && !hitSomething) {
			shooting = true;
			Player.freeze = true;
			originalX = player.position.x;
			originalY = player.position.y;
		}
		//PLAYER NOT SHOOTING HOOK
		if (!shooting) {
			if (Player.facingRight) {
				if ((transform.position.x-originalX) <= 2.0f ) {
					//once hookShot is back in starting position
					missedHook = false;
					Player.freeze = false;
					Destroy(this.gameObject);
					Player.goingRight = false;
					Player.goingLeft = false;
					Player.goingUp = false;
					Player.goingDown = false;
				}
				if (missedHook && (transform.position.x-originalX) > 0) {
					//bring hookShot back towards player
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					GetComponent<Rigidbody2D>().AddForce(-Vector2.right * reelSpeed);
					GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
					shooting = false;
					if (transform.position.x - (player.position.x+chainLength) <= chainSpaceBack ) {
						chainLength -= chainSpace;
						chainDSwitch = false;
							if (!chainDSwitch) {
								i--;
								chainDSwitch = true;
								if (i >= 0) {
									Destroy(middleChains[i]);
								}
							}
					}
				}
			}
			if (Player.facingLeft) {
				if ((transform.position.x-originalX) >= -2.0f ) {
					missedHook = false;
					Player.freeze = false;
					Destroy(this.gameObject);
					Player.goingRight = false;
					Player.goingLeft = false;
					Player.goingUp = false;
					Player.goingDown = false;
				}
				if (missedHook && (transform.position.x-originalX) < 0) {
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					GetComponent<Rigidbody2D>().AddForce(Vector2.right * reelSpeed);
					GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				
				if ((player.position.x-chainLength) - transform.position.x <= chainSpaceBack ) {
					chainLength -= chainSpace;
					chainDSwitch = false;
					if (!chainDSwitch) {
						i--;
						chainDSwitch = true;
						if (i >= 0) {
							Destroy(middleChains[i]);
						}
					}
				}
				}
			}
			if (Player.facingUp) {
				if ((transform.position.y-originalY) <= 2.0f ) {
					missedHook = false;
					Player.freeze = false;
					Destroy(this.gameObject);
					Player.goingRight = false;
					Player.goingLeft = false;
					Player.goingUp = false;
					Player.goingDown = false;
				}
				if (missedHook && (transform.position.y-originalY) > 0) {
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					GetComponent<Rigidbody2D>().AddForce(-Vector2.up * reelSpeed);
					GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				
				if (transform.position.y - (player.position.y+chainLengthY) <= chainSpaceBack) {
					
					chainLengthY -= chainSpace;
					chainDSwitch = false;
					if (!chainDSwitch) {
						i--;
						chainDSwitch = true;
						if (i >= 0) {
							Destroy(middleChains[i]);
						}
					}
				}
				}
			}
			if (Player.facingDown) {
				if ((transform.position.y-originalY) >= -2.0f ) {
					missedHook = false;
					Player.freeze = false;
					Destroy(this.gameObject);
					Player.goingRight = false;
					Player.goingLeft = false;
					Player.goingUp = false;
					Player.goingDown = false;
				}
				if (missedHook && (transform.position.y-originalY) < 0) {
					GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					GetComponent<Rigidbody2D>().AddForce(Vector2.up * reelSpeed);
					GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				
				if ((player.position.y-chainLengthY) - transform.position.y <= chainSpaceBack) {
					chainLengthY -= chainSpace;
					chainDSwitch = false;
					if (!chainDSwitch) {
						i--;
						chainDSwitch = true;
						if (i >= 0) {
							Destroy(middleChains[i]);
						}
					}
				}
				}
			}
		}
		//PLAYER SHOOTING HOOK
		if (shooting) {
			if (Player.facingRight) {
				//shoot hook out from player
				GetComponent<Rigidbody2D>().AddForce(Vector2.right * hookSpeed);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				if ((transform.position.x-originalX) >= hookLength) {
					//hook reaches max length without hitting anything
					missedHook = true;
					shooting = false;
				}
				if (transform.position.x - (player.position.x+chainLength) >= 1.0f) {
					chainLength += chainSpace;
					chainSwitch = false;
					if (!chainSwitch) {
						//ensure one chain is placed each time
						chainSwitch = true;
						Vector3 rightChain = new Vector3(transform.position.x-chainSpace,player.position.y,0);
						middleChains[i] = (GameObject)Instantiate (Resources.Load ("middleChain"),rightChain,Quaternion.identity);
						i++;
					}
				}
			}
			if (Player.facingLeft) {
				GetComponent<Rigidbody2D>().AddForce(-Vector2.right * hookSpeed);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				if ((transform.position.x-originalX) <= -hookLength) {
					missedHook = true;
					shooting = false;
				}
				if ((player.position.x-chainLength) - transform.position.x >= 1.0f) {
					chainLength += chainSpace;
					chainSwitch = false;
					if (!chainSwitch) {
						chainSwitch = true;
						Vector3 leftChain = new Vector3(transform.position.x+chainSpace,player.position.y,0);
						middleChains[i] = (GameObject)Instantiate (Resources.Load ("middleChain"),leftChain,Quaternion.identity);
						i++;
					}
				}
			}
			if (Player.facingUp) {
				GetComponent<Rigidbody2D>().AddForce(Vector2.up * hookSpeed);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				if ((transform.position.y-originalY) >= hookLength) {
					missedHook = true;
					shooting = false;
				}
				if (transform.position.y - (player.position.y+chainLengthY) >= 1.0f) {
					chainLengthY += chainSpace;
					chainSwitch = false;
					if (!chainSwitch) {
						chainSwitch = true;
						Vector3 upChain = new Vector3(player.position.x,transform.position.y-chainSpace,0);
						middleChains[i] = (GameObject)Instantiate (Resources.Load ("middleChain"),upChain,Quaternion.identity);
						i++;
						if (middleChains[0] != null) {
							//put chain behind player
							middleChains[0].GetComponent<SpriteRenderer>().sortingOrder = 1;
						}
					}
				}
			}
			if (Player.facingDown) {
				GetComponent<Rigidbody2D>().AddForce(-Vector2.up * hookSpeed);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				if ((transform.position.y-originalY) <= -hookLength) {
					missedHook = true;
					shooting = false;
				}
				if ((player.position.y-chainLengthY) - transform.position.y >= 1.0f) {
					chainLengthY += chainSpace;
					chainSwitch = false;
					if (!chainSwitch) {
						chainSwitch = true;
						Vector3 downChain = new Vector3(player.position.x,transform.position.y+chainSpace,0);
						middleChains[i] = (GameObject)Instantiate (Resources.Load ("middleChain"),downChain,Quaternion.identity);
						i++;
					}
				}
			}
		}
		//PLAYER HIT ATTACHABLE OBJECT
		if (hitSomething) {
			if (Player.facingRight) {
				player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * reelSpeed);
				player.GetComponent<Rigidbody2D>().velocity = constantRSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				if (transform.position.x - (player.position.x+chainLength) <= 0.1f) {
					chainLength -= chainSpace;
					chainDSwitch = false;
					if (!chainDSwitch) {
						chainDSwitch = true;
						if (j >= 0 && j < numChains) {
							if (middleChains[j] != null) {
								Destroy(middleChains[j]);
							}
						}
						j++;
					}
				}
			}
			if (Player.facingLeft) {
				player.GetComponent<Rigidbody2D>().AddForce(-Vector2.right * reelSpeed);
				player.GetComponent<Rigidbody2D>().velocity = constantRSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				if ((player.position.x-chainLength) - transform.position.x <= 0.2f) {
					chainLength -= chainSpace;
					chainDSwitch = false;
					if (!chainDSwitch) {
						chainDSwitch = true;
						if (j >= 0 && j < numChains) {
							if (middleChains[j] != null) {
								Destroy(middleChains[j]);
							}
						}
						j++;
					}
				}
			}
			if (Player.facingUp) {
				player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * reelSpeed);
				player.GetComponent<Rigidbody2D>().velocity = constantRSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				if (transform.position.y - (player.position.y+chainLengthY) <= 0.2f) {
					chainLengthY -= chainSpace;
					chainDSwitch = false;
					if (!chainDSwitch) {
						chainDSwitch = true;
						if (j >= 0 && j < numChains) {
							if (middleChains[j] != null) {
								Destroy(middleChains[j]);
							}
						}
						j++;
					}
				}
			}
			if (Player.facingDown) {
				player.GetComponent<Rigidbody2D>().AddForce(-Vector2.up * reelSpeed);
				player.GetComponent<Rigidbody2D>().velocity = constantRSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				if ((player.position.y-chainLengthY) - transform.position.y <= 0.2f) {
					chainLengthY -= chainSpace;
					chainDSwitch = false;
					if (!chainDSwitch) {
						chainDSwitch = true;
						if (j >= 0 && j < numChains) {
							if (middleChains[j] != null) {
								Destroy(middleChains[j]);
							}
						}
						j++;
					}
				}
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "hookShot") {
			//hit a target you can reel in to
			shooting = false;
			missedHook = false;  //fixes bug if you barely hit something
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			hitSomething = true;
			AudioSource.PlayClipAtPoint(hitSound, transform.position,Player.volume);
			
		}
		if (other.gameObject.tag == "lever" || other.gameObject.tag == "leverUp" || other.gameObject.tag == "leverLeftFlip" || other.gameObject.tag == "leverDownFlip") {
			
			
			if (!missedHook) {
				if (!dontDouble2) {
					AudioSource.PlayClipAtPoint(hitSound, transform.position,Player.volume);
					dontDouble = true;
				}
				//hit up position lever
				shooting = false;
				missedHook = true;
				Transform leverFlipT = other.gameObject.transform.Find("leverFlip");
				var leverScript = leverFlipT.GetComponent<Lever>();
				if (!leverScript.hitLeverFlip && !leverScript.retractBridge) {
					Lever lever = other.GetComponent<Lever>();
					lever.hitLever = true;
				}
			}
		}
		if (other.gameObject.tag == "leverFlip" || other.gameObject.tag == "leverFlipUp" || other.gameObject.tag == "leverLeft" || other.gameObject.tag == "leverDown") {
			
			if (!missedHook) {
				if (!dontDouble) {
					AudioSource.PlayClipAtPoint(hitSound, transform.position,Player.volume);
					dontDouble2 = true;
				}
				//hit down position lever
				shooting = false;
				missedHook = true;
				Transform lever = other.gameObject.transform.parent;
				var leverScript = lever.GetComponent<Lever>();
				if (!leverScript.hitLever && !leverScript.extendBridge) {
					Lever leverF = other.GetComponent<Lever>();
					leverF.hitLeverFlip = true;
				}
			}
		}
		if (other.gameObject.tag == "barrel") {
			Destroy(other.gameObject);
		}
	}
	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.tag == "hookShot") {
			for (int i = 0; i < 5; i++) {
				if (other.gameObject.GetComponent<Collider2D>().name == Player.collisionNames[i]) {
					shooting = false;
					player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
					hitSomething = false;
					Player.freeze = false;
					missedHook = false;
					Player.goingRight = false;
					Player.goingLeft = false;
					Player.goingUp = false;
					Player.goingDown = false;
					for (int a = 0; a < numChains; a++) {
					if (middleChains[a] != null) {
						Destroy(middleChains[a]);
					}
					}
					Destroy(this.gameObject);
				}
			}
		}
	}
}
