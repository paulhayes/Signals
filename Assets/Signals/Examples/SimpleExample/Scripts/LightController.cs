using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	[SerializeField]
	Signal lightSignal;

	[SerializeField]
	Light targetLight;

	void OnEnable()
	{
		lightSignal.Attach(OnLightSignal);
	}

	void OnDisable()
	{
		lightSignal.Detach(OnLightSignal);
	}

    private void OnLightSignal(object obj)
    {
        targetLight.enabled =!targetLight.enabled;
    }
}
