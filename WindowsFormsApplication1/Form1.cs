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

namespace WindowsFormsApplication1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            setLabelsVisibility(false);
        }

        private void setLabelsVisibility(bool isShowLables){
            lableFileName.Enabled = isShowLables;
            lableFileName.Visible = isShowLables;
            
            lableSizeFile.Enabled = isShowLables;
            lableSizeFile.Visible = isShowLables;

            lablelFileNameText.Enabled = isShowLables;
            lablelFileNameText.Visible = isShowLables;
            
            lableFileNameSize.Enabled = isShowLables;
            lableFileNameSize.Visible = isShowLables;
        }
        private void setLablesText(string text, int size) {
            lablelFileNameText.Text = text;
            lableFileNameSize.Text = size.ToString();
        }
        private string getFileName(string fullFileName) { 
            Array arr = fullFileName.Split('\\');
            int lastIndex = arr.Length - 1;
            return arr.GetValue(lastIndex).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                String fileName = dialog.FileName;
                try
                {
                    openNewFile.Enabled = false;
                    openNewFile.Visible = false;

                    actionButton.Enabled = true;
                    actionButton.Visible = true;
                    String text = File.ReadAllText(fileName);
                    setLabelsVisibility(true);
                    setLablesText(getFileName(fileName), text.Length);
                }
                catch { 
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
