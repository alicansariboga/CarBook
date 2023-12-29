using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AboutDtos
{
    public class ResultAboutDto
    {
        // paste special paste (json format) from api
            
        public int aboutID { get; set; }
        public string title { get; set; }
        public string decription { get; set; }
        public string imageUrl { get; set; }
    
    }
}
