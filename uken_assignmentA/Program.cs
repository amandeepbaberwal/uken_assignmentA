using System;
using System.Collections.Generic;
using System.Linq;
namespace uken_assignmentA
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();
            Dictionary<string, int> tempD = new Dictionary<string, int>();
            Dictionary<string, int> sameValueD = new Dictionary<string, int>();
            string[] lines = System.IO.File.ReadAllLines(@"/Users/amandeep/Desktop/QAEng/src/5.txt");
            words.Clear();
            var minValue = Int32.MaxValue;
            var minKey = String.Empty;
            foreach (string l in lines)
            {
                if (words.ContainsKey(l))
                {
                    int t = 0;
                    words.TryGetValue(l, out t);
                    t++;
                    words[l] = t;
                }
                else
                {
                    words.Add(l, 1);
                }
            }
            // finding minimum vl
            Console.WriteLine("All Pairs");
            foreach (KeyValuePair<string, int> pair in words.OrderBy(i => i.Value))
            {
                Console.WriteLine(pair);
                tempD.Add(pair.Key, pair.Value);
                if (pair.Value < minValue)
                {
                    minValue = pair.Value;
                    minKey = pair.Key;
                }
            }
            Console.WriteLine("==============================");
            //writing minimum frequency number
            Console.WriteLine("number that has repeated the fewest number of times: " + minKey + ", " +words[minKey]);
            foreach (var t in tempD)
            {
                foreach (var o in tempD)
                {
                    if (t.Value == o.Value && t.Key != o.Key && !sameValueD.ContainsKey(t.Key))
                    {
                        sameValueD.Add(t.Key, t.Value);
                    }
                }
            }
            Console.WriteLine("===============================");
            var result = sameValueD.GroupBy(x => x.Value)
                            .Select(g => g.OrderBy(x => x.Key).First());
            foreach (var item in result) {
                Console.WriteLine($"{item.Key} is the lowest key for the same value: { item.Value}");
            }
        }
    }
}
