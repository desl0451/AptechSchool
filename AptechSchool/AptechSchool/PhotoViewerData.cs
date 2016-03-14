using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.Utils.Serializing;
using System.Collections.Specialized;
using System.Collections;
using System.Drawing;
using System.IO;

namespace AptechSchool {
    /// <summary>
    /// Í¼Æ¬ÊÓÍ¼Êý¾Ý
    /// </summary>
    public class PhotoViewerData: IXtraSerializable {
        /// <summary>
        /// Directory Collection
        /// </summary>
        PathCollection folders;
        /// <summary>
        /// Alibum Collection
        /// </summary>
        AlbumCollection albums;
        /// <summary>
        /// Alibum Data
        /// </summary>
        AlbumData others;

        bool firstRun;

        [XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 1, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)]

        ///
        /// return album collection
        /// 
        public AlbumCollection Albums {
            get {
                if(albums == null)
                    albums = new AlbumCollection();
                return albums;
            }
        }
        [XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 2, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)]
        ///return path collection
        public PathCollection Folders {
            get {
                if(folders == null)
                    folders = new PathCollection();
                return folders;
            }
        }
        [XtraSerializableProperty(XtraSerializationVisibility.Content)]
        public AlbumData Others {
            get {
                if(others == null)
                    others = new AlbumData();
                return others;
            }
        }
        [XtraSerializableProperty]
        public bool FirstRun {
            get { return firstRun; }
            set { firstRun = value; }
        }

        #region IXtraSerializable Members

        void IXtraSerializable.OnEndDeserializing(string restoredVersion) { }
        void IXtraSerializable.OnEndSerializing() { }
        void IXtraSerializable.OnStartDeserializing(DevExpress.Utils.LayoutAllowEventArgs e) { }
        void IXtraSerializable.OnStartSerializing() { }

        #endregion

        public void SaveLayoutToXml(string fileName) {
            if(File.Exists(fileName))
                //¡¡Set File Attribue
                File.SetAttributes(fileName, FileAttributes.Normal);
            SaveLayoutCore(new XmlXtraSerializer(), fileName);
        }
        public void RestoreLayoutFromXml(string fileName) {
            File.SetAttributes(fileName, FileAttributes.Normal);

            RestoreLayoutCore(new XmlXtraSerializer(), fileName);
        }
        protected virtual bool SaveLayoutCore(XtraSerializer serializer, object path) {
            System.IO.Stream stream = path as System.IO.Stream;
            if(stream != null)
                return serializer.SerializeObjects(
                    new XtraObjectInfo[] { new XtraObjectInfo("PhotoViewerData", this) },
                                             stream, this.GetType().Name);
            else
                return serializer.SerializeObjects(
                    new XtraObjectInfo[] { new XtraObjectInfo("PhotoViewerData", this) },
                                            path.ToString(), this.GetType().Name);
        }
        protected virtual void RestoreLayoutCore(XtraSerializer serializer, object path) {
            System.IO.Stream stream = path as System.IO.Stream;
                if(stream != null)
                    serializer.DeserializeObjects(new XtraObjectInfo[] { new XtraObjectInfo("PhotoViewerData", this) },
                        stream, this.GetType().Name);
                else
                    serializer.DeserializeObjects(new XtraObjectInfo[] { new XtraObjectInfo("PhotoViewerData", this) },
                        path.ToString(), this.GetType().Name);
        }
        object XtraCreateAlbumsItem(XtraItemEventArgs e) {
            return new AlbumData();
        }
        void XtraSetIndexAlbumsItem(XtraSetItemIndexEventArgs e) {
            Albums.Insert(e.NewIndex, (AlbumData)e.Item.Value);
        }
        object XtraCreateFoldersItem(XtraItemEventArgs e) {
            return new PathData();
        }
        void XtraSetIndexFoldersItem(XtraSetItemIndexEventArgs e) {
            Folders.Insert(e.NewIndex, (PathData)e.Item.Value);
        }

        public void Clear() {
            Albums.Clear();
            Folders.Clear();
        }
    }

    public class AlbumCollection : CollectionBase {
        public int Add(AlbumData album) { return List.Add(album); }
        public void Insert(int index, AlbumData album) { List.Insert(index, album); }
        public void Remove(AlbumData album) { List.Remove(album); }
        public AlbumData this[int index] { get { return List[index] as AlbumData; } set { List[index] = value; } }
    }

    /// <summary>
    /// CollectionBase¡¡Super Collection
    /// Path Collection
    /// </summary>
    public class PathCollection : CollectionBase {

        public int Add(PathData path) { return List.Add(path); }
        public void Insert(int index, PathData path) { List.Insert(index, path); }
        public void Remove(PathData path) { List.Remove(path); }
        public void Remove(string path) {
            foreach(PathData pData in this) {
                if(pData.Path == path) {
                    Remove(pData);
                    return;
                }
            }
        }
        public PathData this[int index] { get { return List[index] as PathData; } set { List[index] = value; } }
        public bool Contains(string file) {
            foreach(PathData pData in this) {
                if(pData.Path == file)
                    return true;
            }
            return false;
        }
    }
    
    public class AlbumData : IXtraSerializable {
        PathCollection files;
        DateTime date;
        string name;
        string description;

        [XtraSerializableProperty(XtraSerializationVisibility.Collection, true, false, true, 1, XtraSerializationFlags.DeserializeCollectionItemBeforeCallSetIndex)]
        public PathCollection Files {
            get {
                if(files == null)
                    files = new PathCollection();
                return files;
            }
        }

        [XtraSerializableProperty]
        public string Name { get { return name; } set { name = value; } }
        [XtraSerializableProperty]
        public DateTime Date { get { return date; } set { date = value; } }
        [XtraSerializableProperty]
        public string Description { get { return description; } set { description = value; } }

        #region IXtraSerializable Members

        void IXtraSerializable.OnEndDeserializing(string restoredVersion) { }
        void IXtraSerializable.OnEndSerializing() { }
        void IXtraSerializable.OnStartDeserializing(DevExpress.Utils.LayoutAllowEventArgs e) { }
        void IXtraSerializable.OnStartSerializing() { }

        #endregion

        object XtraCreateFilesItem(XtraItemEventArgs e) {
            return new PathData();
        }
        void XtraSetIndexFilesItem(XtraSetItemIndexEventArgs e) {
            Files.Insert(e.NewIndex, (PathData)e.Item.Value);
        }
    }

    public class PathData : IXtraSerializable {
        string name;
        string path;
        Image image;

        [XtraSerializableProperty]
        public string Name { get { return name; } set { name = value; } }
        [XtraSerializableProperty]
        public string Path { get { return path; } set { path = value; } }
        public Image Image { get { return image; } set { image = value; } }

        #region IXtraSerializable Members

        void IXtraSerializable.OnEndDeserializing(string restoredVersion) { }
        void IXtraSerializable.OnEndSerializing() { }
        void IXtraSerializable.OnStartDeserializing(DevExpress.Utils.LayoutAllowEventArgs e) { }
        void IXtraSerializable.OnStartSerializing() { }

        #endregion
    }
}
