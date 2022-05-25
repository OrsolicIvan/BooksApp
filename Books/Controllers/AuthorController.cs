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

namespace Books.Controllers
{
    //[Authorize]
    public class AuthorController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public AuthorController(IUnitOfWork unitOfWork, IMapper mapper, DataContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/Author

        [HttpGet]
        public IActionResult GetAllAuthors([FromQuery]int count)
        {
            var authors = _unitOfWork.Authors.GetAllAuthors(count);
            return Ok(authors);
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
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, Author author)
        {
            if (id != author.AuthorId)
            {
                return BadRequest();
            }

            _context.Entry(author).State = EntityState.Modified;

            try 
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Author
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Author>> AddAuthor(AuthorDto authorInfoDto)
        {
            try
            {
                var authorInfo = _mapper.Map<AuthorDto, Author>(authorInfoDto);
                _unitOfWork.Authors.Add(authorInfo);
                _unitOfWork.Complete();

                return CreatedAtAction("GetAuthor", new { id = authorInfo.AuthorId }, authorInfo);
            }
            catch
            {
                return BadRequest();
            }
        }
        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _context.AuthorInfo.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            _context.AuthorInfo.Remove(author);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _context.AuthorInfo.Any(e => e.AuthorId == id);
        }
    }
}
