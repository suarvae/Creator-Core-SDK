using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Dtos.Transaction
{
    public class UpdateCampaignRequestDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Item name cant be shorter than 3 characters")]
        [MaxLength (75, ErrorMessage = "Item name cant be over 75 characters")]
        public string campaignTitle {get;set;} = string.Empty;

        [Required]
        [MinLength(2, ErrorMessage = "Description cant be shorter than 3 characters")]
        [MaxLength (750, ErrorMessage = "Description cant be over 75 characters")]
        public string campaignDescription {get;set;} = string.Empty;

        [Required]
        [Range(0, 1000000000)]
        public decimal campaignValue{get;set;} =0;
    }
}