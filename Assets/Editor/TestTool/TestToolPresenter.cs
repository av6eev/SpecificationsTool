
using System.Collections.Generic;
using Editor.TestTool.Body;
using Editor.TestTool.Header;
using Editor.TestTool.Parse;
using Editor.TestTool.Tabs.Collection;
using Presenter;

namespace Editor.TestTool
{
    public class TestToolPresenter : PresentersList
    {
        private readonly TestToolContext _context;
        private readonly TestToolContainer _container;

        public TestToolPresenter(TestToolContext context, TestToolContainer container)
        {
            _context = context;
            _container = container;

            foreach (var presenter in CreatePresenters())
            {
                Add(presenter);
            }
        }

        public override IEnumerable<IPresenter> CreatePresenters()
        {
            yield return new TestToolTabCollectionPresenter(_context, _context.TabCollection, _container.BodyContainer.Root);
            yield return new TestToolParsePresenter(_context, _context.ParseModel);
            yield return new TestToolHeaderPresenter(_context, new TestToolHeaderModel(), _container.HeaderContainer);
            yield return new TestToolBodyPresenter(_context, _context.BodyModel, _container.BodyContainer);
        }
    }
}