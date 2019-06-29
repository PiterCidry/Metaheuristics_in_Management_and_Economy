namespace ProjectTaskScheduling
{
    internal class Base
    {
        public int Time { get; }
        public int TaskNumber { get; }
        public int Term { get; }

        public Base(int taskNumber, int time, int term)
        {
            TaskNumber = taskNumber;
            Time = time;
            Term = term;
        }
    }
}
