using System;
using System.Collections.Generic;
using System.Linq;
using Editor.TestTool.Body.FindTab.Warnings;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using UnityEngine;

namespace Editor.TestTool.Utilities.Roslyn
{
    public static class RoslynAnalyzer
    {
        public static IEnumerable<string> AnalyzeInheritanceFromBaseClass(List<SyntaxTree> syntaxTrees, Type baseClassType)
        {
            foreach (var syntaxTree in syntaxTrees)
            {
                var root = syntaxTree.GetRoot();
                var classDeclarationSyntax = root.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();

                if (!TryGetBaseClasses(classDeclarationSyntax, out var baseClasses)) continue;
                if (!CheckBaseClassesContainsType(baseClasses, baseClassType)) continue;
                
                yield return classDeclarationSyntax.Identifier.ToString();
            }
        }
        
        public static bool TryGetBaseClasses(ClassDeclarationSyntax classDeclarationSyntax, out IEnumerable<TypeSyntax> baseClasses)
        {
            if (classDeclarationSyntax == null)
            {
                baseClasses = null;
                return false;
            }

            if (classDeclarationSyntax.BaseList == null)
            {
                TestToolBodyFindTabWarningsModel.AddWarning($"{classDeclarationSyntax.Identifier.ToString()} does not have a base class so is not included in the list!");
                
                baseClasses = null;
                return false;
            }

            baseClasses = classDeclarationSyntax.BaseList.Types.Select(x => x.Type);
            return true;
        } 
        
        public static bool CheckBaseClassesContainsType(IEnumerable<TypeSyntax> baseClasses, Type type)
        {
            if (baseClasses == null) return false;
            
            foreach (var typeSyntax in baseClasses)
            {
                switch (typeSyntax)
                {
                    case GenericNameSyntax genericNameSyntax:
                        Debug.Log($"generic  - {typeSyntax}");
                        break;
                    case SimpleNameSyntax simpleNameSyntax:
                        if (simpleNameSyntax.Identifier.ToString() == type.Name)
                        {
                            return true;
                        }
                        break;
                }
            }            
            
            return false;
        }
    }
}
