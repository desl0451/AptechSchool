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
    public partial class MainClassManager : Form
    {
        private List<Student> usersList = new List<Student>();
        public MainClassManager()
        {
            InitializeComponent();
            LoadData();//加载数据
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            ViewData.Clear();
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
             InitNavBar();
            //UpdateMainGalleryContent(forceProcess);

            UserServices ss = new UserServices();
            usersList = ss.GetALLUsers();
        }

        private void InitNavBar()
        {
            InitNavBar(false);
        }
        //加载数据
        private void InitNavBar(bool onlyAlbums)
        {
            //navBarControl1.SelectedLink = null;
            //foreach (NavBarGroup group in navBarControl1.Groups)
            //{
            //    if (onlyAlbums && group != albumGroup)
            //        continue;
            //    for (int i = group.ItemLinks.Count - 1; i >= 0; i--)
            //    {
            //        navBarControl1.Items.Remove(group.ItemLinks[i].Item);
            //    }
            //}
            navBarControl1.BeginUpdate();
            try
            {
                //foreach (AlbumData album in ViewData.Albums)
                //{
                //    NavBarItem item = CreateAlbumItem(album);
                //    navBarControl1.Items.Add(item);
                //    albumGroup.ItemLinks.Add(item);
                //}
                //if (onlyAlbums)
                //    return;
                //foreach (PathData folder in ViewData.Folders)
                //{
                //    NavBarItem item = CreateFolderItem(folder);
                //    if (item != null)
                //    {
                //        navBarControl1.Items.Add(item);
                //        foldersGroup.ItemLinks.Add(item);
                //    }
                //}
                //foreach (PathData file in ViewData.Others.Files)
                //{
                //    NavBarItem item = CreateFolderItem(file);
                //    if (item != null)
                //    {
                //        navBarControl1.Items.Add(item);
                //        othersGroup.ItemLinks.Add(item);
                //    }
                //}
            }
            finally { navBarControl1.EndUpdate(); }
            if (navBarControl1.Items.Count > 0)
                navBarControl1.SelectedLink = navBarControl1.Items[0].Links[0];
        }




        #region 加载文件夹
        private void GenerateSampleData()
        {
            ViewData.Clear();

            AddFolder("\\S2T82");
            //AddFolder("\\SamplePhotos\\Photo2");
            //AddFolder("\\SamplePhotos\\Photo3");
            //AddFolder("\\SamplePhotos\\Photo4");

            if (ViewData.Folders.Count > 1)
            {
                List<string> files = GetImagesInFolder(ViewData.Folders[0]);
                files.AddRange(GetImagesInFolder(ViewData.Folders[1]));

                //AddAlbum("Sample Album 1", DateTime.Now, "This is a sample album 1", files);
            }
            if (ViewData.Folders.Count > 3)
            {
                List<string> files = GetImagesInFolder(ViewData.Folders[2]);
                files.AddRange(GetImagesInFolder(ViewData.Folders[3]));

                //AddAlbum("Sample Album 2", DateTime.Now, "This is a sample album 2", files);
            }

            ViewData.Others.Name = "Other";
            ViewData.Others.Date = DateTime.Now;
            ViewData.Others.Description = "Other image files";

            UpdateData();
            // UpdateMainGalleryContent(true);
        }

        private void UpdateMainGalleryContent(bool forceProcess)
        {
            //if (navBarControl1.SelectedLink == null)
            //{
            //    ClearGalleryAndImages();
            //    return;
            //}
            //AlbumData album = navBarControl1.SelectedLink.Item.Tag as AlbumData;
            //PathData path = navBarControl1.SelectedLink.Item.Tag as PathData;
            //bool shouldRecreateGallery = lastSelectedGroup != navBarControl1.SelectedLink.Group || forceProcess;
            //bool isOtherFiles = navBarControl1.SelectedLink.Group == othersGroup;
            //if (album != null)
            //{
            //    if (shouldRecreateGallery)
            //        ProcessAlbums();
            //    if (!flag)
            //        ScrollToAlbum(album, !shouldRecreateGallery);
            //}
            //else if (path != null)
            //{
            //    if (shouldRecreateGallery)
            //    {
            //        if (isOtherFiles)
            //            ProcessOthers();
            //        else
            //            ProcessFolders();
            //    }
            //    if (isOtherFiles)
            //        ScrollToFile(path.Path, !shouldRecreateGallery);
            //    else
            //        ScrollToFolder(path, !shouldRecreateGallery);
            //}
            //UpdateItemsEnabledState();
        }
        #endregion
        protected void UpdateData() { UpdateData(false); }
        protected void UpdateData(bool onlyAlbums)
        {
            //SaveData();
            //InitNavBar(onlyAlbums);
        }
        #region 
        //加载文件夹
        private void AddFolder(string relativePath)
        {
            PathData pData = new PathData();
            pData.Path = DataPath + relativePath;
            pData.Name = Path.GetFileName(pData.Path);
            if (!Directory.Exists(pData.Path))
            {
                XtraMessageBox.Show(this, "Error: no such path '" + pData.Path + "'. Maybe you removed this folder?", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ViewData.Folders.Add(pData);
        }
        #endregion






        #region 读取指定文件夹中的图片
        //////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////// 
        ///        
        ///读取指定文件夹中的图片
        ///        
        protected List<string> GetImagesInFolder(PathData folder)
        {
            string strFilter = "*bmp;*tga;*.jpg;*.png;*.gif";
            string[] m_arExt = strFilter.Split(';');
            List<string> files = new List<string>();
            foreach (string filter in m_arExt)
            {
                string[] str = Directory.GetFiles(folder.Path, filter);
                files.AddRange(str);
            }
            return files;
        }
        #endregion


        protected string DataPath
        {
            get
            {
                string dataPath = GetDataDir(); ;
                if (Directory.Exists(dataPath))
                    return dataPath;
                return string.Empty;
            }
        }
        protected string ViewDataFile { get { return DataPath + "data.xml"; } }

        private void MainClassManager_Load(object sender, EventArgs e)
        {
           // mainGallery.Dock = DockStyle.Fill;        

            SchoolclassServices ss = new SchoolclassServices();

            string ClassName = "";
            GalleryItemGroup group1 =  new GalleryItemGroup(); ;
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
            mainGallery.Gallery.ImageSize = new Size(120, 90);
            mainGallery.Gallery.ShowItemText = true;


            mainGallery.Gallery.Groups.Add(group1);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //string path = GetDataDir();
            //ProcessAlbums();
        }
        protected string GetDataDir()
        {
            //返回Debug目录
            string path = AppDomain.CurrentDomain.BaseDirectory;
            //for (int i = 0; i < 10; i++)
            //{
            //path += "..\\";
            //if (Directory.Exists(path + "Data"))
            //    return path + "Data";
            //}
            path += "material\\";
            if (Directory.Exists(path))
                return path;
            //material
            return string.Empty;
        }
        //图片视对象
        PhotoViewerData viewData;
        private void ProcessAlbums()
        {
            mainGallery.Gallery.BeginUpdate();
            try
            {
                ClearGalleryAndImages();
                foreach (AlbumData album in ViewData.Albums)
                {
                    ProcessAlbum(album);
                }
            }
            finally
            {
                mainGallery.Gallery.EndUpdate();
            }
        }
        private void ProcessAlbum(AlbumData albumData)
        {
            ProcessAlbum(albumData, true);
        }

        private void ProcessAlbum(AlbumData albumData, bool showEditButtons)
        {
            GalleryItemGroup group = CreateAlbumGroup(albumData);
            //AlbumGroupCaptionControl control = (AlbumGroupCaptionControl)group.CaptionControl;
            //if (!showEditButtons)
            //    control.HideEditButtons();
            mainGallery.Gallery.Groups.Add(group);
            foreach (PathData pData in albumData.Files)
            {
                group.Items.Add(CreatePhotoGalleryItem(pData.Path));
            }
        }
        private GalleryItem CreatePhotoGalleryItem(string fileName)
        {
            GalleryItem item = new GalleryItem();
            item.Caption = Path.GetFileName(fileName);
            item.Hint = fileName;
            item.Tag = fileName;
            return item;
        }

        private GalleryItemGroup CreateAlbumGroup(AlbumData albumData)
        {
            GalleryItemGroup group = new GalleryItemGroup();
            group.Tag = albumData;
            group.Caption = albumData.Name;
            group.CaptionAlignment = GalleryItemGroupCaptionAlignment.Stretch;
            // group.CaptionControl = CreateAlbumGroupCaptionControl(albumData);
            return group;
        }
        //private Control CreateAlbumGroupCaptionControl(AlbumData albumData)
        //{
        //    //AlbumGroupCaptionControl control = new AlbumGroupCaptionControl();
        //    //control.Album = albumData;
        //    //control.MainForm = this;
        //    //return control;
        //}


        /// <summary>
        /// 判断图片视频是否为空
        /// </summary>
        protected PhotoViewerData ViewData
        {
            get
            {
                if (viewData == null)
                    viewData = new PhotoViewerData();
                return viewData;
            }
        }

        /// <summary>
        /// 清除节点
        /// </summary>
        private void ClearGalleryAndImages()
        {
            mainGallery.Gallery.Groups.Clear();
            foreach (GalleryItemGroup group in mainGallery.Gallery.Groups)
            {
                if (group.CaptionControl != null)
                {
                    group.CaptionControl.Dispose();
                    group.CaptionControl = null;
                    foreach (GalleryItem item in group.Items)
                    {
                        if (item.Image != null)
                        {
                            item.Image.Dispose();
                            item.Image = null;
                        }
                        PathData pData = item.Tag as PathData;
                        pData.Image = null;
                    }
                }
            }
        }
    }
}
