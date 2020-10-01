﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OneClickZip.Includes.Classes;
using OneClickZip.Includes.Classes.Extensions;
using OneClickZip.Includes.Classes.TreeNodeSerialize;
using OneClickZip.Includes.Utilities;

namespace OneClickZip.Includes.Models
{
    [Serializable]
    public class ZipFileModel
    {
        private SerializableTreeNode treeViewZipFileStructure;
        private FileNameCreator fileNameCreator;
        private String filePath;
        private String targetFilePath;

        public ZipFileModel()
        {
            this.treeViewZipFileStructure = new SerializableTreeNode();
        }

        public ZipFileModel(TreeNodeExtended treeNodeExtended, FileNameCreator fileNameCreator)
        {
            this.fileNameCreator = fileNameCreator;
            this.treeViewZipFileStructure = new SerializableTreeNode();
            SetTreeViewZipFileStructureForFileWriting(treeNodeExtended);
        }

        public string ZipFileName { get => fileNameCreator.FileFormulaName; }

        public TreeNodeExtended GetTreeViewZipFileStructure() {
            return SerializableTreeViewOperation.fnPrepareToRead(treeViewZipFileStructure);
        }
        public SerializableTreeNode GetTreeViewZipFileSerializedStructure
        {
            get
            {
                return this.treeViewZipFileStructure;
            }
        }

        public void SetTreeViewZipFileStructureForFileWriting(TreeNodeExtended treeNodeExtended)
        {
            treeViewZipFileStructure = SerializableTreeViewOperation.fnPrepareToWrite(treeNodeExtended);
        }

        public FileNameCreator FileNameCreator { get => fileNameCreator; set => fileNameCreator = value; }
        
        public string FilePath { get => filePath; set => filePath = value; }
        
        public string TargetFilePath { 
            get 
            {
                if (targetFilePath == null) return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (targetFilePath == "") return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if(!Directory.Exists(targetFilePath)) return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                return targetFilePath;
            }
            set => targetFilePath = value; 
        }

        public String GetFullPathFileAndNameOfNewZipArchive
        {
            get
            {
                String targetPath = TargetFilePath.Trim();
                if(!TargetFilePath.EndsWith(@"\")) targetPath += @"\";
                return String.Format(@"{0}{1}.zip", targetPath, fileNameCreator.GetDerivedFormula());
            }
        }

        public String GetFileName
        {
            get
            {
                if (filePath == null) return "";
                if (filePath == "") return "";
                if (FileSystemUtilities.IsFullPathIsDirectory(filePath))
                {
                    DirectoryInfo dInfo = new DirectoryInfo(filePath);
                    return dInfo.Name;
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    return fileInfo.Name;
                }
            }
        }
    }
}
