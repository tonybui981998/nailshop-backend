using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.DataDto.FeedBackDto
{
    public class FeedBackDto
    {
        public int Id { get; set; }
          public string FullName { get; set; }

        public string Email{get;set;}

        public string Message { get; set; }
    }
}