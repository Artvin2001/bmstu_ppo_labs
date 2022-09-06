using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TurHelper5;

namespace TurHelper6
{
    class Program
    {
        static void Main(string[] args)
        {
            View view = new View();
            Presenter presenter = new Presenter(new Model(), view);
            view.StartMenu();
        }
    }
}
