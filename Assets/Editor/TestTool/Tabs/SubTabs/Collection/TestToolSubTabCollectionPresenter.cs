using Editor.TestTool.Body.CreateTab.Parameters.SubTabs.Class;
using Presenter;

namespace Editor.TestTool.Tabs.SubTabs.Collection
{
    public abstract class TestToolSubTabCollectionPresenter : PresentersList
    {
        private readonly TestToolContext _context;
        private readonly TestToolSubTabCollection _collection;
        private readonly TestToolSubTabCollectionContainer _container;

        private readonly PresentersDictionary<TestToolSubTabModel> _presenters = new();
        
        public TestToolSubTabCollectionPresenter(TestToolContext context, TestToolSubTabCollection collection, TestToolSubTabCollectionContainer container)
        {
            _context = context;
            _collection = collection;
            _container = container;
        }

        public override void Init()
        {
            base.Init();
            
            _collection.OnAdd.OnChanged += HandleAdd;
            _collection.OnRemove.OnChanged += HandleRemove;
        }

        public override void Dispose()
        {
            base.Dispose();
            
            _collection.OnAdd.OnChanged -= HandleAdd;
            _collection.OnRemove.OnChanged -= HandleRemove;
        }

        private void HandleAdd(TestToolSubTabModel model)
        {
            if (model == null) return;
            
            IPresenter tabPresenter = null;
            
            switch (model)
            {
                case TestToolBodyCreateTabClassSubTabModel classSubTabModel:
                    tabPresenter = new TestToolBodyCreateTabClassSubTabPresenter(_context, classSubTabModel, _container.Root);
                    break;
            }
            
            tabPresenter?.Init();
            
            _presenters.Add(model, tabPresenter);
        }

        private void HandleRemove(TestToolSubTabModel model)
        {
            _presenters.Remove(model);
        }
    }
}