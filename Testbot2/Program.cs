using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Testbot2
{
    internal class Program
    {
        //string url = @"data-26099-2022-05-23.zip";
        //WebClient client = new WebClient() { Encoding = Encoding.Default };
        //client.BaseAddress = "https://data.mos.ru/";
        //    client.DownloadFile(url, "data-26099-2022-05-23.zip");
        //5512214364:AAGjH5_zeRw0uYRhEGug5Tv87SCD2FnDHG8
        static void Main(string[] args)
        {
            string token = "5512214364:AAGjH5_zeRw0uYRhEGug5Tv87SCD2FnDHG8";
            WebClient wc = new WebClient() { Encoding = Encoding.Default };
            string startUrl = $@"https://api.telegram.org/bot{token}/";

            int update_id = 0;
            while (true)
            {
                string url = $"{startUrl}getUpdates?offset={update_id}";
                string r = wc.DownloadString(url);
                Console.WriteLine(r);
                //Console.ReadKey();
                JToken[] mass = JObject.Parse(r)["result"].ToArray();
                foreach (dynamic m in mass)
                {
                    update_id = Convert.ToInt32(m.update_id) + 1;
                    string userMessage = m["message"]["text"].ToString();
                    string userId = m.message.from.id;
                    string useFirstrName = m.message.from.first_name;

                    string text = $"{useFirstrName} {userId} {userMessage}";

                    Console.WriteLine(text);
                    if (userMessage == "hi")
                    {
                        string responseText = $"Здравствуй ушлёпок, {useFirstrName}";
                        url = $"{startUrl}sendMessage?chat_id={userId}&text={responseText}";
                        //Console.WriteLine("+");
                        Console.WriteLine(wc.DownloadString(url));
                    }
                }
                Thread.Sleep(500);
            }
        }
    }
}
