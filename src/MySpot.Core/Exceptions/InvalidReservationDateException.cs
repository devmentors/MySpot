namespace MySpot.Core.Exceptions;

public sealed class InvalidReservationDateException : CustomException
{
    public DateTime Date { get; }

    public InvalidReservationDateException(DateTime date) 
        : base($"Reservation date: {date:d} is invalid.")
    {
        Date = date;
    }
}