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

        //���A�x�ɉ����ēǂݍ���CSV��ς���
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
        string line = "�o�O�˗�1,1,3," + rare + ",HAL����" + "3000";

        //ID�̍s�܂œǂݍ���
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
                    title = "�o�O�˗�2",
                    reward = 1,
                    lowRobotCount = 3,
                    rarity = rare,
                    name = "HAL����",
                    hp = 3000
                };

                return info;
            }
        }

        //�J���}�ŋ�؂��Ċi�[
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
