using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RobotApp.RobotData;
using static RobotAppTests.Stubs.Parts;

namespace RobotAppTests.Utils
{
    public class TestUtils
    {
        public static Robot CreateRobotFromParts(TestArms arms, TestBody body, TestCore core, TestLegs legs)
        {
            Robot robot = new Robot();

            robot.AddArms(arms);
            robot.AddCore(core);
            robot.AddBody(body);
            robot.AddLegs(legs);

            return robot;
        }
    }
}
