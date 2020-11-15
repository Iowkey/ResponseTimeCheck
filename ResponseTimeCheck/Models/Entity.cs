using System;
using System.ComponentModel.DataAnnotations;

namespace ResponseTimeCheck
{
    public class Entity
    {
        [Key]
        public int RequestID { get; set; }
        public TimeSpan RequestTime { get; set; }
        public string ErrorMessage { get; set; }

    }
}
