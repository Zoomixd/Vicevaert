using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Contract;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Application.Infrastructure;
using Vicevært.Domain.Entities;

namespace Vicevært.Application.Implementation
{
    public class RekvisitionCommand : IRekvisitionCommand
    {
        
        private readonly IRekvisitionRepository _repository;

        public RekvisitionCommand(IRekvisitionRepository repository)
        {

            _repository = repository;
        }


        async Task IRekvisitionCommand.CreateAsync(RekvisitionCommandDto rekvisitionDto)
        {
            var rekvisition = new Vicevært.Domain.Entities.Rekvisition(rekvisitionDto.RekvisitionType, rekvisitionDto.Kommentar, rekvisitionDto.LejerId);
            await _repository.AddAsync(rekvisition);
        }
    }
}
