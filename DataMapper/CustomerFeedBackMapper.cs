using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DataDto.FeedBackDto;
using backend.Models;

namespace backend.DataMapper
{
    public static class CustomerFeedBackMapper
    {
        public static FeedBackDto ToGetAllFeedBack(this CustomerFeedback customerFeedback){
            return new FeedBackDto  {
                Id = customerFeedback.Id,
                FullName = customerFeedback.FullName,
                Email = customerFeedback.Email,
                Message = customerFeedback.Message
            };
        }
    }
}