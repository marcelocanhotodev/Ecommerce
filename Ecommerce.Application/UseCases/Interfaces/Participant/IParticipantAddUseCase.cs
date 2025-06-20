using Ecommerce.Application.Domain;
using Ecommerce.Application.UseCases.Models.Ecommerce.Application.UseCases.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.UseCases.Interfaces.Participant
{
    public interface IParticipantAddUseCase
    {
        Task<ParticipantCreateResponse> ExecuteAsync(ParticipantCreateRequest request, CancellationToken cancellationToken = default);
    }
}