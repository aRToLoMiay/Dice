using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterParser : MonoBehaviour
{

	public Transform parameterPanel;

	// Use this for initialization
	void Start ()
	{
	}

	// Update is called once per frame
	void Update ()
	{
	}

	public int GetLeftBorderParameter ()
	{
		int result = 0;
		Transform leftBorderParameter_InputField = parameterPanel.GetChild (0).GetChild (0).GetChild (2);
		if (leftBorderParameter_InputField.GetComponent<Text> ().text.Length != 0) {
			result = System.Convert.ToInt32 (leftBorderParameter_InputField.GetComponent<Text> ().text);
		}
		return result;
	}

	public int GetRightBorderParameter ()
	{
		int result = 0;
		Transform rightBorderParameter_InputField = parameterPanel.GetChild (1).GetChild (0).GetChild (2);
		if (rightBorderParameter_InputField.GetComponent<Text> ().text.Length != 0) {
			result = System.Convert.ToInt32 (rightBorderParameter_InputField.GetComponent<Text> ().text);
		}
		return result;
	}

	public int GetParameterValue ()
	{
		int result = 0;
		Transform parameterValue_InputField = parameterPanel.GetChild (2).GetChild (0).GetChild (2);
		if (parameterValue_InputField.GetComponent<Text> ().text.Length != 0) {
			result = System.Convert.ToInt32 (parameterValue_InputField.GetComponent<Text> ().text);
		}
		return result;
	}
}
