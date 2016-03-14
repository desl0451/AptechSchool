using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars.Ribbon;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using System.IO;
using DevExpress.XtraEditors;//XtraMessageBox
using System.Data.SqlClient;
using AptechSchoolBLL;
using AptechSchoolModels;

namespace AptechSchool
{
    public partial class DisplayUsers : UserControl
    {
        private List<Student> usersList = new List<Student>();
        public DisplayUsers()
        {
            InitializeComponent();
            LoadData();//加载数据
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            //ViewData.Clear();
            bool forceProcess = false;
            //判断文件是否存在
            //if (File.Exists(ViewDataFile))
            //{
            //    ViewData.RestoreLayoutFromXml(ViewDataFile);
            //}
            //if (ViewData.FirstRun)
            //{
            //    GenerateSampleData();
            //    forceProcess = true;
            //}
            //InitNavBar();
            //UpdateMainGalleryContent(forceProcess);

            UserServices ss = new UserServices();
            usersList = ss.GetALLUsers();
        }

        private void DisplayUsers_Load(object sender, EventArgs e)
        {
            SchoolclassServices ss = new SchoolclassServices();

            string ClassName = "";
            GalleryItemGroup group1 = new GalleryItemGroup(); ;
            Image img = null;
            foreach (Student user in usersList)
            {
                ClassName = ss.GetClassName(Convert.ToInt32(user.SClass));

                if (group1.Caption != ClassName)
                {
                    group1 = new GalleryItemGroup();
                    mainGallery.Gallery.Groups.Add(group1);
                }
                group1.Caption = ClassName;
                img = Image.FromFile(GetDataDir() + ClassName + "\\" + user.SPicture);
                group1.Items.Add(new GalleryItem(img, user.SName, ""));
            }
            mainGallery.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside;
            mainGallery.Gallery.ImageSize = new Size(90, 120);
            mainGallery.Gallery.ShowItemText = true;


            mainGallery.Gallery.Groups.Add(group1);
        }
        protected string GetDataDir()
        {
            //返回Debug目录
            string path = AppDomain.CurrentDomain.BaseDirectory;
            path += "material\\";
            if (Directory.Exists(path))
                return path;
            //material
            return string.Empty;
        }
    }
}
