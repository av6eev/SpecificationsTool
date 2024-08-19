using Editor.Extensions;
using Presenter;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.FindTab.List
{
    public class TestToolBodyFindTabListPresenter : IPresenter
    {
        private readonly TestToolContext _context;
        private readonly TestToolBodyFindTabListContainer _container;

        public TestToolBodyFindTabListPresenter(TestToolContext context, TestToolBodyFindTabListContainer container)
        {
            _context = context;
            _container = container;
        }
        
        public void Init()
        {
            var specificationNames = _context.ParseModel.FindAllSpecificationNames();
            var primaryStyle = $"body-list-group-element body-list-group-element-primary";
            var secondaryStyle = $"body-list-group-element body-list-group-element-secondary";
            var missingText = "Missing";

            foreach (var element in specificationNames)
            {
                switch (element.Value)
                {
                    case TestToolBodyFindTabListColumnType.All:
                        _container.JsonGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.ScrObjGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.ClassGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        break;
                    case TestToolBodyFindTabListColumnType.J:
                        _container.JsonGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.ScrObjGroupBox.Add(CreateLabel(secondaryStyle, missingText));
                        _container.ClassGroupBox.Add(CreateLabel(secondaryStyle, missingText));
                        break;
                    case TestToolBodyFindTabListColumnType.C:
                        _container.ClassGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.JsonGroupBox.Add(CreateLabel(secondaryStyle, missingText));
                        _container.ScrObjGroupBox.Add(CreateLabel(secondaryStyle, missingText));
                        break;
                    case TestToolBodyFindTabListColumnType.S:
                        _container.ScrObjGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.ClassGroupBox.Add(CreateLabel(secondaryStyle, missingText));
                        _container.JsonGroupBox.Add(CreateLabel(secondaryStyle, missingText));
                        break;
                    case TestToolBodyFindTabListColumnType.JC:
                        _container.JsonGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.ClassGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.ScrObjGroupBox.Add(CreateLabel(secondaryStyle, missingText));
                        break;
                    case TestToolBodyFindTabListColumnType.JS:
                        _container.JsonGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.ScrObjGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.ClassGroupBox.Add(CreateLabel(secondaryStyle, missingText));
                        break;
                    case TestToolBodyFindTabListColumnType.CS:
                        _container.ClassGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.ScrObjGroupBox.Add(CreateLabel(primaryStyle, element.Key));
                        _container.JsonGroupBox.Add(CreateLabel(secondaryStyle, missingText));
                        break;
                    default:
                        Debug.LogError("No type declared");
                        break;
                }
            }
        }

        public void Dispose()
        {
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