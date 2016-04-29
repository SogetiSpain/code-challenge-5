namespace CrossCutting.Models
{
    using System.Collections.Generic;

    public class ReserveModel
    {
        public string train_id { get; set; }

        public string booking_reference { get; set; }

        public IEnumerable<string> seats { get; set; }
    }
}
