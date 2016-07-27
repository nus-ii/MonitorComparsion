using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonitorItem;

namespace MonitorComparsion
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Monitor> mList = new List<Monitor>();
            for (;;)
            {
                if (mList.Count >= 1)
                    SaveListToCSV(mList, "MonitorComparsion.CSV");
                   
                PrintMonitorList(mList);
                InputMonitorList(mList);
            }
        }

        private static void SaveListToCSV(List<Monitor> mList, string v)
        {
            string result = Monitor.GetCSVHeader()+"\r\n";

            foreach(var m in mList)
            {
                result = result + m.GetCSVString() + "\r\n";
            }

            try
            {
                File.WriteAllText(v, result);
            }
            catch
            {
                
            }
            
        }

        private static void InputMonitorList(List<Monitor> mList)
        {
          
            for(;;)
            {
                Console.WriteLine("Diagonal Inch?");
                string sdi = Console.ReadLine();
                if (string.IsNullOrEmpty(sdi))
                    break;

                Console.WriteLine("Pixel W?");
                string spw = Console.ReadLine();
                if (string.IsNullOrEmpty(spw))
                    break;

                Console.WriteLine("Pixel H?");
                string sph = Console.ReadLine();
                if (string.IsNullOrEmpty(sph))
                    break;

                try
                {
                    Monitor target = new Monitor(Convert.ToDecimal(sdi), Convert.ToInt32(spw), Convert.ToInt32(sph));
                    mList.Add(target);
                 
                }
                catch
                {
                    Console.WriteLine("Data Error, try again.");
                }

            }
        }

        private static void PrintMonitorList(List<Monitor> mList)
        {
            Console.Clear();
            foreach(var m in mList)
            {
                Console.WriteLine(m.ToString());
            }
        }
    }
}
