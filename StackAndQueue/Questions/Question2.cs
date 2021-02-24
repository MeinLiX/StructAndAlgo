using System;
using System.Collections.Generic;
using System.Linq;

namespace StackAndQueue.Questions
{
    class Question2
    {
        private Dictionary<string, (int pos, int num, bool sign)> ArrStat = new()
        {
            ["max"] = new(-1, 0, true),
            ["min"] = new(-1, int.MaxValue, true)
        };

        internal void Init(List<int> arr)
        {
            Console.WriteLine("\n**************\t" + this.GetType().Name);
            if(arr!=null && arr.Count>0 && arr[0] != 0)
            {
                ArrStat["max"]= new(0, arr[0], arr[0] > 0);
                ArrStat["min"] = new(0, arr[0], arr[0] > 0);
            }

            foreach (var item in arr.Select((num, pos) => new { pos, num }))
            {
                if (item.num == 0)
                    break;

                    if (Math.Abs(ArrStat["max"].num) < Math.Abs(item.num))
                    ArrStat["max"] = new(item.pos, item.num, item.num > 0);

                if (Math.Abs(ArrStat["min"].num) > Math.Abs(item.num))
                    ArrStat["min"] = new(item.pos, item.num, item.num > 0);
            }

            if (ArrStat["max"].pos < 0 && ArrStat["min"].pos < 0 || (ArrStat["max"].sign && ArrStat["min"].sign))
                Console.WriteLine("Item not found.");
            else if (ArrStat["max"].sign)
                Console.WriteLine($"MINbyABS:{{pos:{ArrStat["min"].pos},value:{ArrStat["min"].num}}}");
            else if (ArrStat["min"].sign)
                Console.WriteLine($"MAXbyABS:{{pos:{ArrStat["max"].pos},value:{ArrStat["max"].num}}}");
            else
                Console.WriteLine($"MAXbyABS:{{pos:{ArrStat["max"].pos},value:{ArrStat["max"].num}}}\nMINbyABS:{{pos:{ArrStat["min"].pos},value:{ArrStat["min"].num}}}");
        }
    }
}
