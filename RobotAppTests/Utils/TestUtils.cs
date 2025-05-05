using RobotApp.RobotData;
using static RobotAppTests.Stubs.Parts;

namespace RobotAppTests.Utils
{
    public class TestUtils
    {
        public static Robot CreateRobotFromParts(TestArms arms, TestBody body, TestCore core, TestLegs legs, string name = null)
        {
            Robot robot = new Robot();

            robot.AddName(name);
            robot.AddArms(arms);
            robot.AddCore(core);
            robot.AddBody(body);
            robot.AddLegs(legs);

            return robot;
        }
    }
}
