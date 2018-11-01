using UnityEngine;
using System.Collections;

public class scriptfarola : MonoBehaviour {
	public GameObject particula1;
	public GameObject particula2;
	public GameObject particula3;
	public AudioSource audio;
		// Use this for initialization
	void Start () {
		particula1.SetActive (false);
		particula2.SetActive (false);
		particula3.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D personaje){
				string tag = personaje.tag;
				if (tag == "Player") {
			audio.Play();
			particula1.SetActive (true);
			particula2.SetActive (true);
			particula3.SetActive (true);

			Debug.Log("coño enciende");
			      	
			}

		}

}
