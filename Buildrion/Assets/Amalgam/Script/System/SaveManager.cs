using UnityEngine;
using UnityEngine.Events;
using System.IO;

//本来はシングルトンにして使う

public class SaveManager : MonoBehaviour
{
    #region Field
    /// <summary>
    /// セーブデータファイルの保存場所パス(Awakeで取得する)
    /// </summary>
    [SerializeField] private string filePath;

    /// <summary>
    /// セーブデータ本体
    /// </summary>
    private SaveData _save;

    /// <summary>
    /// ロードされた時に呼び出す関数群を登録しておく
    /// </summary>
    public UnityEvent events;
    #endregion

    #region Property
    /// <summary>
    /// セーブデータを弄る時はこれを使って
    /// </summary>
    public SaveData SaveD
    {
        get { return _save; }
    }
    #endregion

    #region Function
    private void Awake()
    {
        filePath = Application.persistentDataPath + "/" + "savedata.json";
        Debug.Log(filePath);
        _save = new SaveData();
    }

    //===================================================================================
    public void Save()
    {
        string json = JsonUtility.ToJson(_save);

        StreamWriter sw = new StreamWriter(filePath);
        sw.Write(json);
        sw.Flush();
        sw.Close();

        Debug.Log("Save");
    }

    public void Load()
    {
        //セーブファイルの存在確認
        if(File.Exists(filePath))
        {
            StreamReader sr = new StreamReader(filePath);
            string data = sr.ReadToEnd();
            sr.Close();

            _save = JsonUtility.FromJson<SaveData>(data);
        }

        //ロードしたときに1回呼ぶ
        Progress();

        Debug.Log("Load");
    }

    //===================================================================================
    private void Progress()
    {
        //セーブデータを参照して値を設定する等の関数を登録しておく
        events.Invoke();
    }
    #endregion
}
