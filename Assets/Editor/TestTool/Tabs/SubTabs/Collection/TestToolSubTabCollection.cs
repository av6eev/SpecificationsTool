using System.Collections.Generic;
using Reactive.Event;

namespace Editor.TestTool.Tabs.SubTabs.Collection
{
    public class TestToolSubTabCollection
    {
        public readonly ReactiveEvent<TestToolSubTabModel> OnAdd = new();
        public readonly ReactiveEvent<TestToolSubTabModel> OnRemove = new();

        public readonly Dictionary<TestToolSubTabType, TestToolSubTabModel> SubTabs = new();
        
        public void Add(TestToolSubTabModel tabModel)
        {
            SubTabs.Add(tabModel.Type, tabModel);
            OnAdd.Invoke(tabModel);
        }

        public void Remove(TestToolSubTabType type)
        {
            if (SubTabs.Remove(type, out var tabModel))
            {
                OnRemove.Invoke(tabModel);    
            }
        }
    }
}