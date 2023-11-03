using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GuessGame
{
    internal static class Program
    {
        private static int _guessedNumber;

        private static readonly Dictionary<string, string> Messages =
            new Dictionary<string, string>();

        private static int _attemptNumber;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Messages.Add("high", "Too high, try again!");
            Messages.Add("low", "Too low, try again!");
            Messages.Add("ok", "Congratulation! You win!\nTotal attempts: ");

            CreateNumber();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void CreateNumber()
        {
            var rand = new Random();
            _guessedNumber = rand.Next(1, 100);
            _attemptNumber = 0;
            Console.WriteLine(_guessedNumber);
        }

        public static string GuessNumber(int number)
        {
            string result;
            _attemptNumber++;
            if (number > _guessedNumber)
            {
                result = Messages["high"];
            }
            else if (number < _guessedNumber)
            {
                result = Messages["low"];
            }
            else
            {
                result = Messages["ok"] + _attemptNumber;
                CreateNumber();
            }

            return result;
        }
    }
}