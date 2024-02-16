using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace WPFDemo.Models
{
    public class Book
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public DateTime? Publish { get; set; }
        public string? Type { get; set; }

        public string ToCsv()
        {
            return $"{Title}|{Author}|{Publish}|{Type}";
        }
        public static Book FromCsv(string line)
        {
            var splits = line.Split('|');
            var instance = new Book()
            {
                Title = splits[0],
                Author = splits[1],
                Publish = DateTime.Parse(splits[2]),
                Type = splits[3]
            };
            return instance;
        }
        public override string ToString()
        {
            return $"{Author} - {Title}";
        }
    }
}
