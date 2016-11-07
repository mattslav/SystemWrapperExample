using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemWrapperExample
{
    public class PlateCreator
    {
        public void Create(CreatePlateParameters createPlateParameters)
        {
            Console.WriteLine("Plate Created");
        }
    }

    public class CreatePlateParameters
    {
        public string Barcode { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedTimestamp { set; get; }
        public string CreatedBy { get; set; }
    }
}
