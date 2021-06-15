using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyAppWithLatestAuth.Models;
using System.ComponentModel.DataAnnotations;
namespace VidlyAppWithLatestAuth.DTOs
{
    public class CustomerDTO
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name.")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        //[Min18YearsIfMember]
        public DateTime? DateOfBirth { get; set; }
    }
}