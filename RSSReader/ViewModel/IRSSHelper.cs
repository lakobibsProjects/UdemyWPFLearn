using RSSReader.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.ViewModel
{
    public interface IRSSHelper
    {
        List<Item> GetPosts();
    }
}
