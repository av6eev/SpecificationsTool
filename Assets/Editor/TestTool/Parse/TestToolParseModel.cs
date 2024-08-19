using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Editor.TestTool.Body.FindTab.List;
using Editor.TestTool.Utilities.Roslyn;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Specification;
using UnityEditor;

namespace Editor.TestTool.Parse
{
    public class TestToolParseModel
    {
        public readonly List<SyntaxTree> SyntaxTrees = new();
        
        public void Parse()
        {
            var directoryInfo = new DirectoryInfo(RoslynAnalyzerConst.PathToAnalyzeDirectory);
            var filePaths = directoryInfo.GetFiles(RoslynAnalyzerConst.ParseFileFormat, SearchOption.AllDirectories).Select(info => info.FullName).ToList();
            
            foreach (var path in filePaths)
            {
                var code = new StreamReader(path).ReadToEnd();
                var compilationUnit = SyntaxFactory.ParseCompilationUnit(code);
                SyntaxTrees.Add(compilationUnit.SyntaxTree);
            }
        }
        
        public Dictionary<string, TestToolBodyFindTabListColumnType> FindAllSpecificationNames()
        {
            var foundSpecificationNames = new Dictionary<string, TestToolBodyFindTabListColumnType>();
            var jsonSpecificationNames = FindJsonSpecifications().ToList();
            var scrObjSpecificationNames = FindScrObjSpecifications().ToList();
            var classSpecificationNames = FindClassSpecifications().ToList();

            var collections = new[] { classSpecificationNames, jsonSpecificationNames, scrObjSpecificationNames };
            var resultIndex = GetCollectionIndexWithMaxLength(collections);

            foreach (var name in collections[resultIndex])
            {
                // All
                if (ContainsAny(jsonSpecificationNames, name) &&
                    ContainsAny(classSpecificationNames, name) &&
                    ContainsAny(scrObjSpecificationNames, name))
                {
                    foundSpecificationNames.Add(name, TestToolBodyFindTabListColumnType.All);
                }
                // J
                else if (ContainsAny(jsonSpecificationNames, name) &&
                         !ContainsAny(classSpecificationNames, name) &&
                         !ContainsAny(scrObjSpecificationNames, name))
                {
                    foundSpecificationNames.Add(name, TestToolBodyFindTabListColumnType.J);
                }
                // C
                else if (ContainsAny(classSpecificationNames, name) &&
                         !ContainsAny(jsonSpecificationNames, name) &&
                         !ContainsAny(scrObjSpecificationNames, name))
                {
                    foundSpecificationNames.Add(name, TestToolBodyFindTabListColumnType.C);
                }
                // S
                else if (ContainsAny(scrObjSpecificationNames, name) &&
                         !ContainsAny(classSpecificationNames, name) &&
                         !ContainsAny(jsonSpecificationNames, name))
                {
                    foundSpecificationNames.Add(name, TestToolBodyFindTabListColumnType.S);
                }
                // JC
                else if (ContainsAny(jsonSpecificationNames, name) &&
                         ContainsAny(classSpecificationNames, name) &&
                         !ContainsAny(scrObjSpecificationNames, name))
                {
                    foundSpecificationNames.Add(name, TestToolBodyFindTabListColumnType.JC);
                }
                // JS
                else if (ContainsAny(jsonSpecificationNames, name) &&
                         ContainsAny(scrObjSpecificationNames, name) &&
                         !ContainsAny(classSpecificationNames, name))
                {
                    foundSpecificationNames.Add(name, TestToolBodyFindTabListColumnType.JS);
                }
                // CS
                else if (ContainsAny(classSpecificationNames, name) &&
                         ContainsAny(scrObjSpecificationNames, name) &&
                         !ContainsAny(jsonSpecificationNames, name))
                {
                    foundSpecificationNames.Add(name, TestToolBodyFindTabListColumnType.CS);
                }
            }

            return foundSpecificationNames;
        }

        private IEnumerable<string> FindClassSpecifications()
        {
            foreach (var name in RoslynAnalyzer.AnalyzeInheritanceFromBaseClass(SyntaxTrees, typeof(BaseSpecification)))
            {
                yield return name.Split("Specification").First();
            }
        }

        private IEnumerable<string> FindJsonSpecifications()
        {
            var directoryInfo = new DirectoryInfo("Assets/Content/Specifications/Json/");
            var fileInfos = directoryInfo.GetFiles("*.json", SearchOption.AllDirectories);
            
            foreach (var fileInfo in fileInfos)
            {
                yield return fileInfo.Name.Split("_specifications").First();
            }
        }

        private IEnumerable<string> FindScrObjSpecifications()
        {
            var assetGuids = AssetDatabase.FindAssets("Specification", new[] {"Assets/Content/Specifications/ScriptableObject/"});
            
            foreach (var file in assetGuids)
            {
                var path = AssetDatabase.GUIDToAssetPath(file);
                var fileName = path.Split('/').Last().Split("Specification").First();
                
                yield return fileName;
            }
        }

        private bool ContainsAny(in List<string> list, string value)
        {
            return list.Any(element => element.Equals(value, StringComparison.InvariantCultureIgnoreCase));
        }

        private int GetCollectionIndexWithMaxLength(params List<string>[] collections)
        {
            var max = 0;
            var index = 0;
            
            for (var i = 0; i < collections.Length; i++)
            {
                var collection = collections[i];
                
                if (max < collection.Count)
                {
                    max = collection.Count;
                    index = i;
                }
            }

            return index;
        }

        public void Clear()
        {
            SyntaxTrees.Clear();
        }
    }
}