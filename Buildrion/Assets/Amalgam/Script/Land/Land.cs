using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//土地の情報を管理するクラス

public class Land : MonoBehaviour
{
    public enum LandStatus
    {
        NoBuild = 0,
        InConstruct,
        IsBuilt,
        LandStatMax
    }

    [SerializeField, Tooltip("土地の状態")] private LandStatus landStatus;

    public bool isOrdered { get; set; }
    [SerializeField, Tooltip("作業中フラグ")] private bool isWarking;
    [SerializeField] private int reward;
    [SerializeField] private int repuiredCount;
    public float workPower { get; set; } = 0;

    [SerializeField] private List<RobotBase> robotList;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private float returnInterval = 1.0f;

    private void Awake()
    {
        landStatus = LandStatus.NoBuild;
        isOrdered = false;
        isWarking = false;

        if(progressBar == null)
        {
            progressBar = gameObject.GetComponentInChildren<ProgressBar>();
        }

        progressBar.gameObject.SetActive(false);
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
                    progressBar.gameObject.SetActive(true);
                }
            }
            else
            {
                //プログレスバーの進行
                progressBar.value += workPower;

                if(progressBar.value >= 1.0f)
                {
                    landStatus = LandStatus.IsBuilt;
                }
            }
        }
       else if(landStatus == LandStatus.IsBuilt)
        {
            if(isWarking)
            {
                StartCoroutine(ReternRobot());
                isWarking = false;
                isOrdered = false;
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

    public void SetOrderInfo(int rew, int roboNum)
    {
        reward = rew;
        repuiredCount = roboNum;
        isOrdered = true;
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
