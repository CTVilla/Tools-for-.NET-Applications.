using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace TestTool {
    class Program {
        static void Main ( string [ ] args ) {
            Logger.getInstance ( "Tools" ).d ( "Main", "hola mundo" );
            Console.ReadKey ();
            Logger.getInstance ( "Tools" ).e ( "Main", new Exception () );
        }
    }
}
