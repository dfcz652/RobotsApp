using RobotApp.RobotData.Base;
using RobotApp.RobotData.RobotParts;

namespace RobotAppTests.Stubs
{
    public class Parts
    {
        public class TestArms : Arms
        {
            public TestArms() : base(0, 0, 0, [])
            {
                RobotCharacteristics.Clear();
            }

            public TestArms(List<RobotCharacteristicBase> characteristics) : base(0, 0, 0, [])
            {
                RobotCharacteristics.Clear();
                RobotCharacteristics = characteristics;
            }
        }

        public class TestBody : Body
        {
            public TestBody() : base(0, [])
            {
                RobotCharacteristics.Clear();
            }

            public TestBody(List<RobotCharacteristicBase> characteristics) : base(0, [])
            {
                RobotCharacteristics.Clear();
                RobotCharacteristics = characteristics;
            }
        }

        public class TestCore : Core
        {
            public TestCore() : base(0, 0, [])
            {
                RobotCharacteristics.Clear();
            }

            public TestCore(List<RobotCharacteristicBase> characteristics) : base(0, 0, [])
            {
                RobotCharacteristics.Clear();
                RobotCharacteristics = characteristics;
            }
        }

        public class TestLegs : Legs
        {
            public TestLegs() : base(0, 0, [])
            {
                RobotCharacteristics.Clear();
            }

            public TestLegs(List<RobotCharacteristicBase> characteristics) : base(0, 0, [])
            {
                RobotCharacteristics.Clear();
                RobotCharacteristics = characteristics;
            }
        }
    }
}
