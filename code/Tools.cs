using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class Tools
    {
            public static string ReadLine()
        {
            string? readLine = Console.ReadLine();
            if (readLine == null)
            {
                return"";
            }
            else
            {
                return readLine;
            }
        }    
    }
}