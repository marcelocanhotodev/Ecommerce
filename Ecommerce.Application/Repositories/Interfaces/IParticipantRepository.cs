using Ecommerce.Application.Domain;

namespace Ecommerce.Application.Repositories.Interfaces
{
    public interface IParticipantRepository
    {
        Task<Participant?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Participant>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<Participant> AddAsync(Participant participant, CancellationToken cancellationToken = default);
        Task UpdateAsync(Participant participant, CancellationToken cancellationToken = default);
        Task DeleteAsync(long id, CancellationToken cancellationToken = default);
    }
}