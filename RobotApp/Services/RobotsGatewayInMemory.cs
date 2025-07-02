using RobotApp.RobotData;

namespace RobotApp.Services
{
    public class RobotsGatewayInMemory : IRobotsGateway
    {
        private List<Robot> _robots = new();

        public int Count => _robots.Count();

        public void Add(Robot robot)
        {
            _robots.Add(robot);
        }

        public void Clear()
        {
            _robots.Clear();
        }

        public Robot GetByName(string name)
        {
            return _robots.FirstOrDefault(r => r.Name == name);
        }
    }
}
