using Reactive.Event;

namespace Editor.TestTool.Tabs.SubTabs
{
    public abstract class TestToolSubTabModel
    {
        public readonly ReactiveEvent OnClose = new();
        
        public readonly TestToolSubTabType Type;
        public bool IsOpened;

        protected TestToolSubTabModel(TestToolSubTabType type)
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