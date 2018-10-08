using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightSwitch : MonoBehaviour, IPointerDownHandler {

	[SerializeField]
	Signal switchSignal;

    public void OnPointerDown(PointerEventData eventData)
    {
        switchSignal.Trigger();
    }

    
}
