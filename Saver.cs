using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public abstract class Saver : ISender
    {

        //рефакторинг: 6."Решение задач обобщения" Подъём поля
        private readonly string DEFAULT_SAVE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public virtual void SendData(Ticket ticket)
        {

        }
    }
}
