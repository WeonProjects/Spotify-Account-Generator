using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifyGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many accounts should be created? ");

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var test = Generator();

                Thread.Sleep(100);
            }

            Console.WriteLine("Account creation finished.");
            Console.ReadLine();
        } 
        public static async Task Generator()
        {
            HttpClient client = new HttpClient();

            using (var formContent = new MultipartFormDataContent("----WebKitFormBoundaryXkpMxJ9cdAxKNTw8"))
            {
                formContent.Headers.ContentType.MediaType = "multipart/form-data";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));

                string mail = "seuth" + new Random().Next(0, 999) + "tool" + new Random().Next(0, 99999) + "@gmail.com";
                string pass = "seuth" + new Random().Next(0, 9999999);

                formContent.Add(new StringContent(pass), "password_repeat");
                formContent.Add(new StringContent("1"), "iagree");
                formContent.Add(new StringContent("5"), "birth_month");
                formContent.Add(new StringContent("male"), "gender");
                formContent.Add(new StringContent(pass), "password");
                formContent.Add(new StringContent("desktop"), "creation_flow");
                formContent.Add(new StringContent("https://login.app.spotify.com?utm_source=spotify&utm_medium=desktop-win32-store&utm_campaign=msft_1&referral=msft_1&referrer=msft_1"), "creation_point");
                formContent.Add(new StringContent(Encoding.UTF8.GetString(Convert.FromBase64String(GetName()))), "displayname");
                formContent.Add(new StringContent("4c7a36d5260abca4af282779720cf631"), "key");
                formContent.Add(new StringContent("desktop"), "platform");
                formContent.Add(new StringContent(mail), "email");
                formContent.Add(new StringContent("2000"), "birth_year");
                formContent.Add(new StringContent("1"), "birth_day");
                formContent.Add(new StringContent("msft_1"), "referrer");

                Console.WriteLine(mail + ":" + pass);

                var Reg = await client.PostAsync("https://spclient.wg.spotify.com/signup/public/v1/account/", formContent);
            }
        }
        public static string GetName()
        {
            return "c2V1dGg=";
        }
    }
}