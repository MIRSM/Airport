using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    //сохраняет билет как картинку
    public class ImageSaver : Saver
    {
        //рефакторинг: 6."Решение задач обобщения" Подъём поля
        //private readonly string DEFAULT_SAVE_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public override void SendData(Ticket ticket)
        {

        }
    }
}
