using UnityEngine;
using System.Collections;

public class scriptercehijo : MonoBehaviour {
	public scriptgordo scripcolision;
	// Use this for initialization
	void Start () {
		scripcolision = this.GetComponentInParent<scriptgordo>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter2D(Collision2D choque1) {
		
		if (choque1.collider.tag == "Pared"){
			Debug.Log ("me choco contra enemigos");
			scripcolision.chocopared = true;
		}
		
		if((choque1.collider.tag=="enemigo")||(choque1.collider.tag=="enemigo1")) {
			Debug.Log ("me choco contra enemigos");
			scripcolision.chocopared = true;
		}
		
		
	}

	void OnTriggerEnter2D(Collider2D recive){
				string tag = recive.tag;
				
				if (tag == "guan") {
						Debug.Log ("guante a gordo");
			if(scripcolision.activo){
			scripcolision.vida --;
			scripcolision.reciviendodaño = true;
			}
				}

		}

}
