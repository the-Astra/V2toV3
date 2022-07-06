using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Heck_V2toV3
{
    public partial class LoadWindow : Form
    {

        public ProgressBar Bar { get { return loadBar; } }

        public LoadWindow(string text, int tasks)
        {
            InitializeComponent();
            loadText.Text = text;
            loadBar.Minimum = 0;
            loadBar.Maximum = tasks;
            loadBar.Value = 0;
            loadBar.Step = 1;
        }
    }
}
