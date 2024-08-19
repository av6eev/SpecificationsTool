using UnityEngine.UIElements;

namespace Editor.Extensions
{
    public static class VisualElementExtension
    {
        public static VisualElement AddStyle(this VisualElement visualElement, string styleNames)
        {
            foreach (var element in styleNames.Split(" "))
            {
                visualElement.AddToClassList(element);    
            }
            
            return visualElement;
        }
    }
}