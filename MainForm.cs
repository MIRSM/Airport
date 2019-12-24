using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Airport
{
    public struct MaxStatistic
    {
        public int MaxCount;
        public string From;
        public string To;
    }

    public partial class MainForm : Form
    {
        private const int MINIMUM_PASSANGERS_COUNT = 1;

        public static MainForm FormHandle;
        //рефакторинг: 3."Организация данных" Замена магического числа символьной константой
        public MainForm()
        {
            InitializeComponent();
            DataBase.InitConnection();
            CenterToScreen();            
            UpdateAirportsComboBox(cbArrival);
            UpdateAirportsComboBox(cbDestination);
            cbArrival.Select();
            //numericUpDown1.Value = 1;
            numericUpDown1.Value = MINIMUM_PASSANGERS_COUNT;
            FormHandle = this;
        }

        protected override void OnClosed(EventArgs e)
        {
            DataBase.CloseConnection();
            base.OnClosed(e);
        }
        //рефакторинг: 5."Упрощение вызовов методов" Переименование метода
        //public List<string[]> GetData(string airportFrom, string airportTo, int nClass, int Count, string date)
        public List<string[]> GetInfoAboutTrip(string airportFrom, string airportTo, int nClass, int Count, string date)
        {
            return DataBase.GetInfoFromTo(airportFrom, airportTo, nClass, Count, date);
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            string airportFrom = cbArrival.Text.ToLower();
            string airportTo = cbDestination.Text.ToLower();
            string date = mTbDate.Text;
            int nClass = 1;
            int Count = (int)numericUpDown1.Value;
            if (string.IsNullOrWhiteSpace(airportFrom))
            {
                MessageBox.Show("Не заполнено поле 'Отправление'");
                return;
            }
            if (string.IsNullOrWhiteSpace(airportTo))
            {
                MessageBox.Show("Не заполнено поле 'Прибытие'");
                return;
            }
            if (!mTbDate.MaskCompleted)
            {
                MessageBox.Show("Некорректно заполнено поле 'Дата'");
                return;
            }
            if (rbFirstClass.Checked)
                nClass = 3;
            else if (rbBuisnesClass.Checked)
                nClass = 2;
            else
                nClass = 1;
            airportFrom = airportFrom.ToUpper()[0] + airportFrom.Substring(1, airportFrom.Length - 1);
            airportTo = airportTo.ToUpper()[0] + airportTo.Substring(1, airportTo.Length - 1);

            var splitedDate =date.Split('.');
            date = string.Format("{0}-{1}-{2}",splitedDate[2],splitedDate[0],splitedDate[1]);
            var result = GetInfoAboutTrip(airportFrom, airportTo, nClass, Count, date);
            if (result.Count == 0)
            {
                MessageBox.Show("Поиск не дал результатов");
                return;
            }
            foreach (var r in result)
            {
                var SplitedDate = r[0].Split('.');
                r[0] = string.Format("{0}-{1}-{2}", SplitedDate[1], SplitedDate[0], SplitedDate[2]);
                var splitedDate2 = r[1].Split('.');
                r[1] = string.Format("{0}-{1}-{2}", splitedDate2[1], splitedDate2[0], splitedDate2[2]);
                r[4] = (Convert.ToInt32(r[4]) - DataBase.GetNotAvailablePlaces(Convert.ToInt32(r[6]), nClass).Count).ToString();
            }
            FormResultOfSearch formResultOfSearch = new FormResultOfSearch(result,nClass,Convert.ToInt32(numericUpDown1.Value));
            Hide();
            formResultOfSearch.ShowDialog();
            Show();
        }

        private void UpdateAirportsComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            var Airports = GetAirports();
            for (int i = 0; i < Airports.Length; i++)
                comboBox.Items.Add(Airports[i]);
            comboBox.AutoCompleteCustomSource = new AutoCompleteStringCollection();
            comboBox.AutoCompleteCustomSource.AddRange(Airports);
        }

        private string[] GetAirports()
        {
            return DataBase.GetAirports().ToArray();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                btSearch_Click(this, new EventArgs());
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtMostPopularRoute_Click(object sender, EventArgs e)
        {
            var result = DataBase.GetMostPopularRoute();
            MessageBox.Show($"Самый популярный маршрут: {result.From}-{result.To}: {result.MaxCount} поездок!");
        }
    }
}
