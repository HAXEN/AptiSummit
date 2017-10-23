using System.Collections.Generic;
using System.Linq;

namespace AptiSummit.Api
{
    public interface IHaveLinks
    {
        IEnumerable<ILinkItem> Links();
    }

    public interface ILinkItem
    {
        string Href { get; }
        string Rel { get; }
        string Description { get; }
    }

    public abstract class ViewModelBase<TViewModel> : IHaveLinks
        where TViewModel : ViewModelBase<TViewModel>
    {
        private readonly List<LinkItem> _links = new List<LinkItem>();

        public abstract TViewModel MySelf();
        public abstract string Self();

        public TViewModel AddLink(string path, string relation, string description = null)
        {
            EnsureSelf();
            _links.Add(new LinkItem
            {
                Href = path,
                Rel = relation,
                Description = description,
            });
            return MySelf();
        }

        private void EnsureSelf()
        {
            if (_links.Any() == false)
                _links.Add(new LinkItem
                {
                    Rel = "self",
                    Href = Self(),
                });
        }

        IEnumerable<ILinkItem> IHaveLinks.Links()
        {
            EnsureSelf();
            return _links;
        }

        public class LinkItem : ILinkItem
        {
            public string Href { get; set; }
            public string Rel { get; set; }
            public string Description { get; set; }
        }
    }
}