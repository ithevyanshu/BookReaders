namespace NagarroReader.Logger
{
    public interface ILog
    {
        void LogException(string message);
        public static Log GetInstance { get; }
    }
}
