using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using AptechSchoolCommon;
using AptechSchoolBLL;
namespace AptechSchool
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainClassManager classManager = new MainClassManager();
            classManager.Show();
        }
        /// <summary>
        /// Jusp Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barBtnUrl_ItemClick(object sender, ItemClickEventArgs e)
        {
            ProcessUtil.GoHref("www.hlj-aptech.com");
        }

        private void accordionControlElement3_Click(object sender, EventArgs e)
        {
            StudentFind stu = new StudentFind();
            panelControl1.Controls.Clear();
            stu.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(stu);
        }

        private void accordionControlElement4_Click(object sender, EventArgs e)
        {

        }

        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
    
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            EducationalInfo educational = new EducationalInfo();
            educational.Dock = DockStyle.Fill;
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(educational);

        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //EducationalServices eduServices = new EducationalServices();
            //comboBox1.DataSource = eduServices.GetAllEducationals();
            //comboBox1.DisplayMember = "educationalname";
            //comboBox1.ValueMember = "eid";
        }
    }
}