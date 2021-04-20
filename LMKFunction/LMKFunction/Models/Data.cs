namespace LMKFunction.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Data
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Estudiante { get; set; }
        [Required]
        public int Temperatura { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime EventDate { get; set; }
    }
}