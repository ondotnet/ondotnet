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
            int numberOfItems = rng.Next(10000, 100000);
            int numberOfChildren = rng.Next(1000000, 100000000);
            return Enumerable.Range(1, numberOfItems).Select((x, index) => new Item
            {
                Id = index + 1,
                Title = Titles[rng.Next(Titles.Length)],
                Children = Enumerable.Range(2, numberOfChildren)
                    .Select(childIndex => new ItemChild
                    {
                        Id = index * numberOfChildren + childIndex,
                        ParentId = index + 1,
                        Title = ChildTitles[rng.Next(ChildTitles.Length)]
                    }).ToList()
            })
            .ToArray();
        }
    }
}
