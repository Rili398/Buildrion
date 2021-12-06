using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//オプションとかの管理をする予定

public enum GameState
{
    Title = 0,
    Game,
    Result,
    GameStateMax
}

public class GameManager : Singleton<GameManager>
{
    [Header("制限時間")]
    [SerializeField] private float timer;

    [Header("所持金")]
    [SerializeField] private int money;
    [SerializeField] private Text moneyText;

    [Header("ロボット数")]
    [SerializeField] private RobotBase roboBase;
    [SerializeField] private Text roboText;

    [Header("合体時の倍率")]
    [SerializeField] private float margedRate;
    const float DefaultMargeRate = 3.0f;

    private GameState gameState;
    public bool isGameEnd;

    private GameTimer gameTimer;
    [SerializeField] private Text timeText;
    public bool isTimeStop;

    void Start()
    {
        //フレームレート設定
        Application.targetFrameRate = 60;

        roboBase = GameObject.FindGameObjectWithTag("RobotBase").GetComponent<RobotBase>();

        margedRate = 3.0f;

        gameState = GameState.Game;
        isGameEnd = false;
        isTimeStop = false;

        gameTimer = new GameTimer(timer);
    }

    private void Update()
    {
        if(gameState == GameState.Title)
        {
            isGameEnd = false;
            gameState = GameState.Game;
        }
        else if(gameState == GameState.Game)
        {
            if (moneyText != null)
            {
                moneyText.text = "所持金：" + money.ToString("D8");
            }

            if (roboText != null)
            {
                roboText.text = "ロボ数：　" + roboBase.GetNowRobotCnt() + "／" + roboBase.robotMax;
            }

            if(timeText != null)
            {
                int tmp = Mathf.FloorToInt(gameTimer.LeftTime);
                timeText.text = tmp.ToString();
            }

            if (!isTimeStop)
            {
                gameTimer.UpdateTimer();
            }

            if(gameTimer.IsTimeUp)
            {
                //得点計算
                Singleton<ResultMaster>.Instance.ScoreCalculate();
                gameTimer.ResetTimer();
                gameState = GameState.Result;
            }
        }
        else if(gameState == GameState.Result)
        {
            if(!isGameEnd)
            {
                isGameEnd = true;
            }

            if (moneyText != null)
            {
                moneyText.text = "所持金：" + money.ToString("D8");
            }

            if (roboText != null)
            {
                roboText.text = "ロボ数　" + roboBase.GetNowRobotCnt() + "／" + roboBase.robotMax;
            }
        }
    }

    //=========================================================================

    public void AddMoney(int value)
    {
        money += value;
    }

    public int GetMoney()
    {
        return money;
    }

    public float GetMargeRate()
    {
        return margedRate;
    }

    public void SetMargeRate(float inMRate)
    {
        margedRate = inMRate;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void SetGameState(GameState gs)
    {
        gameState = gs;
    }

    public void ResetGame()
    {
        gameTimer.ResetTimer();
        money = 0;
        gameState = GameState.Title;
        margedRate = DefaultMargeRate;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
