using System;
using System.ComponentModel.DataAnnotations;

namespace VSDev.Api.DTOs
{
    public class MainEntityViewModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
