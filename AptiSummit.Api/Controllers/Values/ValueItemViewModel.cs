using System.ComponentModel.DataAnnotations;

namespace AptiSummit.Api.Controllers.Values
{
    public class ValueItemViewModel : ViewModelBase<ValueItemViewModel>
    {
        /// <summary>
        /// Id of Value
        /// </summary>
        [Required] public int Id { get; private set; }

        /// <summary>
        /// Name of Value
        /// </summary>
        [Required] public string Name { get; private set; }

        public override ValueItemViewModel MySelf() => this;
        public override string Self() => $"/api/values/{Id}";

        public static ValueItemViewModel Create(Value value)
        {
            if (value == null)
                return null;

            return new ValueItemViewModel
            {
                Id = value.Id,
                Name = value.Name,
            };
        }
    }
}