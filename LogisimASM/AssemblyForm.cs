using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LogisimASM {
    public partial class AssemblyForm : Form {
        public AssemblyForm() {
            InitializeComponent();
        }

        private void AssemblyForm_Load(object sender, EventArgs e) {
            filenameBox.TextChanged += filenameBox_TextChanged;
        }

        private void filenameBox_TextChanged(object sender, EventArgs e) {
            assembleButton.Enabled = !String.IsNullOrWhiteSpace(filenameBox.Text);
        }

        private void downloadLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            downloadLabel.LinkVisited = true;

            try {
                Process.Start("https://github.com/Rexagon/logisim-cpu8bit");
            } catch {
                MessageBox.Show("Unable to open link.");
            }
        }
        private void githubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            githubLabel.LinkVisited = true;

            try {
                Process.Start("https://github.com/darktohka");
            } catch {
                MessageBox.Show("Unable to open link.");
            }
        }

        private void browseButton_Click(object sender, EventArgs e) {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Please choose the file to assemble!";
            dialog.Filter = "Assembly Script (*.asm)|*.asm|All Files (*.*)|*.*";
            dialog.InitialDirectory = Environment.CurrentDirectory;
            dialog.ShowDialog();

            if (String.IsNullOrWhiteSpace(dialog.FileName)) {
                return;
            }

            filenameBox.Text = dialog.FileName;
        }

        private void assembleButton_Click(object sender, EventArgs e) {
            string inputFilename = filenameBox.Text;
            string input, rom;

            fileAssemblyBox.Text = "";

            try {
                input = File.ReadAllText(inputFilename);
            } catch {
                MessageBox.Show("Could not read input file!", "Logisim Assembler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try {
                rom = Assembler.AssembleToRAM(input);
            } catch (Exception ex) {
                MessageBox.Show(String.Format("Could not assemble file...\n\n{0}", ex.ToString()), "Logisim Assembler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string outputFilename = Regex.Replace(inputFilename, ".asm", ".rom", RegexOptions.IgnoreCase);

            try {
                File.WriteAllText(outputFilename, rom);
            } catch (Exception ex) {
                MessageBox.Show(String.Format("Could not save {0}!...\n\n{1}", outputFilename, ex.ToString()), "Logisim Assembler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            fileAssemblyBox.Text = rom;
            MessageBox.Show(String.Format("Saved assembled machine code to {0}!", outputFilename), "Logisim Assembler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void assembleTextButton_Click(object sender, EventArgs e) {
            string rom;

            try {
                rom = Assembler.AssembleToRAM(inputAssemblyBox.Text);
            } catch (Exception ex) {
                MessageBox.Show(String.Format("Could not assemble code!\n\n{0}", ex.ToString()), "Logisim Assembler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            outputAssemblyBox.Text = rom;
        }
    }
}
