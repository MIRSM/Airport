using System.Windows.Forms;

namespace Airport
{
    public class Notificator : INotificator
    {

        //рефакторинг: 6."Решение задач обобщения" Подъём поля
        internal readonly string TICKET = "Билет";

        public virtual void Notificate(TypeStatus status)
        {
            MessageBox.Show($"Были произведены действия с {TICKET}ом");
        }
    }
}
