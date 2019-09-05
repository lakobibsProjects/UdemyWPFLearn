using RSSReader.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.ViewModel
{
    public class MainVM
    {
        IRSSHelper rssHelper;
        public ObservableCollection<Item> Items { get; set; }

        public MainVM(IRSSHelper rssHelper)
        {
            this.rssHelper = rssHelper;
            Items = new ObservableCollection<Item>();

            ReadRss();
        }

        private void ReadRss()
        {
            //IRSSHelper rssHelper;
            var posts = new FakeRSSHelper().GetPosts();

            Items.Clear();

            foreach(var post in posts)
                Items.Add(post);
            
        }
    }
}
