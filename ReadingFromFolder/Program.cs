// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReadingFromFolder;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        InputFile items = new InputFile();
        using (StreamReader r = new StreamReader("example_big.in.json"))
        {
            string json = r.ReadToEnd();
            items = JsonConvert.DeserializeObject<InputFile>(json);
        }

        foreach (var testCase in items.TestCases)
        {
            var dict = new Dictionary<string, List<string>>();
            
            foreach (var dictonaries in testCase.Dictionary)
            {
                var key = dictonaries[0].ToLower();
                var value = dictonaries[1].ToLower();
                foreach (var word in dictonaries)
                {
                    if (key != value)
                    {
                        if (!dict.ContainsKey(key))
                        {
                            List<string> initList = new List<string>();
                            initList.Add(value);
                            dict.Add(key, initList);
                        }
                        else
                        {
                            List<string> list = dict[key];
                            if (list.Contains(value) == false && key != value)
                            {
                                list.Add(value);
                            }
                            dict[key] = list;
                        }
                        key = dictonaries[1].ToLower();
                        value = dictonaries[0].ToLower();
                    }
                    
                }
            }

            var helpClass = new HelpClass(dict);
            foreach (var queries in testCase.Queries)
            {
                var value1 = queries[0].ToLower();
                var value2 = queries[1].ToLower();

                if (string.Equals(value1, value2))
                {
                    Console.WriteLine("synonyms");
                }
                else
                {
                    if (dict.ContainsKey(value1) && dict.ContainsKey(value2))
                    {
                        if (dict[value1].Contains(value2) || dict[value2].Contains(value1))
                        {
                            Console.WriteLine("synonyms");
                        }
                        else
                        {
                            Console.WriteLine(helpClass.FindValue(value1, value2));
                        }
                    }
                    else
                    {
                        Console.WriteLine("different");

                    }
                }
            }
        }
        Console.ReadLine();
    }
}