using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorCoreAPI.Dtos.Transaction
{
    public class CreateCampaignDto
    {
        [Required]
        [MinLength(2, ErrorMessage = "Item name cant be shorter than 3 characters")]
        [MaxLength (75, ErrorMessage = "Item name cant be over 75 characters")]
        public string CampaignTitle {get;set;} = string.Empty;

        [Required]
        [MinLength(2, ErrorMessage = "Campaign description cant be shorter than 3 characters")]
        [MaxLength (750, ErrorMessage = "Campaign description cant be over 500 characters")]
        public string CampaignDescription {get;set;} = string.Empty;
        

        [Required]
        [Range(0, 1000000000)]
        public decimal campaignValue{get;set;}
    }
}