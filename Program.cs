using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace lab4p4
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            var google = new Website("http://google.pl", "/");
            var ath = new Website("http://ath.bielsko.pl", "/");
            var wikipedia = new Website("https://pl.wikipedia.org", "/wiki/.Net_Core");
            var youtube = new Website("https://youtube.com", "/");
            var ath2 = new Website("http://ath.bielsko.pl", "/graficzne-formy-przekazu-informacji/");


            var tasks = new List<Task<string>>();

            stopwatch.Start();
            tasks.Add(google.Download());
            Console.WriteLine(stopwatch.Elapsed);
            tasks.Add(ath.Download());
            Console.WriteLine(stopwatch.Elapsed);
            tasks.Add(wikipedia.Download());
            Console.WriteLine(stopwatch.Elapsed);
            tasks.Add(youtube.Download());
            Console.WriteLine(stopwatch.Elapsed);
            tasks.Add(ath2.Download());
            Console.WriteLine(stopwatch.Elapsed);

            await Task.WhenAny(tasks);
            Console.WriteLine(stopwatch.Elapsed);
            var htmls = await Task.WhenAll(tasks);
            Console.WriteLine(stopwatch.Elapsed);

            foreach (var item in htmls)
            {
                Console.WriteLine(item.Length);
            }


        }
    }
}
