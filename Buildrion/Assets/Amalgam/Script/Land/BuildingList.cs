using System.Collections.Generic;

//建物の名前とオブジェクト名を管理する

public class BuildingList
{
    public List<string> BuildingName { get; private set; }

    public BuildingList()
    {
        //建物名
        BuildingName = new List<string>();
        BuildingName.Add("テスト建物");
        BuildingName.Add("HAL月面");
        BuildingName.Add("さいたまスーパーアリーナ");
    }
}
