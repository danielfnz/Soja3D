using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MacroNutrientes : MonoBehaviour {

	private float pH;//0 fraco - 1 media - 2 alto
	private float P; //fosforo
	private float K; //potassio
	private float Ca; //calcio
	private float Mg; //magnesio
	private float S; //enxofre
	private float Hal; //Hidrogenio/Aluminio
	private float Al;//Aluminio

	private string ValorTexturaTexto;
	private string ValorPhTexto;

	private Color phColor;
	private Color TexturaColor;

	private float CTCTotal;

	private float SatAl;
	//private float PCTC;
	private float KCTC;
	private float CaCTC;
	private float MgCTC;
	private float SCTC;
	private float HalCTC;

	//GameObjects para pegar os valores dos macronutrientes
	public GameObject TexturaObj;
	public GameObject phObj;
	public GameObject painelObj;

	//GameObjects para apresentar o resultado da analise
	public GameObject phObj2;
	public GameObject ctcObj;
	public GameObject CaCTCObj;
	public GameObject MgCTCObj;
	public GameObject KCTCObj;
	public GameObject SatAlOBJ;
	public GameObject SObj;
	public GameObject PObj;

	//Objetos para apresentar o Textura do solo e pH
	public Text ValorPh;
	public GameObject ValorTextura1;
	public GameObject ValorTextura;

	//Fosforo
	public GameObject MetodoFosforoSlide;
	public GameObject TeorArgilaSlide;
	public GameObject pMelSlide1;
	public GameObject pMelSlide;
	public GameObject pRemSlide;
	private double TeorArgilaValor,VR;
	private double NiCri,pMelValor,pRemValor;

	public void SetMacronutrientes() {
		Ca = float.Parse(System.String.Format("{0:0.00}", painelObj.transform.GetChild(1).GetComponent<Slider>().value));
		Mg = float.Parse(System.String.Format("{0:0.00}", painelObj.transform.GetChild(3).GetComponent<Slider>().value));
		Al = float.Parse(System.String.Format("{0:0.00}", painelObj.transform.GetChild(5).GetComponent<Slider>().value));
		Hal = float.Parse(System.String.Format("{0:0.00}", painelObj.transform.GetChild(7).GetComponent<Slider>().value));
		K = float.Parse(System.String.Format("{0:0.00}", painelObj.transform.GetChild(9).GetComponent<Slider>().value));
		S = float.Parse(System.String.Format("{0:0.00}", painelObj.transform.GetChild(11).GetComponent<Slider>().value));
		
		SetPh();
		SetFosforo();

		CalcularCTC();

		SetSatAl();
		SetCalcioCTC();
		SetMagnesioCTC();
		SetPotassioCTC();
		SetEnxofre();

		InterpretarAnalise();
	}

	public void SetFosforo(){

		//Teor de Argila
		if(MetodoFosforoSlide.GetComponent<Dropdown>().value == 0){
			PObj.transform.GetChild(2).GetComponent<Slider>().minValue = 1; 

			TeorArgilaValor = (TeorArgilaSlide.GetComponent<Slider>().value / 10);
			pMelValor = pMelSlide1.GetComponent<Slider>().value;

			if(TeorArgilaValor <=15){
				PObj.transform.GetChild(2).GetComponent<Slider>().maxValue = 30; 

				if(pMelValor <=6.0){
					print("Fosforo muito baixo");
					
				}
				if(pMelValor>=6.1 && pMelValor<=12){
					print("Fosforo baixo");

				}
				if(pMelValor>=12.1 && pMelValor<=18){
					print("Fosforo medio");

				}
				if(pMelValor>=18.1 && pMelValor<=25){
					print("Fosforo adequado");

				}
				if(pMelValor >25){
					print("Fosforo alto");

				}
			}
			if(TeorArgilaValor>=16 && TeorArgilaValor<=35){
				PObj.transform.GetChild(2).GetComponent<Slider>().maxValue = 25; 
				if(pMelValor <=5){
					print("Fosforo muito baixo");
					
				}
				if(pMelValor>=5.1 && pMelValor<=10){
					print("Fosforo baixo");

				}
				if(pMelValor>=10.1 && pMelValor<=15){
					print("Fosforo medio");

				}
				if(pMelValor>=15.1 && pMelValor<=20){
					print("Fosforo adequado");

				}
				if(pMelValor >20){
					print("Fosforo alto");

				}
			}
			if(TeorArgilaValor>=36 && TeorArgilaValor<=60){
				PObj.transform.GetChild(2).GetComponent<Slider>().maxValue = 20; 
				if(pMelValor <=3){
					print("Fosforo muito baixo");
					
				}
				if(pMelValor>=3.1 && pMelValor<=5){
					print("Fosforo baixo");

				}
				if(pMelValor>=5.1 && pMelValor<=8){
					print("Fosforo medio");

				}
				if(pMelValor>=8.1 && pMelValor<=12){
					print("Fosforo adequado");

				}
				if(pMelValor >12){
					print("Fosforo alto");

				}
			}
			if(TeorArgilaValor >=60){
				PObj.transform.GetChild(2).GetComponent<Slider>().maxValue = 10; 
				if(pMelValor <=2.0){
					print("Fosforo muito baixo");
					
				}
				if(pMelValor>=2.1 && pMelValor<=3){
					print("Fosforo baixo");

				}
				if(pMelValor>=3.1 && pMelValor<=4){
					print("Fosforo medio");

				}
				if(pMelValor>=4.1 && pMelValor<=6){
					print("Fosforo adequado");

				}
				if(pMelValor >6){
					print("Fosforo alto");

				}
			}
			SetTextura();
		}

		//P(rem) e P(mel)
		if(MetodoFosforoSlide.GetComponent<Dropdown>().value == 1){
			pMelValor = pMelSlide.GetComponent<Slider>().value;
			pRemValor = pRemSlide.GetComponent<Slider>().value;

			//Passo 1
			NiCri = 4.62 +(0.324741 * pRemValor) + (0.00160568 * (pRemValor*pRemValor));
			//Passo 2
			VR = (pMelValor / NiCri) * 100;	

			if(VR <=50){
				print("Fosforo muito baixo");

			}
			if(VR>=50.1 && VR<=72.5){
				print("Fosforo baixo");

			}
			if(VR>=72.6 && VR<=100){
				print("Fosforo medio");

			}
			if(VR>=100.1 && VR<=150){
				print("Fosforo adequado");

			}
			if(VR >=150){
				print("Fosforo alto");

			}
		}
	}

	public void SetTextura() {	

		if(TeorArgilaValor<1){
			print("Textura do solo: Arenosa");
			ValorTexturaTexto = "Arenosa";
			TexturaColor = Color.red;

		}
		if(TeorArgilaValor>=1 && TeorArgilaValor<4){
			print("Textura do solo: Media");
			ValorTexturaTexto = "Média";
			TexturaColor = Color.yellow;
		}
		if(TeorArgilaValor>=4){
			print("Textura do solo: Argilosa");
			ValorTexturaTexto = "Argilosa";
			TexturaColor = Color.green;
		}
		
		ValorTextura.SetActive(true);
		ValorTextura1.SetActive(true);
		ValorTextura.GetComponent<Text>().text =  ValorTexturaTexto.ToString();
		ValorTextura.GetComponent<Text>().color =  TexturaColor;

	}

	public void SetPh() {
		this.pH = phObj.transform.GetChild(1).GetComponent<Slider>().value;

		this.pH = float.Parse(System.String.Format("{0:0.0}",this.pH));

		if(this.pH < 4.6){
			print("pH do solo: Baixo");
			ValorPhTexto = "Baixo";
			phColor = Color.red;
		}
		if(this.pH>=4.6 && this.pH<=5.5){
			print("ph do solo: Medio");
			ValorPhTexto = "Médio";
			phColor = Color.yellow;
		}
		if(this.pH>=5.6 && this.pH<=6.5){
			print("pH do solo: Alto");
			ValorPhTexto = "Alto";
			phColor = Color.green;
		}
	}

	public void CalcularCTC(){
		this.CTCTotal = Ca+Mg+Hal+K;
		this.CTCTotal = float.Parse(System.String.Format("{0:0.00}",this.CTCTotal));

		if(CTCTotal <= 1.6){
			print ("CTC muito Baixa " + CTCTotal);
		}
		if(CTCTotal>=1.7 && CTCTotal <=4.3) {
			print ("CTC baixo "+CTCTotal);
		}
		if(CTCTotal>=4.4 && CTCTotal <=8.6) {
			print ("CTC medio "+CTCTotal);
		}
		if (CTCTotal > 8.6){
			print ("CTC Alta "+CTCTotal);
		}
	}

	private void SetSatAl(){
		this.SatAl = (Al/(Ca+Mg+K+Al)) * 100;
		this.SatAl = float.Parse(System.String.Format("{0:0.00}",this.SatAl));

		if(SatAl <= 2){
			print ("Saturacao de Aluminio(SatAl) Baixo "+ SatAl);
		}
		if(SatAl>=3 && SatAl <=5) {
			print ("Saturacao de Aluminio(SatAl) Medio "+ SatAl);
		}
		if(SatAl>=6 && SatAl <=10) {
			print ("Saturacao de Aluminio(SatAl) Alto "+ SatAl);
		}
	}

	public void SetCalcioCTC(){
		this.CaCTC = (Ca / CTCTotal) *100;
		this.CaCTC = float.Parse(System.String.Format("{0:0.00}",this.CaCTC));

		if(CaCTC <= 15){
			print ("Calcio muito Baixo "+ CaCTC);
		}
		if(CaCTC>=16 && CaCTC <=25) {
			print ("Calcio baixo "+ CaCTC);
		}
		if(CaCTC>=26 && CaCTC <=40) {
			print ("Calcio medio "+ CaCTC);
		}
		if (CaCTC > 40){
			print ("Calcio Adequado "+ CaCTC);
		}
	}

	public void SetMagnesioCTC(){
		this.MgCTC = (Mg / CTCTotal) *100;
		this.MgCTC = float.Parse(System.String.Format("{0:0.00}",this.MgCTC));

		if(MgCTC <= 5){
			print ("Magnesio muito Baixo "+MgCTC);
		}
		if(MgCTC>=6 && MgCTC <=10) {
			print ("Magnesio baixo "+MgCTC);
		}
		if(MgCTC>=11 && MgCTC <=15) {
			print ("Magnesio medio "+MgCTC);
		}
		if (MgCTC >= 16){
			print ("Magnesio Adequado "+MgCTC);
		}
	}

/*	public void SetHidrogenioCTC(){
		this.HalCTC = (Hal / CTCTotal) *100;
		this.HalCTC = float.Parse(System.String.Format("{0:0.00}",this.HalCTC));

		if(HalCTC <45){
			print ("Hidrogenio +Al Baixo "+HalCTC);
		}
		if(HalCTC>=45 && HalCTC <=100) {
			print ("Hidrogenio +Al medio "+HalCTC);
		}
		if (HalCTC > 100){
			print ("Hidrogenio +Al alto "+HalCTC);
		}
	}*/			

	public void SetPotassioCTC(){
		this.KCTC = (K/ CTCTotal) * 100;
		this.KCTC = float.Parse(System.String.Format("{0:0.00}",this.KCTC));

		if(KCTC <=1){
			print ("Potassio muito Baixo "+KCTC);
		}
		if(KCTC >=1.1 && KCTC <=2){
			print ("Potassio  Baixo "+KCTC);
		}
		if(KCTC>=2.1 && KCTC <=3) {
			print ("Potassio medio "+KCTC);
		}
		if (KCTC >= 3.1){
			print ("Potassio adequado "+KCTC);
		}
	}

	public void SetEnxofre(){
		if(S<=4) {
			print ("Enxofre baixo "+S);
		}
		if(S>=5 && S <=9) {
			print ("Enxofre medio "+S);
		}
		if (S >= 10){
			print ("Enxofre alto "+S);
		}
	}	

	private void InterpretarAnalise() {
	//Setando valores no textos
		phObj2.transform.GetChild(1).GetComponent<Text>().text =  pH.ToString();
		ctcObj.transform.GetChild(1).GetComponent<Text>().text =  CTCTotal.ToString();
		CaCTCObj.transform.GetChild(1).GetComponent<Text>().text =  CaCTC.ToString();
		MgCTCObj.transform.GetChild(1).GetComponent<Text>().text =  MgCTC.ToString();
		KCTCObj.transform.GetChild(1).GetComponent<Text>().text =  KCTC.ToString();
		SatAlOBJ.transform.GetChild(1).GetComponent<Text>().text =  SatAl.ToString();
		SObj.transform.GetChild(1).GetComponent<Text>().text =  S.ToString();
		if(MetodoFosforoSlide.GetComponent<Dropdown>().value == 1){
			PObj.transform.GetChild(1).GetComponent<Text>().text =  VR.ToString();
		}
		else {
			PObj.transform.GetChild(1).GetComponent<Text>().text =  pMelValor.ToString();
		}

	//setando valores no slides
		phObj2.transform.GetChild(2).GetComponent<Slider>().value =  pH;
		ctcObj.transform.GetChild(2).GetComponent<Slider>().value =  CTCTotal;
		CaCTCObj.transform.GetChild(2).GetComponent<Slider>().value =  CaCTC;
		MgCTCObj.transform.GetChild(2).GetComponent<Slider>().value =  MgCTC;
		KCTCObj.transform.GetChild(2).GetComponent<Slider>().value =  KCTC;
		SatAlOBJ.transform.GetChild(2).GetComponent<Slider>().value =  SatAl;
		SObj.transform.GetChild(2).GetComponent<Slider>().value =  S;
		if(MetodoFosforoSlide.GetComponent<Dropdown>().value == 1){
			PObj.transform.GetChild(2).GetComponent<Slider>().value =  (float)VR;
		}
		else {
			PObj.transform.GetChild(2).GetComponent<Slider>().value =  (float)pMelValor;
		}

		ValorPh.GetComponent<Text>().text =  ValorPhTexto.ToString();
		ValorPh.GetComponent<Text>().color =  phColor;
	}	

}
