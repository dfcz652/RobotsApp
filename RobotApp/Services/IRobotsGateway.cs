using RobotApp.RobotData;

namespace RobotApp.Services
{
    public interface IRobotsGateway
    {
        int Count {  get; }
        void Add(Robot robot);
        void Clear();
        Robot GetByName(string name);

        List<Robot> GetAll();
    }
}
