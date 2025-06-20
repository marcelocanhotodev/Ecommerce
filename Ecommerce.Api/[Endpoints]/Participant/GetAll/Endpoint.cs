using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Participant;
using Ecommerce.Application.UseCases.Interfaces.Product;
using Ecommerce.Application.UseCases.Models.Ecommerce.Application.UseCases.Models;
using FastEndpoints;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Api._Endpoints_.Participant.GetAll
{
    public class Endpoint : EndpointWithoutRequest<ParticipantGetAllResponse>
    {
        private readonly IParticipantGetAllUseCase _getAllParticipantsUseCase = default!;

        public Endpoint(IParticipantGetAllUseCase getAllParticipantsUseCase)
        {
            _getAllParticipantsUseCase = getAllParticipantsUseCase ?? throw new ArgumentNullException(nameof(getAllParticipantsUseCase));
        }

        public override void Configure()
        {
            Get("participant");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Lista todos os participantes";
                s.Response<List<ParticipantGetAllResponse>>(200, "Lista de participantes");
            });
        }

        public override async Task HandleAsync(CancellationToken ct)
        {
            var response = await _getAllParticipantsUseCase.ExecuteAsync(ct);
            await SendAsync(response);
        }
    }
}