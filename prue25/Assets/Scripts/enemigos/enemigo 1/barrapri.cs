using UnityEngine;
using System.Collections;

public class barrapri : MonoBehaviour {
	public enemi1 scriptdañopri;
	public GameObject barraene;
	private float vidaent;
	private float vidagolprrr;
	private float resultado;

		// Use this for initialization
		void Start () {
		barraene = GameObject.Find ("Primer");
		scriptdañopri= barraene.GetComponent<enemi1>();
			vidaent = scriptdañopri.vida;
			
		}
		
		// Update is called once per frame
		void Update () {
			vidagolprrr = scriptdañopri.vida;

		if(vidagolprrr <=0)vidagolprrr=0 ;
			
			this.gameObject.transform.localScale= new Vector2(vidagolprrr / vidaent,1) ;
			
			
		}
	}
