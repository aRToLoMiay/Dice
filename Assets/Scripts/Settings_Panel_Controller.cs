using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_Panel_Controller : MonoBehaviour {

	public Transform settingsPanel;
	public GameObject manualPanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Exit_Button_Click()
	{
		Application.Quit ();
	}
		
	public void Manual_Button_Click()
	{
		manualPanel.SetActive (true);
	}

	public void CloseManual_Button_Click()
	{
		manualPanel.SetActive (false);
	}


}
