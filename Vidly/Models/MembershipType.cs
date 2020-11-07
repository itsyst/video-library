using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Vidly.Models
{
    [Table("MembershipTypes")]
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name{ get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        
        
        // To avoid the magic numbers
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}
