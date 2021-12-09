using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//土地の情報を管理するクラス

public enum LandStatus
{
    NoBuild = 0,
    InConstruct,
    IsBuilt,
    LandStatMax
}

public class Land : MonoBehaviour
{
    [SerializeField, Tooltip("土地の状態")] private LandStatus landStatus;

    public bool isOrdered { get; set; }
    [SerializeField, Tooltip("作業中フラグ")] private bool isWarking;

    [Header("依頼情報")]
    [SerializeField] private int reward;
    [SerializeField] private int repuiredCount;
    [SerializeField] private string buildingName;
    public float workPower { get; set; } = 0;
    [SerializeField] private float wp;

    [Header("各種パラメータ")]
    [SerializeField] private List<Robot> robotList;
    [SerializeField] private ProgressBar02 progressBar;
    [SerializeField] private float returnInterval = 1.0f;
    public float margeRate;
    public int robotCnt;
    public ParticleSystem particle;

    //建物のリスト
    private BuildingList buildingList;
    private Marge marge;

    //作業中ロボット
    [SerializeField] private Animator[] roboAnimator;
    [SerializeField] private Animator margedRoboAnimator;

    private void Awake()
    {
        //landStatus = LandStatus.NoBuild;
        isOrdered = false;
        isWarking = false;

        if(progressBar == null)
        {
            progressBar = gameObject.GetComponentInChildren<ProgressBar02>();
        }

        progressBar.gameObject.SetActive(false);
        buildingList = new BuildingList();

        marge = GetComponent<Marge>();
        margeRate = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム進行状態確認
        if(Singleton<GameManager>.Instance.isGameEnd)
        {
            return; 
        }

        //ステート管理
       if (landStatus == LandStatus.InConstruct)
        {
            if (!isWarking)
            {
                if (repuiredCount <= robotList.Count)
                {
                    isWarking = true;
                    marge.isWarking = true;
                    //建設中オブジェクト表示
                    if (buildingName != null)
                    {
                        transform.GetChild(1).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(true);

                        transform.GetChild(2).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(false);

                        SetViewRobot(false);
                    }
                }
            }
            else
            {
                //プログレスバーの進行　ここ時止め
                if (!marge.timeStop)
                {
                    progressBar.AddValue(workPower * margeRate);
                }

                if(progressBar.GetIsMax())
                {
                    landStatus = LandStatus.IsBuilt;

                    //建設後オブジェクトに切り替え
                    if (buildingName != null)
                    {
                        transform.GetChild(1).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(false);

                        transform.GetChild(2).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(true);
                    }
                }
            }
        }
       else if(landStatus == LandStatus.IsBuilt)
        {
            if(isWarking)
            {
                //依頼終了

                //ロボット送り返し
                StartCoroutine(ReternRobot());

                //パラメータ等リセット
                isWarking = false;
                isOrdered = false;
                workPower = 0;
                progressBar.ResetProgress();
                progressBar.gameObject.SetActive(false);
                transform.GetComponentInChildren<OrderRelay>().CanselOrder();
                marge.isWarking = false;
                InvisibleRobot();

                //完成パーティクル発生
                particle.Play();

                //お金加算
                Singleton<GameManager>.Instance.AddMoney(reward);

                //スコア加算
                Singleton<ResultMaster>.Instance.AddNowSlot();
                Singleton<ResultMaster>.Instance.AddTotalMoney(reward);

                reward = 0;
            }
        }

        robotCnt = robotList.Count;
    }

    //=========================================================================

    private void OnTriggerEnter(Collider other)
    {
        //依頼発生時
        if (isOrdered)
        {
            if (other.gameObject.CompareTag("Robot"))
            {
                //ロボットをリストに格納
                Robot robot = other.gameObject.GetComponent<Robot>();
                Vector3 tmp = robot.GetDestination();
                tmp.y = 0.0f;

                //目的地がここじゃなければ格納しない
                if (tmp == transform.position)
                {
                    robotList.Add(robot);
                    robot.SetRState(RobotState.Working);
                    robot.gameObject.SetActive(false);

                    //作業力計算
                    workPower += robot.warkPower;
                }
            }
        }
    }

    //=========================================================================

    //土地の状態設定
    public void SetLandStatus(LandStatus ls)
    {
        landStatus = ls;
    }

    //土地の状態取得
    public LandStatus GetLandStatus()
    {
        return landStatus;
    }

    //依頼情報受け取り
    public void SetOrderInfo(int rew, int roboNum, string name, float hp)
    {
        reward = rew;
        repuiredCount = roboNum;
        buildingName = name;
        progressBar.gameObject.SetActive(true);
        progressBar.SetMaxValue(hp); 

        isOrdered = true;
    }

    //建築中ロボット表示設定
    public void SetViewRobot(bool isMarge)
    {
        //合体／非合体
        if (isMarge)
        {
            //合体ロボ召喚
            foreach(var anim in roboAnimator)
            {
                anim.gameObject.SetActive(false);
            }

            if (margedRoboAnimator != null)
            {
                margedRoboAnimator.gameObject.SetActive(true);
            }

            margedRoboAnimator.SetBool("build", true);
        }
        else
        {
            //非合体ロボ召喚
            foreach (var anim in roboAnimator)
            {
                anim.gameObject.SetActive(true);
                anim.SetBool("build", true);
            }

            if (margedRoboAnimator != null)
            {
                margedRoboAnimator.gameObject.SetActive(false);
            }
        }
    }

    //建築中ロボット非表示
    public void InvisibleRobot()
    {
        foreach (var anim in roboAnimator)
        {
            anim.gameObject.SetActive(false);
        }

        if (margedRoboAnimator != null)
        {
            margedRoboAnimator.gameObject.SetActive(false);
        }
    }

    //=========================================================================

    IEnumerator ReternRobot()
    {
        //リストの上からロボットを有効化
        foreach(var robo in robotList)
        {
            robo.gameObject.SetActive(true);

            //帰還モードに変更
            robo.SetRState(RobotState.Return);

            yield return new WaitForSeconds(returnInterval);
        }

        robotList.Clear();
    }
}
