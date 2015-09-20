public class OptionsTwo : MonoBehaviour {
	public AudioClip mouseOver;
	public AudioClip select;
	public GameObject pauseMenu; 
	public GameObject Button1;
	public GameObject Button2;
	public GameObject Button3;
	public GameObject Button4;
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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void MouseEnter() {
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(mouseOver, transform.position,Player.volume);
		Time.timeScale = 0;
	}
	public void GoBack() {
		//disable options2 menu completely
		Options2.GetComponent<Canvas>().enabled = false;
		OButton1.GetComponent<Button>().interactable = false;
		OButton2.GetComponent<Button>().interactable = false;
		transform.GetComponent<Button>().interactable = false;
		//enable pause menu completely
		pauseMenu.GetComponent<Canvas>().enabled = true;
		Button1.GetComponent<Button>().interactable = true;
		Button2.GetComponent<Button>().interactable = true;
		Button3.GetComponent<Button>().interactable = true;
		Button4.GetComponent<Button>().interactable = true;
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(select, transform.position,Player.volume);
		Time.timeScale = 0;
	}
	public void ListOfControls() {
		//disable options2 menu completely
		Options2.GetComponent<Canvas>().enabled = false;
		OButton1.GetComponent<Button>().interactable = false;
		OButton2.GetComponent<Button>().interactable = false;
		transform.GetComponent<Button>().interactable = false;
		//enable list of controls screen completely
		losMenu.GetComponent<Canvas>().enabled = true;
		losButton1.GetComponent<Button>().interactable = true;
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(select, transform.position,Player.volume);
		Time.timeScale = 0;
	}
	public void SoundOptions() {
		//disable options2 menu completely
		Options2.GetComponent<Canvas>().enabled = false;
		OButton1.GetComponent<Button>().interactable = false;
		OButton2.GetComponent<Button>().interactable = false;
		transform.GetComponent<Button>().interactable = false;
		//enable sound options menu completely
		soundOptions.GetComponent<Canvas>().enabled = true;
		soundButton1.GetComponent<Button>().interactable = true;
		slider.GetComponent<Slider>().interactable = true;
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(select, transform.position,Player.volume);
		Time.timeScale = 0;
	}
}
