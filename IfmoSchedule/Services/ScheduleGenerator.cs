namespace IfmoSchedule.Services
{
    public class ScheduleGenerator
    {
        private string GetHeader()
        {
            //TODO: Static messages' head
            return null;
        }

        public string GenerateMessage(int day, int weekType)
        {
            var msg = GetHeader();
            msg += GetScheduleData(day, weekType);
            return msg;
        }

        private string GetScheduleData(int day, int weekType)
        {
            //TODO: Convert data from repository to string
            return null;
        }
    }
}