#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;


[CustomEditor(typeof(PlayAudio))]
public class PlayAudioEditor : Editor
{
    private SerializedProperty OptionsProp;
    private SerializedProperty AudioSelectedProp;
    private SerializedProperty PlayOnObjectProp;
    private SerializedProperty AudioTrigger;


    private void OnEnable()
    {
        OptionsProp = serializedObject.FindProperty("Action");
        AudioSelectedProp = serializedObject.FindProperty("heliAudioSelected");
        PlayOnObjectProp = serializedObject.FindProperty("audioType");
        AudioTrigger = serializedObject.FindProperty("playAudio");
    }

    public override void OnInspectorGUI()
    {

        
        serializedObject.Update();

        EditorGUILayout.LabelField("Play On Awake", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(AudioTrigger);
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Action when trigger", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(OptionsProp);
        if ((PlayAudio.Options)OptionsProp.enumValueIndex == PlayAudio.Options.HelicopterAudio)
        {
            AudioSelectedProp = serializedObject.FindProperty("heliAudioSelected");
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Helicopter Audio Select", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(AudioSelectedProp);
        }
        else if ((PlayAudio.Options)OptionsProp.enumValueIndex == PlayAudio.Options.PlayMiscDialogue)
        {
            AudioSelectedProp = serializedObject.FindProperty("heliAudioSelected");

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Misc Audio Select", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(AudioSelectedProp);
        }
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Where to Play Audio", EditorStyles.boldLabel);

        EditorGUILayout.PropertyField(PlayOnObjectProp);
        serializedObject.ApplyModifiedProperties();

    }
}
#endif