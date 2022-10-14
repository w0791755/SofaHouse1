using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SofaHouse.Models
{
    public class Sofa
    {
  
            public int Id { get; set; }
            public string type { get; set; }
            public string material { get; set; }
            public string size { get; set; }
            public string theme { get; set; }
            public string availability { get; set; }
            public string price { get; set; }

            [DataType(DataType.Date)]
            public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }

    }
}



