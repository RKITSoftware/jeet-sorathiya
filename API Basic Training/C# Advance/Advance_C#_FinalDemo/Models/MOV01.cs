using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Advance_C__FinalDemo.Models
{
    [Alias("MOV01")]
    public class MOV01
    {
        [AutoIncrement]
        [PrimaryKey]
        public int V01F01 { get; set; }
        public string V01F02 { get; set; }
        public DateTime V01F03 { get; set; }
        [ForeignKey(typeof(CAT01))]
        public int V01F04 { get; set; }
        [ForeignKey(typeof(DIR01))]
        public int V01F05 { get; set; }
    }
}