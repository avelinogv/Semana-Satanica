using UnityEngine;
using System.Collections;

public class primerenepadrecon : MonoBehaviour {
	

		public GameObject player;
		
		public float velocidad = 6f;
		public float distancia ;
		public float rangoVision = 15.0f;
		public bool activo = false;
		public int dirrecion =1;
	   public enemi1 scriptene1hijo;
	public GameObject barra1, barra2;
	private bool guantazo=false;
	public GUI1 scguiene1;
	public GameObject guiene1;
	public bool muerto=false;
	public GameObject itemyo,itemguante,itempuntuacion;
		// Use this for initialization
		void Start () {
		guiene1= GameObject.Find("Main Camera");
		scguiene1 = guiene1.GetComponent<GUI1> ();
		player = GameObject.Find("Avepadre");

		scriptene1hijo = GetComponentInChildren<enemi1>();
			
			
		}
		
		// Update is called once per frame
		void Update () {
		comportamiento();
		scriptene1hijo.nodaño ();


		reciviendodañodeplayer ();

		if (muerto == false) {
			if (scriptene1hijo.vida <= 0) {
				scriptene1hijo.muerteene1();
				
				guiene1.SendMessage ("suma", 20);
				instanitem();
				Destroy (this.gameObject, 1);
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
		//izquierda
		Debug.DrawRay(new Vector2(transform.position.x-4,transform.position.y), 
		              this.gameObject.transform.right*-1 * 5.0f,
		              Color.black);
		//derecha
		Debug.DrawRay(new Vector2(transform.position.x+4,transform.position.y+1), 
		              this.gameObject.transform.right * 5.0f,
		              Color.green);
		
		RaycastHit2D visionde;
		RaycastHit2D visionizq;
		
		visionde = Physics2D.Raycast (new Vector2(transform.position.x+4,transform.position.y),this.gameObject.transform.right );
		visionizq = Physics2D.Raycast (new Vector2(transform.position.x-4,transform.position.y),this.gameObject.transform.right*-1 );
		distancia = Vector3.Distance(this.gameObject.transform.position,
		                             player.gameObject.transform.position);
		if (distancia < rangoVision) {
			activo = true;
			scriptene1hijo.ataque1();
			barra1.SetActive(true);
			barra2.SetActive(true);
		}
		if (activo == true) {

		
		if (dirrecion == 1) {
			
			if (scriptene1hijo.chocopared==true){
				dirrecion = 2;
				scriptene1hijo.chocopared=false;
			} 
			else{
				
					//lo ve por la derecha y aumenta la velocidad
					if ((visionde.collider.tag == "Player") && (distancia< 18)){
						this.transform.Translate (new Vector2 (velocidad *2* Time.deltaTime, 0));                                
						this.transform.localScale = new Vector2 (-1, 1);
						Debug.Log ("Player lo veo por la derecha asi q corro");
					                                                            
				           }else{ //no ve nada y anda normal
					           this.transform.Translate (new Vector2 (velocidad* Time.deltaTime, 0));                                
					            this.transform.localScale = new Vector2 (-1, 1);
				                 }
		
			}


	  }else {
				if (scriptene1hijo.chocopared==true){
					dirrecion = 1;
					scriptene1hijo.chocopared=false;
				} 
				//lo ve por la izquierda y aumenta la velocidad
				if ((visionizq.collider.tag == "Player") && (distancia< 18)){
					this.transform.Translate (new Vector2 (-velocidad *2* Time.deltaTime, 0));                                
					this.transform.localScale = new Vector2 (1, 1);
					Debug.Log ("Player loveo por la izquierda");
				
			}else{ //no ve nada y anda normal
				this.transform.Translate (new Vector2 (-velocidad* Time.deltaTime, 0));                                
				this.transform.localScale = new Vector2 (1, 1);
			}
		     
		    }
		}
	}




	void reciviendodañodeplayer(){		

		if ((guantazo)&&(activo)) {
			scriptene1hijo.daño ();
			guantazo=false;
				}




				if (scriptene1hijo.reciviendogolpe == true) {
								
			
						scriptene1hijo.daño ();


			if(this.transform.position.x<=player.transform.position.x){
				rigidbody2D.AddForce(new Vector2(-200,500));
				Debug.Log("ohhh no salgo volando pala izquierda");
			}
			else {
				rigidbody2D.AddForce(new Vector2(200,500));
				Debug.Log("ohhh no salgo volando pala derecha");
			}
               
                   Debug.Log ("animacion enemigo 1");
			         scriptene1hijo.reciviendogolpe = false;
				}
	}








	void OnTriggerEnter2D(Collider2D recive){
		string tag = recive.tag;

		
		if (tag == "guan") {

			if(scguiene1.guantesnum>=6){
				scriptene1hijo.vida=-30;
				guantazo=true;
			}

			else{
			Debug.LogError("guante a enemigo 1");
			scriptene1hijo.vida--;
			guantazo=true;
			    }
		
		
		
		}
		

		
	}



	
	}
				
