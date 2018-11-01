using UnityEngine;
using System.Collections;

public class Lapida : MonoBehaviour {
	public Animator meneo;
	// Use this for initialization
	void Start () {
		meneo=this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	



	}

	void OnTriggerEnter2D(Collider2D detecto){
		string tag = detecto.tag;
		if (tag == "Player") {
			meneo.SetBool("activa",true);

		}
		
	}


}
