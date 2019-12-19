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
    public enum TypeStatus
    {
        Reservated = 1,
        Bought = 2,
        Returned = 3,
        Enabled = 4
    }

    public partial class FormFillTicket : Form
    {
        int RouteSectionId;
        int TypeSeatId;
        int SeatNumber;
        string Fio;

        public FormFillTicket(int route_section_id, int nClass,string Date, string AirportFrom,string AirportTo)
        {
            InitializeComponent();
            CenterToScreen();
            RouteSectionId = route_section_id;
            TypeSeatId = nClass;

            lPrice.Text = Form1.DataBase.GetPrice(route_section_id, nClass);
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
        }

        private void BtBuy_Click(object sender, EventArgs e)
        {
            FillParams();
            Form1.DataBase.AddUserWithTicket(Fio, SeatNumber, TypeSeatId, RouteSectionId, (int)TypeStatus.Bought);
            BtUpdateInfo_Click(this, new EventArgs());
            tbLastName.Enabled = tbName.Enabled = tbSurname.Enabled = cbPlace.Enabled = false;
        }

        private void BtReservate_Click(object sender, EventArgs e)
        {
            FillParams();
            Form1.DataBase.AddUserWithTicket(Fio, SeatNumber, TypeSeatId, RouteSectionId, (int)TypeStatus.Reservated);
            BtUpdateInfo_Click(this, new EventArgs());
            tbLastName.Enabled = tbName.Enabled = tbSurname.Enabled = cbPlace.Enabled = false;
        }

        private bool FillParams()
        {
            if (!CheckControlsForFilling())
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }
            tbSurname.Text = tbSurname.Text.ToLower();
            tbSurname.Text = $"{tbSurname.Text[0].ToString().ToUpper()}{tbSurname.Text.Substring(1)}";
            tbName.Text = tbName.Text.ToLower();
            tbName.Text = $"{tbName.Text[0].ToString().ToUpper()}{tbName.Text.Substring(1)}";
            tbLastName.Text = tbLastName.Text.ToLower();
            tbLastName.Text = $"{tbLastName.Text[0].ToString().ToUpper()}{tbLastName.Text.Substring(1)}";
            Fio = $"{tbSurname.Text} {tbName.Text} {tbLastName.Text}";
            SeatNumber = Convert.ToInt32(cbPlace.Text);
            return true;
        }

        private bool CheckControlsForFilling()
        {
            if (string.IsNullOrWhiteSpace(tbSurname.Text) || string.IsNullOrWhiteSpace(tbName.Text) ||
                string.IsNullOrWhiteSpace(cbPlace.Text))
                return false;
            return true;
        }

        private void BtUpdateInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbSurname.Text) || string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            tbSurname.Text = tbSurname.Text.ToLower();
            tbSurname.Text = $"{tbSurname.Text[0].ToString().ToUpper()}{tbSurname.Text.Substring(1)}";
            tbName.Text = tbName.Text.ToLower();
            tbName.Text = $"{tbName.Text[0].ToString().ToUpper()}{tbName.Text.Substring(1)}";
            tbLastName.Text = tbLastName.Text.ToLower();
            tbLastName.Text = $"{tbLastName.Text[0].ToString().ToUpper()}{tbLastName.Text.Substring(1)}";
            Fio = $"{tbSurname.Text} {tbName.Text} {tbLastName.Text}";
            var result = Form1.DataBase.CheckClientForTicket(Fio, RouteSectionId);
            switch (result)
            {
                case 0:
                    btBuy.Enabled = true;
                    btReservate.Enabled = true;
                    btReturn.Enabled = false;
                    break;
                case 1:
                    btBuy.Enabled = true;
                    btReservate.Enabled = false;
                    btReturn.Enabled = true;
                    break;
                case 2:
                    btBuy.Enabled = false;
                    btReservate.Enabled = false;
                    btReturn.Enabled = true;
                    break;
            }
            if (btReturn.Enabled)
            {
                cbPlace.Items.Clear();
                SeatNumber = Form1.DataBase.GetPlace(Fio, RouteSectionId);
                cbPlace.Items.Add(SeatNumber);
                cbPlace.Text = SeatNumber.ToString();
            }
            else
            {
                var ListOfNotAvailablePlaces = Form1.DataBase.GetNotAvailablePlaces(RouteSectionId, TypeSeatId);
                var FirstindexOfPlace = TypeSeatId == 1 ? Form1.DataBase.GetFirstSeatIndex(RouteSectionId, TypeSeatId) + 1 : 1;
                var NumberOfSeats = Form1.DataBase.GetNumberOfSeats(RouteSectionId, TypeSeatId);
                for (int i = FirstindexOfPlace; i <= NumberOfSeats; i++)
                {
                    if (ListOfNotAvailablePlaces.Contains(i))
                        continue;
                    cbPlace.Items.Add(i);
                }
            }

        }
        
        private void BtReturn_Click(object sender, EventArgs e)
        {
            Form1.DataBase.ReturnTicket(Fio, RouteSectionId);
            tbLastName.Enabled = tbName.Enabled = tbSurname.Enabled = false;
            BtUpdateInfo_Click(this, new EventArgs());
        }
    }
}
