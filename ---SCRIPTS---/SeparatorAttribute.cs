#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class SeparatorAttribute : PropertyAttribute { }

[CustomPropertyDrawer(typeof(SeparatorAttribute))]
public class SeparatorDrawer : DecoratorDrawer
{
    public override void OnGUI(Rect position)
    {
        position.y += position.height / 2;
        position.height = 1;
        EditorGUI.DrawRect(position, Color.gray);
    }

    public override float GetHeight()
    {
        return 2;
    }
}

#endif