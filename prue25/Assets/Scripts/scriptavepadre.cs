using UnityEngine;
using System.Collections;

public class scriptavepadre : MonoBehaviour {


	public int vida =30;
	public int velandar=10;
	public int correr;
	public float anda;
	public float salta;
	public float ataco;
	public int numataque=0;
	public int contadorfu;
	public bool puedesaltar=true;
	public avel scriphijo;
	public int fuerzasalto=600;
	bool doblesalto=true;
	private bool animaciondaño=false;
	public bool pared= false;
	public int guante=0;
	public int creditos=3;
	public int miniitemyo=0;
	public new Vector2 spawn;
	public AudioSource speaker;
	public AudioClip[] Sonido;


	void Start () {
		spawn=new Vector2(29.31534f,1.045287f);
		scriphijo = GetComponentInChildren<avel>();
	
	   
	}

	void FixedUpdate(){
		if ((animaciondaño)&&(vida>=0)){
			scriphijo.daño();
			animaciondaño=false;
		}
	}



	// Update is called once per frame
	void Update () {

		scriphijo.nowalk ();
		scriphijo.nosprint ();
		scriphijo.nodaño();
		scriphijo.nomatao ();
		if (miniitemyo >= 8) {
			creditos++;

				}


		credit ();
		muero ();
		mando ();
		andar ();      
		ataque ();  

	
	}
	void sumamini(bool coge){
		if (coge) {
			miniitemyo++;
						vida += 5;
						if (vida > 30)vida = 30;
						
				}
	}


	void mando(){

		anda = Input.GetAxis("Horizontal");
		salta = Input.GetAxis("Vertical");
		ataco = Input.GetAxis("ataque");

	}
	
	void acciones(){
		
		andar ();

		
		
	               }

	void ataque(){

		if(ataco!=0 && numataque==1){
			Debug.Log("doi volteleta");
			scriphijo.voltea();
		}
		else scriphijo.novoltea();
		
		if(ataco!=0 && numataque==2){
			scriphijo.pierna();
            if(doblesalto){
			rigidbody2D.AddForce (new Vector2 (0, 600));
				doblesalto=false;              
			}

		}
		else scriphijo.nopierna();
		
		if ((ataco != 0) && (numataque == 3)&&(anda==0)) {

						scriphijo.ko ();
			
				} else
						scriphijo.noko ();
		
	}

	void saltar (int fuerzasalto){
		if ((salta > 0.1) && (puedesaltar == true)) {
			scriphijo.jump ();
			
					
			if(anda>0){

				rigidbody2D.AddForce (new Vector2 (300, fuerzasalto));
			           }
			else if (anda <0){
				rigidbody2D.AddForce (new Vector2 (-300, fuerzasalto));
			                 }
			else{
				rigidbody2D.AddForce (new Vector2 (0, fuerzasalto));
			}
			puedesaltar = false;
			
			
			
				} else
						scriphijo.nojump ();
		if(rigidbody2D.velocity.y<0)rigidbody2D.AddForce (new Vector2 (0, -fuerzasalto));
	}
	
	public void dañandome(){
		scriphijo.daño ();
		
	}
	
	void andar(){
		//Estando en el suelo
		if (puedesaltar) {
			
			if (anda != 0) {
				//correr	
				numataque=1;
				if (Input.GetAxis("correr")!=0){
					scriphijo.sprint();
					saltar (1000+contadorfu*2);

					velandar=15;
				                                }
				
				//andar
				else {            			
					velandar=6;
					scriphijo.walk ();

					saltar (300);
				
				}       
				contadorfu++;
				if (anda > 0) {

					this.transform.localScale = new Vector2 (1, 1);

					this.transform.Translate(new Vector2(velandar*Time.deltaTime,0));

				} else {

					this.transform.localScale = new Vector2 (-1, 1);  
				
					this.transform.Translate(new Vector2(-velandar*Time.deltaTime,0));

				}
		
			}else{
				saltar (500);
			numataque=3;
			}
		}
		else numataque=2;
	}            
	
	void cortasalto(){
	if (puedesaltar) scriphijo.nojump();
	}

	void credit(){
		if (miniitemyo>= 8) {
			creditos++;
			miniitemyo=0;
				     }


		}


	void muero(){
				if (vida <= 0) {

		
		                   
					

						//Destroy(this.gameObject);
		
				
						scriphijo.matao ();
					

					

				}
		}


	public void sonpatada(){
		speaker.volume=1f;
		speaker.PlayOneShot(Sonido[0]);
		}

	void OnTriggerEnter2D(Collider2D duele){
				string tag = duele.tag;
				if (tag == "cabeza") {
			scriphijo.daño();
			animaciondaño=true;
			Debug.Log ("recive un misil y le quita 2");			
			vida-=2;
				}

	}


	void OnTriggerStay2D(Collider2D duele){
		string tag = duele.tag;
		if (tag == "Pared") {
			pared=true;
		}
		
	}


	void OnTriggerExit2D(Collider2D duele){
		string tag = duele.tag;
		if (tag == "Pared") {
			pared=false;
		}
		
	}


	void OnCollisionEnter2D(Collision2D cosa) {

		if (cosa.collider.tag == "tercerhijo") {
			animaciondaño=true;
					
			vida--;
		}


		if (cosa.collider.tag == "enemigo1") {
			animaciondaño=true;
			Debug.Log ("pega enemigo 1 y quita 1");			
			vida--;
		}

		if (cosa.collider.tag == "enemigo3") {
			animaciondaño=true;
			Debug.Log ("pega enemigo 1 y quita 1");			
			vida-=3;
		}


		if (cosa.collider.tag == "enemigo4") {
			animaciondaño=true;
			vida-=10;
			Debug.Log ("recive una explosion y quita 10");			
			
		}

		if (cosa.collider.tag == "helice") {
			animaciondaño=true;
			vida-=10;		
			
		}


		if (cosa.transform.tag == "suelo") {
			Debug.Log("Pisando plataforma");
			Debug.Log ("listo para salto");			
			puedesaltar = true;
			contadorfu=0;
			doblesalto=true;
		}
	
	
	
	}




}



