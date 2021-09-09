using System.Collections.Generic;

namespace ODataTopError.Models
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}