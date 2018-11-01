using UnityEngine;
using System.Collections;

public class scripcalavera : MonoBehaviour {
	public GUI1 scguicala;
	public GameObject guica;
	// Use this for initialization
	void Start () {
		guica = GameObject.Find ("Main Camera");
		scguicala= guica.GetComponent<GUI1>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D recive){
		string tag = recive.tag;
		if (tag == "Player") {
			scguicala.extras++;
			scguicala.puntuacion+=100;
			Destroy(this.gameObject);
			
		}
		
		if (tag == "suelo") {
			this.rigidbody2D.isKinematic=true;
			
		}

	}


}
