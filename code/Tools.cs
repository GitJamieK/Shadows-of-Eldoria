using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Game
{
    static class Tools
    {
        public static void Loading()
        {
            char[] Frames = { '|', '/', '-', '\\' };
            
            Thread animThread = new Thread(() => 
            {
                int i = 0;
                while (!Console.KeyAvailable)
                {
                    Console.Write(Frames[i % Frames.Length]);
                    Thread.Sleep(100);
                    Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                    i++;
                }
            });
            animThread.Start();
            animThread.Join();
        }
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