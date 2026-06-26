using piedteam_net1_2_hocmienphi.repository.abstraction;

namespace piedteam_net1_2_hocmienphi.repository.entity;

public class User : BaseEntity<Guid>
{
    public Guid Id { get; set; }
    public string FirstName  { get; set; }
    public string LastName  { get; set; }
    public string Email  { get; set; }
    public string Role   { get; set; }
}