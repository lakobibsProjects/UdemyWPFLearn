using RSSReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.ViewModel
{
    public class FakeRSSHelper : IRSSHelper
    {
        public List<Item> GetPosts()
        {
            List<Item> items = new List<Item>();

            items.Add(new Item()
                {
                    Title = "Some title",
                    PubDate = "Thu, 22 Nov 2018 06:13:30 GMT"
            });
            items.Add(new Item()
            {
                Title = "Another title",
                PubDate = "Fri, 23 Nov 2018 09:27:14 GMT"
            });

            return items;
        }
    }
}
