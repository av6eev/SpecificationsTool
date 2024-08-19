using Editor.TestTool.Body;
using Reactive.Event;

namespace Editor.TestTool.Tabs
{
    public abstract class TestToolTabModel
    {
        public readonly ReactiveEvent OnClose = new();
        
        public readonly TestToolBodyTabType Type;
        public bool IsOpened;

        public TestToolTabModel(TestToolBodyTabType type)
        {
            Type = type;
        }
        
        public void Close()
        {
            IsOpened = false;
            OnClose.Invoke();
        }
    }
}