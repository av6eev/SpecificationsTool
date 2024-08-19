using System.Collections.Generic;
using Reactive.Event;

namespace Editor.TestTool.Body.FindTab.Warnings
{
    public static class TestToolBodyFindTabWarningsModel
    {
        public static readonly ReactiveEvent<string> OnAdd = new();
        public static readonly List<string> Warnings = new();

        public static void AddWarning(object message)
        {
            var messageToString = message.ToString();
            
            Warnings.Add(messageToString);
            OnAdd?.Invoke(messageToString);
        }
    }
}