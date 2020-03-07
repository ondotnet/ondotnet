using System.Collections.Generic;

namespace backendapi 
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ItemChild> Children { get; set; }
    }
}