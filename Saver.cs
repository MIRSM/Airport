using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport
{
    public abstract class Saver : ISender
    {

        public virtual void SendData(Ticket ticket)
        {

        }
    }
}
