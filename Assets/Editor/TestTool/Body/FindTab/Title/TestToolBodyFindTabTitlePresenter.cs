using Presenter;

namespace Editor.TestTool.Body.FindTab.Title
{
    public class TestToolBodyFindTabTitlePresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolBodyFindTabTitleContainer _container;

        public TestToolBodyFindTabTitlePresenter(TestToolContext context, TestToolBodyFindTabTitleContainer container)
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