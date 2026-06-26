using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using piedteam_net1_2_hocmienphi.repository;
using piedteam_net1_2_hocmienphi.repository.entity;
using piedteam_net1_2_hocmienphi.service.UserService;

namespace piedteam_net1_2_hocmienphi.api.Controllers;

[ApiController] 
[Route("/api/[controller]")]
public class usersController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    private usersController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        
    }
    
    [HttpPost("")]
    public IActionResult AddNewUser(Request.AddNewUser request)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            FirstName = request.firstName,
            LastName = request.lastName,
            Email = request.email,
            Role = "user",
            IsDeleted = false
        };
        
        _dbContext.Add(user);
        _dbContext.SaveChanges();
        
        return Ok("User created successfully!!");
    }

    [HttpGet("")]
    public IActionResult GetAllUsers(
            int page, 
            int pagesize, 
            string? role, 
            string? searchTerm 
    )
    {

        var query = _dbContext.Users.Where(u => u.IsDeleted == false);
        query = query.Skip((page - 1) * pagesize).Take(pagesize);
        if (searchTerm != null)
        {
            query = query.Where(u => 
                u.FirstName.Contains(searchTerm) || 
                u.LastName.Contains(searchTerm) || 
                u.Email.Contains(searchTerm));
            var seleteQuery = query.ToList();
            return Ok(seleteQuery);
        }

        return Ok("");
    }
}