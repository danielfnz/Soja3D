using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ControleTempo : MonoBehaviour {

    public int valorSlider;
    public GameObject RegrasCrescimento;
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
    //V0
    if(valorSlider == 0 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(0);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
    //VE
    if(valorSlider == 5 ){
     RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(1);
     RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
     }
        //VC
     else if(valorSlider == 8 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(2);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }

        //V1
    else if(valorSlider == 12 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(3);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //V2
    else if(valorSlider == 18 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(4);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //V3
    else if(valorSlider == 25 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(6);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //V4
    else if(valorSlider == 32 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(8);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //V5
    else if(valorSlider == 38 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(9);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //V6
    else if(valorSlider == 46 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(11);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        ///Reprodutivo
        //R1
    else if(valorSlider == 53 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(12);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //R2
    else if(valorSlider == 60 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(13);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //R3
    else if(valorSlider == 66 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(15);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //R4
    else if(valorSlider == 73 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(17);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //R5
    else if(valorSlider == 85 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(18);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }
        //R6
    else if(valorSlider == 96 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(18);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);
    }

        //R7
    else if(valorSlider == 107 ){
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(18);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);

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
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setInteracao(18);
        RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(false);

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
       RegrasCrescimento.GetComponent<RegrasDeCrescimento>().setHabilitado(true);
    }


}

private IEnumerator SetValorSlide(float waitTime) {
    while (slide.value<=120) {
        yield return new WaitForSeconds(waitTime);
        slide.value = slide.value+1;
    }
}

}
