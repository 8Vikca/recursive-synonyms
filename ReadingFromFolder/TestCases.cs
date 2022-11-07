using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingFromFolder
{
    public class InputFile
    {
        public int T { get; set; }

        public List<TestCases> TestCases { get; set; } = new List<TestCases>();
    }

    public class TestCases
    {
        public string N { get; set; }

        public string Q { get; set; }

        public List<List<string>> Dictionary { get; set; } = new List<List<string>>();

        public List<List<string>> Queries { get; set; } = new List<List<string>>();

    }
}
