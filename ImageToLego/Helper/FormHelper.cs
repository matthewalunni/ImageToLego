using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToLego.Helper
{
    class FormHelper
    {
        /// <summary>
        /// this method prompts a user to upload a file.
        /// </summary>
        /// <param name="filter">string filter used to specify file types</param>
        /// <returns>a string filepath</returns>
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


        /// <summary>
        /// this method checks if controls are filled on a form
        /// </summary>
        /// <param name="controls">controls to be checked</param>
        /// <returns>true if controls are filled</returns>
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

        /// <summary>
        /// this method adds headers to a specified datagridview
        /// columns are named their header text
        /// </summary>
        /// <param name="dgv">datagridview for headers to be added to</param>
        /// <param name="headers">list of columns to make</param>
        public static void AddDataGridViewHeaders(DataGridView dgv, params string[] headers)
        {

            foreach (var head in headers)
            {
                dgv.Columns.Add(head, head);
            }

        }
    }
}
