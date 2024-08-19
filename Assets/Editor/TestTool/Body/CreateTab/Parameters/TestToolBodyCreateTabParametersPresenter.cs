using System.Collections.Generic;
using Editor.TestTool.Body.CreateTab.Parameters.Name;
using Editor.TestTool.Body.CreateTab.Parameters.Type;
using Editor.TestTool.Tabs.SubTabs.Collection;
using Presenter;

namespace Editor.TestTool.Body.CreateTab.Parameters
{
    public class TestToolBodyCreateTabParametersPresenter : TestToolSubTabCollectionPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolBodyCreateTabParametersModel _model;
        private readonly TestToolBodyCreateTabParametersContainer _container;

        public TestToolBodyCreateTabParametersPresenter(TestToolContext context, TestToolBodyCreateTabParametersModel model, TestToolBodyCreateTabParametersContainer container)
        : base(context, model, container)
        {
            _context = context;
            _model = model;
            _container = container;

            foreach (var presenter in CreatePresenters())
            {
                Add(presenter);
            }
        }

        public override IEnumerable<IPresenter> CreatePresenters()
        {
            yield return new TestToolBodyCreateTabParametersNamePresenter(_context, _model, _container.NameContainer);
            yield return new TestToolBodyCreateTabParametersTypePresenter(_context, _model, _container.TypeContainer);
        }
    }
}