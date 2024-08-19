using Presenter;

namespace Editor.TestTool.Body.CreateTab.Title
{
    public class TestToolBodyCreateTabTitlePresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolBodyCreateTabTitleContainer _container;

        public TestToolBodyCreateTabTitlePresenter(TestToolContext context, TestToolBodyCreateTabTitleContainer container)
        {
            _context = context;
            _container = container;
        }
        
        public void Init()
        {
        }

        public void Dispose()
        {
        }
    }
}