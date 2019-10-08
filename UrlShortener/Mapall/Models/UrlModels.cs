using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Mapall.Models
{
    [Table("tbUrl")]
    public class UrlModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Urlshortener { get; set; }

        public UrlModel()
        {
            this.Url = "";
            this.Urlshortener = "";
        }

        public UrlModel(UrlModel obj)
        {
            this.Url = obj.Url;
            this.Urlshortener = obj.Urlshortener;
        }

        public void CreateShortenerURL(string shortUrl = "")
        {
            if (shortUrl != "")
                this.Urlshortener = "https://example.com/" + shortUrl;
            else
                this.Urlshortener = "https://example.com/" + RandomLink();
        }

        // Generate a random string with a given size  
        private string RandomString(int size)
        {
            System.Text.StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            random.Next(0, 1);

            if (random.Next(0, 1) == 0)
                return builder.ToString().ToLower();

            return builder.ToString();
        }

        // Generate a random password  
        private string RandomLink()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(RandomString(2));
            builder.Append(RandomNumber(0, 9));
            builder.Append(RandomNumber(0, 9));
            builder.Append(RandomString(2));

            return builder.ToString();
        }

        // Generate a random number between two numbers
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}