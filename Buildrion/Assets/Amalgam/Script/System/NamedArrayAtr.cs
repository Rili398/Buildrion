using UnityEngine;

//�z��ɖ��O��t����C���X�y�N�^�g��

public class NamedArrayAtr : PropertyAttribute
{
    public readonly string[] names;
    public NamedArrayAtr(string[] names) { this.names = names; }
}
