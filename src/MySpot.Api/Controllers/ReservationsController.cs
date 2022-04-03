using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySpot.Application.Abstractions;
using MySpot.Application.Commands;

namespace MySpot.Api.Controllers;

[ApiController]
[Route("parking-spots")]
public class ReservationsController : ControllerBase
{
    private readonly ICommandHandler<ReserveParkingSpotForVehicle> _reserveParkingSpotsForVehicleHandler;
    private readonly ICommandHandler<ReserveParkingSpotForCleaning> _reserveParkingSpotsForCleaningHandler;
    private readonly ICommandHandler<ChangeReservationLicencePlate> _changeReservationLicencePlateHandler;
    private readonly ICommandHandler<DeleteReservation> _deleteReservationHandler;

    public ReservationsController(ICommandHandler<ReserveParkingSpotForVehicle> reserveParkingSpotsForVehicleHandler,
        ICommandHandler<ReserveParkingSpotForCleaning> reserveParkingSpotsForCleaningHandler,
        ICommandHandler<ChangeReservationLicencePlate> changeReservationLicencePlateHandler,
        ICommandHandler<DeleteReservation> deleteReservationHandler)
    {
        _reserveParkingSpotsForVehicleHandler = reserveParkingSpotsForVehicleHandler;
        _reserveParkingSpotsForCleaningHandler = reserveParkingSpotsForCleaningHandler;
        _changeReservationLicencePlateHandler = changeReservationLicencePlateHandler;
        _deleteReservationHandler = deleteReservationHandler;
    }


    [Authorize]
    [HttpPost("{parkingSpotId:guid}/reservations/vehicle")]
    public async Task<ActionResult> Post(Guid parkingSpotId, ReserveParkingSpotForVehicle command)
    {
        await _reserveParkingSpotsForVehicleHandler.HandleAsync(command with
        {
            ReservationId = Guid.NewGuid(),
            ParkingSpotId = parkingSpotId,
            UserId = Guid.Parse(User.Identity.Name)
        });
        return NoContent();
    }

    [HttpPost("reservations/cleaning")]
    public async Task<ActionResult> Post(ReserveParkingSpotForCleaning command)
    {
        await _reserveParkingSpotsForCleaningHandler.HandleAsync(command);
        return NoContent();
    }

    [HttpPut("reservations/{reservationId:guid}")]
    public async Task<ActionResult> Put(Guid reservationId, ChangeReservationLicencePlate command)
    {
        await _changeReservationLicencePlateHandler.HandleAsync(command with {ReservationId = reservationId});
        return NoContent();
    }

    [HttpDelete("reservations/{reservationId:guid}")]
    public async Task<ActionResult> Delete(Guid reservationId)
    {
        await _deleteReservationHandler.HandleAsync(new DeleteReservation(reservationId));
        return NoContent();
    }
}