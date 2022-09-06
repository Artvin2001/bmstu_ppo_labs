using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TurHelper8.UI.IvIew;
using TurHelper8.UI.Presenters;
using TurHelper6;

namespace TurHelper8
{
    public partial class Form1 : Form
    {
        private Model model;
        public Form1()
        {
            InitializeComponent();
            this.model = new Model();
        }

    }
}
