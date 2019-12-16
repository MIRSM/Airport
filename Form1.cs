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
    public enum SaveType
    {
        PDF = 0,
        IMAGE = 1
    }

    public partial class Form1 : Form
    {
        private const int MAGIC_NUMER_FOR_SMALL_SEARCH = 10;
        /*
         * Класс клиент. Создается при бронировании/покупке. ФИО, паспортные данные
         * Работа приложения. Клиент вводит дату отправления, а также места откуда и куда. 
         * Ему выводится список с данными: дата и время вылета/прилета, место вылета/прилета, стоимость, 
         * время полета (включая время пересадки).
         * клиент может забронировать/купить билет по карте. Нужно ввести данные карты.
         * Можно даже сгенерировать какой нибудь пдф билета
         * добавить комментарии в код
         */

        public static DataBase DataBase;

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            DataBase = new DataBase();
            UpdateAirportsComboBox(cbArrival);
            UpdateAirportsComboBox(cbDestination);
            cbArrival.Select();
        }

        //рефакторинг: 3."Организация данных" Замена магического числа символьной константой
        //магическое число 10
        private void SmallSearch()
        {
            //  for(int i = 0; i < 10; i++)
            for (int i = 0; i < MAGIC_NUMER_FOR_SMALL_SEARCH; i++)
            {
                //тут выполняется небольшой поиск 
                //доступных маршрутов
            }
        }

        //рефакторинг: 5."Упрощение вызовов методов" Переименование метода
        //public List<string[]> GetInfoAboutTrip(int number, string date1, string date2 = null)
        //public List<string[]> GetData(int number, string date1, string date2 = null)
        //{
        //}

        public Ticket BuyBookTicket(string date1, string departure, string arrival,
            string firstName, string lastName, string surName,
            Place place, uint price, string plane, bool bought)
        {
            Ticket ticket = new Ticket(date1, departure, arrival, firstName, lastName, surName, place, price, plane, bought);
            DataBase.SendData(ticket);
            return ticket;
        }

        //рефакторинг: 4."Упрощение условных выражений" Замена условного оператора полиморфизмом,
        //рефакторинг: 2. "Перемещение функций между объектами" Введение внешнего метода
        public void SaveTicket(Ticket ticket, Saver saver)
        {
            saver.SendData(ticket);

            /*Saver saver = null;
            switch (saveType)
            {
                case SaveType.PDF:
                    saver = new PdfSaver();
                    break;
                case SaveType.IMAGE:
                    saver = new ImageSaver();
                    break;
            }
            saver.SendData(ticket);*/
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
            var result=DataBase.GetInfoFromTo(airportFrom, airportTo, nClass, Count, date);
            if (result.Count == 0)
            {
                MessageBox.Show("Поиск не дал результатов");
                return;
            }
            foreach (var r in result)
            {
                //MessageBox.Show(string.Format("{0} {1} {2} {3} {4}", r[0],r[1],r[2],r[3],r[4]));
                var SplitedDate = r[0].Split('.');
                r[0] = string.Format("{0}-{1}-{2}", SplitedDate[1], SplitedDate[0], SplitedDate[2]);
                var splitedDate2 = r[1].Split('.');
                r[1] = string.Format("{0}-{1}-{2}", splitedDate2[1], splitedDate2[0], splitedDate2[2]);
            }
            FormResultOfSearch formResultOfSearch = new FormResultOfSearch(result,nClass);
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
            //sql запрос
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
    }
}
