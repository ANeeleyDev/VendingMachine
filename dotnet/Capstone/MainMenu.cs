using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Capstone
{
    public static class MainMenu
    {
        public void MenuItemsDisplayed()  // if user enters 1 in main menu
        {
            string directory = Environment.CurrentDirectory;
            string sourceFile = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, sourceFile);
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string currentline = sr.ReadLine();
                        Console.WriteLine(currentline);
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine($"You selected an incorrect number. Please choose a number between 1 and 3");
            }
        }


    }
}
