namespace Airport
{
    public interface INotificatorWithAdditionalInfo
    {
        void NotificateWithTicket(TypeStatus status, string FIO, string AirportFrom, string AirportTo, int Class, int Count, string date, int Price);
    }
}
