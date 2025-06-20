using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases.Interfaces.Participant
{
    public interface IParticipantDeleteUseCase
    {
        Task ExecuteAsync(long id, CancellationToken cancellationToken = default);
    }
}