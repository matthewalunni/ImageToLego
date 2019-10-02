using System;
using System.Collections.Generic;

namespace ImageToLego.Helper
{
    public class ListEventArgs : EventArgs
    {
        public List<object> Data { get; set; }

        public ListEventArgs(List<object> data)
        {
            this.Data = data;
        }
    }
}