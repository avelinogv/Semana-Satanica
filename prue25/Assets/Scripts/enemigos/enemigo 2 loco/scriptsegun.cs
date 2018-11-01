using UnityEngine;
using System.Collections;

public class scriptsegun : MonoBehaviour {
	
	public GameObject player;
	public Animator animacion;
	public float velocidad = 6f;
	public float distancia ;
	public float rangoVision = 20.0f;

	public bool reciviendogolpe= false;
	public int vida =5;
	public scriptavepadre scripdaño;
	public bool reciviendodaño=false;


	public GameObject prefab;
	public GUI1 scguiene2;
	public GameObject guiene2;
	public bool muerto=false;
	public GameObject itemyo,itemguante,itempuntuacion;
	
	// Use this for initialization
	void Start () {
		guiene2= GameObject.Find("Main Camera");
		scguiene2 = guiene2.GetComponent<GUI1> ();
	
	// Use this for initialization

		player = GameObject.Find("Avepadre");
		scripdaño=player.GetComponent<scriptavepadre>();
		animacion= this.gameObject.GetComponent<Animator>();

	
		
	}
	
	
	void  FixedUpdate(){
	
		
		
		
	}
	// Update is called once per frame
	void Update () {
		animacion.SetBool("ataca",false);
		animacion.SetBool("daño",false);
		
		if (reciviendodaño) {
			animacion.SetBool("daño",true);
			reciviendodaño=false;
		}
		comportamiento();
		
		
		
		if (muerto == false) {
						if (vida <= 0) {
								animacion.SetBool ("explosion", true);
		
								guiene2.SendMessage ("suma", 10);
								Destroy (this.gameObject, 1);
				                  instanitem();
								muerto = true;
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



	void comportamiento(){





		distancia = Vector3.Distance(this.gameObject.transform.position,
		                             player.gameObject.transform.position);
	

		Debug.DrawRay(new Vector2(transform.position.x-4,transform.position.y+5), 
		              this.gameObject.transform.right*-1 * 5.0f,
		              Color.black);
		//derecha
		Debug.DrawRay(new Vector2(transform.position.x+4,transform.position.y+5), 
		              this.gameObject.transform.right * 5.0f,
		              Color.green);
		
		RaycastHit2D visionde;
		RaycastHit2D visionizq;
		
		visionde = Physics2D.Raycast (new Vector2(transform.position.x+4,transform.position.y+5),this.gameObject.transform.right );
		visionizq = Physics2D.Raycast (new Vector2(transform.position.x-4,transform.position.y+5),this.gameObject.transform.right*-1 );
		distancia = Vector3.Distance(this.gameObject.transform.position,
		                             player.gameObject.transform.position);

	
					
						
		if ((visionde.collider.tag == "Player") && (distancia < 10)) {
			this.transform.localScale = new Vector2 (-1, 1);
						
								animacion.SetBool ("ataca", true);


			                           }
						
				                                                                
						
						
					
						if ((visionizq.collider.tag == "Player") && (distancia < 10)) {
								this.transform.localScale = new Vector2 (1, 1);
						
								animacion.SetBool ("ataca", true);
			                         
		
						}
				                                                                    
				
	}


	public void instanciandodisparo(){
		GameObject Misil;
		Misil = Instantiate(prefab,new Vector2(this.transform.position.x,this.transform.position.y+6),
		                    transform.rotation)as GameObject;
		
		scripbala gs = Misil.GetComponent<scripbala>();
		
		if (this.transform.localScale.x >0){
			
			gs.disparo(Vector2.right* -1, true);
			
			
		}else{
			
			gs.disparo(Vector2.right , false);
		}
	}



	void OnTriggerEnter2D(Collider2D recive){
				string tag = recive.tag;
		if (tag == "enemigo4") {
			vida -=5;
			reciviendodaño=true;
		}

				if (tag == "guan") {
		
			if(scguiene2.guantesnum>=6){
				vida =-30;
				reciviendodaño=true;
			}else{


						Debug.Log("guante a enemigo 1");
						vida --;
			reciviendodaño=true;
			}
			}

		if (tag == "Avelino") {
			Debug.Log("guante a enemigo 1");
	
			if(scripdaño.numataque==1){
				Debug.Log("la volteleta quita 1 al loco");
				reciviendodaño=true;
				vida-=1;
			}
			if(scripdaño.numataque==2){
				Debug.Log("la Patada quita 5 al loco");
				reciviendodaño=true;
				vida-=5;
				
			}




			reciviendodaño=true;
		} 
		}

}