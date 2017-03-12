using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {
	public GameObject carregando;

	public void Iniciar() {
		Application.LoadLevel("Fenologia");
		carregando.SetActive(true);
		Destroy(this.gameObject);
		
	}

	public void InicioPrincipal() {
		Application.LoadLevel("Menu");
		Destroy(this.gameObject);		
	}

	public void Avaliar(){
		  Application.OpenURL("http://unity3d.com/");
	}

	public void Sair(){
		Application.Quit();
	}

	public void Voltar(){
	 gameObject.SetActive(false);
	}

}
