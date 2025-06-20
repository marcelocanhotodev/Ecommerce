using Ecommerce.Application.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases.Interfaces.Participant
{
    public interface IParticipantUpdateUseCase
    {
        Task ExecuteAsync(Domain.Participant participant, CancellationToken cancellationToken = default);
    }
}