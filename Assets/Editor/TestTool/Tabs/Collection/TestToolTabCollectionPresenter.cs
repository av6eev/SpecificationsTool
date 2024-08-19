using Editor.TestTool.Body.CreateTab;
using Editor.TestTool.Body.FindTab;
using Presenter;
using UnityEngine.UIElements;

namespace Editor.TestTool.Tabs.Collection
{
    public class TestToolTabCollectionPresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolTabCollection _collection;
        private readonly VisualElement _rootContainer;

        private IPresenter _currentTabPresenter;
        
        public TestToolTabCollectionPresenter(TestToolContext context, TestToolTabCollection collection, VisualElement rootContainer)
        {
            _context = context;
            _collection = collection;
            _rootContainer = rootContainer;
        }

        public void Init()
        {
            _collection.CurrentTab.OnChanged += HandleTabChange;
            _collection.OnClear.OnChanged += HandleClear;
        }

        public void Dispose()
        {
            _collection.CurrentTab.OnChanged -= HandleTabChange;
            _collection.OnClear.OnChanged -= HandleClear;
        }

        private void HandleTabChange(TestToolTabModel newModel, TestToolTabModel oldModel)
        {
            if (newModel == null) return;
            
            if (oldModel != null)
            {
                _collection.CloseTab(oldModel);
                
                if (oldModel.Type == newModel.Type)
                {
                    _collection.CurrentTab.Value = null;
                    return;                
                }
            }
            
            _currentTabPresenter = null;
            
            switch (newModel)
            {
                case TestToolFindTabModel findTabModel:
                    _currentTabPresenter = new TestToolFindTabPresenter(_context, findTabModel, _rootContainer);
                    break;
                case TestToolCreateTabModel createTabModel:
                    _currentTabPresenter = new TestToolCreateTabPresenter(_context, createTabModel, _rootContainer);
                    break;
            }
            
            _currentTabPresenter?.Init();
        }

        private void HandleClear()
        {
            _currentTabPresenter?.Dispose();
            _currentTabPresenter = null;
        }
    }
}