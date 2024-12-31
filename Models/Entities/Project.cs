﻿using System.ComponentModel.DataAnnotations;

namespace Assesmant.Models.Entities
{
    public class Project
    {
        [Key]
        public int Project_Id {  get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<Task> tasks { get; set; }
    }
}
