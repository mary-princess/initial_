using Spire.Xls;
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
    public partial class addStudent : Form
    {
        public addStudent()
        {
            InitializeComponent();
        }
        Logs myLogs;

        public addStudent(Logs mylogs)
        {
            InitializeComponent();
            this.myLogs = mylogs;
            if (!string.IsNullOrEmpty(myLogs.ImagePath) && File.Exists(myLogs.ImagePath))
            {
                picProfile.Image = Image.FromFile(myLogs.ImagePath);
                picProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            Workbook book = new Workbook();
            book.LoadFromFile(@"C:\Users\User\OneDrive\Desktop\Book1.xlsx");
            //book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx");

            Worksheet sheet = book.Worksheets[0];

            string name = "",
                gender = "",
                hobbies = "",
                degree = "",
                favoriteColor = "",
                sayings = "",
                username = "",
                password = "",
                imagePath = "";
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                name += txtName.Text;
            }
            if (radFemale.Checked == true)
            {
                gender += radFemale.Text;
            }
            if (radMale.Checked == true)
            {
                gender += radMale.Text;
            }

            if (chkVball.Checked == true)
            {
                hobbies += chkVball.Text + " , ";
            }
            if (chkBball.Checked == true)
            {
                hobbies += chkBball.Text + " , ";
            }
            if (chkBadminton.Checked == true)
            {
                hobbies += chkBadminton.Text + " , ";
            }

            if (cboColor.SelectedItem != null)
            {
                favoriteColor += cboColor.Text;
            }

            if(cboDegree.SelectedItem != null)
            {
                degree += cboDegree.Text;
            }

            if (!string.IsNullOrEmpty(txtSayings.Text))
            {
                sayings += txtSayings.Text;

            }
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                username += txtUsername.Text;
            }
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                password += txtPassword.Text;
            }
            
            imagePath = txtProfile.Text;


            int age = myLogs.CalculateAge(dtpBirthdate.Value);
            lblAge.Text = age.ToString();


            int row = sheet.LastRow + 1;

            sheet.Range[row, 1].Value = name;
            sheet.Range[row, 2].Value = gender;
            sheet.Range[row, 3].Value = hobbies;
            sheet.Range[row, 4].Value = degree;
            sheet.Range[row, 5].Value = favoriteColor;
            sheet.Range[row, 6].Value = sayings;
            sheet.Range[row, 7].Value = myLogs.Age.ToString();
            sheet.Range[row, 8].Value = username;
            sheet.Range[row, 9].Value = password;
            sheet.Range[row, 10].Value = "1";
            //sheet.Range[row, 11].Value = imagePath;

            book.SaveToFile(@"C:\Users\User\OneDrive\Desktop\Book1.xlsx", ExcelVersion.Version2016);
            //book.SaveToFile(@"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx", ExcelVersion.Version2016);

            myLogs.insertLogs(myLogs.GlobalUser, "Inserting Info");
            DataTable dt = sheet.ExportDataTable();
            Form2 form2 = new Form2();
            form2.dgvData.DataSource = dt;
            MessageBox.Show("Successfully added data.");
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Visited Dashbooard");
            dashboard.Show();
            this.Hide();
        }

        private void btnActiveStatus_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Visited Active Student");
            form2.Show();
            this.Hide();
        }

        private void btnInactiveStatus_Click(object sender, EventArgs e)
        {
            InActiveStudent inActiveStudent = new InActiveStudent(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Visited Inactive Student");
            inActiveStudent.Show();
            this.Hide();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            frmLogs logs = new frmLogs(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Visited Logs");
            logs.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Log Out");
            login.Show();
            this.Hide();
        }

        private void addStudent_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblName.Text = myLogs.GlobalUser;
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            //Workbook book = new Workbook();
            //book.LoadFromFile(@"C:\Users\User\OneDrive\Desktop\Book1.xlsx");
            ////book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx");

            //Worksheet sheet = book.Worksheets[0];

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";


            if (file.ShowDialog() == DialogResult.OK) 
            { 
                Image selectedImage = Image.FromFile(file.FileName);

                //picProfile.Image = selectedImage;
                //picProfile.SizeMode = PictureBoxSizeMode.StretchImage;

                txtProfile.Text = file.FileName;

                myLogs.Profile = selectedImage;
                myLogs.ImagePath = file.FileName;

                //int row = sheet.Rows.Length + 1;

                //sheet.Range[row, 11].Value = file.FileName;

                //book.SaveToFile(@"C:\Users\User\OneDrive\Desktop\Book1.xlsx", ExcelVersion.Version2016);
                ////book.SaveToFile(@"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx", ExcelVersion.Version2016);

            }

        }


        //TO BE CONTINUED
        //public void showStatus(string status)
        //{
        //    Workbook book = new Workbook();
        //    book.LoadFromFile(@"C:\Users\ACT-STUDENT\Desktop\Book1.xlsx");

        //    Worksheet sh = book.Worksheets[0];
        //    DataTable dt = sh.ExportDataTable();
        //    DataRow[] row = dt.Select("Status = " + status);

        //    foreach (DataRow row2 in row)
        //    {
        //    }
        //}
    }
}
