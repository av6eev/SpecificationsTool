using Editor.TestTool.Utilities.ReactiveField;
using Reactive.Event;

namespace Editor.TestTool.Tabs.Collection
{
    public class TestToolTabCollection
    {
        public readonly ReactiveEvent OnClear = new();
        public NonCheckReactiveField<TestToolTabModel> CurrentTab { get; private set; } = new();

        public void OpenTab(TestToolTabModel tabModel)
        {
            tabModel.IsOpened = true;
            CurrentTab.Value = tabModel;
        }

        public void CloseTab(TestToolTabModel tabModel)
        {
            tabModel.Close();
        }

        public void Clear()
        {
            CurrentTab = null;
            OnClear.Invoke();
        }
    }
}