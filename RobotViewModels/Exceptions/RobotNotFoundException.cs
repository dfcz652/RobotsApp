namespace RobotViewModels.Exceptions
{
    public class RobotNotFoundException : Exception
    {
        public RobotNotFoundException(string message) : base(message) 
        {
        }
    }
}