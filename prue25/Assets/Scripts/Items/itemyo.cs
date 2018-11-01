using UnityEngine;
using System.Collections;

public class itemyo : MonoBehaviour {
	private bool suelo= false;
	public bool pared = false;
	public Animator animo;
	private int dirre = 1;
	public GameObject mini;
	public scriptavepadre scmini;


	// Use this for initialization
	void Start () {
		animo= this.GetComponent<Animator>();
		mini = GameObject.Find ("Avepadre");
		scmini=mini.GetComponent<scriptavepadre>();
	}

	// Update is called once per frame
	void Update () {

	
		if (suelo) {
			this.rigidbody2D.isKinematic=true;
						animo.SetBool ("corre", true);		
						this.transform.Translate (new Vector2 (8 * Time.deltaTime * dirre, 0));                                
						this.transform.localScale = new Vector2 (0.4f * dirre, 0.4f);
						if (pared) {
								dirre = dirre * -1;
								pared = false;
						}
				} else {
			            this.rigidbody2D.isKinematic=false;
						

		              }



	}

	void OnTriggerExit2D(Collider2D tocosue){
				string tag = tocosue.tag;
				if (tag == "suelo") {
						suelo = false;
				} 

		}

	void OnTriggerStay2D(Collider2D tocosue){
		string tag = tocosue.tag;
		if (tag == "suelo") {
			suelo= true;
		} 

	                             }

	void OnTriggerEnter2D(Collider2D recive){
				string tag = recive.tag;

		if (tag == "Pared") {
			pared = true;
				}
		                             
		if (tag == "Player") {
		
			mini.SendMessage("sumamini",true);
			Destroy (this.gameObject);
		}  

	
	                                       }



}