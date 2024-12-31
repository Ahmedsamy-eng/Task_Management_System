using Assesmant.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Task = Assesmant.Models.Entities.Task;


namespace Assesmant.Models
{
    public class ProjectViewModel
    {
        [Key]
        public int Task_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priorty { get; set; }
        public DateTime DeadLine { get; set; }

        public int Pro_ID {  get; set; }
        [ForeignKey("Pro_ID")]

        public IEnumerable<Project> ProjectList { get; set; }

        public int TeamMember_ID {  get; set; }
        [ForeignKey("TeamMember_ID")]
        public IEnumerable<TeamMember> TeamList { get; set; }


    }
}
