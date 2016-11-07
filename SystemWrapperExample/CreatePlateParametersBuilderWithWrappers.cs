using System;
using SystemInterface;

namespace SystemWrapperExample
{
    public class CreatePlateParametersBuilderWithWrappers
    {
        private readonly IDateTime _dateTime;

        public CreatePlateParametersBuilderWithWrappers(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public CreatePlateParameters Build(string barcode)
        {
            return new CreatePlateParameters
            {
                Barcode = barcode,
                Active = true,
                CreatedTimestamp = _dateTime.Now.DateTimeInstance,
                CreatedBy = "System"
            };
        }
    }
}