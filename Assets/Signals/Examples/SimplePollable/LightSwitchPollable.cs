using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightSwitchPollable : MonoBehaviour, IPointerDownHandler 
{
	[SerializeField]
	BoolPollable lightState;

    public void OnPointerDown(PointerEventData eventData)
    {
        lightState.Value = !lightState.Value;
    }

    	
}
