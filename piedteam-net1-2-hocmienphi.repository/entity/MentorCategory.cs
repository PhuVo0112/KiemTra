namespace piedteam_net1_2_hocmienphi.repository.entity;

public class MentorCategory
{
    public Guid Id  { get; set; } 
    public Mentor Mentor { get; set; }
    public Guid MentorId  { get; set; }
    public Category Category { get; set; }
    public Guid CategoryId  { get; set; }
}