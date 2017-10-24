using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AptiSummit.Api.Controllers.Values
{
    public class ValuesListViewModel : ViewModelBase<ValuesListViewModel>
    {
        /// <summary>
        /// Number of values in the system
        /// </summary>
        [Required] public int TotalCount { get; private set; }

        /// <summary>
        /// Index of first item returned in the list
        /// </summary>
        [Required] public int Index { get; private set; }

        /// <summary>
        /// Number of items returned on each page
        /// </summary>
        [Required] public int PageSize { get; private set; }

        /// <summary>
        /// List values
        /// </summary>
        [Required] public IEnumerable<ValuesItemViewModel> Values { get; private set; }

        public override ValuesListViewModel MySelf() => this;
        public override string Self() => "/api/values";

        public class ValuesItemViewModel : ViewModelBase<ValuesItemViewModel>
        {
            /// <summary>
            /// Id of Value
            /// </summary>
            [Required] public int Id { get; private set; }

            /// <summary>
            /// Name of Value
            /// </summary>
            [Required] public string Name { get; private set; }

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