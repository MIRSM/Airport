using System.Windows.Forms;

namespace Airport
{
    public class ReservateNotificator : Notificator
    {
        //рефакторинг: 6."Решение задач обобщения" Подъём поля
        //private readonly string Ticket = "Билет";
        public override void Notificate(TypeStatus status)
        {
            if (status == TypeStatus.Bought)
                MessageBox.Show($"{TICKET} куплен");
        }
    }
}
