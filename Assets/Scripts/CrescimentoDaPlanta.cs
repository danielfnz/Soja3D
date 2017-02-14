using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CrescimentoDaPlanta : MonoBehaviour {

	public float valorSlider;
	private int interacao;
    public GameObject soja3d;
    public Text valorSliderText;

    public void changeValorSlide(float newValue)
	{
		//Captura o valor atual do slider
		valorSlider = (int)newValue;
		//Pega o valor e adiciona Dias, para ser mostrado acima do slider
		valorSliderText.text =  valorSlider.ToString()+" Dias";
	}
    void Start (){
        InvokeRepeating("AtualizaGalhos",0.5f,0.1f);
    }
    void AtualizaGalhos()
    {
        Redenrizacao3D j = soja3d.GetComponent<Redenrizacao3D>();
        foreach(GameObject jota in j.CauleSecundarios)
        {
            int diaCriado = jota.GetComponent<GAL_DiaCriado>().diaCriado;
            jota.transform.localScale = new Vector3(jota.transform.localScale.x, (0.4f * diaCriado) / ((int)valorSlider + 70), jota.transform.localScale.z);
        }
    }
	
	// Update is called once per frame
	void Update () {



	 if(valorSlider == 0 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(0);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    if(valorSlider == 7 ){
       soja3d.GetComponent<Redenrizacao3D>().setInteracao(1);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 8 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(2);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 10 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(3);
          soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 13 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(4);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 16 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(5);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 17 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(6);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 20 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(7);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 21 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(8);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 22 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(9);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 23 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(10);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 27 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(11);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 29 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(12);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 33 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(13);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
      ///Reprodutivo
    else if(valorSlider == 35 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(14);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 37 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(15);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //R2
    else if(valorSlider == 60 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(16);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 75 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(17);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 85 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(18);
        soja3d.GetComponent<Redenrizacao3D>().GenerateTree();
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 94 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(19);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    else if(valorSlider == 100 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(20);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    
    else if(valorSlider == 110 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(21);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);

        GameObject[] vagens = GameObject.FindGameObjectsWithTag("Vagems");
        foreach(GameObject teste in vagens) {
          teste.GetComponent<Vagem>().changeMaterial(1);
        }
    }
    else if(valorSlider == 120 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(21);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);

        GameObject[] VAGEMS = GameObject.FindGameObjectsWithTag("Vagems");
        foreach(GameObject teste in VAGEMS) {
          teste.GetComponent<Vagem>().changeMaterial(2);
        }

        GameObject[] CAULES = GameObject.FindGameObjectsWithTag("Caules");
        foreach(GameObject teste in CAULES) {
          teste.GetComponent<Caule>().changeMaterial(1);
        }
        GameObject[] FOLHAS = GameObject.FindGameObjectsWithTag("Folhas");
        foreach(GameObject teste in FOLHAS) {
            Object.DestroyImmediate(teste);
        }
    }
    else {
     soja3d.GetComponent<Redenrizacao3D>().setHabilitado(true);
 	}

	}
}
