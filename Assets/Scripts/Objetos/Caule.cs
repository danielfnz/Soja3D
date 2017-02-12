using UnityEngine;
using System.Collections;

public class Caule : MonoBehaviour {

	private MeshRenderer rend1;
	public Material[] materials;

	// Use this for initialization
	void Start () {
	rend1 = transform.GetChild(0).GetComponent<MeshRenderer>();

	}
	public void changeMaterial (int index){
		    rend1.sharedMaterial = materials[index];
	}
}
