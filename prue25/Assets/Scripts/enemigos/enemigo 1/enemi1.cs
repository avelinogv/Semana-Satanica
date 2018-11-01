using UnityEngine;
using System.Collections;

public class enemi1 : MonoBehaviour {
	public Animator animacion1;
	public bool chocopared= false;
	public bool reciviendogolpe=false;
	public bool dandogolpe=false;
	public int vida=10;
	public GameObject Avepadre;
	public scriptavepadre scripdaño;

	public GameObject gamepadre1;
	public primerenepadrecon scrippadre1;




	// Use this for initialization
	void Start () {
		gamepadre1 = GameObject.FindGameObjectWithTag ("enemigo");
		animacion1=this.gameObject.GetComponent<Animator>();
		Avepadre = GameObject.Find ("Avepadre");
		scripdaño=Avepadre.GetComponent<scriptavepadre>();
		scrippadre1 = gamepadre1.GetComponent<primerenepadrecon>();

	

	}
	
	// Update is called once per frame
	void Update () {
	
	}





	public void ataque1(){
				animacion1.SetBool ("ataque", true);
		}
	public void ataque1no(){
		animacion1.SetBool ("ataque", false);
	}

	public void daño(){
		animacion1.SetBool ("golpe",true);
	}
	public void nodaño(){
		animacion1.SetBool ("golpe",false);
	}
	 public void muerteene1(){
		animacion1.SetBool("explosion",true);
	
	
	}



	void OnCollisionEnter2D(Collision2D choque1) {
		if ((choque1.collider.tag == "Pared")||(choque1.collider.tag=="enemigo")||(choque1.collider.tag=="enemigo1")||(choque1.collider.tag=="tercerhijo")) {
						Debug.Log ("me choco");
						chocopared = true;
				}



		                                            }
	

	
	//pegando al enemigo a traves de su triguer
	void OnTriggerEnter2D(Collider2D recive){
		string tag = recive.tag;

		if (tag == "enemigo4") {
			vida -=5;
			reciviendogolpe=true;
		}

						
		if(tag=="Avelino"){
			print("Haciendo daño al enemigo 1");
			reciviendogolpe=true;

			if(scripdaño.numataque==1){
				Debug.Log("la volteleta quita 1 de vida");
			vida--;
			                            }
			if(scripdaño.numataque==2){
				Debug.Log("la Patada quita 5 de vida");

				vida-=5;


			}
		}

	}


}
