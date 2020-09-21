using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace uccApiCore2.Controllers.Common
{
    public class ErrorLogger
    {
        public static void Log(string message)
        {
            try
            {

                //string directory = @"C:\Project\Mohit\EcommApiCore\uccApiCore2\wwwroot\errorlog";
                string directory = @"C:\inetpub\wwwroot\EcommApi\wwwroot\errorlog";
                if (Directory.Exists(directory))
                {

                    string errorFile = directory + @"\" + DateTime.Today.Date.ToString("yyyy-MM-dd").Replace(" /", "-") + ".txt";
                    if (!File.Exists(errorFile))
                    {
                        FileStream fs = File.Create(errorFile);
                        if (fs != null)
                        {
                            fs.Close();
                        }
                    }

                    if (File.Exists(errorFile))
                    {
                        //FileStream fs = new FileStream(errorFile, FileMode.Append);
                        // FileInfo f = new FileInfo(errorFile);
                        //StreamWriter sw = f.AppendText();

                        using (StreamWriter sW = File.AppendText(errorFile))
                        {


                            sW.WriteLine("-------------------------------------------------");
                            sW.WriteLine("Error Occurrred At:" + DateTime.Now.ToString());
                            sW.WriteLine(message);
                            sW.WriteLine("---------------------END-------------------------");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
