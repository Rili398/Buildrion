
//ロボット強化のテーブル管理

public struct RobotUpgradeTable
{
    public int cost;
    public int roboMax;
};

public class RcUpGradeTable
{
    public RobotUpgradeTable[] roboUGT { get; private set; }

    public RcUpGradeTable()
    {
        roboUGT = new RobotUpgradeTable[10];

        roboUGT[0] = new RobotUpgradeTable() { cost =  300, roboMax = 12 };
        roboUGT[1] = new RobotUpgradeTable() { cost =  350, roboMax = 15 };
        roboUGT[2] = new RobotUpgradeTable() { cost =  500, roboMax = 18 };
        roboUGT[3] = new RobotUpgradeTable() { cost =  600, roboMax = 21 };
        roboUGT[4] = new RobotUpgradeTable() { cost =  800, roboMax = 24 };
        roboUGT[5] = new RobotUpgradeTable() { cost = 1000, roboMax = 27 };
        roboUGT[6] = new RobotUpgradeTable() { cost = 1500, roboMax = 30 };
        roboUGT[7] = new RobotUpgradeTable() { cost = 2500, roboMax = 36 };
        roboUGT[8] = new RobotUpgradeTable() { cost = 4000, roboMax = 45 };
        roboUGT[9] = new RobotUpgradeTable() { cost = 900000, roboMax = 100 };
    }
}
