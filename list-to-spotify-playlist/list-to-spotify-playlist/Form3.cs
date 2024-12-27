using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace list_to_spotify_playlist
{
    public partial class Form3 : Form
    {
        private Form1 parentForm;
        public Form3(Form1 parentForm)
        {
            InitializeComponent();
            this.parentForm = parentForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                parentForm.LoadFormIntoPanel(new Form1());
                parentForm.Show();
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Ścieżka do pliku
            string filePath = @"F:\Programowanie\list to spotify playlist\songs_list.txt";
            string scriptPath = @"F:\Programowanie\list to spotify playlist\scripts\create_playlist.py";
            string playlistName = textBox1.Text;

            try
            {
                // Zapisz zawartość richTextBox1 do pliku
                File.WriteAllText(filePath, richTextBox1.Text);

                // Poinformuj użytkownika o sukcesie
                MessageBox.Show("Zawartość została zapisana do pliku.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Obsłuż błędy
                MessageBox.Show($"Wystąpił błąd podczas zapisywania pliku: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "python", // Upewnij się, że Python jest w PATH
                    Arguments = $"\"{scriptPath}\" \"{playlistName}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    string errors = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    // Wyświetlenie wyniku działania skryptu
                    if (!string.IsNullOrEmpty(output))
                    {
                        MessageBox.Show(output, "Output", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    if (!string.IsNullOrEmpty(errors))
                    {
                        MessageBox.Show(errors, "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd podczas uruchamiania skryptu: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (parentForm != null)
            {
                Form4 successForm = new Form4(new Form1());
                parentForm.LoadFormIntoPanel(successForm);
            }
        }
    }
}
