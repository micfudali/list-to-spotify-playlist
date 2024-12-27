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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void LoadFormIntoPanel(Form form)
        {
            contentPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 authorizationForm = new Form2(this);
            LoadFormIntoPanel(authorizationForm);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 createPlaylistForm = new Form3(this);
            LoadFormIntoPanel(createPlaylistForm);
        }
    }
}
