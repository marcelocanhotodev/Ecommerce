using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Participant;
using Ecommerce.Application.UseCases.Models.Ecommerce.Application.UseCases.Models;

namespace Ecommerce.Application.UseCases.Participant
{
    public class ParticipantAddUseCase : IParticipantAddUseCase
    {
        private readonly IParticipantRepository _repository;

        public ParticipantAddUseCase(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task<ParticipantCreateResponse> ExecuteAsync(ParticipantCreateRequest req, CancellationToken cancellationToken = default)
        {

            // Mapeia o request para a entidade de domínio
            var participant = new Domain.Participant
            {
                name = req.Name,
                email = req.Email,
                document = req.Document ?? string.Empty,
                phone = req.Phone ?? string.Empty,
                createdat = DateTime.UtcNow
            };

            var participantCreated = await _repository.AddAsync(participant, cancellationToken);

            var response = new ParticipantCreateResponse
            {
                Id = participantCreated.id,
                Name = participantCreated.name,
                Email = participantCreated.email,
                Phone = participantCreated.phone,
                CreatedAt = participantCreated.createdat,
                UpdatedAt = participantCreated.updatedat
            };

            return response;
        }
    }
}