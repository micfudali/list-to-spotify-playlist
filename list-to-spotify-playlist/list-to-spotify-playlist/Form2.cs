using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.IO;

namespace list_to_spotify_playlist
{
    public partial class Form2 : Form
    {
        private Form1 parentForm;
        public Form2(Form1 Parent)
        {
            InitializeComponent();
            this.parentForm = Parent;
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.LoadFormIntoPanel(new Form1());
                parentForm.Show();
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string envFilePath = @"f:\Programowanie\list to spotify playlist\.env";

            try
            {
                string[] lines = File.ReadAllLines(envFilePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("CLIENT_ID="))
                    {
                        lines[i] = $"CLIENT_ID={textBox1.Text}";
                    }
                    else if (lines[i].StartsWith("CLIENT_SECRET="))
                    {
                        lines[i] = $"CLIENT_SECRET={textBox2.Text}";
                    }
                }

                File.WriteAllLines(envFilePath, lines);

                MessageBox.Show("Dane zostały zapisane pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas zapisywania pliku:\n{ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
