using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ReceiptScanning
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("response.json");
            var dataList = JsonSerializer.Deserialize<List<Receipt>>(json);
            dataList = dataList.Where(x=> string.IsNullOrEmpty(x.locale)).ToList();

            foreach (var item in dataList)
            {
                var currentItemY = item.boundingPoly.vertices[3].y;

                var basedPointY = dataList.FirstOrDefault(x => Math.Abs(x.boundingPoly.vertices[3].y - currentItemY) < 10);

                if (basedPointY != null)
                {
                    item.basedPointY = basedPointY.boundingPoly.vertices[3].y;
                }
            }
            
            var sortedList = dataList.OrderBy(x => x.basedPointY).ThenBy(x => x.boundingPoly.vertices[3].x).ToList();
            var value = string.Empty;

            for (int i = 1; i < sortedList.Count + 1; i++)
            {
                var currentValue = sortedList[i - 1].description;
                var currentBasedPointY = sortedList[i - 1].basedPointY;

                if (i != sortedList.Count && currentBasedPointY == sortedList[i].basedPointY)
                {
                    if (string.IsNullOrEmpty(value))
                    {
                        value = currentValue;
                    }
                    else
                    {
                        value += string.Format(" {0}", currentValue);
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        value += string.Format(" {0}", currentValue);

                        Console.WriteLine(value);
                    }
                    else
                    {
                        Console.WriteLine(currentValue);
                    }

                    value = string.Empty;
                }
            }
        }
    }
}
