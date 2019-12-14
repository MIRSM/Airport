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

        DataBase DataBase;

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
            DataBase = new DataBase();
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
        public List<string[]> GetInfoAboutTrip(int number, string date1, string date2 = null)
        //public List<string[]> GetData(int number, string date1, string date2 = null)
        {
            return DataBase.GetData(number, date1, date2);
        }

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

        }

        private void cbArrival_DropDown(object sender, EventArgs e)
        {
            UpdateAirportsComboBox(cbArrival);
        }

        private void cbDestination_DropDown(object sender, EventArgs e)
        {
            UpdateAirportsComboBox(cbDestination);
        }
        
        private void UpdateAirportsComboBox(ComboBox comboBox)
        {
            comboBox.Items.Clear();
            var Airports = GetAirports();
            for (int i = 0; i < Airports.Length; i++)
                comboBox.Items.Add(Airports[i]);
        }

        private string[] GetAirports()
        {
            string[] result = new string[1];
            result[0] = "test";
            //sql запрос

            return result;
        }
    }
}
