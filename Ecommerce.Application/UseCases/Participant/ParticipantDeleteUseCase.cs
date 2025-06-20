using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Participant;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases.Participant
{
    public class ParticipantDeleteUseCase : IParticipantDeleteUseCase
    {
        private readonly IParticipantRepository _repository;

        public ParticipantDeleteUseCase(IParticipantRepository repository)
        {
            _repository = repository;
        }

        public async Task ExecuteAsync(long id, CancellationToken cancellationToken = default)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }
    }
}