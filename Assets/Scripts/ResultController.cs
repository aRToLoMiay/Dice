using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{

	public Transform resultPanel;
	public GameObject mainCamera;

	private Dice.Dice dice;
	//public ParameterParser pp;

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void CaluculateResult_Button_Click ()
	{ 
		int leftBorderParameter = mainCamera.GetComponent<ParameterParser> ().GetLeftBorderParameter ();
		int rightBorderParameter = mainCamera.GetComponent<ParameterParser> ().GetRightBorderParameter ();
		int parameterValue = mainCamera.GetComponent<ParameterParser> ().GetParameterValue ();
		int minimumDiceValue = mainCamera.GetComponent<DiceValueParser> ().GetMinimumDiceValue ();
		int maximumDiceValue = mainCamera.GetComponent<DiceValueParser> ().GetMaximumDiceValue ();
		double significanceParameter = mainCamera.GetComponent<SignificanceParameterController> ().GetSignificanceParameter ();
		dice = new Dice.Dice (minimumDiceValue, maximumDiceValue, leftBorderParameter, rightBorderParameter, significanceParameter);
		string result;
		if (!(leftBorderParameter < rightBorderParameter)) {
			result = "Левая граница параметра должна быть меньше правой.";
		} else if (!((parameterValue >= leftBorderParameter) && (parameterValue <= rightBorderParameter))) {
			result = "Значение параметра должно находиться между границами.";
		} else if (!(minimumDiceValue < maximumDiceValue)) {
			result = "Минимальное значение дайса должно быть меньше максимального.";
		} else {
			result = "Выпавшее значение:\n" + dice.ThrowDise (parameterValue).ToString ();
		}
		resultPanel.GetChild (1).GetComponent<Text> ().text = result.ToString();
		dice = null;
	}
}