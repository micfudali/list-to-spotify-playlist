using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace list_to_spotify_playlist
{
    public partial class Form4 : Form
    {
        private Form1 parentForm;
        public Form4(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
