using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Logs
{
    public class AuditLog
    {
        public string Action { get; set; }
        public string UserEmail { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
