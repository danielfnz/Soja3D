using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public GameObject carregando;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Iniciar() {
		carregando.SetActive(true);
		Destroy(this.gameObject);
		Application.LoadLevel("Fenologia");
	}

	public void Sair(){
		Application.Quit();
	}
}
