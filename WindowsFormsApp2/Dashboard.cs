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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        Logs myLogs;
        public Dashboard(Logs myLogs)
        {
            InitializeComponent();
            this.myLogs = myLogs;
            if (!string.IsNullOrEmpty(myLogs.ImagePath) && File.Exists(myLogs.ImagePath))
            {
                picProfile.Image = Image.FromFile(myLogs.ImagePath);    
                picProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            }

        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lblName.Text = myLogs.GlobalUser;

           

        }

        private void btnActiveStatus_Click(object sender, EventArgs e)
        {
           Form2 activestudent = new Form2(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Visited Active Student");

            activestudent.Show();
            this.Hide();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnInactiveStatus_Click(object sender, EventArgs e)
        {
            InActiveStudent inActiveStudent = new InActiveStudent(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Visited Inactive Student");
            inActiveStudent.Show();
            this.Hide();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            addStudent addStudent = new addStudent(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Visited Add Student");
            addStudent.Show();
            this.Hide();
        }

        private void btnLogs_Click(object sender, EventArgs e)
        {
            frmLogs log = new frmLogs(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Visited Logs");
            log.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login(myLogs);
            myLogs.insertLogs(myLogs.GlobalUser, "Log Out");
            login.Show();
            this.Hide();
        }
    }
}
