using Presenter;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab.Parameters.BaseClass
{
    public class TestToolBodyCreateTabParametersBaseClassPresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolBodyCreateTabParametersBaseClassModel _model;
        private readonly TestToolBodyCreateTabParametersBaseClassContainer _container;

        public TestToolBodyCreateTabParametersBaseClassPresenter(TestToolContext context, TestToolBodyCreateTabParametersBaseClassModel model, TestToolBodyCreateTabParametersBaseClassContainer container)
        {
            _context = context;
            _model = model;
            _container = container;
        }
        
        public void Init()
        {
            _container.BaseClassField.RegisterValueChangedCallback(evt =>
            {
                Debug.Log(evt.newValue);
            });
        }

        public void Dispose()
        {
            _container.BaseClassField.UnregisterValueChangedCallback(evt =>
            {
                Debug.Log(evt.newValue);
            });
        }
    }
}