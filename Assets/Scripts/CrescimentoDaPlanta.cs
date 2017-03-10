using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CrescimentoDaPlanta : MonoBehaviour {

    public int valorSlider;
    public GameObject soja3d;
    public Slider slide;
    public Text valorSliderText;

    private IEnumerator coroutine;
    private int interacao;

    void Start() {
    coroutine = SetValorSlide(0.3f);
    }

    public void PlaySlide(){
    StartCoroutine(coroutine);
    }

    public void StopSlide(){
    StopCoroutine(coroutine);  
    }

    public void changeValorSlide(float newValue){
		//Captura o valor atual do slider
		valorSlider = (int)newValue;
		//Pega o valor e adiciona Dias, para ser mostrado acima do slider
		valorSliderText.text =  valorSlider.ToString()+" Dias";
	}

    private IEnumerator SetValorSlide(float waitTime) {
        while (slide.value<=120) {
            yield return new WaitForSeconds(waitTime);
            slide.value = slide.value+1;
        }
    }
	
	// Update is called once per frame
	void Update () {
    //V0
	 if(valorSlider == 0 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(0);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //VE
    if(valorSlider == 5 ){
       soja3d.GetComponent<Redenrizacao3D>().setInteracao(1);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //VC
    else if(valorSlider == 8 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(2);
          soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }

    //V1
    else if(valorSlider == 12 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(3);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //V2
    else if(valorSlider == 18 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(4);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //V3
    else if(valorSlider == 25 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(6);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //V4
    else if(valorSlider == 32 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(8);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //V5
    else if(valorSlider == 38 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(9);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //V6
    else if(valorSlider == 46 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(11);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    ///Reprodutivo
    //R1
    else if(valorSlider == 53 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(12);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //R2
    else if(valorSlider == 60 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(13);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //R3
    else if(valorSlider == 66 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(15);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //R4
    else if(valorSlider == 73 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(17);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //R5
    else if(valorSlider == 85 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(18);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }
    //R6
    else if(valorSlider == 96 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(18);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);
    }

    //R7
    else if(valorSlider == 107 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(18);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);

        GameObject[] vagens = GameObject.FindGameObjectsWithTag("Vagems");
        foreach(GameObject teste in vagens) {
          teste.GetComponent<VagemScript>().changeMaterial(1);
        }
        GameObject[] FOLHAS = GameObject.FindGameObjectsWithTag("Folhas");
        foreach(GameObject teste2 in FOLHAS) {
        teste2.GetComponent<FolhaScript>().changeMaterialFolha(2);
        }
    }

    //R8
    else if(valorSlider == 118 ){
        soja3d.GetComponent<Redenrizacao3D>().setInteracao(18);
        soja3d.GetComponent<Redenrizacao3D>().setHabilitado(false);

        GameObject[] VAGEMS = GameObject.FindGameObjectsWithTag("Vagems");
        foreach(GameObject teste in VAGEMS) {
          teste.GetComponent<VagemScript>().changeMaterial(2);
        }

        GameObject[] CAULES = GameObject.FindGameObjectsWithTag("Caules");
        foreach(GameObject teste in CAULES) {
          teste.GetComponent<Caule>().changeMaterial(1);
        }
        GameObject[] FOLHAS = GameObject.FindGameObjectsWithTag("Folhas");
        foreach(GameObject teste in FOLHAS) {
            Object.DestroyImmediate(teste);
        }
        GameObject[] PRIMEIRASFOLHAS = GameObject.FindGameObjectsWithTag("PrimeirasFolhas");
        foreach(GameObject teste in PRIMEIRASFOLHAS) {
            Object.DestroyImmediate(teste);
        }
    }
    else {
     soja3d.GetComponent<Redenrizacao3D>().setHabilitado(true);
 	}

	}
}
