using UnityEngine;
using System.Collections;

public class scripbala : MonoBehaviour {
	public Vector2 direccion = Vector2.zero;
	public float rapvelocidad = 30.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

			transform.Translate(direccion.normalized * Time.deltaTime * rapvelocidad);
			
			

	}

	public void disparo(Vector2 dir, bool derecha ){
		
		
		if (!derecha) this.transform.localScale = new Vector2(-1,1);
		
		direccion = dir;

		//_velocidad =  velocidad;
	}

	void OnCollisionEnter2D(Collision2D coll){
		Destroy(this.gameObject);
	}
}
