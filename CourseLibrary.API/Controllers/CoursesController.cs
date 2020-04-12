using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseLibrary.API.Models;
using CourseLibrary.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CourseLibrary.API.Controllers
{
    [ApiController]
    [Route("/api/authors/{authorId}/courses")]
    public class CoursesController : ControllerBase
    {
        private ICourseLibraryRepository _courseLibraryRepository;
        private IMapper _mapper;
        public CoursesController(ICourseLibraryRepository courseLibraryRepository, IMapper mapper)
        {
            _courseLibraryRepository = courseLibraryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CourseDto>> GetCoursesByAuthorId(Guid authorId)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courses = _courseLibraryRepository.GetCourses(authorId);

            return Ok(_mapper.Map<IEnumerable<CourseDto>>(courses));
        }

        [HttpGet("{courseId}", Name = "GetCoursesForAuthor")]
        public ActionResult<CourseDto> GetCourseByAuthorId(Guid authorId, Guid courseId)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var course = _courseLibraryRepository.GetCourse(authorId, courseId);

            return Ok(_mapper.Map<CourseDto>(course));
        }

        [HttpPost]
        public ActionResult<CourseDto> CreateCourseForAuthor(Guid authorId, CourseForCreateDto courseDto)
        {
            if (!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courseEntity = _mapper.Map<Entities.Course>(courseDto);
            _courseLibraryRepository.AddCourse(authorId, courseEntity);
            _courseLibraryRepository.Save();

            var cource = _mapper.Map<CourseDto>(courseEntity);
            return CreatedAtRoute("GetCoursesForAuthor",
                new { authorId = authorId, courceId = courseEntity.Id }, cource);
        }

        [HttpPatch("{courseId}")]
        public IActionResult UpdateCourceForPartialUpdate(Guid authorId, Guid courseId,
            [FromBody]JsonPatchDocument<CourseForUpdateDto> patchDocument)
        {
            if(!_courseLibraryRepository.AuthorExists(authorId))
            {
                return NotFound();
            }

            var courceFromRepo = _courseLibraryRepository.GetCourse(authorId, courseId);
            if(courceFromRepo == null)
            {
                //Upsert
                var courseDto = new CourseForUpdateDto();
                patchDocument.ApplyTo(courseDto);

                var courseToAdd = _mapper.Map<Entities.Course>(courseDto);
                courseToAdd.Id = courseId;

                _courseLibraryRepository.AddCourse(authorId, courseToAdd);
                _courseLibraryRepository.Save();

                var course = _mapper.Map<CourseForUpdateDto>(courseToAdd);

                return CreatedAtRoute("GetCoursesForAuthor", new
                {
                    authorId,
                    courseId = courseToAdd.Id
                }, course);
            }

            var courseToPatch = _mapper.Map<CourseForUpdateDto>(courceFromRepo);
            patchDocument.ApplyTo(courseToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(courseToPatch, courceFromRepo);

            _courseLibraryRepository.UpdateCourse(courceFromRepo);
            _courseLibraryRepository.Save();

            return NoContent();
        }
    }
}