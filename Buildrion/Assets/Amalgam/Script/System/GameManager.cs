using UnityEngine;

//オプションとかの管理をする予定

public class GameManager : Singleton<GameManager>
{
    // Start is called before the first frame update
    void Start()
    {
        //フレームレート設定
        Application.targetFrameRate = 60;
    }
}
