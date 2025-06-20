using Ecommerce.Application.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases.Interfaces.Participant
{
    public interface IParticipantGetByIdUseCase
    {
        Task<Domain.Participant?> ExecuteAsync(long id, CancellationToken cancellationToken = default);
    }
}