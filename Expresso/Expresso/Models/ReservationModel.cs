using System;
using System.Collections.Generic;
using System.Text;
using PropertyChanged;

namespace Expresso.Models
{
    [AddINotifyPropertyChangedInterface]
    class ReservationModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TotalPeople { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public TimeSpan Time { get; set; } = DateTime.Now.TimeOfDay;
    }
}
