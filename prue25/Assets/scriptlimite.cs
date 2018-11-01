using UnityEngine;
using System.Collections;

public class scriptlimite : MonoBehaviour {
	public GameObject limite;
	private Transform posicion;
	// Use this for initialization
	void Start () {
		limite = GameObject.Find ("Avepadre");
		posicion = limite.GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (posicion.transform.position.x,23, posicion.transform.position.z);




	}
}
