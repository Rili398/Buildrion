using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CSVLoader : MonoBehaviour
{
    private TextAsset csvFile;
    [SerializeField] private string commonPath;
    [SerializeField] private string rarePath;
    [SerializeField] private string sRarePath;

    public OrderInfo LoadOrderFromCsv(OrdersRarity rare, int id)
    {
        OrderInfo info = new OrderInfo();

        //レア度に応じて読み込むCSVを変える
        if(rare == OrdersRarity.OR_Common)
        {
            csvFile = Resources.Load(commonPath) as TextAsset;
        }
        else if (rare == OrdersRarity.OR_Rare)
        {
            csvFile = Resources.Load(rarePath) as TextAsset;
        }
        else if (rare == OrdersRarity.OR_SuperRare)
        {
            csvFile = Resources.Load(sRarePath) as TextAsset;
        }

        StringReader stringReader = new StringReader(csvFile.text);
        string line = "バグ依頼1,1,3," + rare + ",HAL月面" + "3000";

        //IDの行まで読み込み
        for(int i = 0; i <= id; i++)
        {
            if (stringReader.Peek() != -1)
            {
                line = stringReader.ReadLine();
            }
            else
            {
                info = new OrderInfo
                {
                    title = "バグ依頼2",
                    reward = 1,
                    lowRobotCount = 3,
                    rarity = rare,
                    name = "HAL月面",
                    hp = 3000
                };

                return info;
            }
        }

        //カンマで区切って格納
        string[] spritLine = line.Split(',');
        info.title = spritLine[0];
        info.reward = int.Parse(spritLine[1]);
        info.lowRobotCount = int.Parse(spritLine[2]);
        info.rarity = rare;
        info.name = spritLine[3];
        info.hp = float.Parse(spritLine[4]);

        return info;
    }
}
