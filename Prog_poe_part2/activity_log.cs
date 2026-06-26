using Google.Protobuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_poe_part2
{//start of namespace
    public class log_entry 
    {
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }        
    }
    public class activity_log
    {
        //start of fields
        private List<log_entry> entries;
        private int max_entries;

        public activity_log()
        {
            entries = new List<log_entry>();
            max_entries = 50;
        }

        //start of method
        public void log(string message)
        {
            try
            {
                entries.Insert(0, new log_entry
                {
                    Message = message,
                    Timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log error:" + ex.Message);
            }
        }//end od method

        //start of method
        public List<log_entry> get_recent(int count = 10)
        {
            try
            {
                int take = Math.Min(count, entries.Count);
                return entries.GetRange(0, take);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Log error:" + ex.Message);
                return new List<log_entry>();
            }
        }
        public void clear_log()
        {
            entries.Clear();
        }
    }
}
