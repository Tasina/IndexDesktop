using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndexDesktop
{
    public partial class Main : Form
    {
        int count = 0;

        public Main()
        {
            InitializeComponent();
            SetupForm();
            SetupItems();
        }

        private void SetupForm()
        {
            ControlBox = false;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        private void SetupItems()
        {
            lblInputError.BackColor = Color.Transparent;
            lblListError.BackColor = Color.Transparent;

            btnQuit.BackColor = Color.FromArgb(75, Color.Black);
            btnQuit.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, Color.Black);
            btnQuit.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.Black);

            btnMinimaz.BackColor = Color.FromArgb(75, Color.Black);
            btnMinimaz.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, Color.Black);
            btnMinimaz.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.Black);

            btnHelp.BackColor = Color.FromArgb(75, Color.Black);
            btnHelp.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, Color.Black);
            btnHelp.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.Black);

            btnAdd.BackColor = Color.FromArgb(100, Color.Black);
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, Color.Black);
            btnAdd.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.Black);

            btnRemove.BackColor = Color.FromArgb(100, Color.Black);
            btnRemove.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, Color.Black);
            btnRemove.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.Black);

            btnSend.BackColor = Color.FromArgb(100, Color.Black);
            btnSend.FlatAppearance.MouseOverBackColor = Color.FromArgb(150, Color.Black);
            btnSend.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, Color.Black);
        }



        //
        //               All Buttons
        //

        private void btnAdd_Click(object sender, EventArgs e)
        {

            string empty = "";
            if (tbPath.Text.Equals(empty))
            {
                lblInputError.Text = "Please enter a valid path";
            }
            else
            {
                if (!File.Exists(tbPath.Text))
                {
                    lblInputError.Text = "Could't find the file";
                }
                else
                {
                    count++;
                    lbFiles.Items.Add(tbPath.Text);
                    tbPath.Text = "";
                    lblListError.Text = "";
                    lblInputError.Text = "";
                }

            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbFiles.SelectedItem == null)
            {
                lblListError.Text = "Please select a file";
            }
            else
            {
                for (int i = lbFiles.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    lbFiles.Items.RemoveAt(lbFiles.SelectedIndices[i]);
                }
                lblInputError.Text = "";
                lblListError.Text = "";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (lbFiles != null)
            {
                foreach (string path in lbFiles.Items)
                {
                    //if (File.Exists(path.ToString())){
                    FileParser fp = new FileParser();
                    fp.ReadFiles(path);
                    //}else
                    //{
                    //    lblInputError.Text = "Could't find the file" + path;
                    //}
                }
                lbFiles.Items.Clear();
            }
            else
            {
                lblListError.Text = "The list is empty";
            }

        }


        //
        //              HeaderButttons
        //

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimaz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {

        }
    }
}
