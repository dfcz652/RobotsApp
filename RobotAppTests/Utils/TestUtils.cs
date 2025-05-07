using RobotApp.RobotData;
using static RobotAppTests.Stubs.Parts;

namespace RobotAppTests.Utils
{
    public class TestUtils
    {
        public static Robot CreateRobot(TestArms arms, TestBody body, TestCore core, TestLegs legs, string name = "UnnamedRobot")
        {
            Robot robot = new Robot(name);

            robot.AddArms(arms);
            robot.AddCore(core);
            robot.AddBody(body);
            robot.AddLegs(legs);

            return robot;
        }
    }
}
