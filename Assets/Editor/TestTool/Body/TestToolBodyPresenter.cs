using Presenter;

namespace Editor.TestTool.Body
{
    public class TestToolBodyPresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolBodyModel _model;
        private readonly TestToolBodyContainer _container;

        private IPresenter _currentTabPresenter;
        
        public TestToolBodyPresenter(TestToolContext context, TestToolBodyModel model, TestToolBodyContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }

        public void Init()
        {
        }

        public void Dispose()
        {
            _context.TabCollection.Clear();
        }
    }
}