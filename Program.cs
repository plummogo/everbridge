using System.Collections.Generic;
using System;
public class TreeNode
{
public string Id { get; set; }
public List<TreeNode> Children { get; set; }
public TreeNode()
{
Children = new List<TreeNode>();
}
public TreeNode FindNode(string nodeId)
{
if (Id.Equals(nodeId, StringComparison.OrdinalIgnoreCase))
{
return this;
}
foreach (var child in Children)
{
var result = child.FindNode(nodeId);
if (result != null)
{
return result;
}
}
return null;
}
}

public class Program
{
public static void Main()
{
Console.WriteLine("Test Start");
Console.WriteLine("Test1: " + RunTest(() => LoadTestData().FindNode("UK").Id == "UK"));
Console.WriteLine("Test1: " + RunTest(() => LoadTestData().FindNode("England").Id == "England"));
Console.WriteLine("Test1: " + RunTest(() => LoadTestData().FindNode("Scotland").Id == "Scotland"));
Console.WriteLine("Test1: " + RunTest(() => LoadTestData().FindNode("University of Liverpool").Id == "University of Liverpool"));
Console.WriteLine("Test1: " + RunTest(() => LoadTestData().FindNode("University of Cambridge").Id == "University of Cambridge"));
Console.WriteLine("Test1: " + RunTest(() => LoadTestData().FindNode("University of Oxford") == null));
Console.WriteLine("Test End");
}
private static string RunTest(Func<bool> test)
{
try
{
return test() ? "PASSED" : "FAILED";
}
catch (Exception)
{
return "FAILED";
}
}
private static TreeNode LoadTestData()
{
return new TreeNode {
Id = "UK",
Children = new List<TreeNode> {
new TreeNode {
Id = "England",
Children = new List<TreeNode> {
new TreeNode {
Id = "Liverpool",
Children = new List<TreeNode> {
new TreeNode {
Id = "University of Liverpool",
Children = new List<TreeNode>()
},
new TreeNode {
Id = "John Moores University",
Children = new List<TreeNode>()
}
}
},
new TreeNode {
Id = "Bath",
Children = new List<TreeNode> {
new TreeNode {
Id = "University of Bath",
Children = new List<TreeNode>()
},
new TreeNode {
Id = "University of Bath in Swindon",
Children = new List<TreeNode>()
}
}
},
new TreeNode {
Id = "York",
Children = new List<TreeNode> {
new TreeNode {
Id = "University of York",
Children = new List<TreeNode>()
}
}
},
new TreeNode {
Id = "Cambridge",
Children = new List<TreeNode> {
new TreeNode {
Id = "University of Cambridge"
}
}
}
}
},
new TreeNode {
Id = "Scotland",
Children = new List<TreeNode> {
new TreeNode {
Id = "Glasgow",
Children = new List<TreeNode>()
},
new TreeNode {
Id = "Edinburgh",
Children = new List<TreeNode> {
new TreeNode {
Id = "Edinburgh University"
}
}
}
}
},
new TreeNode {
Id = "Wales",
Children = new List<TreeNode> {
new TreeNode {
Id = "Cardif"
}
}
}
}
};
}
}
