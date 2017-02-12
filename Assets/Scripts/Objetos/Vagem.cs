using UnityEngine;
using System.Collections;

public class Vagem : MonoBehaviour {


	private MeshRenderer rend1;
	private MeshRenderer rend2;
	public Material[] materials;

	// Use this for initialization
	void Start () {
	rend1 = transform.GetChild(0).GetComponent<MeshRenderer>();
	rend2 = transform.GetChild(1).GetComponent<MeshRenderer>();

	}
	public void changeMaterial (int index){
		    rend1.sharedMaterial = materials[index];
		    rend2.sharedMaterial = materials[index];
	}
	
}
