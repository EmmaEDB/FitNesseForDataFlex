namespace FitNesseForDataFlexStdinStdout
{
    public interface ISession
    {
        void Write(string message, string prefixFormat);
        void Write(string message);
        string Read(int length);
        void Close();
    }
}