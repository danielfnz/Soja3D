using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class Redenrizacao3D : MonoBehaviour {

	public bool debug = true;
  private bool habilitado = true;
  private bool folhaTri = true;

  public int interacao = 0;
  //Axioma
  public string input = "A";
  //Saida resultante das interacoes
  private string regrasAtuais;
  [ReadOnly]
  public string result;

  //Game object cilindro usado como referencia
  public GameObject Slide;
  public GameObject CaulePrincipal;
  public GameObject CauleSecundario;
  public GameObject PrimeirasFolhas;
  public GameObject FolhaTrifoliada;
  public GameObject Flor;
  public GameObject Flor2;
  public GameObject Vagem;

  //Dicionario par armazenar as regras
  public Dictionary<char, string> regras = new Dictionary<char, string>();
  [Range(0,30)]

  private List<GameObject> objetos = new List<GameObject>();
  [SerializeField]
  public List<GameObject> CauleSecundarios = new List<GameObject>();
  private List<point> cauleprincipal = new List<point>();
  private List<point> primeirasfolhas = new List<point>();
  private List<point> caulesecundario = new List<point>();
  private List<point> folhastrifoliadas = new List<point>();
  private List<point> flores  = new List<point>();

  public void AtivaFolhasTri() {
    this. folhaTri=true;
    this.GenerateTree();
  }
  public void DesativaFolhasTri() {
   this.folhaTri=false;
   this.GenerateTree();
 }

 public void setHabilitado(bool valor) {
   this.habilitado=valor;
 }

 public void setInteracao(int valor) {
  this.interacao=valor;
  GenerateTree();
}


private struct point
{
  public point(Vector3 rP, Vector3 rA, float rL) { Point = rP; Angle = rA; BranchLength = rL; }
  public Vector3 Point;
  public Vector3 Angle;
  public float BranchLength;
}

	// Pivot point1 around point2 by angles
private Vector3 pivot(Vector3 point1, Vector3 point2, Vector3 angles)
{
  Vector3 dir = point1 - point2;
  dir = Quaternion.Euler(angles) * dir;
  point1 = dir + point2;
  return point1;
}

    // Use this for initialization
void Start () {
  GenerateTree();
}

public void GenerateTree()
{   
  if(habilitado) {
    LimpaObjetos();

       	// Regras
    if(interacao==1) {
      regras.Add('A', "I[+z][-z]A");
    }
    else {
      regras.Add('A', "I[+z][-z]B");
      regras.Add('B', "I[+C]D");

      if(interacao % 2 == 0) { 
        if(interacao>13) {
          regras.Add('C', "[-f+f-f]p[-L]");
        }  
        else {
          regras.Add('C', "p[-L]");
        }
      }
      else {
        if(interacao>13) {                   
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

        //Regras obtidas(Usado apenas na unity)
   result = regrasAtuais;

        //Transforma as regras em pontos na lista
   TransformaRegras(regrasAtuais);

        //Transforma os pontos em cilindros
   Redenriza3D();
 }
}


private void LimpaObjetos() {
	//Limpa as listas de pontos e GameObjetos
	regras.Clear();
	cauleprincipal.Clear();
	primeirasfolhas.Clear();
	caulesecundario.Clear();
	folhastrifoliadas.Clear();
  flores.Clear();
  foreach (GameObject obj in objetos)
  {
    Object.DestroyImmediate(obj);
  }
  CauleSecundarios.Clear();
  objetos.Clear();
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


//TRANSFORMA AS REGRAS EM PONTOS
private void TransformaRegras(string p_input)
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
		switch (c)
		{

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
            primeirasPonto.Point.z = -0.1f; 
            primeirasPonto.Point.x = -0.065f;


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

    private void Redenriza3D(){

	     //Percorre lista de caule principal para criar o objeto
      for (int i = 0; i < cauleprincipal.Count; i += 2)	{
        CriarCaulePrincipal(cauleprincipal[i], cauleprincipal[i + 1], 0.1f);
      }
	     //Percorre lista de caule secundario para criar o objeto
      for (int i = 0; i < caulesecundario.Count; i += 2)
      {
        CriarCauleSecundario(caulesecundario[i], caulesecundario[i + 1], 0.1f);
      }

	     //Percorre a lista de primeiras folhas passando o angulo e a posicao para ser criado o objeto
      for (int i = 0; i < primeirasfolhas.Count; i += 1){
        CriarPrimeiraFolha(primeirasfolhas[i].Angle,primeirasfolhas[i]);
      }

	     //Percorre lista de folhas trifoliadas
      for (int i = 0; i < folhastrifoliadas.Count; i += 1)
      {
        CriarFolhaTrifoliada(folhastrifoliadas[i],folhastrifoliadas[i].Angle);
      }

      if(interacao==14 || interacao==15){
        //Percorre lista de Flores
        for (int i = 0; i < flores.Count; i += 1)
        {
          CriarFlor(flores[i],flores[i].Angle, Flor,new Vector3(0.01f,0.01f,0.01f));
        }
      }
      if(interacao==16){
        //Percorre lista de Flores
        for (int i = 0; i < flores.Count; i += 1)
        {
          CriarFlor(flores[i],flores[i].Angle, Flor2,new Vector3(0.018f,0.018f,0.018f));
        }
      } 
      if(interacao==17){
        //Percorre lista de Flores
        for (int i = 0; i < flores.Count; i += 1)
        {
          CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.05f,0.05f,0.05f));
        }
      } 
      if(interacao==18){
        //Percorre lista de Flores
        for (int i = 0; i < flores.Count; i += 1)
        {
          CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.09f,0.09f,0.09f));
        }
      } 
      if(interacao==19){
        //Percorre lista de Flores
        for (int i = 0; i < flores.Count; i += 1)
        {
          CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.15f,0.15f,0.15f));
        }
      } 
      if(interacao==20){

        //Percorre lista de Flores
        for (int i = 0; i < flores.Count; i += 1)
        {
          CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.18f,0.18f,0.18f));
        }
      } 
      if(interacao==21){

        //Percorre lista de Flores
        for (int i = 0; i < flores.Count; i += 1)
        {
          CriarFlor(flores[i],flores[i].Angle, Vagem, new Vector3(0.18f,0.18f,0.18f));
        }
      } 

    }

    private void CriarCaulePrincipal(point point1, point point2, float radius)
    {
      //UnityEngine.Random.Range(0,3);
     //Cria o cilindro, de acordo com o cilindro passado como referencia
     GameObject newCylinder = (GameObject)Instantiate(CaulePrincipal);
     //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
     newCylinder.SetActive(true);

     //Comprimento do ramo(1 ponto ao outro)
     // float length = Vector3.Distance(point2.Point, point1.Point);
     // radius = radius * length;

      //Scale o tamanho do cylindro(x,y,z) y = comprimento
     Vector3 scale = new Vector3(0.03f, 0.05f , 0.03f);
     newCylinder.transform.localScale = scale;

      //Seta o ponto inicial dos cilindros como o mesmo do seu ramo
     newCylinder.transform.position = point1.Point;
     //Rotaciona de acordo com a regra + ou -
     newCylinder.transform.Rotate(point2.Angle);
     //Coloca todos os ramos como Parent do Object Soja3D
     newCylinder.transform.parent = this.transform;
     //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
     objetos.Add(newCylinder);
   }

   private void CriarCauleSecundario(point point1, point point2, float radius)
   {
     //UnityEngine.Random.Range(0,3);
     //Cria o cilindro, de acordo com o cilindro passado como referencia
     GameObject newCylinder = (GameObject)Instantiate(CauleSecundario);
     //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
     newCylinder.SetActive(true);

     //Scale o tamanho do cylindro(x,y,z) y = comprimento
     Vector3 scale = new Vector3(0.01f, 0.02f , 0.01f);
     newCylinder.transform.localScale = scale;

     //Seta o ponto inicial dos cilindros como o mesmo do seu ramo
     newCylinder.transform.position = (point1.Point + new Vector3(0,0.05f,0));
     //Rotaciona de acordo com a regra + ou -
     newCylinder.transform.Rotate(point2.Angle);
     //Coloca todos os ramos como Parent do Object Soja3D
     newCylinder.transform.parent = this.transform;
     CrescimentoDaPlanta jota = GameObject.Find("SliderFenologia").GetComponent<CrescimentoDaPlanta>();
     newCylinder.AddComponent<GAL_DiaCriado>();
     newCylinder.GetComponent<GAL_DiaCriado>().diaCriado = (int)jota.valorSlider;
     //Adiciona o gameobject dentro da lista
     CauleSecundarios.Add(newCylinder);
     //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
     objetos.Add(newCylinder);
   }

   private void CriarPrimeiraFolha(Vector3 angle, point point1)
   {
      //UnityEngine.Random.Range(0,3);
      //Cria o cilindro, de acordo com o cilindro passado como referencia
     GameObject folha = (GameObject)Instantiate(PrimeirasFolhas);
      //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
     folha.SetActive(true);
     folha.transform.Rotate(angle);
     folha.transform.position +=point1.Point;

      //Coloca todos os ramos como Parent do Object Soja3D
     folha.transform.parent = this.transform;
     //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
     objetos.Add(folha);
   }

   private void CriarFolhaTrifoliada(point point1, Vector3 angle)
   {

    GameObject trifoliada = (GameObject)Instantiate(FolhaTrifoliada);
    //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
    trifoliada.SetActive(folhaTri);

    //trifoliada.transform.Rotate(angle);
    //Seta o ponto inicial dos cilindros como o mesmo do seu ramo
    trifoliada.transform.position = (point1.Point);

    //Coloca todos os ramos como Parent do Object Soja3D
    trifoliada.transform.parent = this.transform;
    //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
    objetos.Add(trifoliada);
  }

  private void CriarFlor(point point1, Vector3 angle,GameObject qual_flor, Vector3 scala)
  {

    GameObject flor = (GameObject)Instantiate(qual_flor);
    //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
    flor.SetActive(flor);
    flor.transform.localScale = scala;

    //trifoliada.transform.Rotate(angle);
    //Seta o ponto inicial dos cilindros como o mesmo do seu ramo
    flor.transform.position = (point1.Point + new Vector3(0,0.06f,0));
    flor.transform.Rotate(point1.Angle);

    //Coloca todos os ramos como Parent do Object Soja3D
    flor.transform.parent = this.transform;
    //Adicione o cilindro a Lista para que sejam deletados de acordo com a interação
    objetos.Add(flor);
  }
}
