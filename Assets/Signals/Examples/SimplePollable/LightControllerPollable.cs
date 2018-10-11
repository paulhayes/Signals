using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControllerPollable : MonoBehaviour 
{
	[SerializeField]
	BoolPollable pollable;

	[SerializeField]
	Light light;

	void Start()
	{
		light.enabled = pollable.Value;
	}

	void Update()
	{
		if( pollable.HasChanged() ){
			light.enabled = pollable.Value;
		}
	}
}
