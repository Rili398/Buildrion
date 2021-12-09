using System.Collections.Generic;

//建物の名前とオブジェクト名を管理する

public class BuildingList
{
    public List<string> BuildingName { get; private set; }

    public BuildingList()
    {
        //建物名
        BuildingName = new List<string>();
        BuildingName.Add("家");
        BuildingName.Add("アパート");
        BuildingName.Add("豪邸");
        BuildingName.Add("ビル");
    }
}
