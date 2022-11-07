using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ReadingFromFolder
{
    public class HelpClass
    {
        private Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
        public HelpClass(Dictionary<string, List<string>> dictionary)
        {
            dict = dictionary;
        }
        public string FindValue(string firstKey, string findValue)
        {
            var usedKeys = new List<string>();
            usedKeys.Add(firstKey);
            var values = dict[firstKey];
            var output = DFS(usedKeys, findValue, values);
            if (output == "synonyms")
            {
                return "synonyms";
            }
            return "different";
        }
        public string DFS(List<string> usedKeys, string findValue, List<string> values)
        {
            foreach (var item in values)
            {
                if (findValue == item)
                {
                    return "synonyms";
                }

            }
            for (int i = 0; i < values.Count; i++)
            {
                var item = values[i];
                if (!usedKeys.Contains(item))
                {
                    var newValues = dict[item];
                    usedKeys.Add(item);
                    if (i == values.Count - 1)
                    {
                        return DFS(usedKeys, findValue, newValues);
                    }
                    else
                    {
                        foreach (var itemNew in values)
                        {
                            var output = DFS(usedKeys, findValue, newValues);
                            if (output == "synonyms")
                            {
                                return "synonyms";
                            }
                        }
                    }

                }
            }
            return "Different here";
        }
    }
}
