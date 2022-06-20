using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trackingApi.Data;
using trackingApi.Models;
//a controller is a class that inherits from ControllerBase and contains Action which will which will process the request
//it provides properties and methods to help manage HTTP requests

namespace trackingApi.Controllers
{//you can change the behaviors of a controller an action methods by using attributes that come from Microsoft.AspNetCore.MVC; namespace
    [Route("api/[controller]")] //Route attribute allows mapping requests to action methods. It can be applied at the Controller level or at the action level
    [ApiController] //attribute used to apply common conventions to your controller like automatic validation of the model, binding requests data to the model, etc. 
    public class IssueController : ControllerBase
    {
        private readonly IssueDbContext _context;
        public IssueController(IssueDbContext context) => _context = context;


        //create an action method that will be mapped to HTTP method GET to get a list of issues 
        //the method returns an IEnumerable<Issue>
        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
        {
            return await _context.Issues.ToListAsync();
            
        }

        //create an action method to return specific issue 
        [HttpGet("id")]
        [ProducesResponseType(typeof(Issue), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _context.Issues.FindAsync(id);
            return issue == null ? NotFound() : Ok(issue);
        }

        //add a method for creating a new Issue 
        //the method returns an IactionResult
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _context.Issues.AddAsync(issue);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = issue.Id }, issue);
            //CreatedAtAction returns reponse with status code and the location. It takes 3 parameters
            //action that returns single issue GetById
            //the Id of the issue as an anonymous object
            //the issue itself
        }

        //add action method for updating an issue 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Issue issue)
        {
            if(id != issue.Id) return BadRequest();

            _context.Entry(issue).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        //add method for Deleting an Issue
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var issueToDelete = await _context.Issues.FindAsync(id);
            if (issueToDelete == null) return NotFound();

            _context.Issues.Remove(issueToDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
