using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Participant;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases.Participant
{
    public class ParticipantUpdateUseCase : IParticipantUpdateUseCase
    {
        private readonly IParticipantRepository _repository;

        public ParticipantUpdateUseCase(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(Domain.Participant participant, CancellationToken cancellationToken = default)
        {
            await _repository.UpdateAsync(participant, cancellationToken);
        }
    }
}