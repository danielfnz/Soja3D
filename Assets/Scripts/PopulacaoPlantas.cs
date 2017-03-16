using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulacaoPlantas : MonoBehaviour {

	public GameObject populacaoCamera;
	public GameObject normalCamera;
	public GameObject ModeloSoja;

	private List<GameObject> populacaoSoja = new List<GameObject>();


	public void Individual() {
		normalCamera.SetActive(true);
		populacaoCamera.SetActive(false);
		foreach (GameObject obj in populacaoSoja){
			Object.DestroyImmediate(obj);
		}
	}

	public void Populacao(){
		int posx,posz,anguloy;

		populacaoCamera.SetActive(true);
		normalCamera.SetActive(false);

		for(int i=0;i<50; i++){
			GameObject soja = (GameObject)Instantiate(ModeloSoja); 
			//Valor random da posição x e y
			posx = UnityEngine.Random.Range(-5, 0);
			posz = UnityEngine.Random.Range(-5, 0);
			//Angulo de inclinação da soja, para não ficar muito fake
			anguloy = UnityEngine.Random.Range(-50, 50);
			
			soja.transform.position += new Vector3(posx,0,posz);   
			soja.transform.Rotate(new Vector3(0,anguloy,0)); 
			populacaoSoja.Add(soja);
		}   
	}

	void LateUpdate (){
    if(Input.anyKeyDown){
      GameObject.Find("Controles").SetActive(false);
    }
  }
}
