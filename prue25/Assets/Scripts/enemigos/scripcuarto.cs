using UnityEngine;
using System.Collections;

public class scripcuarto : MonoBehaviour {
	
	public GameObject player;
	public Animator animacion;
	public float velocidad = 12f;
	public float distancia ;
	public float rangoVision = 50.0f;
	public bool activo = false;
	public bool reciviendodaño=false;
	private bool persigue=false;

	
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Avepadre");	
	}
	
	
	void  FixedUpdate(){
		
		
		
		
	}
	// Update is called once per frame
	void Update () {
		animacion.SetBool("ataque",false);

		
	
		comportamiento();
		
		
		
		
		muerene1 ();
		
		
		
		
		
	}             
	
	
	
	void comportamiento(){

		distancia = Vector3.Distance(this.gameObject.transform.position,
		                             player.gameObject.transform.position);




				if (distancia <= rangoVision) {
						animacion.SetBool ("ataca", true);
						persigue = true;
				                              }

		if (persigue) {
		
						if (this.transform.position.x <= player.transform.position.x) {
						
								this.transform.Translate (new Vector2 (velocidad * Time.deltaTime, 0));                                
								this.transform.localScale = new Vector2 (-1, 1);
				
				
				
						} else {
				
					
								this.transform.Translate (new Vector2 (-velocidad * Time.deltaTime, 0));                                
								this.transform.localScale = new Vector2 (1, 1);
					
						}
				
				}
		}
	
	
	
	void muerene1(){
		
		if (reciviendodaño) {
			animacion.SetBool("muere",true);
			Destroy(this.gameObject,1);
			               }
		
	                }	

	
	
	void OnCollisionEnter2D(Collision2D choca) {
		
		if ((choca.collider.tag == "Pared")||(choca.collider.tag == "Player")||(choca.collider.tag == "enemi1")||
		    (choca.collider.tag == "enemigo2")||(choca.collider.tag == "tercerhijo")){
			reciviendodaño=true;
		}
		
                                                     }



}