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
    [SerializeField] private bool io;
    [SerializeField, Tooltip("作業中フラグ")] private bool isWarking;

    [Header("依頼情報")]
    [SerializeField] private int reward;
    [SerializeField] private int repuiredCount;
    [SerializeField] private string buildingName;
    public float workPower { get; set; } = 0;
    [SerializeField] private float wp;

    [Header("各種パラメータ")]
    [SerializeField] private List<Robot> robotList;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private float returnInterval = 1.0f;

    //建物のリスト
    private BuildingList buildingList;

    private void Awake()
    {
        //landStatus = LandStatus.NoBuild;
        isOrdered = false;
        isWarking = false;

        if(progressBar == null)
        {
            progressBar = gameObject.GetComponentInChildren<ProgressBar>();
        }

        progressBar.gameObject.SetActive(false);
        buildingList = new BuildingList();
    }

    // Update is called once per frame
    void Update()
    {
        //ステート管理
       if (landStatus == LandStatus.InConstruct)
        {
            if (!isWarking)
            {
                if (repuiredCount <= robotList.Count)
                {
                    isWarking = true;
                    //建設中オブジェクト表示
                    if (buildingName != null)
                    {
                        transform.GetChild(1).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(true);

                        transform.GetChild(2).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(false);
                    }
                }
            }
            else
            {
                //プログレスバーの進行
                progressBar.value += workPower;

                if(progressBar.value >= 1.0f)
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
                StartCoroutine(ReternRobot());
                isWarking = false;
                isOrdered = false;
                workPower = 0;
                progressBar.ResetPb();
                progressBar.gameObject.SetActive(false);
                transform.GetComponentInChildren<OrderRelay>().CanselOrder();
            }
        }

        io = isOrdered;
        wp = workPower;
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
                robotList.Add(robot);
                robot.SetRState(RobotState.Working);
                robot.gameObject.SetActive(false);

                //作業力計算
                workPower += robot.warkPower;
            }
        }
    }

    //=========================================================================

    public void SetLandStatus(LandStatus ls)
    {
        landStatus = ls;
    }

    public LandStatus GetLandStatus()
    {
        return landStatus;
    }

    public void SetOrderInfo(int rew, int roboNum, string name)
    {
        reward = rew;
        repuiredCount = roboNum;
        buildingName = name;
        progressBar.gameObject.SetActive(true);

        isOrdered = true;

        Debug.Log("reward:" + reward);
        Debug.Log("reCon:" + repuiredCount);
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
