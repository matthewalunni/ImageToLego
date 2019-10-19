using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageToLego.Helper
{
    class TypeCoversions
    {

        /// <summary>
        /// this method puts a list of delimited strings to a data table
        /// assumes there is a header line
        /// </summary>
        /// <param name="list">list to be converted to datatable</param>
        /// <param name="delimiter">delimiter in strings</param>
        /// <returns>a new datatable</returns>
        public static DataTable ToDataTable(IEnumerable<string> list, string delimiter)
        {
            DataTable dt = new DataTable();
            // Creating the columns
            string[] headers = list.ElementAt(0).Split(delimiter.ToCharArray());
            int count = 0;
            foreach (var csvLine in list)
            {
                count++;
                string[] row = list.ElementAt(0).Split(delimiter.ToCharArray());
                if (count == 1)
                {
                    foreach (var element in row)
                    {
                        dt.Columns.Add(element.Trim());
                    }
                }
                else
                {
                    foreach (var element in row)
                    {
                        dt.Rows.Add(element.Trim());
                    }
                }
            }

            return dt;
        }

    }
}
