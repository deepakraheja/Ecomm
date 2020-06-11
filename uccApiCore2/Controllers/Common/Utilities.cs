using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using uccApiCore2.BAL;
using uccApiCore2.BAL.Interface;
using uccApiCore2.Entities;
using uccApiCore2.Repository;
using uccApiCore2.Repository.Interface;

namespace uccApiCore2.Controllers.Common
{
    public class Utilities
    {
        public void SaveImage(int ProductId, string[] FileSource, string Type, string WebRootPath)
        {
            if (ProductId > 0)
            {
                if (FileSource.Length > 0)
                {
                    string FolderPath;
                    //if (Type == "banner")
                        FolderPath = WebRootPath + "\\ProductImage\\" + ProductId + "\\" + Type + "\\";
                    //else
                    //    FolderPath = WebRootPath + "\\uccImages\\Employee\\" + UserId + "\\";
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
                        string filename = ProductId.ToString() + '-' + DateTime.Now.ToString("MMddyyyyhhmmss") + "-" + (i + 1) + ".jpg";
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
                                if (Type == "bannerImage" || Type == "frontImage")
                                {
                                    ProductRepository obj = new ProductRepository();
                                    Product product = new Product();
                                    product.ImagePath = filename;
                                    product.ProductID = ProductId;
                                    product.Type = Type;
                                    obj.SaveProductImages(product);
                                }
                            }
                        }
                    }

                }
            }
        }
        public string[] ProductImagePath(int ProductId, string Type, string WebRootPath)
        {
            string[] base64ImageRepresentation = new string[0];
            string folderPath;
            folderPath = WebRootPath + "\\ProductImage\\" + ProductId + "\\" + Type + "\\";
            //if (IsUser)
            //    folderPath = WebRootPath + "\\uccImages\\User\\" + UserId + "\\";
            //else
            //    folderPath = WebRootPath + "\\uccImages\\Employee\\" + UserId + "\\";
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
