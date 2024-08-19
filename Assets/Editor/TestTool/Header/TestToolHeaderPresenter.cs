using Editor.TestTool.Body;
using Editor.TestTool.Body.CreateTab;
using Editor.TestTool.Body.FindTab;
using Presenter;
using UnityEngine;

namespace Editor.TestTool.Header
{
    public class TestToolHeaderPresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolHeaderModel _model;
        private readonly TestToolHeaderContainer _container;
        
        private TestToolCreateTabModel _createTabModel;
        private TestToolFindTabModel _findTabModel;

        public TestToolHeaderPresenter(TestToolContext context, TestToolHeaderModel model, TestToolHeaderContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }
        
        public void Init()
        {
            _createTabModel = new TestToolCreateTabModel();
            _findTabModel = new TestToolFindTabModel();

            _container.FindButton.clicked += HandleFindClick;
            _container.CreateButton.clicked += HandleCreateClick;
        }

        public void Dispose()
        {
            _container.FindButton.clicked -= HandleFindClick;
            _container.CreateButton.clicked -= HandleCreateClick;
        }

        private void HandleCreateClick()
        {
            _context.TabCollection.OpenTab(_createTabModel);
        }

        private void HandleFindClick()
        {
            _context.TabCollection.OpenTab(_findTabModel);
        }
    }
}