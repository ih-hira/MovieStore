using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieStore.DTO
{
    public class MembershipTypeDTO
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }
        [StringLength(120)]
        public string Name { get; set; }
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}