using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Books.Models;
using Books.Dto;
using AutoMapper;
using Serilog;
using StanAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Books.Interfaces;
using AutoMapper.QueryableExtensions;
using Microsoft.Extensions.Logging;

namespace Books.Controllers
{
    //[Authorize]
    public class AuthorController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorController> _logger;


        public AuthorController(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AuthorController> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Author

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetAuthorDto>>> GetAll()
        {
            try
            {
                var AuthorInfo = _unitOfWork.Authors.GetAll();
                _logger.LogInformation($"Returned all authors from database");
                return Ok(AuthorInfo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAll action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name = "AuthorById")]
        public async Task<IActionResult> GetAuthorById(int id)
        {
            try
            {

                var author = await _unitOfWork.Authors.GetAuthorsById(id);
                if (author == null)
                {
                    _logger.LogError($"Author with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"Returned Author for id: {id}");
                    var authorResult = _mapper.Map<AuthorDto>(author);
                    return Ok(authorResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAuthorId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]

        public async Task<ActionResult> AddAuthor(AddAuthorDto addAuthorDto)
        {
            try
            {
                if (addAuthorDto == null)
                {
                    _logger.LogError("Author object sent from client is null.");
                    return BadRequest("Author object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid author object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var author = new Author
                {
                    AuthorName = addAuthorDto.AuthorName,
                    AuthorBirthYear = addAuthorDto.AuthorBirthYear
                };

                _unitOfWork.Authors.Add(author);
                _unitOfWork.Complete();

                return Ok(author);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside AddAuthor action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            try
            {
                var author = await _unitOfWork.Authors.GetAuthorsById(id);
                if (author == null)
                {
                    _logger.LogError($"Author with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                _unitOfWork.Authors.DeleteAuthor(author);

                _unitOfWork.Complete();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteAuthor action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorUpdateDto author)
        {
            try
            {
                if (author == null)
                {
                    _logger.LogError("Author object sent from client is null.");
                    return BadRequest("Author object is null");
                }

                var authorEntity = await _unitOfWork.Authors.GetAuthorsById(id);
                if (authorEntity == null)
                {
                    _logger.LogError($"Author with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                _mapper.Map(author, authorEntity);
                _unitOfWork.Authors.UpdateAuthor(authorEntity);
                _unitOfWork.Complete();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateAuthor action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}

        


        //// GET: api/Author/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<AuthorDto>> GetAuthor(int id)
        //{
        //    try
        //    {
        //        var authors = await _authorRepository.GetAuthorByIdAsync(id);
        //        var mappedEntities = _mapper.Map<Author, AuthorDto>(authors);
        //        if (mappedEntities == null) { return NotFound();}
        //        return mappedEntities;
        //    }
        //    catch(Exception)
        //    {

        //        return BadRequest("rrgvr");
        //    }
        //}

        // PUT: api/Author/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAuthor(int id, Author author)
        //{
        //    if (id != author.AuthorId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(author).State = EntityState.Modified;

        //    try 
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AuthorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Author>> AddAuthor(AuthorDto authorInfoDto)
        //{
        //    try
        //    {
        //        var authorInfo = _mapper.Map<AuthorDto, Author>(authorInfoDto);
        //        _unitOfWork.Authors.Add(authorInfo);
        //        _unitOfWork.Complete();

        //        return CreatedAtAction("GetAuthor", new { id = authorInfo.AuthorId }, authorInfo);
        //    }
        //    catch
        //    {
        //        return BadRequest();
        //    }
        //}
        // DELETE: api/Author/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAuthor(int id)
        //{
        //    var author = await _context.AuthorInfo.FindAsync(id);
        //    if (author == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.AuthorInfo.Remove(author);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AuthorExists(int id)
        //{
        //    return _context.AuthorInfo.Any(e => e.AuthorId == id);
        //}
    
