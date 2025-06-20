using System;

namespace Ecommerce.Application.UseCases.Models
{
    namespace Ecommerce.Application.UseCases.Models
    {
        public class ParticipantCreateRequest
        {
            public string Name { get; set; } = default!;
            public string Email { get; set; } = default!;
            public string Document { get; set; } = default!;
            public string? Phone { get; set; }
        }

        public class ParticipantCreateResponse
        {
            public long Id { get; set; }
            public string Name { get; set; } = default!;
            public string Document { get; set; } = default!;
            public string Email { get; set; } = default!;
            public string? Phone { get; set; }
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            public DateTime? UpdatedAt { get; set; }
        }

        public class ParticipantGetAllResponse
        {
            public List<Domain.Participant> Participants { get; set; } = new List<Domain.Participant>();
        }
    }
}
