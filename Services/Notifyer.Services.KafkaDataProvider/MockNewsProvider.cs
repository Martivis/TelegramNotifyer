using Notifyer.Services.KafkaDataProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifyer.Services.KafkaDataProvider
{
    internal class MockNewsProvider : INewsProvider
    {
        private readonly List<NewsModel> _news = new List<NewsModel>()
        {
            new NewsModel()
            {
                Id = 1,
                Title = "Test",
                Cathegory = "Sport",
                Content = "Test",
            },
            new NewsModel()
            {
                Id = 2,
                Title = "Test 2",
                Cathegory = "Sport",
                Content = "Test",
            },
            new NewsModel()
            {
                Id = 3,
                Title = "Test 3",
                Cathegory = "IT",
                Content = "Test",
            },
            new NewsModel()
            {
                Id = 4,
                Title = "Test 4",
                Cathegory = "IT",
                Content = "Test",
            },
            new NewsModel()
            {
                Id = 5,
                Title = "Test 5",
                Cathegory = "Sport",
                Content = "Test",
            },
        };

        private int _lastIndex = 0;

        public Task<NewsModel> GetNewsModelAsync()
        {
            return Task.FromResult(_news[_lastIndex++]);
        }
    }
}
