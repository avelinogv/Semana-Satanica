using UnityEngine;
using System.Collections;

public class scroller : MonoBehaviour {
	public GameObject personaje;
	
	public scriptavepadre cojo;
	public float x;
	public float increment;
	public float fondoz;
	public float y=0f;
	// Use this for initialization
	void Start () {
		personaje = GameObject.Find ("Avepadre");
		cojo= personaje.GetComponent<scriptavepadre>();
		x = 0;
	}
	
	// Update is called once per frame
	void Update () {

		
		if ((cojo.anda> 0)&&(cojo.puedesaltar)&&(cojo.pared==false)) {


			if(Input.GetAxis("correr")!=0){

			x+=increment;
			if(x>1.0f){
				x-=1.0f;
			}
			}else{
					x+=increment/2;
					if(x>1.0f){
						x-=1.0f;
					}
				     }
			
			
			            
			
			
			}
		
		else if ((cojo.anda  < 0)&&(cojo.puedesaltar)&&(cojo.pared==false)) {



			if(Input.GetAxis("correr")!=0){
			x-=increment;
			if(x>1.0f){
				x+=1.0f;
			           }
			                              
			}else{
				x-=increment/2;
				if(x>1.0f){
					x+=1.0f;
				}
			                                    }
			}
		
		
		
		transform.position = new Vector3 (personaje.transform.position.x,y,fondoz);
		
		renderer.sharedMaterial.SetTextureOffset ("_MainTex",new Vector2(x,0));

	}
}
