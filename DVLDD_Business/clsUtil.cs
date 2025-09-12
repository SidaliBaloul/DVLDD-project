using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsUtil
    {
        public static bool CreateFolderIfIsNotExist(string foldername)
        {
            if(!Directory.Exists(foldername))
            {
                try
                {
                    Directory.CreateDirectory(foldername);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;
        }

        public static string GenerateGuid()
        {
            Guid newguid = Guid.NewGuid();

            return newguid.ToString();
        }

        public static string ReplaceFileNameWithGuid(string sourcefile)
        {
            string filename = sourcefile;

            FileInfo inf = new FileInfo(filename);
            string ext = inf.Extension;

            return GenerateGuid() + ext;
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourcefile)
        {
            string destinationfolder = @"C:\DVLD-People-Images\";

            if (!Directory.Exists(destinationfolder))
                return false;

            string ImageDestintion = destinationfolder + ReplaceFileNameWithGuid(sourcefile);

            try
            {
                File.Copy(sourcefile, ImageDestintion, true);
            }
            catch (IOException iox)
            {
                return false;
            }

            sourcefile = ImageDestintion;
            return true;
        }


    }
}
