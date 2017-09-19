using System;
using System.Collections.Generic;

namespace RestaurantApiMenulog.Models.Application
{
    public class GenericResponseModel
    {
        public object Response { get; set; }
        public bool IsSuccess => ExceptionList is null && ErrorList is null;
        public IEnumerable<Exception> ExceptionList { get; set; } = null;
        public IEnumerable<string> ErrorList { get; set; } = null;
    }
}