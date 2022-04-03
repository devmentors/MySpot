using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities;

public class VehicleReservation : Reservation
{
    public UserId UserId { get; private set; }
    public EmployeeName EmployeeName { get; private set; }
    public LicencePlate LicencePlate { get; private set; }

    private VehicleReservation()
    {
    }

    public VehicleReservation(ReservationId reservationId, UserId userId, EmployeeName employeeName,
        LicencePlate licencePlate, Capacity capacity, Date date) : base(reservationId, capacity, date)
    {
        UserId = userId;
        EmployeeName = employeeName;
        LicencePlate = licencePlate;
    }

    public void ChangeLicencePlate(LicencePlate licencePlate)
        => LicencePlate = licencePlate;
}