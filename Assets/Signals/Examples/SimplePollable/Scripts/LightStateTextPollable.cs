using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightStateTextPollable : MonoBehaviour {

	[SerializeField]
	BoolPollable lightState;

	[SerializeField]
	TextMesh textField;
	
	void Start()
	{
		UpdateText();
	}

	void Update () 
	{
		if( lightState.HasChanged() ){
			UpdateText();
		}	
	}

	void UpdateText()
	{
		textField.text = lightState.Value ? "On" : "Off" ;
	}
}
