using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Participant;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases.Participant
{
    public class ParticipantGetByIdUseCase : IParticipantGetByIdUseCase
    {
        private readonly IParticipantRepository _repository;

        public ParticipantGetByIdUseCase(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Participant?> ExecuteAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _repository.GetByIdAsync(id, cancellationToken);
        }
    }
}