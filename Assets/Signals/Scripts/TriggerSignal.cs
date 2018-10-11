using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSignal : MonoBehaviour {

	public Signal target;

	public System.Object data;
	public bool triggerOnStart;
	void Start()
	{
		if( triggerOnStart ){
			target.TriggerAmbiguous( data );
			Destroy( gameObject );
		}
	}
}
