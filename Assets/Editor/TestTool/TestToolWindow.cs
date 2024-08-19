using Editor.TestTool.Body;
using Editor.TestTool.Parse;
using Editor.TestTool.Tabs.Collection;
using UnityEditor;
using UnityEngine;

namespace Editor.TestTool
{
    public class TestToolWindow : EditorWindow
    {
        private TestToolPresenter _presenter;
        private TestToolContext _testToolContext;
        private TestToolContainer _testToolContainer;

        [MenuItem("Tool/Test tool", false, 1)]
        public static void ShowWindow()
        {
            var toolStartupWindow = GetWindow<TestToolWindow>();
            toolStartupWindow.titleContent = new GUIContent("Test tool");
        }

        public void OnEnable()
        {
            var root = rootVisualElement;
            
            _testToolContainer = new TestToolContainer(root);
            _testToolContext = new TestToolContext
            {
                BodyModel = new TestToolBodyModel(),
                ParseModel = new TestToolParseModel(),
                TabCollection = new TestToolTabCollection()
            };

            _presenter = new TestToolPresenter(_testToolContext, _testToolContainer);
            _presenter.Init();
        }

        private void OnDestroy()
        {
            _presenter.Dispose();
            _presenter = null;
            _testToolContext = null;
        }
    }
}