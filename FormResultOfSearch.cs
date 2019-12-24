using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Airport
{
    public partial class FormResultOfSearch : Form
    {
        int nClass;
        int CountPassangers;

        public FormResultOfSearch(List<string[]> ListOfRoutes, int nclass, int nCountPassangers)
        {
            InitializeComponent();
            nClass = nclass;
            CountPassangers = nCountPassangers;
            foreach (var row in ListOfRoutes)
            {
                dataGridView1.Rows.Add(row);
            }
            Width = dataGridView1.Columns[0].Width + dataGridView1.Columns[1].Width +
                dataGridView1.Columns[2].Width + dataGridView1.Columns[4].Width +
                dataGridView1.Columns[4].Width + dataGridView1.Columns[5].Width + 5;
            dataGridView1.Width = Width - 19;
            dataGridView1.Height = dataGridView1.Rows.Count <= 7 ? dataGridView1.ColumnHeadersHeight * dataGridView1.Rows.Count : dataGridView1.Height;
            btSelectTicket.Location = new Point(btSelectTicket.Location.X, dataGridView1.Height + 2);
            Height = dataGridView1.Height + 40 + btSelectTicket.Height + 2;
            btSelectTicket.Visible = true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                BtSelectTicket_Click(this, new EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtSelectTicket_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                for (int i = 0; i < CountPassangers; i++)
                {
                    FormFillTicket formFillTicket = new FormFillTicket(
                        Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[6].Value),
                        nClass,
                        Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value),
                        Convert.ToString(dataGridView1.SelectedRows[0].Cells[2].Value),
                        Convert.ToString(dataGridView1.SelectedRows[0].Cells[3].Value));
                    formFillTicket.ShowDialog();
                }
            }
        }
    }
}
