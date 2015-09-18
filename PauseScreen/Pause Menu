	public AudioClip mouseOver;
	public AudioClip select;
	public GameObject pauseMenu; 
	public GameObject Button1;
	public GameObject Button2;
	public GameObject Button3;
	public GameObject Options2;
	public GameObject OButton1;
	public GameObject OButton2;
	public GameObject OButton3;
	public GameObject losMenu;
	public GameObject losButton1;
	public GameObject soundOptions;
	public GameObject soundButton1;
	public GameObject slider;
	// Use this for initialization
	void Start () {
		paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		//PAUSING
		if (Input.GetKeyDown(KeyCode.Escape)) {
			paused = !paused;
			if (paused) {
				Debug.Log("pause");
				AudioSource.PlayClipAtPoint(pauseSound, transform.position,Player.volume);
				Time.timeScale = 0;
				Player.freeze = true;
				//show pause screen
				pauseMenu.GetComponent<Canvas>().enabled = true;
				Button1.GetComponent<Button>().interactable = true; 
				Button2.GetComponent<Button>().interactable = true; 
				Button3.GetComponent<Button>().interactable = true; 
				transform.GetComponent<Button>().interactable = true; 
			}
			if (!paused) {
				Debug.Log("unpause");
				//hide pause screen
				pauseMenu.GetComponent<Canvas>().enabled = false;
				Button1.GetComponent<Button>().interactable = false; 
				Button2.GetComponent<Button>().interactable = false; 
				Button3.GetComponent<Button>().interactable = false; 
				transform.GetComponent<Button>().interactable = false;
				//hide options screen
				Options2.GetComponent<Canvas>().enabled = false;
				OButton1.GetComponent<Button>().interactable = false;
				OButton2.GetComponent<Button>().interactable = false;
				OButton3.GetComponent<Button>().interactable = false; 
				//hide list of controls screen
				losMenu.GetComponent<Canvas>().enabled = false;
				losButton1.GetComponent<Button>().interactable = false;
				//hide sound options
				soundOptions.GetComponent<Canvas>().enabled = false;
				soundButton1.GetComponent<Button>().interactable = false;
				slider.GetComponent<Slider>().interactable = false;
				Time.timeScale = 1;
				AudioSource.PlayClipAtPoint(unpauseSound, transform.position,Player.volume);
				if (!HookShot.shooting && !HookShot.missedHook && !HookShot.hitSomething) {
					//prevent bug because hookShot freezes you
					Player.freeze = false;
				}
				
			}
		}

	}
	public void Resume() {
		//RESUME BUTTON IN PAUSE MENU
		paused = false;
		pauseMenu.GetComponent<Canvas>().enabled = false;
		Button1.GetComponent<Button>().interactable = false; 
		Button2.GetComponent<Button>().interactable = false; 
		Button3.GetComponent<Button>().interactable = false; 
		transform.GetComponent<Button>().interactable = false; 
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(unpauseSound, transform.position,Player.volume);
		if (!HookShot.shooting && !HookShot.missedHook && !HookShot.hitSomething) {
			Player.freeze = false;
		}
	}
	public void MouseEnter() {
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(mouseOver, transform.position,Player.volume);
		Time.timeScale = 0;
	}
	public void ChangeScene(int newSceneNum) {
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(select, transform.position,Player.volume);
		Application.LoadLevel(newSceneNum);
	}
	public void Exit() {
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(select, transform.position,Player.volume);
		Application.Quit();
	}
	
	public void OptionsTwo() {
		//disable pause menu completely
		pauseMenu.GetComponent<Canvas>().enabled = false;
		Button1.GetComponent<Button>().interactable = false;
		Button2.GetComponent<Button>().interactable = false;
		Button3.GetComponent<Button>().interactable = false;
		transform.GetComponent<Button>().interactable = false;
		//enabled options2 menu completely
		Options2.GetComponent<Canvas>().enabled = true;
		OButton1.GetComponent<Button>().interactable = true;
		OButton2.GetComponent<Button>().interactable = true;
		OButton3.GetComponent<Button>().interactable = true;
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(select, transform.position,Player.volume);
		Time.timeScale = 0;
		
	}
}
