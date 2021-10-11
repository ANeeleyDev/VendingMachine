using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Log
    {
        public void WritingAFile()
        {
            // Directory and file name
            string directory = Environment.CurrentDirectory;
            string filename = "Log.txt";

            string fullPath = Path.Combine(directory, filename);

            try
            {
                using (StreamWriter sw = new StreamWriter(fullPath, true))
                {
                    sw.WriteLine(DateTime.Now);
                    //sw.Write(" ");
                    //sw.Write(" ");
                    //  sw.WriteLine();
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }

    }
}
