﻿using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Interfaces;
using Service.Interfaces;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public AuthorService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public AuthorDto CreateAuthor(AuthorForCreationDto author)
        {
            var authorEntity = _mapper.Map<Author>(author);

            _repository.Author.CreateAuthor(authorEntity);
            _repository.Save();

            var authorToReturn = _mapper.Map<AuthorDto>(authorEntity);
            return authorToReturn;
        }

        public IEnumerable<AuthorDto> GetAllAuthors(bool trackChanges)
        {
            var authors = _repository.Author.GetAllAuthors(trackChanges);
            
            var authersDto=_mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authersDto;
        }

        public AuthorDto GetAuthor(Guid authorId, bool trackChanges)
        {
            var author = _repository.Author.GetAuthor(authorId,trackChanges);
            if (author is null)
            {
                throw new AuthorNotFoundExeption(authorId);
            }

            var authorDto = _mapper.Map<AuthorDto>(author);
            return authorDto;
        }
    }
}
