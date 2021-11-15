using UnityEngine;

//配列に名前を付けるインスペクタ拡張

public class NamedArrayAtr : PropertyAttribute
{
    public readonly string[] names;
    public NamedArrayAtr(string[] names) { this.names = names; }
}
