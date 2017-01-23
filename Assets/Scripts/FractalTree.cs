using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class FractalTree : MonoBehaviour {

	public bool debug = true;

	public Dictionary<char, string> rules = new Dictionary<char, string>();
	[Range(0,6)]
    //Interações
	public int iterations = 4;
    //Axioma
	public string input = "I";
    //Saida resultante das interacoes
	private string output;
	[ReadOnly]
	public string result;

	List<point> cauleprincipal = new List<point>();
	List<point> caulesecundario = new List<point>();
	List<GameObject> objetos = new List<GameObject>();
    //Lista das primeiras folhas
	List<point> primeirasList = new List<point>();

    //Game object cilindro usado como referencia
	public GameObject cylinder;
	public GameObject PrimeirasFolhas;

    // Use this for initialization
	void Start () {
		GenerateTree();
	}

	public void GenerateTree()
	{   
        //Limpa as listas
		rules.Clear();
		cauleprincipal.Clear();
		primeirasList.Clear();
		caulesecundario.Clear();
		foreach (GameObject obj in objetos)
		{
            //Object.Destroy(obj);
			Object.DestroyImmediate(obj);
		}
		objetos.Clear();

        // Regras
        // Key is replaced by value
		rules.Add('I', "I[+z][-z]A");
		rules.Add('A', "S[+iL][-L]B");
		rules.Add('B', "S[+C]A");
		rules.Add('C', "p[iL][iL][-iL]");

		output = input;
        // Aplica as regras de acordo com as interacoes
		for (int i = 0; i < iterations; i++){
			output = applyRules(output);
		}

        //Regras obtidas
		result = output;
        //Transforma as regras em pontos
		determinecauleprincipal(output);

        //Transforma os pontos em cilindros
		CriarCaulePrincipais();

		CriarPrimeirasFolhas();

		CriarCauleSecundarios();

	}

	private string applyRules(string p_input)
	{
		StringBuilder sb = new StringBuilder();
        // Loop through characters in the input string
		foreach (char c in p_input)
		{
            // If character matches key in rules, then replace character with rhs of rule
			if (rules.ContainsKey(c))
			{
				sb.Append(rules[c]);
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

	struct point
	{
		public point(Vector3 rP, Vector3 rA, float rL) { Point = rP; Angle = rA; BranchLength = rL; }
		public Vector3 Point;
		public Vector3 Angle;
		public float BranchLength;
	}

    //TRANSFORMA AS REGRAS EM PONTOS
	private void determinecauleprincipal(string p_input)
	{
        //Cria uma pilha chamada returnValue
        //Passando a struct point como elemento
		Stack<point> returnValues = new Stack<point>();
		point lastPoint = new point(Vector3.zero, Vector3.zero, 1f);
		point primeirasPonto = new point(Vector3.zero, Vector3.zero, 1f);
		returnValues.Push(lastPoint);

		foreach (char c in p_input)
		{
			switch (c)
			{
                //Caule principal
                case 'I': // Draw line of length lastBranchLength, in direction of lastAngle
                cauleprincipal.Add(lastPoint);

                point caule = new point(lastPoint.Point + new Vector3(0, 0.5f, 0), lastPoint.Angle, 0.5f);
                caule.BranchLength = lastPoint.BranchLength;
                if (caule.BranchLength <= 0.0f) caule.BranchLength = 0.001f;

                caule.Angle.y = lastPoint.Angle.y + UnityEngine.Random.Range(-30, 30);

                caule.Point = pivot(caule.Point, lastPoint.Point, new Vector3(caule.Angle.x, 0, 0));
                caule.Point = pivot(caule.Point, lastPoint.Point, new Vector3(0, caule.Angle.y, 0));

                cauleprincipal.Add(caule);
                lastPoint = caule;
                break;


                //Primeiras folhas
                case 'z': // Draw line of length lastBranchLength, in direction of lastAngle
                //Cria um ponto na struct passando como referencia ((posicao inicial + posicao final), rotacao, e nao sei
                point folhas = new point(primeirasPonto.Point, primeirasPonto.Angle, 1f);
              
                primeirasList.Add(folhas);
            
                break;

                case 'S': // Draw line of length lastBranchLength, in direction of lastAngle
                caulesecundario.Add(lastPoint);

                point newPoint = new point(lastPoint.Point + new Vector3(0, 0.5f, 0), lastPoint.Angle, 0.5f);
                newPoint.BranchLength = lastPoint.BranchLength;
                if (newPoint.BranchLength <= 0.0f) newPoint.BranchLength = 0.001f;

                newPoint.Angle.y = lastPoint.Angle.y + UnityEngine.Random.Range(-30, 30);

                newPoint.Point = pivot(newPoint.Point, lastPoint.Point, new Vector3(newPoint.Angle.x, 0, 0));
                newPoint.Point = pivot(newPoint.Point, lastPoint.Point, new Vector3(0, newPoint.Angle.y, 0));

                caulesecundario.Add(newPoint);
                lastPoint = newPoint;
                break;

               //Folhas trifoliadas
                case 'L': // Draw line of length lastBranchLength, in direction of lastAngle
          		caulesecundario.Add(lastPoint);

                point newPoint2 = new point(lastPoint.Point + new Vector3(0, 0.5f, 0), lastPoint.Angle, 0.5f);
                newPoint2.BranchLength = lastPoint.BranchLength;
                if (newPoint2.BranchLength <= 0.0f) newPoint2.BranchLength = 0.001f;

                newPoint2.Angle.y = lastPoint.Angle.y + UnityEngine.Random.Range(-30, 30);

                newPoint2.Point = pivot(newPoint2.Point, lastPoint.Point, new Vector3(newPoint2.Angle.x, 0, 0));
                newPoint2.Point = pivot(newPoint2.Point, lastPoint.Point, new Vector3(0, newPoint2.Angle.y, 0));

                caulesecundario.Add(newPoint2);
                lastPoint = newPoint2;
                break;

                //Regiao Foliar
                case 'p': // Draw line of length lastBranchLength, in direction of lastAngle
                // cauleprincipal.Add(lastPoint);

                // point regiaoFolhiar = new point(lastPoint.Point + new Vector3(0, lastPoint.BranchLength, 0), lastPoint.Angle, 1f);
                // newPoint.BranchLength = lastPoint.BranchLength - 0.02f;
                // if (newPoint.BranchLength <= 0.0f) newPoint.BranchLength = 0.001f;

                // newPoint.Angle.y = lastPoint.Angle.y + UnityEngine.Random.Range(-30, 30);

                // newPoint.Point = pivot(regiaoFolhiar.Point, lastPoint.Point, new Vector3(regiaoFolhiar.Angle.x, 0, 0));
                // newPoint.Point = pivot(newPoint.Point, lastPoint.Point, new Vector3(0, newPoint.Angle.y, 0));

                // cauleprincipal.Add(regiaoFolhiar);
                // lastPoint = regiaoFolhiar;
                break;

                case '+': // Rotate +30
                primeirasPonto.Angle.y += 0;               
                lastPoint.Angle.x += 30.0f;  
                lastPoint.Angle.y += 90.0f;  
                break;

                case '[': // Save State
                returnValues.Push(lastPoint);
                break;

                case '-': // Rotate -30 
                primeirasPonto.Angle.y += 180.0f;   
                primeirasPonto.Point.x = 0.55f;  

                lastPoint.Angle.x += -30.0f; 
                lastPoint.Angle.y += 90.0f; 
                break;

                case ']': // Load Saved State
                lastPoint = returnValues.Pop();
                break;
            }
        }
    }
    //Percorre lista de caule principal para criar o objeto
    private void CriarCaulePrincipais()
    {
    	for (int i = 0; i < cauleprincipal.Count; i += 2)
    	{
    		CriarCaulePrincipal(cauleprincipal[i], cauleprincipal[i + 1], 0.1f);
    	}
    }

    //Percorre a lista de Folhas passando o angulo e a posicao para ser criado o objeto
    private void CriarPrimeirasFolhas()
    {
    	for (int i = 0; i < primeirasList.Count; i += 1)
    	{
    		CriarPrimeiraFolha(primeirasList[i].Angle,primeirasList[i]);
    	}
    }

    //Percorre lista de caule principal para criar o objeto
    private void CriarCauleSecundarios()
    { 
    
    	for (int i = 0; i < caulesecundario.Count; i += 2)
    	{
    		CriarCauleSecundario(caulesecundario[i], caulesecundario[i + 1], 0.1f);
    	}
    }
 

    // Pivot point1 around point2 by angles
    private Vector3 pivot(Vector3 point1, Vector3 point2, Vector3 angles)
    {
    	Vector3 dir = point1 - point2;
    	dir = Quaternion.Euler(angles) * dir;
    	point1 = dir + point2;
    	return point1;
    }

    private void CriarCaulePrincipal(point point1, point point2, float radius)
    {
        //UnityEngine.Random.Range(0,3);
        //Cria o cilindro, de acordo com o cilindro passado como referencia
    	GameObject newCylinder = (GameObject)Instantiate(cylinder);
        //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
    	newCylinder.SetActive(true);

        //Comprimento do ramo(1 ponto ao outro)
    	float length = Vector3.Distance(point2.Point, point1.Point);
    	radius = radius * length;

        //Scale o tamanho do cylindro(x,y,z) y = comprimento
    	Vector3 scale = new Vector3(0.05f, 0.5f , 0.05f);
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
    	GameObject newCylinder = (GameObject)Instantiate(cylinder);
        //Seta esse cilindro como ativo, porque o cilindro passado por referencia esta invisivel
    	newCylinder.SetActive(true);

        //Comprimento do ramo(1 ponto ao outro)
    	float length = Vector3.Distance(point2.Point, point1.Point);
    	radius = radius * length;

        //Scale o tamanho do cylindro(x,y,z) y = comprimento
    	Vector3 scale = new Vector3(0.05f, 0.5f , 0.05f);
    	newCylinder.transform.localScale = scale;

        //Seta o ponto inicial dos cilindros como o mesmo do seu ramo
    	newCylinder.transform.position = (point1.Point + new Vector3(0,0.5f,0));
        //Rotaciona de acordo com a regra + ou -
    	newCylinder.transform.Rotate(point2.Angle);
        //Coloca todos os ramos como Parent do Object Soja3D
    	newCylinder.transform.parent = this.transform;
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

    // Update is called once per frame
    void Update ()
    {
        //Se ativado, não destroi os ramos criados para que seja possivel estudar cada ramo
    	if (debug)
    	{
    		for (int i = 0; i < cauleprincipal.Count; i += 2)
    		{
    			Debug.DrawLine(cauleprincipal[i].Point, cauleprincipal[i + 1].Point, Color.black);
    		}
    	}
    }
}
