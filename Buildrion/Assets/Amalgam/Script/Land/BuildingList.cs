using System.Collections.Generic;

//�����̖��O�ƃI�u�W�F�N�g�����Ǘ�����

public class BuildingList
{
    public List<string> BuildingName { get; private set; }

    public BuildingList()
    {
        //������
        BuildingName = new List<string>();
        BuildingName.Add("�e�X�g����");
        BuildingName.Add("HAL����");
        BuildingName.Add("�������܃X�[�p�[�A���[�i");
    }
}
