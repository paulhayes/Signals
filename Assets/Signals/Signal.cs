using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject 
{
	event System.Action<object> listeners;

	internal void TriggerAmbiguous(object obj)
	{
		if( listeners != null){
			listeners.Invoke(obj);
		}
	}

	public void Trigger()
	{
		TriggerAmbiguous(null);
	}

	public void Trigger(int i)
	{
		TriggerAmbiguous(i);
	}

	public void Trigger(bool b)
	{
		TriggerAmbiguous(b);
	}

	public void Trigger(UnityEngine.Object obj)
	{
		TriggerAmbiguous(obj);
	}

	public void Trigger(System.Object obj)
	{
		TriggerAmbiguous(obj);
	}

	public void Attach(System.Action<object> callback)
	{
		listeners += callback;
	}

	public void Detach(System.Action<object> callback)
	{
		listeners -= callback;
	}

    void OnDisable()
	{
		listeners = null;
	}

}
