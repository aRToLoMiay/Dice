using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignificanceParameterController : MonoBehaviour {

	public GameObject significanceParameterPanel;

	private int BASE_SIGNIFICANCE_PARAMETER_SLIDER_VALUE = 15;
	private double COMPRESSION_RATIO_SLIDER = 0.05;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SignificanceParameterReset_Button_Click()
	{
		GameObject.Find ("SignificanceParameter_Slider").GetComponent<Slider> ().value = BASE_SIGNIFICANCE_PARAMETER_SLIDER_VALUE;
	}

	public double GetSignificanceParameter()
	{
		float sliderValue = GameObject.Find ("SignificanceParameter_Slider").GetComponent<Slider> ().value;
		return sliderValue * COMPRESSION_RATIO_SLIDER;
	}
}
