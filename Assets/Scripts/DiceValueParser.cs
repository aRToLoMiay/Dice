using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceValueParser : MonoBehaviour {

	public Transform diceValuePanel;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}

	public int GetMinimumDiceValue()
	{
		int result = 0;
		Transform minimumDiceValue_InputField = diceValuePanel.GetChild (0).GetChild (0).GetChild (2);
		if (minimumDiceValue_InputField.GetComponent<Text> ().text.Length != 0) {
			result = System.Convert.ToInt32 (minimumDiceValue_InputField.GetComponent<Text> ().text);
		}
		return result;
	}

	public int GetMaximumDiceValue()
	{
		int result = 0;
		Transform maximumDiceValue_InputField = diceValuePanel.GetChild (1).GetChild (0).GetChild (2);
		if (maximumDiceValue_InputField.GetComponent<Text> ().text.Length != 0) {
			result = System.Convert.ToInt32 (maximumDiceValue_InputField.GetComponent<Text> ().text);
		}
		return result;
	}
}
