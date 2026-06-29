using piedteam_net1_2_hocmienphi.repository.abstraction;

namespace piedteam_net1_2_hocmienphi.repository.entity;

public class Mentor : BaseEntity<Guid>
{
    public string JobTitle  { get; set; }
    public string Organize { get; set; }
    
    public User User { get; set; }
    public Guid UserId { get; set; }
    public ICollection<MentorCategory> MentorCategories { get; set; }
}