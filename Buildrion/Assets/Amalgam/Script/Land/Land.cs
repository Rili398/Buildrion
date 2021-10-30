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

    [Header("各種パラメータ")]
    [SerializeField] private List<RobotBase> robotList;
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
                if (repuiredCount < robotList.Count)
                {
                    isWarking = true;
                    //建設中オブジェクト表示
                    if (buildingName != null)
                    {
                        transform.GetChild(1).GetChild(
                            buildingList.BuildingName.IndexOf(buildingName)
                            ).gameObject.SetActive(true);
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
                transform.GetComponentInChildren<OrderRelay>().CanselOrder();
            }
        }
    }

    //=========================================================================

    private void OnCollisionEnter(Collision collision)
    {
        //依頼発生時
        if (isOrdered)
        {
            if (collision.gameObject.CompareTag("Robot"))
            {
                //ロボットをリストに格納
                RobotBase rbase = collision.gameObject.GetComponent<RobotBase>();
                robotList.Add(rbase);
                rbase.gameObject.SetActive(false);

                //作業力計算
                //workPower += rbase.warkPower;
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
            //robo.SetRobotState(RobotState.Return);
            robotList.Remove(robo);

            yield return new WaitForSeconds(returnInterval);
        }
    }
}
