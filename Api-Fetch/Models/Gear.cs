using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fetch.Models
{

    public class GearRecord
    {
        public string Title { get; set; }
        public List<Result> Result { get; set; }
    }
    public class Result
    { 
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal FinalPrice { get; set; }
        public Image Images { get; set; }
    }
    public class Image
    {
        public string PrimarySmall { get; set; }
        public string PrimaryMedium { get; set; }
    }
  
}
