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
        public static string FileUploadPrompt(string filter)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.FileName = "Upload a File";
                ofd.Filter = filter;
                ofd.Title = "Upload a File";
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
            foreach(var control in controls)
            {
                if (string.IsNullOrEmpty(control.Text))
                {
                    return false;
                }
            }
            return true;
        }

        

    }
}
