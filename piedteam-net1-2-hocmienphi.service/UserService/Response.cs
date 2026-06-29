using piedteam_net1_2_hocmienphi.repository.entity;

namespace piedteam_net1_2_hocmienphi.service.UserService;

public class Response
{
    public class GetUsersResponse
    {
        public Guid Id  { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        
    }

    public class GetUserDetailResponse : GetUsersResponse
    {
        public string? JobTitle { get; set; }
        public string? Organization { get; set; }
        public List<CategoryResponse>? Categories { get; set; }
    }
    
    public class CategoryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
    }
}