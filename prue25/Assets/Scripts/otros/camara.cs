using UnityEngine;
using System.Collections;

public class camara : MonoBehaviour {

	public GameObject localizador;
	private Transform posicionave;

	public int posx =10;
	public int posy=10;
	public int posz=-1;

	public float actual;
	public float ult;
	public scriptavepadre cam;


	// Use this for initialization
	void Start () {
				localizador = GameObject.Find ("Avepadre");
				posicionave = localizador.GetComponent<Transform> ();
				
				
		}
	// Update is called once per frame
	void Update (){ /*
		actual= posicionave.transform.position.y;
		ult = actual;


		if (actual > ult) {
			Debug.Log("na no piro");
						if (actual > 19) {
								posy++;
						}
				} else if (ult > actual) {
			                  if(ult>19){
				posy--;
			                            }

				                  }
				                  */
		transform.position = new Vector3 (posicionave.transform.position.x+posx,+posy, posicionave.transform.position.z+posz);


	}


}
