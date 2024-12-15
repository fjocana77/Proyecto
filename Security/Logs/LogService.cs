using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Logs
{
    public static class LogService
    {
        private static readonly List<AuditLog> Logs = new List<AuditLog>();

        public static void AddLog(string action, string userEmail)
        {
            Logs.Add(new AuditLog
            {
                Action = action,
                UserEmail = userEmail,
                Timestamp = DateTime.Now
            });
        }

        public static IEnumerable<AuditLog> GetLogs()
        {
            return Logs;
        }
    }
}
