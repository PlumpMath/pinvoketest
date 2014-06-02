using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace pinvoke_exceptions
{
    class Program
    {
        [DllImport("Win32Project1.dll")]
        static extern bool TestFunc();
        [DllImport( "Shlwapi.dll", SetLastError = true, CharSet = CharSet.Auto )]
        public static extern string PathGetArgs( string path );
        static void Main(string[] args)
        {
            bool? tfr = null;
            try
            {
                tfr = TestFunc();
                Console.WriteLine(tfr.Value ? "There were no problems." : "dll internally handled exception" );
            }
            catch
            {
                Random rd = new Random();
                for (int i = 0; i < 10; i++)
                    Console.Beep(rd.Next(500, 11000), rd.Next(10, 30));
                Console.WriteLine("Exception handled by managed code");
            }
            Console.WriteLine("Any key to try same thing with pinvoke...");
            Console.ReadKey();
	        String arg = "\"c:\\program files (x86)\\microsoft lifecam\\lifeexp.exe\"";
            try
            {
                var res = PathGetArgs(arg); // this will crash aidans and alexs PCs, and its not catchable.
            }
            catch { }
        }
    }
}
