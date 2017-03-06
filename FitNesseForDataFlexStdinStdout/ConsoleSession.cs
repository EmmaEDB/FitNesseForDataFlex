using System;
using System.IO;
using System.Text;

namespace FitNesseForDataFlexStdinStdout
{
    public class ConsoleSession : ISession
    {
        public ConsoleSession()
        {
            _saveOut = Console.Out;
            _saveError = Console.Error;
            CaptureConsole();
        }

        public void Write(string message, string prefixFormat)
        {
            WriteCaptured();
            WriteToConsole(string.Format(prefixFormat, message.Length) + message);
        }

        public void Write(string message)
        {
            WriteCaptured();
            WriteToConsole(message);
        }

        public string Read(int length)
        {
            return ReadFromConsole(length);
        }

        public void Close()
        {
            WriteCaptured();
            Console.SetOut(_saveOut);
            Console.SetError(_saveError);
        }

        private void WriteCaptured()
        {
            WriteEncoded("SOUT :", _captureOut);
            WriteEncoded("SERR :", _captureError);
            CaptureConsole();
        }

        private void WriteEncoded(string prefix, StringWriter content)
        {
            var contentString = content.ToString();
            if (string.IsNullOrEmpty(contentString)) return;
            var encodedContent = prefix + contentString.Replace(Environment.NewLine, Environment.NewLine + prefix);
            if (encodedContent.EndsWith(prefix))
            {
                encodedContent = encodedContent.Substring(0, encodedContent.Length - prefix.Length);
            }
            _saveError.Write(encodedContent);
        }

        private void WriteToConsole(string message)
        {
            _saveOut.Write(message);
        }

       private static string ReadFromConsole(int length)
        {
            var result = new StringBuilder(length);
            for (var i = 0; i < length; i++)
            {
                result.Append((char)Console.Read());
            }
            var message = result.ToString();
            return message;
        }

        private void CaptureConsole()
        {
            _captureOut = new StringWriter();
            _captureError = new StringWriter();
            Console.SetOut(_captureOut);
            Console.SetError(_captureError);
        }

       private readonly TextWriter _saveOut;
       private readonly TextWriter _saveError;
       private StringWriter _captureOut;
       private StringWriter _captureError;
    }
}
