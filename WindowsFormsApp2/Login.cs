﻿using Spire.Xls;
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
using WindowsFormsApp2.Class;

namespace WindowsFormsApp2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        Logs logs = new Logs();  
        public Login(Logs logs)
        {
            InitializeComponent();
            this.logs = logs;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        //private void btnLogin_Click(object sender, EventArgs e)
        //{
        //    Workbook book = new Workbook();
        //    book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx");

        //    Worksheet sheet = book.Worksheets[0];

        //    bool log = false;
        //    int row = sheet.Rows.Length;
        //    for (int i = 2; i <= row; i++) 
        //    {
        //        if (sheet.Range[i, 6].Value == txtUsername.Text &&
        //            sheet.Range[i, 7].Value == txtPassword.Text)
        //        {
        //            log = true;
        //            break;

        //        }
        //        else
        //        {
        //            log = false;
        //        }

        //    }

        //    if (log == true)
        //    {
        //        MessageBox.Show("Successfully Login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        Form1 form1 = new Form1 ();
        //        form1.Show();
        //        this.Hide();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Incorrect username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

    

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\User\OneDrive\Desktop\Book1.xlsx");

            Worksheet sheet = book.Worksheets[0];

            bool log = false;
            int row = sheet.Rows.Length;
            for (int i = 2; i <= row; i++)
            {
                if (sheet.Range[i, 8].Value == txtUsername.Text &&
                    sheet.Range[i, 9].Value == txtPassword.Text)
                {
                    logs.GlobalUser = sheet.Range[i, 8].Value;
                    logs.insertLogs(logs.GlobalUser, "Log In");

                    string imagePath = sheet.Range[i, 11].Value;
                    if (!string.IsNullOrEmpty(imagePath) & File.Exists(imagePath)) 
                    {
                        logs.ImagePath = imagePath;
                        logs.Profile = Image.FromFile(imagePath);
                    }


                    log = true;
                    break;

                }
                else
                {
                    log = false;
                }

            }

            if (log == true)
            {
                MessageBox.Show("Successfully Login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dashboard dashboard = new Dashboard(logs);
                dashboard.Show();
                //Form1 form1 = new Form1();
                //form1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
