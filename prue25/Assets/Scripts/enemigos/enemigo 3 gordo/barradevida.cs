using UnityEngine;
using System.Collections;

public class barradevida : MonoBehaviour {
	public scriptgordo scriptdañogor;
	private float vidaent;
	private float vidagolprrr;
	private float resultado;
	// Use this for initialization
	void Start () {
		scriptdañogor= this.gameObject.GetComponentInParent<scriptgordo>();
		vidaent = scriptdañogor.vida;
	
	}
	
	// Update is called once per frame
	void Update () {
		vidagolprrr = scriptdañogor.vida;


		if(vidagolprrr <=0)vidagolprrr=0 ;
		this.gameObject.transform.localScale= new Vector2(vidagolprrr / vidaent,1) ;


	}
}
