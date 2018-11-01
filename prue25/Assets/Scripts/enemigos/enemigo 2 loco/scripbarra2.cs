using UnityEngine;
using System.Collections;

public class scripbarra2 : MonoBehaviour {

	public scriptsegun scriptdañoseg;
	private float vidaent;
	private float vidagolprrr;
	private float resultado;
	// Use this for initialization
	void Start () {
		scriptdañoseg= this.gameObject.GetComponentInParent<scriptsegun>();
		
		vidaent = scriptdañoseg.vida;
	               }
	
	// Update is called once per frame
	void Update () {
		vidagolprrr = scriptdañoseg.vida;
		
		if(vidagolprrr <=0)vidagolprrr=0 ;
		
		this.gameObject.transform.localScale= new Vector2(vidagolprrr / vidaent,1) ;
		
		
	}
}
