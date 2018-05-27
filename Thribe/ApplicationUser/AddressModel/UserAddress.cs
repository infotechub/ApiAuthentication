using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Thribe.ApplicationUser.UserModel;

namespace Thribe.ApplicationUser.AddressModel
{
    public class UserAddress
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public User UserId { get; set; }  // navigation property
        public long AddressTypeId { get; set; }
        public string AddressType { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostCode { get; set; }
        public DateTime Date { get; set; }


    }
}
