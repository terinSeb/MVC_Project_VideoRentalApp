using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyAppWithLatestAuth.Models;
namespace VidlyAppWithLatestAuth.ViewModals
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipType { get; set; }
        public Customer customer { get; set; }
    }
}