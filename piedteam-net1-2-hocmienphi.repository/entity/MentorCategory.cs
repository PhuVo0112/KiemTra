using piedteam_net1_2_hocmienphi.repository.abstraction;

namespace piedteam_net1_2_hocmienphi.repository.entity;

public class MentorCategory : BaseEntity<Guid>
{
    public Mentor Mentor { get; set; }
    public Guid MentorId  { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId  { get; set; }
}