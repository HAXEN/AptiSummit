using System;
using System.Collections.Generic;
using System.Linq;

namespace AptiSummit.Api.Controllers.Values
{
    public class ValuesListViewModel : ViewModelBase<ValuesListViewModel>
    {
        public int TotalCount { get; set; }
        public int Index { get; set; }
        public int PageSize { get; set; }
        public IEnumerable<ValuesItemViewModel> Values { get; set; }

        public override ValuesListViewModel MySelf() => this;
        public override string Self() => "/api/values";

        public class ValuesItemViewModel : ViewModelBase<ValuesItemViewModel>
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override ValuesItemViewModel MySelf() => this;
            public override string Self() => $"/api/values/{Id}";

            public static ValuesItemViewModel Create(Value value)
            {
                return new ValuesItemViewModel
                {
                    Id = value.Id,
                    Name = value.Name,
                };
            }
        }

        public static ValuesListViewModel Create(IEnumerable<Value> values, int index, int pageSize)
        {
            return new ValuesListViewModel
            {
                TotalCount = values.Count(),
                Index = index,
                PageSize = pageSize,
                Values = values.Skip(index).Take(pageSize).Select(ValuesItemViewModel.Create),
            };
        }
    }
}