using System.Runtime.InteropServices;

namespace FitNesseForDataFlexStdinStdout
{
   /// <summary>
   /// 
   /// </summary>
   [ComVisible(true)]
   [Guid("FFA6D407-6BD8-449B-ADD6-017C3B0E586C")]
   [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    
   public interface IFitNesseForDataFlexStdInStdOut
   {
      string ReadStdIn();
      void WriteStdOut(string value);
      void Init();
   }
}