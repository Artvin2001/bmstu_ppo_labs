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
            localDate = DateTime.Now;
            message += ", Дата, время - " + localDate.ToString() + ", Тип времени - " + localDate.Kind + "\n";
            File.AppendAllText("C:\\ppo\\lab6\\TurHelper6\\log.txt", message);
        }
    }
}
