using System;
using System.Collections.Generic;

namespace Yona.Models
{
    public class DTResult<T>
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public IEnumerable<T> data { get; set; }
    }


    public class DTParameters
    {
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public DTSearch Search { get; set; }
    }

    public class DTSearch
    {
        public string Value { get; set; }
      
    }


}