using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TexturaSolo : MonoBehaviour {

	public GameObject TeorArgila;
	public GameObject TeorArgilaSlide;
	public GameObject pMel1;
	public GameObject pMelSlide1;

	public GameObject pMel;
	public GameObject pMelSlide;
	public GameObject pRem;
	public GameObject pRemSlide;


	public void changeValor(int valor){

		if(valor ==0) {
			TeorArgila.SetActive(true);
			TeorArgilaSlide.SetActive(true);
			pMel1.SetActive(true);
			pMelSlide1.SetActive(true);
			pMel.SetActive(false);
			pMelSlide.SetActive(false);
			pRem.SetActive(false);
			pRemSlide.SetActive(false);
		}
		else {
			TeorArgila.SetActive(false);
			TeorArgilaSlide.SetActive(false);
			pMel1.SetActive(false);
			pMelSlide1.SetActive(false);
			pMel.SetActive(true);
			pMelSlide.SetActive(true);
			pRem.SetActive(true);
			pRemSlide.SetActive(true);

		}
	}

}
