using System.Windows.Forms;

namespace Airport
{
    class BuyingNotificator : Notificator
    {
        public override void Notificate(TypeStatus status)
        {
            if (status == TypeStatus.Bought)
                MessageBox.Show($"{TICKET} куплен");
        }

        //рефакторинг: 6."Решение задач обобщения" Подъём поля
        //private readonly string TICKET = "Билет";

    }
}
