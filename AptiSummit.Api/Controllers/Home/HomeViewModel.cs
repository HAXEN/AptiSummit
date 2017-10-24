using System;

namespace AptiSummit.Api.Controllers.Home
{
    public class HomeViewModel : ViewModelBase<HomeViewModel>
    {
        public override HomeViewModel MySelf()
        {
            return this;
        }

        public override string Self() => "/";
    }
}