using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace uccApiCore2.Controllers.Common
{
    public class Utilities
    {
        public void SaveImage(int UserId, string[] FileSource, bool IsUser, string WebRootPath)
        {
            if (UserId > 0)
            {
                if (FileSource.Length > 0)
                {
                    string FolderPath;
                    if (IsUser)
                        FolderPath = WebRootPath + "\\uccImages\\User\\" + UserId + "\\";
                    else
                        FolderPath = WebRootPath + "\\uccImages\\Employee\\" + UserId + "\\";
                    bool folderExists = System.IO.Directory.Exists(FolderPath);
                    if (!folderExists)
                        Directory.CreateDirectory(FolderPath);
                    DirectoryInfo directory = new DirectoryInfo(FolderPath);
                    foreach (FileInfo file in directory.GetFiles())
                    {
                        file.Delete();
                    }
                    for (int i = 0; i < FileSource.Length; i++)
                    {
                        string filename = UserId.ToString() + '-' + (i + 1) + ".jpg";
                        string fileNameWitPath = FolderPath + filename;
                        using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
                        {
                            using (BinaryWriter bw = new BinaryWriter(fs))
                            {
                                if (FileSource[i].Contains("data:image/jpeg;base64,"))
                                {
                                    byte[] data = Convert.FromBase64String(FileSource[i].Replace("data:image/jpeg;base64,", ""));
                                    bw.Write(data);
                                    bw.Close();
                                }
                                if (FileSource[i].Contains("data:image/jpg;base64,"))
                                {
                                    byte[] data = Convert.FromBase64String(FileSource[i].Replace("data:image/jpg;base64,", ""));
                                    bw.Write(data);
                                    bw.Close();
                                }
                                if (FileSource[i].Contains("data:image/png;base64,"))
                                {
                                    byte[] data = Convert.FromBase64String(FileSource[i].Replace("data:image/png;base64,", ""));
                                    bw.Write(data);
                                    bw.Close();
                                }
                            }
                        }
                    }

                }
            }
        }
        public string[] UserImagePath(int UserId, bool IsUser, string WebRootPath)
        {
            string[] base64ImageRepresentation = new string[0];
            string folderPath;
            if (IsUser)
                folderPath = WebRootPath + "\\uccImages\\User\\" + UserId + "\\";
            else
                folderPath = WebRootPath + "\\uccImages\\Employee\\" + UserId + "\\";
            //string folderPath = _hostingEnvironment.WebRootPath + "\\uccImages\\User\\" + UserId + "\\";
            if (Directory.Exists(folderPath))
            {
                string[] AllFiles = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories);
                //int fCount = Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories).Length;
                base64ImageRepresentation = new string[AllFiles.Length];
                for (int i = 0; i < AllFiles.Length; i++)
                {
                    byte[] imageArray = System.IO.File.ReadAllBytes(AllFiles[i]);
                    base64ImageRepresentation[i] = "data:image/jpeg;base64," + Convert.ToBase64String(imageArray);
                }
            }
            return base64ImageRepresentation;
        }
    }
}
