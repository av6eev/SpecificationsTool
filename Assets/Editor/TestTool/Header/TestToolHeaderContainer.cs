using Editor.Extensions;
using UnityEngine.UIElements;

namespace Editor.TestTool.Header
{
    public class TestToolHeaderContainer
    {
        public readonly Button FindButton;
        public readonly Button CreateButton;
        
        public TestToolHeaderContainer(VisualElement root)
        {
            var blockRoot = new VisualElement();
            blockRoot.AddStyle("header");

            FindButton = new Button
            {
                text = "Find all specifications",
                focusable = false
            };
            FindButton.ClearClassList();
            FindButton.AddStyle("btn btn-primary .btn-primary:hover .btn-primary:focus");

            CreateButton = new Button
            {
                text = "Create new specification",
                focusable = false
            };
            CreateButton.ClearClassList();
            CreateButton.AddStyle("btn btn-primary .btn-primary:hover .btn-primary:focus");

            blockRoot.Add(FindButton);
            blockRoot.Add(CreateButton);
            root.Add(blockRoot);
        }
    }
}