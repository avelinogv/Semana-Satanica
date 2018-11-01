using UnityEngine;
using System.Collections;

public class scripspawn : MonoBehaviour {
	public GameObject posicionper;
	public scriptavepadre scripspawnfarol;

	// Use this for initialization
	void Start () {
		posicionper = GameObject.Find ("Avepadre");

		scripspawnfarol= posicionper.GetComponent<scriptavepadre>();
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D recive){
		string tag = recive.tag;
		if (tag == "Player") {
			scripspawnfarol.spawn=new Vector2(transform.position.x,transform.position.y);
			//audio.PlayOneShot(clipsSonido);
		}

	}
}
