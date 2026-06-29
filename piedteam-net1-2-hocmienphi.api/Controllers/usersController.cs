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

    public usersController(AppDbContext dbContext)
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
            int page = 1, 
            int pagesize = 10, 
            string? role = null, 
            string? searchTerm = null 
    )
    {

        var query = _dbContext.Users.Where(u => u.IsDeleted == false);

        if (!string.IsNullOrEmpty(role))
        {
            query = query.Where(u => u.Role.Contains(role));
        }

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(u => u.Role == role);
        }
        
        var users = query
            .Skip((page - 1) * pagesize)
            .Take(pagesize)
            .Select(u => new Response.GetUsersResponse(){
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Role = u.Role
            });
            var seleteQuery = users.ToList();
            return Ok(seleteQuery);
    }

    [HttpGet("{id}")]
    public IActionResult GetUserDetails(Guid id)
    {
        var query = _dbContext.Users.Where(x => x.IsDeleted == false);
        
        query = query.Where(u => u.Id == id);

        var seletedQuery = query.Select(x => new Response.GetUserDetailResponse()
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Role = x.Role,
            JobTitle = x.Mentor!.JobTitle,
            Organization = x.Mentor!.Organize,
            Categories = x.Mentor.MentorCategories
                .Select(mc => new Response.CategoryResponse()
                {
                    Id = mc.CategoryId,
                    Name = mc.Category.Name
                }).ToList()
        });
        
        var result = seletedQuery.FirstOrDefault();
        
        return Ok(result);
    }
}