using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;
namespace Backup
{
    class DirectorySearch
    {

        private string sourceDir;
        private string backupDir;
        private string extension;
        //private DirectoryInfo src;
        //private DirectoryInfo bck;
        private string[] subDirs;

        public string Source
        {
            get { return sourceDir; }
            set
            { 
                sourceDir = value;
            }
        }

        public String Backup
        {
            set 
            {
                backupDir = value; 
            }
        }

        public string FileExtension
        {
            set { extension = "*."+ value; }
        }

        public void moveFiles(string path)
        {

            string[] dirs = Directory.GetDirectories(path);
            var files = Directory.EnumerateFiles(path, extension);
            if (dirs.Length > 0 || files != null)
            {
                if (!path.Equals(backupDir))
                {
                    foreach (string curr in files)
                    {
                       //string folderStruct = 
                        string fileName = curr.Substring(path.Length + 1);
                        string source = System.IO.Path.Combine(path, fileName);
                        //string dest = System.IO.Path.Combine(backupDir, fileName);
                        string dest = backupDir + "\\" + curr.Substring(sourceDir.Length + 1);
                        string destStruct = dest.Replace(fileName, "");//set up folder structure
                        Directory.CreateDirectory(destStruct);
                        //Directory.Move(curr, Path.Combine(backupDir, fileName));
                        System.IO.File.Copy(source, dest, true);
                      //  FileSystem.CopyDirectory(source, dest, UIOption.AllDialogs);
                    }
                }
                foreach (string s in dirs)
                {
                    moveFiles(s);
                }
            }
         //   String []rootSubDirs = Directory.GetDirectories(sourceDir);
            //Console.WriteLine(rootSubDirs[0]);
          //  foreach (string subDir in rootSubDirs) 
         //   {
         //       String[] subDirSubs = Directory.GetDirectories(subDir);
         //   }
         
        }


        public void moveFiles1() 
        {
            List<IEnumerable<string>> f = null;
            foreach (string folder in subDirs) {
                f.Add(Directory.EnumerateFiles(sourceDir +"" +folder, extension));

            }
            var files = Directory.EnumerateFiles(sourceDir, extension);

            foreach (string curr in files)
            {
                string fileName = curr.Substring(sourceDir.Length + 1);
                Directory.Move(curr, Path.Combine(backupDir, fileName));
            }
        }
    }
}
