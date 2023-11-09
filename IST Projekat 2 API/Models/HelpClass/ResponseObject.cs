using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IST_Projekat_2_API.Models.HelpClass
{
    public class ResponseObject
    {
        public List<Faktura> requestedElements { get; set; }
        public int totalSizeOfList { get; set; }
    }
}
