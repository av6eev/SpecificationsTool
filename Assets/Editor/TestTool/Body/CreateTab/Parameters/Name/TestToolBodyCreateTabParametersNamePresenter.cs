using Presenter;

namespace Editor.TestTool.Body.CreateTab.Parameters.Name
{
    public class TestToolBodyCreateTabParametersNamePresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolBodyCreateTabParametersModel _parametersModel;
        private readonly TestToolBodyCreateTabParametersNameContainer _container;

        public TestToolBodyCreateTabParametersNamePresenter(TestToolContext context, TestToolBodyCreateTabParametersModel parametersModel, TestToolBodyCreateTabParametersNameContainer container)
        {
            _context = context;
            _parametersModel = parametersModel;
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