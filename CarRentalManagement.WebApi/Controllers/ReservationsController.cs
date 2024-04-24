using CarRentalManagement.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarRentalManagement.Application.Features.Mediator.Commands.PricingCommands;
using CarRentalManagement.Application.Features.Mediator.Commands.ReservationCommands;
using CarRentalManagement.Application.Features.Mediator.Commands.ServiceCommands;
using CarRentalManagement.Application.Features.Mediator.Queries.PricingQueries;
using CarRentalManagement.Application.Features.Mediator.Queries.ReservationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalManagement.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateReservation(CreateReservationCommand command)
        {
            await _mediator.Send(command);
            return Ok("rezervasyon başarıyla eklendi.");
        }
        [HttpGet]
        public async Task<IActionResult> ReservationList()
        {
            var values = await _mediator.Send(new GetReservationQuery());
            return Ok(values);
        }
        [HttpGet("GetReservationById")]
        public async Task<IActionResult> GetReservationById(int id)
        {
           var value= await _mediator.Send(new GetReservationByIdQuery(id));
            return Ok(value);
        }

        [HttpGet("ReservationStatusChangeApproved")]
        public async Task<IActionResult> ReservationStatusChangeApproved(int id)
        {
            _mediator.Send(new ReservationStatusChangeApprovedCommand(id));
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("ReservationStatusChangeCancel")]
        public async Task<IActionResult> ReservationStatusChangeCancel(int id)
        {
            _mediator.Send(new ReservationStatusChangeCancelCommand(id));
            return Ok("Güncelleme Yapıldı");
        }
        [HttpGet("ReservationStatusChangeWait")]
        public async Task<IActionResult> ReservationStatusChangeWait(int id)
        {
            _mediator.Send(new ReservationStatusChangeWaitCommand(id));
            return Ok("Güncelleme Yapıldı");
        }

    }
}
