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
//using JadBenAutho.Tools;

namespace WindowsFormsApplication1
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            resetAllToStart();
        }

        //private HuffmanAlgorithm huffmanAlg = new HuffmanAlgorithm();
        private HaffmanClass haffman = new HaffmanClass();
        //texts
        private string fileNotExist = "Invalid file path",
                        fileNotExistCaption = "File doesn't exist",
                        outputFilePathNotValid = "Invalid output file path",
                        outputFilePathNotValidCaption = "Ouptput file doesn't exist",
                        saveDailogTitle = "Select output file",
                        openDailogTitle = "Select source file",
                        zippingButtonText = "Start zipping",
                        unzippingButtonText = "Start unzipping",
                        zippingProcessText = "File has zipped successfully",
                        zippingProcessTextCaption = "Done zipping";

        private bool isHfs;
        private string lastOpenedExistFileName;

        private void resetAllToStart(){
            setButtonVisibility(actionButton, false);
            processProgress.Visible = false;
            processProgress.Value = 0;
            setLabelsVisibility(false);
            setButtonVisibility(openNewFile, true);
            setButtonVisibility(resetButton, false);
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

        private void showWarning(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void showInfo(string text, string caption)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void setButtonVisibility(System.Windows.Forms.Button button, bool isShow = false)
        {
            button.Enabled = isShow;
            button.Visible = isShow;
        }
        private OpenFileDialog fileOpenDialog()
        {
            OpenFileDialog openFileD = new OpenFileDialog();
            openFileD.FileName = "";
            openFileD.Filter = "All files(*.*)|*.*";
            openFileD.Multiselect = false;
            openFileD.CheckPathExists = true;
            openFileD.ShowHelp = false;
            openFileD.Title = openDailogTitle;
            openFileD.ShowReadOnly = true;

            return openFileD;
        }

        private SaveFileDialog fileSaveDialog()
        {
            SaveFileDialog saveFileD = new SaveFileDialog();
            saveFileD.DefaultExt = "*.hfs";
            saveFileD.Filter = "Huffman Stream files(*.hfs)|*.hfs";
            saveFileD.CheckPathExists = false;
            saveFileD.ShowHelp = false;
            saveFileD.Title = saveDailogTitle;

            return saveFileD;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            resetAllToStart();
        }

        private void unzippingLogic(SaveFileDialog saveDialog)
        {
            
        }
        private void zippingLogic(SaveFileDialog saveDialog)
        {
            string outputFile = saveDialog.FileName;
            //huffmanAlg.PercentCompleted += new PercentCompletedEventHandler(progressStep);
            //FileStream D = new FileStream(outputFile, FileMode.Create);
            //D.Close();
            // create stream to a zipped file
            //FileStream zipStream = new FileStream(lastOpenedExistFileName, FileMode.Open);
            haffman.Zip(lastOpenedExistFileName, outputFile);
            //huffmanAlg.ShrinkWithProgress(zipStream, outputFile, null);
            //zipStream.Close();
            showInfo(zippingProcessText, zippingProcessTextCaption);

            resetAllToStart();
        }

        private bool isHfsFile( string fileName) {
            string type = "hfs";
            Array arr = fileName.Split('.');
            int lastIndex = arr.Length - 1;
            return arr.GetValue(lastIndex).ToString() == type;
        }

        private void updateActionButtonText(bool isZipping)
        {
            actionButton.Text = isZipping ? zippingButtonText : unzippingButtonText; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a dialog to open file
            OpenFileDialog dialog = fileOpenDialog();
            DialogResult result = dialog.ShowDialog();

            //if dialog closed and selected file exists -> continue
            if (result == DialogResult.OK && File.Exists(dialog.FileName)) {
                String fileName = dialog.FileName;
                lastOpenedExistFileName = fileName;
                isHfs = isHfsFile(dialog.SafeFileName);

                setButtonVisibility(openNewFile, false);
                setButtonVisibility(resetButton, true);
                
                //update action button state
                setButtonVisibility(actionButton, true);
                updateActionButtonText(isHfs);
                //update file info labels
                String text = File.ReadAllText(fileName);
                setLabelsVisibility(true);
                setLablesText(getFileName(fileName), text.Length);

            } else if (result != DialogResult.Cancel && result != DialogResult.Abort){    
                //selected file doesn't exist :(
                 showWarning(fileNotExist, fileNotExistCaption);
            }
        }

        private void progressStep()
        {
            processProgress.PerformStep();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (lastOpenedExistFileName != "")
            {
                setLabelsVisibility(false);
                SaveFileDialog saveDialog = fileSaveDialog();
                DialogResult result = saveDialog.ShowDialog();
                if (result == DialogResult.OK && Path.GetFileName(saveDialog.FileName).Length != 0)
                {
                    setButtonVisibility(actionButton, false);
                    setButtonVisibility(resetButton, false);
                    //show progress bar
                    processProgress.Visible = true;
                    if (isHfs){
                        unzippingLogic(saveDialog);
                    }
                    else {
                        zippingLogic(saveDialog);
                    }
                } else if(result != DialogResult.Cancel && result != DialogResult.Abort) {
                    //selected output file doesn't exist :(
                    showWarning(outputFilePathNotValid, outputFilePathNotValidCaption);
                }
            }
        }
    }
}
