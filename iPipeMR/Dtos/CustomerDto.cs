using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using iPipeMR.Models;

namespace iPipeMR.Dtos
{
    public class CustomerDto
    {
/*It should be noted that in this DTO, we are not adding any foreign related property such as the Membership type and data annotations have also been removed since they are unnecessary. It shold also be noted
 that we don't include any custom data type. The main purpose of this object is to send information/data between the client and the server*/
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }
        public byte MembershipTypeId { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        
/*
        [Min18YearsIfAMember]
*/
        public DateTime? Birthdate { get; set; }
    }
} 