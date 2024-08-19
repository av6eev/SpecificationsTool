using Editor.Extensions;
using Presenter;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.FindTab.Warnings
{
    public class TestToolBodyFindTabWarningsPresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolBodyFindTabWarningsContainer _container;

        public TestToolBodyFindTabWarningsPresenter(TestToolContext context, TestToolBodyFindTabWarningsContainer container)
        {
            _context = context;
            _container = container;
        }
        
        public void Init()
        {
            foreach (var warning in TestToolBodyFindTabWarningsModel.Warnings) 
            {
                HandleAdd(warning);
            }

            TestToolBodyFindTabWarningsModel.OnAdd.OnChanged += HandleAdd;
        }

        public void Dispose()
        {
            TestToolBodyFindTabWarningsModel.Warnings.Clear();
            
            TestToolBodyFindTabWarningsModel.OnAdd.OnChanged -= HandleAdd;
        }

        private void HandleAdd(string message)
        {
            _container.GroupBox.Add(CreateLabel("body-warnings-group-element", message));
        }
        
        private Label CreateLabel(string styleNames, string text = "")
        {
            var label = new Label { text = text };
            label.ClearClassList();
            label.AddStyle(styleNames);
            
            return label;
        }
    }
}