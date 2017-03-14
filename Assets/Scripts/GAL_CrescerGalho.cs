using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAL_CrescerGalho : MonoBehaviour
{
    public int diaQueCresceu = 0;
    public int diaQueParaDeCrescer = 24;
    // Use this for initialization
    void Start()
    {
        print(name);
        if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 0)
        diaQueCresceu = 12;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 1)
        diaQueCresceu = 18;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 2)
        diaQueCresceu = 25;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 3)
        diaQueCresceu = 32;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 4)
        diaQueCresceu = 38;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 5)
        diaQueCresceu = 46;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 6)
        diaQueCresceu = 53;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 7)
        diaQueCresceu = 60;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 8)
        diaQueCresceu = 66;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 9)
        diaQueCresceu = 73;
        else if (int.Parse(gameObject.name.Split(' ')[1].ToString()) == 10)
        diaQueCresceu = 85;
    }

	// Update is called once per frame
    void LateUpdate ()
    {
        if(GameObject.Find("ControleDoTempo").GetComponent<UnityEngine.UI.Slider>().value > diaQueCresceu) {
            diaQueParaDeCrescer = diaQueCresceu + 24;
            if (GameObject.Find("ControleDoTempo").GetComponent<UnityEngine.UI.Slider>().value <= diaQueParaDeCrescer)
            transform.localScale = new Vector3(0.01f, (float)(0.01 * ((GameObject.Find("ControleDoTempo").GetComponent<UnityEngine.UI.Slider>().value) - diaQueCresceu) ), 0.01f);
            else
            transform.localScale = new Vector3(0.01f, 0.3f, 0.01f);
        }
    }
}

//0.01 tamanho inicial
//0.3 tamanho final
//12 dia inicial  -  0.01 tamanho inicial
//x dia  -  y tamanho
//12y = 0.01x
//y = 0.01x/12