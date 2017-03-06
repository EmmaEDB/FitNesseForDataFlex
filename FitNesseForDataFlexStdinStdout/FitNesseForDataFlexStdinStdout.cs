using System.Runtime.InteropServices;

namespace FitNesseForDataFlexStdinStdout
{
   [ComVisible(true)]
    [Guid("032C2561-BBDA-49B8-874D-0D58C321E1BD")]
    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("StdInStdOut_Com")]
    public class FitNesseForDataFlexStdInStdOut : IFitNesseForDataFlexStdInStdOut
    {
        private Messenger _messenger;

        public string ReadStdIn()
        {
            var instruction = _messenger.Read();
            return instruction;
        }

        public void Init()
        {
            var messenger = new Messenger(new ConsoleSession());
            _messenger = messenger;
        }

        public void WriteStdOut(string value)
        {
            var messenger = _messenger;
            messenger?.Write(value);
        }
    }
}
