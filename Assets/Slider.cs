using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Slider : MonoBehaviour {

	private float valorSlider;
    public Text valorSlideText;

    //public List<GameObject> Plantas;


    public void changeValor(float newValue)
	{
        valorSlideText.text = newValue.ToString();
        this.valorSlider = newValue;


	//if(valorSlider > 1 && valorSlider <5){
 	//	Plantas[0].SetActive(true);
 	//	Plantas[1].SetActive(false);
		//Plantas[2].SetActive(false);
		//Plantas[3].SetActive(false);
		//Plantas[4].SetActive(false);
		//Plantas[5].SetActive(false);
		//Plantas[6].SetActive(false);
		//Plantas[7].SetActive(false);
		//Plantas[8].SetActive(false);

		//}

		//if(valorSlider > 5 && valorSlider <10){
		//Plantas[0].SetActive(false);
		//Plantas[2].SetActive(false);
		//Plantas[3].SetActive(false);
		//Plantas[4].SetActive(false);
		//Plantas[5].SetActive(false);
		//Plantas[6].SetActive(false);
		//Plantas[7].SetActive(false);
		//Plantas[8].SetActive(false);
 	//	Plantas[1].SetActive(true);
		//}

		//if(valorSlider > 10 && valorSlider <16){
		//Plantas[0].SetActive(false);
		//Plantas[1].SetActive(false);
		//Plantas[3].SetActive(false);
		//Plantas[4].SetActive(false);
		//Plantas[5].SetActive(false);
		//Plantas[6].SetActive(false);
		//Plantas[7].SetActive(false);
		//Plantas[8].SetActive(false);
 	//	Plantas[2].SetActive(true);
		//}

		//if(valorSlider > 16 && valorSlider <22){
		//Plantas[0].SetActive(false);
		//Plantas[1].SetActive(false);
		//Plantas[2].SetActive(false);
		//Plantas[4].SetActive(false);
		//Plantas[5].SetActive(false);
		//Plantas[6].SetActive(false);
		//Plantas[7].SetActive(false);
		//Plantas[8].SetActive(false);
 	//	Plantas[3].SetActive(true);
		//}

		//if(valorSlider > 29 && valorSlider <54){
		//Plantas[0].SetActive(false);
		//Plantas[1].SetActive(false);
		//Plantas[2].SetActive(false);
		//Plantas[3].SetActive(false);
		//Plantas[5].SetActive(false);
		//Plantas[6].SetActive(false);
		//Plantas[7].SetActive(false);
		//Plantas[8].SetActive(false);
 	//	Plantas[4].SetActive(true);
		//}

		//if(valorSlider > 54 && valorSlider <64){
		//Plantas[0].SetActive(false);
		//Plantas[1].SetActive(false);
		//Plantas[2].SetActive(false);
		//Plantas[3].SetActive(false);
		//Plantas[4].SetActive(false);
		//Plantas[6].SetActive(false);
		//Plantas[7].SetActive(false);
		//Plantas[8].SetActive(false);
 	//	Plantas[5].SetActive(true);
		//}

		//if(valorSlider > 64 && valorSlider <72){
		//Plantas[0].SetActive(false);
		//Plantas[1].SetActive(false);
		//Plantas[2].SetActive(false);
		//Plantas[3].SetActive(false);
		//Plantas[4].SetActive(false);
		//Plantas[5].SetActive(false);
		//Plantas[7].SetActive(false);
		//Plantas[8].SetActive(false);
 	//	Plantas[6].SetActive(true);
		//}

		//if(valorSlider > 73 && valorSlider <80){
		//Plantas[0].SetActive(false);
		//Plantas[1].SetActive(false);
		//Plantas[2].SetActive(false);
		//Plantas[3].SetActive(false);
		//Plantas[4].SetActive(false);
		//Plantas[5].SetActive(false);
		//Plantas[6].SetActive(false);
		//Plantas[8].SetActive(false);
 	//	Plantas[7].SetActive(true);
		//}

		//if(valorSlider > 80 && valorSlider <86){
		//Plantas[0].SetActive(false);
		//Plantas[1].SetActive(false);
		//Plantas[2].SetActive(false);
		//Plantas[3].SetActive(false);
		//Plantas[4].SetActive(false);
		//Plantas[5].SetActive(false);
		//Plantas[6].SetActive(false);
		//Plantas[7].SetActive(false);

 	//	Plantas[8].SetActive(true);
		//}

		//if(valorSlider > 86 && valorSlider <92){
		//Plantas[0].SetActive(false);
		//Plantas[1].SetActive(false);
		//Plantas[2].SetActive(false);
		//Plantas[3].SetActive(false);
		//Plantas[4].SetActive(false);
		//Plantas[5].SetActive(false);
		//Plantas[6].SetActive(false);
		//Plantas[7].SetActive(false);
		//Plantas[8].SetActive(true);

		//}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	}
}
