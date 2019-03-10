using System;
using System.ComponentModel.DataAnnotations;

namespace Ddp.Web.Api.Concepts
{
    public class AddConceptRequest
    {
        [Required]
        public Guid ConceptId { get; set; }

        [Required]
        public Guid DomainId { get; set; }
        [Required]
        public string Name { get; set;}
        public string Description { get; set; }
    }
}