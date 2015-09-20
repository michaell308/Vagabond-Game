using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LosMenu : MonoBehaviour {
	public GameObject losMenu;
	public GameObject Options2;
	public GameObject OButton1;
	public GameObject OButton2;
	public GameObject OButton3;
	public AudioClip select;
	public AudioClip mouseOver;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void GoBack() {
		//disable list of controls screen completely
		losMenu.GetComponent<Canvas>().enabled = false;
		transform.GetComponent<Button>().interactable = false;
		//enable options2 menu completely
		Options2.GetComponent<Canvas>().enabled = true;
		OButton1.GetComponent<Button>().interactable = true;
		OButton2.GetComponent<Button>().interactable = true;
		OButton3.GetComponent<Button>().interactable = true;
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(select, transform.position,Player.volume);
		Time.timeScale = 0;
	}
	public void MouseEnter() {
		Time.timeScale = 1;
		AudioSource.PlayClipAtPoint(mouseOver, transform.position,Player.volume);
		Time.timeScale = 0;
	}
}
