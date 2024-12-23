using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.Models;

namespace WinFormsApp2
{
    internal class SimpleDataGridView : DataGridView
    {
        protected override void OnRowLeave(DataGridViewCellEventArgs e)
        {
            base.OnRowLeave(e);
        }

    }
}
