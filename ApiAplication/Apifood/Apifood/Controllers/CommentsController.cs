﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Apifood.Database;
using Apifood.Models;

namespace Apifood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly DemoDbContext _context;

        public CommentsController(DemoDbContext context)
        {
            _context = context;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            return await _context.Comments.ToListAsync();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        [HttpGet("comments")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetcommentsFood([FromQuery] string foodid)
        {

            var tmp = int.Parse(foodid);
            var data = from p in _context.Comments
                       where (p.foodid == tmp)
                       select (p);
            return await data.ToListAsync();
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComment(int id, Comment comment)
        {
            if (id != comment.commentid)
            {
                return BadRequest();
            }

            _context.Entry(comment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentExists(id))
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

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754


        [HttpPost]
        public async Task<ActionResult<Comment>> Addfood([FromBody] ConmentModel Model)
        {
            if (ModelState.IsValid)
            {
                var Comment = new Comment()
                {

                    foodid = Model.foodid,
                    foodname = Model.foodname,
                    customername = Model.customername,
                    commentDescriptions = Model.commentDescriptions
             
                };

                _context.Comments.Add(Comment);
                await _context.SaveChangesAsync();
                return Ok(Comment);
            }

            return BadRequest(ModelState.Values);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.commentid == id);
        }
    }
}
