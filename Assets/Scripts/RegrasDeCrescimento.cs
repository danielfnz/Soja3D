using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class RegrasDeCrescimento : MonoBehaviour {

  public GameObject Redenrizacao3D;
  private bool habilitado = true;
  public int interacao; //Interacao em qual o LSystem esta
  private string input = "A";   //Axioma
  public string regrasAtuais,result;   //Saida resultante das interacoes

  //Dicionario par armazenar as regras
  public Dictionary<char, string> regras = new Dictionary<char, string>();

  public void setHabilitado(bool valor) {
  	this.habilitado=valor;
  }

  public void setInteracao(int valor) {
  	this.interacao=valor;
  	GenerateTree();
  }
  
  public int getInteracao() {
  	return this.interacao;
  }

  public void GenerateTree()
  {   
  	if(habilitado) {
  		Redenrizacao3D.GetComponent<Redenrizacao3D>().LimpaObjetos();
  		regras.Clear();
  

     // Regras
  		if(interacao==1) {
  			regras.Add('A', "I[+z][-z]A");
  		}
  		else {
     // regras.Add('A', "[+z][-z]B");
  			regras.Add('A', "I[+z][-z]B");
  			regras.Add('B', "[+C]D");

  			if(interacao % 2 == 0) { 
  				if(interacao>=12) {
  					regras.Add('C', "[-f+f-f]p[-L]");
  				}  
  				else {
  					regras.Add('C', "p[-L]");
  				}
  			}
  			else {
  				if(interacao>=12) {                   
  					regras.Add('C', "[+f-f+f]p[+L]");
  				}  
  				else {
  					regras.Add('C', "p[+L]");
  				}
  			}
  			regras.Add('D', "I[-C]A");
  		} 	
  		regrasAtuais = input;

      //Transforma as regras em gramatica formal(sequencia)
  		for (int i = 0; i < interacao; i++){
  			regrasAtuais = AplicaRegras(regrasAtuais);
  		}

      //Transforma as regras em pontos na lista
  		Redenrizacao3D.GetComponent<Redenrizacao3D>().TransformaRegras(regrasAtuais);
      //Transforma os pontos em cilindros
  		Redenrizacao3D.GetComponent<Redenrizacao3D>().Redenriza3D();
  	}
  }

  private string AplicaRegras(string p_input)
  {
  	StringBuilder sb = new StringBuilder();
    // Loop through characters in the input string
  	foreach (char c in p_input)	{
        // If character matches key in rules, then replace character with rhs of rule
  		if (regras.ContainsKey(c))
  		{
  			sb.Append(regras[c]);
  		}
        // If not, keep the character
  		else
  		{
  			sb.Append(c);
  		}
  	}
    // Return string with rules applied
  	return sb.ToString();
  }
}
