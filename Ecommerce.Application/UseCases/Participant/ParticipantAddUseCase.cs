using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Ecommerce.Application.UseCases.Interfaces.Participant;
using Ecommerce.Application.UseCases.Models.Ecommerce.Application.UseCases.Models;
using Ecommerce.Application.UseCases.Validators;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Ecommerce.Application.UseCases.Participant
{
    public class ParticipantAddUseCase : IParticipantAddUseCase
    {
        private readonly IParticipantRepository _repository;
        private readonly ILogger<ParticipantAddUseCase> _logger;
        private readonly IValidator<Domain.Participant> _participantValidator;

        public ParticipantAddUseCase(IParticipantRepository repository,
                                     ILogger<ParticipantAddUseCase> log,
                                     IValidator<Domain.Participant> participantValidator)
        {
            _repository = repository;
            _logger = log;
            _participantValidator = participantValidator;
        }

        public async Task<ParticipantCreateResponse> ExecuteAsync(ParticipantCreateRequest req, CancellationToken cancellationToken = default)
        {

            try
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

                await _participantValidator.ValidateAndThrowAsync(participant, cancellationToken);

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
            catch (ValidationException vx)
            {
                _logger.LogWarning(vx.Message);
                throw;
            }
            
        }
    }
}