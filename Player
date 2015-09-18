	private float constantSpeed = 12.0f;
	private float playerSpeed = 100.0f;
	public static bool goingRight;
	public static bool goingLeft;
	public static bool goingUp;
	public static bool goingDown;
	public static bool freeze;
	public static bool facingRight;
	public static bool facingLeft;
	public static bool facingUp;
	public static bool facingDown;
	public static string[] collisionNames;
	private GameObject hookShot;
	public static bool hitSpace = false;
	private int numObjectsTouching = 5;
	public AudioClip shootSound;
	public static float volume = 0.5f;
	private float playerSpeedOnSB = 300f;
	private float constantSpeedOnSB = 100f;
	// Use this for initialization
	void Start () {
		collisionNames = new string[numObjectsTouching];
		freeze = false;
		goingRight = false;
		goingLeft = false;
		goingUp = false;
		goingDown = false;		//need these for reset after going to start menu
		facingRight = true;
		facingLeft = false;
		facingUp = false;
		facingDown = false;
		hitSpace = false;
		if (hookShot != null) {
			Destroy(hookShot);
		}
	}
	
	// Update is called once per frame
	void Update () {
		//sound on player changes with volume slider
		GetComponent<AudioSource>().volume = volume;

		//MOVEMENT
	if (!freeze) {
		if (!Death.playerOnSB) {
		if (Input.GetKey(KeyCode.D)) {
			if (!goingLeft && !goingUp && !goingDown) {
				GetComponent<Rigidbody2D>().AddForce(Vector2.right * playerSpeed, ForceMode2D.Impulse);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				//set direction player is currently going
				goingRight = true;
				goingLeft = false;
				goingUp = false;
				goingDown = false;
				//unflip player
				transform.rotation = new Quaternion(0,0,0,0);
			}
			//set direction player is facing
			facingRight = true;
			//fix bug when shooting hookShot on an angle (prevents this)
			facingLeft = false;
			facingUp = false;
			facingDown = false;
		}
		if (Input.GetKey(KeyCode.A)) {
			if (!goingRight && !goingUp && !goingDown) {
					GetComponent<Rigidbody2D>().AddForce(-Vector2.right * playerSpeed, ForceMode2D.Impulse);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);	
				goingLeft = true;
				goingRight = false;
				goingUp = false;
				goingDown = false;
				//flip player
				transform.rotation = new Quaternion(0,180,0,0);
			}
			facingLeft = true;
			facingRight = false;
			facingUp = false;
			facingDown = false;
		}
		if (Input.GetKey(KeyCode.W)) {
			if (!goingLeft && !goingRight && !goingDown) {
				GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerSpeed, ForceMode2D.Impulse);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);	
				goingUp = true;
				goingRight = false;
				goingLeft = false;
				goingDown = false;
			}
			facingUp = true;
			facingRight = false;
			facingLeft = false;
			facingDown = false;
		}
		if (Input.GetKey(KeyCode.S)) {
			if (!goingLeft && !goingUp && !goingRight) {
				GetComponent<Rigidbody2D>().AddForce(-Vector2.up * playerSpeed, ForceMode2D.Impulse);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				goingDown = true;
				goingRight = false;
				goingLeft = false;
				goingUp = false;
			}
			facingDown = true;
			facingUp = false;
			facingRight = false;
			facingLeft = false;
		}
		//CUSTOM ANGLED MOVEMENTS
		if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) {
			if (!goingLeft && !goingDown) {
				GetComponent<Rigidbody2D>().AddForce((Vector2.right+Vector2.up) * playerSpeed * 2);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				goingRight = true;
				goingUp = true;
				goingLeft = false;
				goingDown = false;
				facingRight = true;
				//part of fix to prevent angled hookShot
				facingLeft = false;
				facingUp = false;
				facingDown = false;
				transform.rotation = new Quaternion(0,0,0,0);
			}
		}
		if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) {
			if (!goingLeft && !goingUp) {
				GetComponent<Rigidbody2D>().AddForce((Vector2.right-Vector2.up) * playerSpeed *2);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				goingRight = true;
				goingDown = true;
				goingLeft = false;
				goingUp = false;
				facingRight = true;
				facingLeft = false;
				facingUp = false;
				facingDown = false;
				transform.rotation = new Quaternion(0,0,0,0);
			}
		}
		if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) {
			if (!goingRight && !goingDown) {
				GetComponent<Rigidbody2D>().AddForce((-Vector2.right+Vector2.up) * playerSpeed * 2);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				goingLeft = true;
				goingUp = true;
				goingRight = false;
				goingDown = false;
				facingLeft = true;
				facingRight = false;
				facingUp = false;
				facingDown = false;
				transform.rotation = new Quaternion(0,180,0,0);
			}
		}
		if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) {
			if (!goingRight && !goingUp) {
				GetComponent<Rigidbody2D>().AddForce((-Vector2.right-Vector2.up) * playerSpeed * 2);
				GetComponent<Rigidbody2D>().velocity = constantSpeed * (GetComponent<Rigidbody2D>().velocity.normalized);
				goingLeft = true;
				goingDown = true;
				goingRight = false;
				goingUp = false;
				facingLeft = true;
				facingRight = false;
				facingUp = false;
				facingDown = false;
				transform.rotation = new Quaternion(0,180,0,0);
			}
		}
		}
		//ON SKYBRIDGE MOVEMENTS
		if (Death.playerOnSB) {
				if (Input.GetKey(KeyCode.D)) {
					if (!goingLeft && !goingUp && !goingDown) {
						GetComponent<Rigidbody2D>().AddForce(Vector2.right * playerSpeedOnSB);
						GetComponent<Rigidbody2D>().velocity = constantSpeedOnSB * (GetComponent<Rigidbody2D>().velocity.normalized);
						//set direction player is currently going
						goingRight = true;
						goingLeft = false;
						goingUp = false;
						goingDown = false;
						//unflip player
						transform.rotation = new Quaternion(0,0,0,0);
					}
					//set direction player is facing
					facingRight = true;
					//fix bug when shooting hookShot on an angle (prevents this)
					facingLeft = false;
					facingUp = false;
					facingDown = false;
				}
				if (Input.GetKey(KeyCode.A)) {
					if (!goingRight && !goingUp && !goingDown) {
						GetComponent<Rigidbody2D>().AddForce(-Vector2.right * playerSpeedOnSB);
						GetComponent<Rigidbody2D>().velocity = constantSpeedOnSB * (GetComponent<Rigidbody2D>().velocity.normalized);	
						goingLeft = true;
						goingRight = false;
						goingUp = false;
						goingDown = false;
						//flip player
						transform.rotation = new Quaternion(0,180,0,0);
					}
					facingLeft = true;
					facingRight = false;
					facingUp = false;
					facingDown = false;
				}
				if (Input.GetKey(KeyCode.W)) {
					if (!goingLeft && !goingRight && !goingDown) {
						GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerSpeedOnSB);
						GetComponent<Rigidbody2D>().velocity = constantSpeedOnSB * (GetComponent<Rigidbody2D>().velocity.normalized);	
						goingUp = true;
						goingRight = false;
						goingLeft = false;
						goingDown = false;
					}
					facingUp = true;
					facingRight = false;
					facingLeft = false;
					facingDown = false;
				}
				if (Input.GetKey(KeyCode.S)) {
					if (!goingLeft && !goingUp && !goingRight) {
						GetComponent<Rigidbody2D>().AddForce(-Vector2.up * playerSpeedOnSB);
						GetComponent<Rigidbody2D>().velocity = constantSpeedOnSB * (GetComponent<Rigidbody2D>().velocity.normalized);
						goingDown = true;
						goingRight = false;
						goingLeft = false;
						goingUp = false;
					}
					facingDown = true;
					facingUp = false;
					facingRight = false;
					facingLeft = false;
				}
				//CUSTOM ANGLED MOVEMENTS
				if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)) {
					if (!goingLeft && !goingDown) {
						GetComponent<Rigidbody2D>().AddForce((Vector2.right+Vector2.up) * playerSpeedOnSB);
						GetComponent<Rigidbody2D>().velocity = constantSpeedOnSB * (GetComponent<Rigidbody2D>().velocity.normalized);
						goingRight = true;
						goingUp = true;
						goingLeft = false;
						goingDown = false;
						facingRight = true;
						//part of fix to prevent angled hookShot
						facingLeft = false;
						facingUp = false;
						facingDown = false;
						transform.rotation = new Quaternion(0,0,0,0);
					}
				}
				if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)) {
					if (!goingLeft && !goingUp) {
						GetComponent<Rigidbody2D>().AddForce((Vector2.right-Vector2.up) * playerSpeedOnSB);
						GetComponent<Rigidbody2D>().velocity = constantSpeedOnSB * (GetComponent<Rigidbody2D>().velocity.normalized);
						goingRight = true;
						goingDown = true;
						goingLeft = false;
						goingUp = false;
						facingRight = true;
						facingLeft = false;
						facingUp = false;
						facingDown = false;
						transform.rotation = new Quaternion(0,0,0,0);
					}
				}
				if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W)) {
					if (!goingRight && !goingDown) {
						GetComponent<Rigidbody2D>().AddForce((-Vector2.right+Vector2.up) * playerSpeedOnSB);
						GetComponent<Rigidbody2D>().velocity = constantSpeedOnSB * (GetComponent<Rigidbody2D>().velocity.normalized);
						goingLeft = true;
						goingUp = true;
						goingRight = false;
						goingDown = false;
						facingLeft = true;
						facingRight = false;
						facingUp = false;
						facingDown = false;
						transform.rotation = new Quaternion(0,180,0,0);
					}
				}
				if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S)) {
					if (!goingRight && !goingUp) {
						GetComponent<Rigidbody2D>().AddForce((-Vector2.right-Vector2.up) * playerSpeedOnSB);
						GetComponent<Rigidbody2D>().velocity = constantSpeedOnSB * (GetComponent<Rigidbody2D>().velocity.normalized);
						goingLeft = true;
						goingDown = true;
						goingRight = false;
						goingUp = false;
						facingLeft = true;
						facingRight = false;
						facingUp = false;
						facingDown = false;
						transform.rotation = new Quaternion(0,180,0,0);
					}
				}
		}
		//TRACK TO STOP MOVEMENT
		if (Input.GetKeyUp(KeyCode.D)) {
			goingRight = false;
		}
		if (Input.GetKeyUp(KeyCode.A)) {
			goingLeft = false;
		}
		if (Input.GetKeyUp(KeyCode.W)) {
			goingUp = false;
		}
		if (Input.GetKeyUp(KeyCode.S)) {
			goingDown = false;
			}// 
		if (!goingRight && !goingLeft && !goingUp && !goingDown && !Death.playerOnSB) {
			//STOP MOVEMENT
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		}

		if (Input.GetKeyDown(KeyCode.Space) && !PauseMenu.paused) {
			if (hookShot == null) {
				//makes hookShot
				hookShot = (GameObject)Instantiate (Resources.Load ("endChain"));
				AudioSource.PlayClipAtPoint(shootSound, transform.position,volume);
			}
			hitSpace = true;
		}
		if (Input.GetKeyUp(KeyCode.Space)) {
			//stops spamming of hookShot
			hitSpace = false;
		}
	}
	//FREEZE
	if (freeze && !Death.dead) {
		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	}
	}
	void OnCollisionStay2D(Collision2D other) {
		//stores object names player is touching to compare to object hookShot is touching
		if (other.gameObject.tag == "hookShot") {
			if (collisionNames[1] == null) { 
				collisionNames[1] = other.collider.name;
			}
			if (collisionNames[2] == null && other.collider.name != collisionNames[1]) { 
				collisionNames[2] = other.collider.name;
			}
			if (collisionNames[3] == null && other.collider.name != collisionNames[2]) { 
				collisionNames[3] = other.collider.name;
			}
			if (collisionNames[4] == null && other.collider.name != collisionNames[3]) { 
				collisionNames[4] = other.collider.name;
			}
		}
	}
	void OnCollisionExit2D(Collision2D other) {
		if (other.gameObject.tag == "hookShot") {
			//reset array of object names player is touching
			collisionNames = new string[numObjectsTouching];
		}
	}
}
