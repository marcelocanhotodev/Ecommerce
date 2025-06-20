using Ecommerce.Application.UseCases.Models.Ecommerce.Application.UseCases.Models;

namespace Ecommerce.Application.UseCases.Interfaces.Participant
{
    public interface IParticipantGetAllUseCase
    {
        Task<ParticipantGetAllResponse> ExecuteAsync(CancellationToken cancellationToken = default);
    }
}