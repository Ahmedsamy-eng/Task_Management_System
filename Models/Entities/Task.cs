using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assesmant.Models.Entities
{
    public class Task
    {
        [Key] 
        public int Task_Id {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string Status {  get; set; }
        public string Priorty {  get; set; }
        public DateTime DeadLine { get; set; }

        public int Pro_Id {  get; set; }
        [ForeignKey("Pro_Id")]
        public Project project { get; set; }

        public int Mem_ID {  get; set; }
        [ForeignKey("Mem_ID")]
        public TeamMember team_member { get; set; }
    }
}
