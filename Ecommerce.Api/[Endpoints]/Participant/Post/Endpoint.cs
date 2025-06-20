using Ecommerce.Application.UseCases.Interfaces.Participant;
using Ecommerce.Application.UseCases.Models.Ecommerce.Application.UseCases.Models;
using FastEndpoints;

namespace Ecommerce.Api._Endpoints_.Participant.Post
{
    public class Endpoint : Endpoint<ParticipantCreateRequest, ParticipantCreateResponse>
    {
        private readonly IParticipantAddUseCase _participantAddUseCase = default!;

        public Endpoint(IParticipantAddUseCase participantAddUseCase)
        {
            _participantAddUseCase = participantAddUseCase;
        }


        public override void Configure()
        {
            Post("participant");
            AllowAnonymous();
            Summary(s =>
            {
                s.Summary = "Cria um novo participante";
                s.Response<ParticipantCreateResponse>(201, "Participante criado");
            });
        }

        public override async Task HandleAsync(ParticipantCreateRequest req, CancellationToken ct)
        {
            var response = await _participantAddUseCase.ExecuteAsync(req, ct);
            await SendAsync(response, 201);
        }
    }
}