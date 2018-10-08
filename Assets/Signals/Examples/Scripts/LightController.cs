using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {
	[SerializeField]
	Signal lightSignal;

	[SerializeField]
	Light light;

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
        light.enabled =!light.enabled;
    }
}
