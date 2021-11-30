using UnityEngine;
using UnityEngine.UI;

//�I�v�V�����Ƃ��̊Ǘ�������\��

public enum GameState
{
    Title = 0,
    Game,
    Result,
    GameStateMax
}

public class GameManager : Singleton<GameManager>
{
    [Header("��������")]
    [SerializeField] private float timer;

    [Header("������")]
    [SerializeField] private int money;
    [SerializeField] private Text moneyText;

    [Header("���{�b�g��")]
    [SerializeField] private RobotBase roboBase;
    [SerializeField] private Text roboText;

    [Header("���̎��̔{��")]
    [SerializeField] private float margedRate;

    private GameState gameState;
    public bool isGameEnd;

    private GameTimer gameTimer;

    void Start()
    {
        //�t���[�����[�g�ݒ�
        Application.targetFrameRate = 60;

        roboBase = GameObject.FindGameObjectWithTag("RobotBase").GetComponent<RobotBase>();

        margedRate = 3.0f;

        gameState = GameState.Game;
        isGameEnd = false;

        gameTimer = new GameTimer(timer);
    }

    private void Update()
    {
        if(gameState == GameState.Title)
        {
            isGameEnd = false;
        }
        else if(gameState == GameState.Game)
        {
            if (moneyText != null)
            {
                moneyText.text = "MONEY :" + money.ToString("D8");
            }

            if (roboText != null)
            {
                roboText.text = "���{���^�ő吔 = " + roboBase.GetNowRobotCnt() + "�^" + roboBase.robotMax;
            }

            gameTimer.UpdateTimer();

            if(gameTimer.IsTimeUp)
            {
                gameState = GameState.Result;

                //���_�v�Z
                
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
                moneyText.text = "MONEY :" + money.ToString("D8");
            }

            if (roboText != null)
            {
                roboText.text = "���{���^�ő吔 = " + roboBase.GetNowRobotCnt() + "�^" + roboBase.robotMax;
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
}
