using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TurHelper6
{
    public class Log
    {
        private DateTime localDate = DateTime.Now;
        public void Loging(string message)
        {
            string mes = "Info: ";
            localDate = DateTime.Now;
            mes += message;
            mes += ", Дата, время - " + localDate.ToString() + ", Тип времени - " + localDate.Kind + "\n";
            File.AppendAllText("C:\\ppo\\lab7, 8\\TurHelper8\\log.txt", mes);
        }

        public void Error(string message)
        {
            string mes = "Error: ";
            localDate = DateTime.Now;
            mes += message;
            mes += ", Дата, время - " + localDate.ToString() + ", Тип времени - " + localDate.Kind + "\n";
            File.AppendAllText("C:\\ppo\\lab7, 8\\TurHelper8\\log.txt", mes);
        }
    }
}
