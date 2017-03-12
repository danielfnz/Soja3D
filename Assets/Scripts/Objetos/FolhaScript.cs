using UnityEngine;
using System.Collections;

public class FolhaScript : MonoBehaviour {

	private MeshRenderer rend1;
	public Material[] materials;

	// Use this for initialization
	void Start () {
	rend1 = transform.GetChild(0).GetComponent<MeshRenderer>();

	}
	public void changeMaterialFolha(int index){
		    rend1.sharedMaterial = materials[index];
	}
}
