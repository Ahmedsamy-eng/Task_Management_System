using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Assesmant.Models.Entities
{
    public class TeamMember
    {
        [Key]
        public int Member_Id {  get; set; }
        public string Name {  get; set; }
        public string Email {  get; set; }
        public string Role {  get; set; }
        public IEnumerable<Task> tasks { get; set; }
    }
}
