using Editor.TestTool.Body.CreateTab.Parameters.SubTabs.Class;
using Presenter;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab.Parameters.Type
{
    public class TestToolBodyCreateTabParametersTypePresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolBodyCreateTabParametersModel _parametersModel;
        private readonly TestToolBodyCreateTabParametersTypeContainer _container;

        public TestToolBodyCreateTabParametersTypePresenter(TestToolContext context, TestToolBodyCreateTabParametersModel parametersModel, TestToolBodyCreateTabParametersTypeContainer container)
        {
            _context = context;
            _parametersModel = parametersModel;
            _container = container;
        }
        
        public void Init()
        {
            _container.TypeField.RegisterValueChangedCallback(evt =>
            {
                switch ((TestToolBodyCreateTabParametersType)evt.newValue)
                {
                    case TestToolBodyCreateTabParametersType.Json:
                        break;
                    case TestToolBodyCreateTabParametersType.ScriptableObject:
                        break;
                    case TestToolBodyCreateTabParametersType.Class:
                        _parametersModel.Add(new TestToolBodyCreateTabClassSubTabModel());
                        break;
                }
            });
        }

        public void Dispose()
        {
            _container.TypeField.UnregisterValueChangedCallback(evt =>
            {
                switch ((TestToolBodyCreateTabParametersType)evt.newValue)
                {
                    case TestToolBodyCreateTabParametersType.Json:
                        break;
                    case TestToolBodyCreateTabParametersType.ScriptableObject:
                        break;
                    case TestToolBodyCreateTabParametersType.Class:
                        _parametersModel.Add(new TestToolBodyCreateTabClassSubTabModel());
                        break;
                }
            });
        }
    }
}