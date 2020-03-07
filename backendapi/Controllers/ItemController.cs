using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backendapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly string[] Titles = new[]
        {
            "Colorado", "New Jersey", "North Dakota", "Missouri", "Kansas", "Tennessee", "Pennsylvania", "New York", "Texas", "South Carolina"
        };

        private static readonly string[] ChildTitles = new[]
        {
            "Aurora", "Thornton", "Jersey City", "Minot", "Kansas City", "Overland Park", "Brentwood", "Whitehall", "Manhattan", "Dallas", "Marshall", "Spartanburg"
        };

        private readonly ILogger<ItemController> _logger;

        public ItemController(ILogger<ItemController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<backendapi.Item> Get()
        {            
            var rng = new Random();
            var children = new List<ItemChild>();
            int parentId = 1;
            int numberOfChildren = rng.Next(2, 200);
            for(int i = 0; i < numberOfChildren; i++) {
                ItemChild currentChild = new ItemChild
                {
                    Id = rng.Next(1, 1000000000),
                    ParentId = parentId,
                    Title = ChildTitles[rng.Next(ChildTitles.Length)]
                };
                children.Add(currentChild);
            }
            return Enumerable.Range(1, 5).Select(index => new Item
            {
                Id = parentId,
                Title = Titles[rng.Next(Titles.Length)],
                Children = children
            })
            .ToArray();
        }
    }
}
