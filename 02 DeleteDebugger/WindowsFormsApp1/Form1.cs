using Microsoft.Win32;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoveDebugger
{
    public partial class Form1 : Form
    {
        private RegistryKey ImageFileExecutionOptionsKey = Registry.LocalMachine.OpenSubKey(DebuggerPath);

        public Form1()
        {
            InitializeComponent();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = ImageFileExecutionOptionsKey.SubKeyCount;
            progressBar1.Step = 1;
        }
        private void Button1_MouseHover()
        {
            this.button1.ForeColor = System.Drawing.Color.MintCream;
            this.button1.BackColor = System.Drawing.Color.Teal;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Button1_MouseHover();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private async void button1_Click(object sender, EventArgs e)
        {
            
            progressBar1.Value = 0; // Reset progress

            try
            {
                
                if (ImageFileExecutionOptionsKey != null)
                {
                    foreach(string subKey in ImageFileExecutionOptionsKey.GetSubKeyNames())
                    {
                        if(subKey.Equals("MsSense.exe"))
                            continue;
                        else {
                            RegistryKey key = Registry.LocalMachine.OpenSubKey($"{DebuggerPath}\\{subKey}", true);
                            if (key.GetValue("Debugger") != null)
                            {
                                key.DeleteValue("Debugger");
                            }

                            await Task.Delay(50); // Simulate a delay for each iteration

                            // Update progress bar
                            progressBar1.Value++;
                        }
                        
                    }
                    MessageBox.Show("Process Completed!");

                }
                

            }
            catch (Exception ex) { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
