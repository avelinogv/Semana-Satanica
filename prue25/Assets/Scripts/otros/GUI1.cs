using UnityEngine;
using System.Collections;

public class GUI1 : MonoBehaviour {
	public Texture2D linvida, boxeo , pantalla;
	public float vidapersonaje;
	public int vidaentera=30;
	public int enemigomuerto=0;
	public int extras=0;
	public float guantesnum;
	public int guantestotal=6;
	public GUISkin skin; 
	public GUISkin miedo; 
	private int tiempo;
	public float puntuacion=0;
	//texto
	public float texizqui=0f, texarriba=0f , texancho=1f,texalto=1f;
	//GUI
	public float izqui=8000f, arriba=3000f , ancho=1f,alto=1f;
	//BARRA VERDE
	public float izquis=16.42f, arribas=24f , anchos=6f,altos=25f;
	//GUANTE BOXEO
	public float izquib=47f, arribab=50f, anchob=29f,altob=100f;
	public scriptavepadre scripvida;
	public GameObject person;

	// Use this for initialization
	void Start () {
		person = GameObject.Find ("Avepadre");
		scripvida=person.GetComponent<scriptavepadre>();
	
	}
	
	// Update is called once per frame
	void Update () {
		tiempo=(int) Time.time * 1;
				vidapersonaje = scripvida.vida;
				guantesnum = scripvida.guante;


				if (vidapersonaje >= vidaentera) {
						vidapersonaje = vidaentera;
				} else if (vidapersonaje <= 0) {
						vidapersonaje = 0;
				}
	
	


	
	
				if (guantesnum == 0) {
						altob = 100;
				} else if (guantesnum > 0) {

						altob = 100 - guantesnum * 15;
				} else if (guantesnum >= 6) {
			altob=10;
				}





	


}

	void suma (int i){
		puntuacion += i;
		enemigomuerto ++;
		}


	void OnGUI(){
		GUI.skin = skin;
		//GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height),escudo);
		GUI.DrawTexture(new Rect(Screen.width / izquis,Screen.height /arribas,Screen.width / anchos/vidaentera*vidapersonaje,Screen.height / 25f),linvida);

		GUI.DrawTexture(new Rect(Screen.width / izquib,Screen.height /arribab,Screen.width / anchob, Screen.height / altob ),boxeo);
		GUI.DrawTexture(new Rect(Screen.width / izqui,Screen.height /arriba,Screen.width / ancho,Screen.height / alto),pantalla);

		//guantes
		GUI.Label(new Rect(Screen.width / 1.06f,Screen.height /1.07f,Screen.width / 1,Screen.height / 1),guantesnum+ "/6");

		//numero de muertos
		GUI.Label(new Rect(Screen.width / 1.19f,Screen.height /1.06f,Screen.width / 1,Screen.height / 1),""+enemigomuerto);
		//Mini yo
		GUI.Label(new Rect(Screen.width / 1.25f,Screen.height /1.12f,Screen.width / 1,Screen.height / 1),""+scripvida.miniitemyo+"/8");
		//extrass
		GUI.Label(new Rect(Screen.width / 1.05f,Screen.height /1.13f,Screen.width / 1,Screen.height / 1),""+extras);
		GUI.skin = miedo;
	
		GUI.Label(new Rect(Screen.width / 2.3f,Screen.height /15f,Screen.width / 1,Screen.height / 1),""+tiempo);
		GUI.Label(new Rect(Screen.width / 1.23f,Screen.height /50.43f,Screen.width / 1,Screen.height / 1),""+puntuacion);
	
		GUI.Label(new Rect(Screen.width / 33f,Screen.height /1.07f,Screen.width / 1,Screen.height / 1),""+scripvida.creditos);
	
	
	}




}
