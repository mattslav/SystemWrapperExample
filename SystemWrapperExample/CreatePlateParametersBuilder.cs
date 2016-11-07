using System;

namespace SystemWrapperExample
{
    public class CreatePlateParametersBuilder
    {
        public CreatePlateParameters Build(string barcode)
        {
            return new CreatePlateParameters
            {
                Barcode = barcode,
                Active = true,
                CreatedTimestamp = DateTime.Now,
                CreatedBy = "System"
            };
        }
    }
}