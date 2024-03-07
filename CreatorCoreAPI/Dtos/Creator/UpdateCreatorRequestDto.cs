using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Dtos.Creator
{
    public class UpdateCreatorRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Creator name cant be shorter than 2 characters")]
        [MaxLength (75, ErrorMessage = "Creator name cant be over 75 characters")]
        public string creatorName{get;set;} = string.Empty;  

        [Required]
        [Range(0.0f, 100.0f)]    
        public float creatorRevenueSplit {get; set;}

        [Required]
        [Range(0.0f, 100000000000.0f)] 
        public decimal creatorRevenue{get;set;}
        
        [Required]
        [Range(0, 1000000000000)]
        public long lifeTimeEarnings{get;set;}
    }
}