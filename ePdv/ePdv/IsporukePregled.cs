using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ePdv
{
    public partial class IsporukePregled : Form
    {
        public IsporukePregled()
        {
            InitializeComponent();
        }

        private void IsporukePregled_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Preview.PregledEisporukeZaglavlje;

            dataGridView2.DataSource = Preview.PregledEisporuke;

            // dataGridView2.Columns["Vrsta_sloga"].Visible = false;

            dataGridView3.DataSource = Preview.PregledEisporukeSum;
        }
    }
}
