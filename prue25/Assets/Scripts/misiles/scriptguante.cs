using UnityEngine;
using System.Collections;

public class scriptguante : MonoBehaviour {
	public Vector2 dirr = Vector2.zero;
	public float guantevelocidad = 30.0f;
	public scriptavepadre scripplayer;
		public GameObject papipega;
	public bool espe=false;
	public AudioSource speaker;
	public AudioClip[] Sonido;
	public bool una=false;


	// Use this for initialization
	void Start () {
		papipega = GameObject.Find ("Avepadre");
		scripplayer=papipega.GetComponent<scriptavepadre>();
	}
	
	// Update is called once per frame
	void Update () {
		if(scripplayer.guante>=6){
			speaker.PlayOneShot(Sonido[0]);
			transform.localScale=new Vector2(5,5);
			transform.Translate(dirr.normalized * Time.deltaTime * guantevelocidad);
		
		     }
		else{
			transform.Translate(dirr.normalized * Time.deltaTime * guantevelocidad);
			if(una==false){
			speaker.PlayOneShot(Sonido[1]);
				una=true;
			              }
		     }
	
	}
	public void lanzaguante(Vector2 dir, bool derecha){
		if (!derecha) this.transform.localScale = new Vector2(-1,1);
		
		dirr = dir;
	}


	
	void OnCollisionEnter2D(Collision2D coll){
		if(scripplayer.guante>=6)scripplayer.guante=0;
		Destroy(this.gameObject);
	}

}
