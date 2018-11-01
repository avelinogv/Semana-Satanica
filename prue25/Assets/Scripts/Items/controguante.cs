using UnityEngine;
using System.Collections;

public class controguante : MonoBehaviour {
	public scriptavepadre pom;
	public GameObject pam;

	// Use this for initialization
	void Start () {
		pam = GameObject.Find ("Avepadre");
		pom=pam.GetComponent<scriptavepadre>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D recive){
		string tag = recive.tag;
		if (tag == "Player") {

			pom.guante++;
			if(pom.guante>=6)pom.guante=6;
			Destroy(this.gameObject);

		}
		if (tag == "suelo") {
			this.rigidbody2D.isKinematic=true;
			
		}

}
}