using Presenter;

namespace Editor.TestTool.Parse
{
    public class TestToolParsePresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolParseModel _model;

        public TestToolParsePresenter(TestToolContext context, TestToolParseModel model)
        {
            _context = context;
            _model = model;
        }
        
        public void Init()
        {
            _model.Parse();
        }

        public void Dispose()
        {
            _model.Clear();
        }
    }
}