using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AptechSchoolBLL;
using AptechSchoolModels;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace AptechSchool
{
    public partial class EducationalInfo : UserControl
    {
        public EducationalInfo()
        {
            InitializeComponent();
            Init();
        }
        private void Init()
        {
            EducationalServices eduServices = new EducationalServices();
            ComboBoxItemCollection coll = comboBoxEdit1.Properties.Items;
            coll.BeginUpdate();
            try
            {
                List<Educational> EList = eduServices.GetAllEducationals();
                foreach (Educational edu in eduServices.GetAllEducationals())
                {
                    coll.Add(edu.EducationalName);
                }


            }
            finally
            {
                coll.EndUpdate();
            }
            comboBoxEdit1.SelectedIndex = -1;

            Application.DoEvents();



        }
    }
}
