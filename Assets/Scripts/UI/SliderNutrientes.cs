using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderNutrientes : MonoBehaviour {

	private float valorSlider;

  public Text calcio;
  public Text magnesio;
  public Text aluminio;
  public Text hidrogenio;
  public Text potassio;
  public Text enxofre;
  public Text ph;
  public Text textura;


  public void changeValorSlideCalcio(float newValue){
	//Captura o valor atual do slider
    valorSlider = newValue;
	//Pega o valor e adiciona Dias, para ser mostrado acima do slider
    calcio.text =  valorSlider.ToString();
  }
  public void changeValorSlideMagnesio(float newValue){
	//Captura o valor atual do slider
    valorSlider = newValue;
	//Pega o valor e adiciona Dias, para ser mostrado acima do slider
    magnesio.text =  valorSlider.ToString();
  }
  public void changeValorSlideAluminio(float newValue){
  //Captura o valor atual do slider
    valorSlider = newValue;
  //Pega o valor e adiciona Dias, para ser mostrado acima do slider
    aluminio.text =  valorSlider.ToString();
  }
  public void changeValorSlideHidrogenio(float newValue){
  //Captura o valor atual do slider
    valorSlider = newValue;
  //Pega o valor e adiciona Dias, para ser mostrado acima do slider
    hidrogenio.text =  valorSlider.ToString();
  }
  public void changeValorSlidePotassio(float newValue){
	//Captura o valor atual do slider
    valorSlider = newValue;
	//Pega o valor e adiciona Dias, para ser mostrado acima do slider
    potassio.text =  valorSlider.ToString();
  }
  public void changeValorSlideEnxofre(float newValue){
	//Captura o valor atual do slider
    valorSlider = newValue;
	//Pega o valor e adiciona Dias, para ser mostrado acima do slider
    enxofre.text =  valorSlider.ToString();
  }			
    public void changeValorSlidepH(float newValue){
  //Captura o valor atual do slider
    valorSlider = newValue;
  //Pega o valor e adiciona Dias, para ser mostrado acima do slider
    ph.text =  System.String.Format("{0:0.00}",valorSlider);
  } 
    public void changeValorSlideTextura(float newValue){
  //Captura o valor atual do slider
    valorSlider = newValue;
  //Pega o valor e adiciona Dias, para ser mostrado acima do slider
    textura.text =  System.String.Format("{0:0.00}",valorSlider);
  }   	
}
