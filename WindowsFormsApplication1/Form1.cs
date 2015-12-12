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
using JadBenAutho.Tools;

namespace WindowsFormsApplication1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            setLabelsVisibility(false);
        }

        private HuffmanAlgorithm AL = new HuffmanAlgorithm();
        //texts
        private string fileNotExist = "Invalid file path",
                        fileNotExistCaption = "File doesn't exist";

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

        private void showWarning(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void setButtonVisibility(System.Windows.Forms.Button button, bool isShow = false)
        {
            button.Enabled = isShow;
            button.Visible = isShow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a dialog to open file
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();

            //if dialog closed and selected file exists -> continue
            if (result == DialogResult.OK && File.Exists(dialog.FileName)) {
                String fileName = dialog.FileName;
                try
                {

                    openNewFile.Enabled = false;
                    openNewFile.Visible = false;

                    setButtonVisibility(actionButton, true);

                    String text = File.ReadAllText(fileName);
                    setLabelsVisibility(true);
                    setLablesText(getFileName(fileName), text.Length);
                }
                catch { 
                }
            } else {    //selected file doesn't exist :(
                showWarning(fileNotExist, fileNotExistCaption);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
