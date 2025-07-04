﻿using Dapper;
using Dapper.Contrib.Extensions;
using Ecommerce.Application.Domain;
using Ecommerce.Application.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Ecommerce.Infrastructure.Repositories
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ParticipantRepository> _logger;

        public ParticipantRepository(string connectionString, ILogger<ParticipantRepository> logger)
        {
            _connectionString = connectionString.Trim().Trim('"').Trim('\'');
            _logger = logger;
        }

        public async Task<Participant?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                return await conn.GetAsync<Participant>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar participante pelo ID {ParticipantId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Participant>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken = default)
        {
            var sql = @"SELECT * FROM participants
                        ORDER BY id
                        OFFSET @Offset LIMIT @PageSize";
            var parameters = new
            {
                Offset = (pageNumber - 1) * pageSize,
                PageSize = pageSize
            };
            await using var conn = new NpgsqlConnection(_connectionString);
            return await conn.QueryAsync<Participant>(sql, parameters);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            var sql = "SELECT COUNT(*) FROM participants";
            await using var conn = new NpgsqlConnection(_connectionString);
            return await conn.ExecuteScalarAsync<int>(sql);
        }


        public async Task<Participant> AddAsync(Participant participant, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var id = await conn.InsertAsync(participant);
                return await conn.GetAsync<Participant>(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar participante: {@Participant}", participant);
                throw;
            }
        }

        public async Task UpdateAsync(Participant participant, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                await conn.UpdateAsync(participant);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar participante: {@Participant}", participant);
                throw;
            }
        }

        public async Task DeleteAsync(long id, CancellationToken cancellationToken = default)
        {
            try
            {
                await using var conn = new NpgsqlConnection(_connectionString);
                var participant = await conn.GetAsync<Participant>(id);
                if (participant != null)
                    await conn.DeleteAsync(participant);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar participante com ID {ParticipantId}", id);
                throw;
            }
        }
    }
}