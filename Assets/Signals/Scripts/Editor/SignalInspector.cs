using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Signal))]
public class SignalInspector : Editor 
{
    private UnityEngine.Object v;
    private object objectValue;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if( Application.isPlaying ){
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Debug Tools");
            var dataType = serializedObject.FindProperty("dataType");
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField( dataType );
            if( EditorGUI.EndChangeCheck() ){
                serializedObject.ApplyModifiedProperties();
            }
            switch( (Signal.TypeEnum)dataType.enumValueIndex ){
                case Signal.TypeEnum.Int: {
                    if(!(objectValue is int)){
                        objectValue = 0;
                    }
                    objectValue = EditorGUILayout.IntField("Value ",(int)objectValue);
                    break;
                }
                case Signal.TypeEnum.Float: {
                    if(!(objectValue is float)){
                        objectValue = 0f;
                    }
                    objectValue = EditorGUILayout.FloatField("Value ",(float)objectValue);
                    break;
                }
                case Signal.TypeEnum.String: {
                    if(!(objectValue is string)){
                        objectValue = string.Empty;
                    }
                    objectValue = EditorGUILayout.TextField("Value ",(string)objectValue);
                    break;
                }
                case Signal.TypeEnum.Boolean: {
                    if(!(objectValue is bool)){
                        objectValue = false;
                    }
                    objectValue = EditorGUILayout.Toggle("Value ",(bool)objectValue);
                    break;
                }
                case Signal.TypeEnum.Object: {
                    v = EditorGUILayout.ObjectField("Value ",v,typeof(UnityEngine.Object), true);
                    break;
                }
            }
            //EditorGUILayout.EnumFlagsField(target)
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
