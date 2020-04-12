using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("/api/authorCollections")]
    public class AuthorCollectionsController : ControllerBase
    {
        ICourseLibraryRepository _courseLibraryRepository;
        IMapper _mapper;
        public AuthorCollectionsController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<IEnumerable<AuthorDto>> CreateAuthorsCollection(IEnumerable<AuthorForCreateDto> authors)
        {
            var authorsEntity = _mapper.Map<IEnumerable<Entities.Author>>(authors);
            foreach (var item in authorsEntity)
            {
                _courseLibraryRepository.AddAuthor(item);
            }
            _courseLibraryRepository.Save();

            return Ok();
        }
    }
}