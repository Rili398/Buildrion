using UnityEngine;
using UnityEditor;

//�C���X�y�N�^��̔z��̗v�f�ɖ��O��t������悤�ɂ���

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
