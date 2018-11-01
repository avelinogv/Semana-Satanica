
using UnityEngine;
using System.Collections;

public class avel : MonoBehaviour {

	public Animator Animacion;
	public GameObject prefabguante;
	public GameObject papi;
	public scriptavepadre scrippapihijo;

	void Start () {
		papi= GameObject.Find("Avepadre");
		scrippapihijo= papi.GetComponent<scriptavepadre>();               
	}
	void FixedUpdate(){

	                  }
	
	// Update is called once per frame
	void Update () {
		
		

	                }

	public void walk(){
		Animacion.SetBool("andar",true);
	}
	public void nowalk(){
		Animacion.SetBool("andar",false);
	}
	public void sprint(){
		Animacion.SetBool("correr",true);
	}
	public void nosprint(){
		Animacion.SetBool("correr",false);
	}

	public void jump(){
		Animacion.SetBool("salto",true);
	}


	public void nojump(){
		Animacion.SetBool("salto",false);
	}


	public void voltea(){
		Animacion.SetBool("volteleta",true);
	}	
	public void novoltea(){
		Animacion.SetBool("volteleta",false);
	}
	public void ko(){
		Animacion.SetBool("puño",true);
	}

	public void noko(){
		Animacion.SetBool("puño",false);
	}

	public void pierna(){

		Animacion.SetBool("patada",true);
	               }

	public void nopierna(){
		Animacion.SetBool("patada",false);
	}

	 public void daño(){
		Animacion.SetBool("daño",true);
	}

	public void nodaño(){
		Animacion.SetBool("daño",false);
	}

	public void matao(){
		Animacion.SetBool("morir",true);
		                }

	public void nomatao(){
		Animacion.SetBool("morir",false);
	
	}



	public void muereanimacion(){

		if (scrippapihijo.creditos <= 0) {
						Destroy (papi.gameObject);
				} else {
						papi.transform.position = scrippapihijo.spawn;
			              scrippapihijo.vida=30;
			             scrippapihijo.creditos--;
				}
	


		}


	
	
	void OnCollisionEnter2D(Collision2D cosa) {

		if(scrippapihijo.numataque==2)scrippapihijo.sonpatada ();

		}



	public void instanciandoguante(){
		GameObject pum;

	
		if (papi.transform.localScale.x >0){
			pum = Instantiate(prefabguante,new Vector2(this.transform.position.x+3,this.transform.position.y+2),
			                    transform.rotation)as GameObject;
			scriptguante gs = pum.GetComponent<scriptguante>();
			gs.lanzaguante(Vector3.right, true);
		}else{ 
			pum = Instantiate(prefabguante,new Vector2(this.transform.position.x-3,this.transform.position.y+2),
			                  transform.rotation)as GameObject;
			scriptguante gs = pum.GetComponent<scriptguante>();
			gs.lanzaguante(Vector3.right*-1, false);
		
	          }

	}

	
}
