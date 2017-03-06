namespace FitNesseForDataFlexStdinStdout
{
    internal class Messenger
    {
        public bool IsEnd { get; private set; }

        public Messenger(ISession session)
        {
            _session = session;
        }

        public string Read()
        {
            var lengthString = string.Empty;
            while (true)
            {
                var lengthCharacter = _session.Read(1);
                if (lengthCharacter == ":") break;
                lengthString += lengthCharacter;
                if (lengthString == "bye") return "bye";
            }
            var messageByteLength = int.Parse(lengthString);
            var message = _session.Read(messageByteLength);
            if (EndIdentifier.Matches(message))
            {
               CloseSession();
            }
            return message;
        }

       private void CloseSession()
       {
          IsEnd = true;
          _session.Close();
       }

       public void Write(string message)
        {
            _session.Write(message);
        }

        private static readonly IdentifierName EndIdentifier = new IdentifierName("bye");

        private readonly ISession _session;
    }
}
