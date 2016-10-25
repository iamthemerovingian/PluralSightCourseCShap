using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class NameChangedEventArgs : EventArgs // this will allow us to derive out class off of the Events args class.
    {
        public string ExistingName { get; set; }
        public string Newname { get; set; }
    }
}
