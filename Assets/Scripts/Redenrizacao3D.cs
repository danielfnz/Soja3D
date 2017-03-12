using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine.UI;

public class Redenrizacao3D : MonoBehaviour {

  private int interacao =0;
  //Game object cilindro usado como referencia
  public GameObject Slide;
  public GameObject cylinder;
  public GameObject PrimeirasFolhas;
  public GameObject FolhaTrifoliada;
  public GameObject Flor;
  public GameObject Flor2;
  public GameObject Vagem;
  public GameObject RegrasDeCrescimento;

  private List<GameObject> objetos = new List<GameObject>();
  private List<point> cauleprincipal = new List<point>();
  private List<point> primeirasfolhas = new List<point>();
  private List<point> caulesecundario = new List<point>();
  private List<point> folhastrifoliadas = new List<point>();
  private List<point> flores  = new List<point>();

  private struct point {
    public point(Vector3 rP, Vector3 rA, float rL) { Point = rP; Angle = rA; BranchLength = rL; }
    public Vector3 Point;
    public Vector3 Angle;
    public float BranchLength;
  }

  private Vector3 pivot(Vector3 point1, Vector3 point2, Vector3 angles) {
    Vector3 dir = point1 - point2;
    dir = Quaternion.Euler(angles) * dir;
    point1 = dir + point2;
    return point1;
  }
 
//TRANSFORMA AS REGRAS EM PONTOS
public void TransformaRegras(string p_input)
{
    //Cria uma pilha chamada returnValue
    //Passando a struct point como elemento
	Stack<point> returnValues = new Stack<point>();
	point lastPoint = new point(Vector3.zero, Vector3.zero, 1f);
	point primeirasPonto = new point(Vector3.zero, Vector3.zero, 1f);
	point folhasPonto = new point(Vector3.zero, Vector3.zero, 1f);
	returnValues.Push(lastPoint);

	foreach (char c in p_input)
	{
		switch (c){

            case 'I': //Cria Caule principal
            cauleprincipal.Add(lastPoint);
            point caule = new point(lastPoint.Point + new Vector3(0, 0.08f, 0), lastPoint.Angle, 0.5f);

            //Efeito retorcido do caule     
            caule.Angle.x = lastPoint.Angle.y + UnityEngine.Random.Range(-15, 15);
            caule.Point = pivot(caule.Point, lastPoint.Point, new Vector3(caule.Angle.x, 0, 0));
            caule.Point = pivot(caule.Point, lastPoint.Point, new Vector3(0, caule.Angle.y, 0));

            cauleprincipal.Add(caule);
            lastPoint = caule;
            break;

            case 'p': //Cria Caule Secundario
            caulesecundario.Add(lastPoint);
            point newPoint = new point(lastPoint.Point , lastPoint.Angle, 0.5f);
            //Cria os pontos para as folhas serem redenrizadas
            //newPoint.Angle.x = lastPoint.Angle.y + UnityEngine.Random.Range(-90, 30);
            newPoint.Point = pivot(newPoint.Point+(new Vector3(0,0.7f,0)), lastPoint.Point, new Vector3(newPoint.Angle.x, 0, 0));
            newPoint.Point = pivot(newPoint.Point, lastPoint.Point, new Vector3(0, newPoint.Angle.y, 0));

            caulesecundario.Add(newPoint);
            lastPoint = newPoint;
            break;

            case 'z': //Cria Primeiras folhas
            point folhas = new point(primeirasPonto.Point, primeirasPonto.Angle, 1f);              
            primeirasfolhas.Add(folhas);            
            break;

            case 'L': //Cria Folhas trifoliadas                      
            point newPoint2 = new point(lastPoint.Point , lastPoint.Angle, 0.5f);       
            folhastrifoliadas.Add(newPoint2);
            lastPoint = newPoint2;
            break;

            case 'f': //Cria Flor          
            point flor = new point(lastPoint.Point , lastPoint.Angle, 0.5f);
            flores.Add(flor);
            lastPoint = flor;
            break;

            case '+': // Rotate +30
            //Inclinacao              
            lastPoint.Angle.x += 50.0f;  
            //Rotacao
            lastPoint.Angle.y += 31.0f;  
            break;

            case '-': // Rotate -30 
            primeirasPonto.Angle.y += 180.0f;  
            primeirasPonto.Angle.x += 80.0f;    
            primeirasPonto.Point.z = -0.037f; 
            primeirasPonto.Point.x = -0.02f;

            lastPoint.Angle.x += -50.0f; 
            lastPoint.Angle.y += 31.0f; 
            break;

            case '[': // Save State
            returnValues.Push(lastPoint);
            break;

            case ']': // Load Saved State
            lastPoint = returnValues.Pop();
            break;
          }
       }
}

public void LimpaObjetos() {
  //Limpa as listas de pontos e GameObjetos
  cauleprincipal.Clear();
  primeirasfolhas.Clear();
  caulesecundario.Clear();
  folhastrifoliadas.Clear();
  flores.Clear();
  foreach (GameObject obj in objetos)
  {
    Object.DestroyImmediate(obj);
  }
  objetos.Clear();
}

public void Redenriza3D(){
    interacao = RegrasDeCrescimento.GetComponent<RegrasDeCrescimento>().interacao;
//Percorre lista de caule principal para criar o objeto
     for (int i = 0; i < cauleprincipal.Count; i += 2)	{
      CriarCaulePrincipal(cauleprincipal[i], cauleprincipal[i + 1], 0.1f);
    }
//Percorre lista de caule secundario para criar o objeto
    for (int i = 0; i < caulesecundario.Count; i += 2)
    {
      CriarCauleSecundario(caulesecundario[i], caulesecundario[i + 1], 0.1f);
    }

    if(interacao <10) {
//Percorre a lista de primeiras folhas passando o angulo e a posicao para ser criado o objeto
      for (int i = 0; i < 2; i += 1){
        CriarPrimeiraFolha(primeirasfolhas[i].Angle,primeirasfolhas[i]);
      }
    }

//Percorre lista de folhas trifoliadas
    for (int i = 0; i < folhastrifoliadas.Count; i += 1)
    {
      CriarFolhaTrifoliada(folhastrifoliadas[i],folhastrifoliadas[i].Angle);
    }

    if(interacao==12){
      //Percorre lista de Flores
      for (int i = 0; i < flores.Count; i += 1)
      {
        CriarFlor(flores[i],flores[i].Angle, Flor,new Vector3(0.008f,0.008f,0.008f));
      }
    }
    if(interacao==13){
      //Percorre lista de Flores
      for (int i = 0; i < flores.Count; i += 1)
      {
        CriarFlor(flores[i],flores[i].Angle, Flor2,new Vector3(0.01f,0.01f,0.01f));
      }
    } 
    //CRIA VAGEM
    if(interacao==15){
      //Percorre lista de Flores
      for (int i = 0; i < flores.Count; i += 1)
      {
        CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.03f,0.03f,0.03f));
      }
    } 
    if(interacao==17){
      //Percorre lista de Flores
      for (int i = 0; i < flores.Count; i += 1)
      {
        CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.05f,0.09f,0.05f));
      }
    } 
    if(interacao==18){
      //Percorre lista de Flores
      for (int i = 0; i < flores.Count; i += 1)
      {
        CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.09f,0.09f,0.09f));
      }
    } 
    //ALTERAR PARA VALORSLIDE

    if(Slide.GetComponent<Slider>().value == 107){

      //Percorre lista de Flores
      for (int i = 0; i < flores.Count; i += 1)
      {
        CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.18f,0.18f,0.18f));
      }
    } 
    //ALTERAR PARA VALORSLIDE
    if(Slide.GetComponent<Slider>().value == 118){

      //Percorre lista de Flores
      for (int i = 0; i < flores.Count; i += 1)
      {
        CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.18f,0.18f,0.18f));
      }
    } 
  }

  private void CriarCaulePrincipal(point point1, point point2, float radius)
  {
  //Cria o cilindro, de acordo com o cilindro passado como referencia
   GameObject newCylinder = (GameObject)Instantiate(cylinder);
  //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
   newCylinder.SetActive(true);

  //Comprimento do ramo(1 ponto ao outro)
   float length = Vector3.Distance(point2.Point, point1.Point);
   radius = radius * length;
   if(interacao==1) {
     Vector3 scale = new Vector3(0.01f, 0.02f , 0.01f);
     newCylinder.transform.localScale = scale;
   }
   else {
     Vector3 scale = new Vector3(0.02f, 0.04f , 0.02f);
      //Scale o tamanho do cylindro(x,y,z) y = comprimento
     newCylinder.transform.localScale = scale;
      //Rotaciona de acordo com a regra + ou -
     newCylinder.transform.Rotate(point2.Angle);
   }

  //Seta o ponto inicial dos cilindros como o mesmo do seu ramo
   newCylinder.transform.position = point1.Point;
  //Coloca todos os ramos como Parent do Object Soja3D
   newCylinder.transform.parent = this.transform;
  //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
   objetos.Add(newCylinder);
 }

 private void CriarCauleSecundario(point point1, point point2, float radius)
 {
  //UnityEngine.Random.Range(0,3);
  //Cria o cilindro, de acordo com o cilindro passado como referencia
   GameObject newCylinder = (GameObject)Instantiate(cylinder);
  //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
   newCylinder.SetActive(true);

  //Scale o tamanho do cylindro(x,y,z) y = comprimento
   Vector3 scale = new Vector3(0.01f, 0.3f , 0.01f);
   newCylinder.transform.localScale = scale;

  //Seta o ponto inicial dos cilindros como o mesmo do seu ramo
   newCylinder.transform.position = (point1.Point + new Vector3(0,0.05f,0));
  //Rotaciona de acordo com a regra + ou -
   newCylinder.transform.Rotate(point2.Angle);
  //Coloca todos os ramos como Parent do Object Soja3D
   newCylinder.transform.parent = this.transform;
  //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
   objetos.Add(newCylinder);
 }

 private void CriarPrimeiraFolha(Vector3 angle, point point1)
 {

   GameObject folha = (GameObject)Instantiate(PrimeirasFolhas);
  //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
   folha.SetActive(true);
   folha.transform.Rotate(angle);
   folha.transform.position +=(point1.Point - new Vector3(0,0.03f,0));
   if(interacao!=1){
     Vector3 scale = new Vector3(0.2f, 2 , 0.2f);
     folha.transform.localScale = scale;
   }

  //Coloca todos os ramos como Parent do Object Soja3D
   folha.transform.parent = this.transform;
  //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
   objetos.Add(folha);
 }

 private void CriarFolhaTrifoliada(point point1, Vector3 angle)
 {

  GameObject trifoliada = (GameObject)Instantiate(FolhaTrifoliada);
  //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
  trifoliada.SetActive(trifoliada);

  //trifoliada.transform.Rotate(angle);
  //Seta o ponto inicial dos cilindros como o mesmo do seu ramo
  trifoliada.transform.position = (point1.Point);

  //Coloca todos os ramos como Parent do Object Soja3D
  trifoliada.transform.parent = this.transform;
  //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
  objetos.Add(trifoliada);
}

private void CriarFlor(point point1, Vector3 angle,GameObject qual_flor, Vector3 scala) {
  GameObject flor = (GameObject)Instantiate(qual_flor);
  //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
  flor.SetActive(flor);
  flor.transform.localScale = scala;
  //trifoliada.transform.Rotate(angle);
  //Seta o ponto inicial dos cilindros como o mesmo do seu ramo
  flor.transform.position = (point1.Point + new Vector3(0.02f,0.06f,0));
  if(qual_flor.name=="Vagem") {
    float valorx = UnityEngine.Random.Range(-60, 60);
    flor.transform.Rotate(new Vector3(0,0,valorx));
  }
  else {
   flor.transform.Rotate(angle);
 }
 //Coloca todos os ramos como Parent do Object Soja3D
 flor.transform.parent = this.transform;
 //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
 objetos.Add(flor);
}
}
