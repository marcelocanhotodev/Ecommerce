using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Participant;
using Ecommerce.Application.UseCases.Models;
using Ecommerce.Application.UseCases.Models.Ecommerce.Application.UseCases.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases.Participant
{
    public class ParticipantGetAllUseCase : IParticipantGetAllUseCase
    {
        private readonly IParticipantRepository _repository;

        public ParticipantGetAllUseCase(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task<ParticipantGetAllResponse> ExecuteAsync(ParticipantGetAllRequest request, CancellationToken cancellationToken = default)
        {
            var participants = await _repository.GetAllAsync(request.Page,request.PageSize,cancellationToken);
            var participantsCount = await _repository.CountAsync(cancellationToken);

            return new ParticipantGetAllResponse
            {
                Participants = participants.ToList(),
                Total = participantsCount,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
    }
}