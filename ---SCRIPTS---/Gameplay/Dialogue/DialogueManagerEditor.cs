#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(DialogueManager))]
public class DialogueManagerEditor : Editor
{
    
    //private SerializedProperty tutorialTextAssetProperty;
    private SerializedProperty tutorialTextProperty;

    private void OnEnable()
    {
        //tutorialTextAssetProperty = serializedObject.FindProperty("tutorialTextAsset");
        tutorialTextProperty = serializedObject.FindProperty("dialogueTutorial");
    }

    public override void OnInspectorGUI()
    {
        int stringListSize = tutorialTextProperty.arraySize;
        for (int i = 0; i < stringListSize; i++)
        {
            SerializedProperty stringProperty = tutorialTextProperty.GetArrayElementAtIndex(i);
            EditorGUILayout.PropertyField(stringProperty, new GUIContent("String " + i));
            serializedObject.Update();
        }
    }

}
#endif
