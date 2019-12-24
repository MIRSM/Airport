using System.Windows.Forms;

namespace Airport
{
    class NotificatorWithTicket : Notificator, INotificatorWithAdditionalInfo
    {
        public override void Notificate(TypeStatus status)
        {
            if (status == TypeStatus.Bought)
                MessageBox.Show($"{TICKET} куплен");
        }

        public void NotificateWithTicket(TypeStatus status, string FIO, string AirportFrom, string AirportTo, int Class, int Count, string date, int Price)
        {
            if (status == TypeStatus.Bought)
                MessageBox.Show($"{TICKET} куплен. Полная информация:\n ФИО: {FIO}\nОтправление: {AirportFrom}\nПрибытие: {AirportTo}\nДата: {date}\nКласс: {Class}\nМесто: {Count}\nЦена: {Price}\nСтатус: {status}");
        }

    }
}
