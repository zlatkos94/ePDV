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
    public partial class Pregled : Form
    {
        public Pregled()
        {
            InitializeComponent();
        }

        private void Pregled_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Preview.PregledEnabavkeZaglavlje;

            dataGridView2.DataSource = Preview.PregledEnabavke;

            // dataGridView2.Columns["Vrsta_sloga"].Visible = false;

            dataGridView3.DataSource = Preview.PregledEnabavkeSum;
        }
    }
}
