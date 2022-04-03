using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities;

public abstract class Reservation
{
    public ReservationId Id { get; }
    public Capacity Capacity { get; private set; }
    public Date Date { get; private set; }

    protected Reservation()
    {
    }

    protected Reservation(ReservationId id, Capacity capacity, Date date)
    {
        Id = id;
        Capacity = capacity;
        Date = date;
    }
}