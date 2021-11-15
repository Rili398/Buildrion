using UnityEngine;
using UnityEditor;

//インスペクタ上の配列の要素に名前を付けられるようにする

[CustomPropertyDrawer(typeof(NamedArrayAtr))]
public class NameArrayDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        try
        {
            int pos = int.Parse(property.propertyPath.Split('[', ']')[1]);
            EditorGUI.PropertyField(position, property, new GUIContent(((NamedArrayAtr)attribute).names[pos]));
        }
        catch
        {
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
