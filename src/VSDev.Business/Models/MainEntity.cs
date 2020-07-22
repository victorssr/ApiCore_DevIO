using System;

namespace VSDev.Business.Models
{
    public class MainEntity
    {
        protected MainEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
