using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P08ZadanieFiltorwanieDanych
{
    public partial class CustomDateTimePicker : UserControl
    {
        public CustomDateTimePicker()
        {
            InitializeComponent();
        }

        public DateTime? Value
        {
            get
            {
                if(dtpData.Visible)
                    return dtpData.Value;
                else
                    return null;
            }
            set
            {
                if (value == null)
                {
                    dtpData.Visible = false;
                    txtData.Visible = true;
                    txtData.Text = "Data nieustalona";
                }
                else
                {
                    dtpData.Visible = true;
                    txtData.Visible = false;
                    dtpData.Value = (DateTime)value;
                }
            }
        }

        private void dtpData_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
                Value = null;
        }

        private void txtData_Click(object sender, EventArgs e)
        {
             
            Value = DateTime.Now;
        }
    }
}
