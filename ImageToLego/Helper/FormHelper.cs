using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToLego.Helper
{
    class FormHelper
    {
        public static string FileUploadPrompt()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.FileName = "Upload an Image";
                ofd.Filter = "Image files(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                ofd.Title = "Upload an Image";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = ofd.FileName;
                        return filePath;
                        
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    return null;
                }
            }
        }



        internal static bool ControlsAreFilled(params Control[] controls)
        {
            return true;
        }
    }
}
