using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Signal))]
public class SignalInspector : Editor 
{
    private UnityEngine.Object v;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if( Application.isPlaying ){
            v = EditorGUILayout.ObjectField(v,typeof(UnityEngine.Object), true);
            if( GUILayout.Button("Trigger") ){
                var obj = new GameObject();
                var triggerComponent = obj.AddComponent<TriggerSignal>();
                triggerComponent.target = target as Signal;
                triggerComponent.triggerOnStart = true;
                triggerComponent.data = v;
            }
        }       
    }
}
