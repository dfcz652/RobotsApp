using RobotApp.RobotData;
using static RobotAppTests.Stubs.Parts;

namespace RobotAppTests.Utils
{
    public class TestUtils
    {
        public static Robot CreateRobot(TestArms arms = null, TestBody body = null, TestCore core = null, TestLegs legs = null, string name = "UnnamedRobot")
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
