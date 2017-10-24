namespace AptiSummit.Api.Controllers.Values
{
    public class ValueItemViewModel : ViewModelBase<ValueItemViewModel>
    {
        public int Id { get; set; }
        public string Name { get; set; }

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