using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EgzaminInzr
{
    public partial class TestResult : Form
    {
        public TestResult(List<string> answers)
        {
            InitializeComponent();
            foreach (var item in answers)
            {
                textBox1.Text += item + Environment.NewLine;
            }
        }
    }
}
