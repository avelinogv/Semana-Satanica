using UnityEngine;
using System.Collections;

public class scriptgordo : MonoBehaviour {

	
	public GameObject playyer;
	public Animator animaciongordo;
	public float velocidad = 6f;
	public float distancia ;
	public float rangoVision = 15.0f;
	public bool activo = false;
	public int dirrecion =1;
	public bool chocopared=false;
	public bool reciviendogolpe= false;
	public int vida =30;
	public scriptavepadre scripdaño;
	public bool reciviendodaño=false;
	public GameObject barrafull;
	public GameObject barra;

	public GUI1 scguiene3;
	public GameObject guiene3;
	public bool muerto=false;
	public int boxeo=0;
	public GameObject itemyo,itemguante,itempuntuacion;
	public AudioSource speaker;
	public AudioClip[] Sonido;


	// Use this for initialization
	void Start () {
		guiene3= GameObject.Find("Main Camera");
		scguiene3 = guiene3.GetComponent<GUI1> ();

	
		playyer = GameObject.Find("Avepadre");
		scripdaño=playyer.GetComponent<scriptavepadre>();
		animaciongordo= this.gameObject.GetComponent<Animator>();

	
		
	}



	// Update is called once per frame
	void Update () {
		animaciongordo.SetBool("ataque",false);
		animaciongordo.SetBool("daño",false);
		boxeo = scripdaño.guante;

		if (reciviendodaño) {
			animaciongordo.SetBool("daño",true);
			reciviendodaño=false;
				}
		comportamiento();

		
		
		
		if (muerto == false) {
			if (vida <= 0) {
				animaciongordo.SetBool ("muere", true);
				
				guiene3.SendMessage ("suma", 30);
				instanitem();
				Destroy (this.gameObject, 1);
				muerto = true;
			}
			
		}

		
		
		
		

	}             
	
	
	
	void comportamiento(){
		//izquierda
		Debug.DrawRay(new Vector2(transform.position.x-5,transform.position.y), 
		              this.gameObject.transform.right*-1 * 5.0f,
		              Color.black);
		//derecha
		Debug.DrawRay(new Vector2(transform.position.x+5,transform.position.y+1), 
		              this.gameObject.transform.right * 5.0f,
		              Color.green);
		
		RaycastHit2D visionde;
		RaycastHit2D visionizq;
		
		visionde = Physics2D.Raycast (new Vector2(transform.position.x+5,transform.position.y),this.gameObject.transform.right );
		visionizq = Physics2D.Raycast (new Vector2(transform.position.x-5,transform.position.y),this.gameObject.transform.right*-1 );
		distancia = Vector3.Distance(this.gameObject.transform.position,
		                             playyer.gameObject.transform.position);
		if (distancia < rangoVision) {
			activo = true;

			animaciongordo.SetBool("anda",true);
			barra.SetActive(true);
			barrafull.SetActive(true);
		}
		if (activo == true) {
			
			
			if (dirrecion == 1) {
				
				if (chocopared==true){
					dirrecion = 2;
					chocopared=false;
				} 
				else{
					
					//lo ve por la derecha y aumenta la velocidad
					if ((visionde.collider.tag == "Player") && (distancia< 10)){

						
						animaciongordo.SetBool("ataque",true);
						Debug.Log ("Gordo inicia ataque al player por la derecha");

					
							                   
						
					}else{ //no ve nada y anda normal

						this.transform.Translate (new Vector2 (velocidad* Time.deltaTime, 0));                                
						this.transform.localScale = new Vector2 (-1, 1);

					}
					
				}
				
				
			}else {
				if (chocopared==true){
					dirrecion = 1;
				chocopared=false;
				} 

				if ((visionizq.collider.tag == "Player") && (distancia< 10)){

					animaciongordo.SetBool("ataque",true);
					Debug.Log ("Gordo inicia ataque al player por la izquierda");


				}else{ //no ve nada y anda normal

					this.transform.Translate (new Vector2 (-velocidad* Time.deltaTime, 0));                                
					this.transform.localScale = new Vector2 (1, 1);

				}
				
			}
		}
	}
	

	
	public void instanitem(){
		
		int numero;
		numero = Random.Range (1, 10);
		if ((numero == 1) || (numero == 2) || (numero == 3)) {
			
			Instantiate (itemyo, new Vector2 (this.transform.position.x, this.transform.position.y + 12),
			             transform.rotation);
		}
		
		
		if ((numero == 4) || (numero == 5) || (numero == 6)) {
			Instantiate (itemguante, new Vector2 (this.transform.position.x, this.transform.position.y + 12),
			             transform.rotation);
		}
		
		if ((numero == 7) || (numero == 8) || (numero == 9)) {
			Instantiate (itempuntuacion, new Vector2 (this.transform.position.x, this.transform.position.y + 12),
			             transform.rotation);
		}
	}




	void OnCollisionEnter2D(Collision2D choque3) {

		if (choque3.collider.tag == "Pared"){
			Debug.Log ("me choco contra enemigos");
			chocopared = true;
		}

		if((choque3.collider.tag=="enemigo")||(choque3.collider.tag=="enemigo1")) {
			Debug.Log ("me choco contra enemigos");
			chocopared = true;
		}

		
	}
	
	public void martillo(){
		speaker.PlayOneShot(Sonido[2]);
	}
	public void explosionson(){

		speaker.PlayOneShot(Sonido[1]);
		}
	//pegando al enemigo a traves de su triguer
	void OnTriggerEnter2D(Collider2D rec3){
				string tag = rec3.tag;
		if (tag == "enemigo4") {
			vida -=10;
			reciviendodaño=true;
				}
		if (tag == "guan") {
		
			if(boxeo>=6){
				vida=-30;
			
			}else{
			vida --;
			reciviendodaño=true;
			      }
		}
				if (tag == "Avelino") {

			if(scripdaño.numataque==1){
				Debug.Log("la volteleta quita 1 al gordo");
				reciviendodaño=true;
				vida--;
			}
			if(scripdaño.numataque==2){
				speaker.PlayOneShot(Sonido[0]);
				Debug.Log("la Patada quita 5 al gordo");
				reciviendodaño=true;
				vida-=5;
				
			}

		}
	}
}