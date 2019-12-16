using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airport
{
    public partial class FormFillTicket : Form
    {
        public FormFillTicket(int route_section_id, int nClass,string Date, string AirportFrom,string AirportTo)
        {
            InitializeComponent();
            lDate.Text = Date;
            lArrival.Text = AirportFrom;
            lDestination.Text = AirportTo;
            switch (nClass)
            {
                case 1:
                    lClass.Text = "Эконом";
                    break;
                case 2:
                    lClass.Text = "Бизнес";
                    break;
                case 3:
                    lClass.Text = "Первый";
                    break;
            }
            lPrice.Text=Form1.DataBase.GetPrice(route_section_id, nClass);
        }

        private void BtBuy_Click(object sender, EventArgs e)
        {

        }

        private void BtReservate_Click(object sender, EventArgs e)
        {

        }
    }
}
