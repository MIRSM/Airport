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
            DataBase = new DataBase();
        }

        public List<string[]> GetData(int number, string date1, string date2 = null)
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

        public void SaveTicket(Ticket ticket, SaveType saveType)
        {
            Saver saver = null;
            switch (saveType)
            {
                case SaveType.PDF:
                    saver = new PdfSaver();
                    break;
                case SaveType.IMAGE:
                    saver = new ImageSaver();
                    break;
            }
            saver.SendData(ticket);
        }
    }
}
