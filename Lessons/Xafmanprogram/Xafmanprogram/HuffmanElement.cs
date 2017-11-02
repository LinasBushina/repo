using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xafmanprogram
{
    class HuffmanElement : IComparable<HuffmanElement>
    {
        private bool isBase;
        private double weight;
        private HuffmanElement parent1;
        private HuffmanElement parent2;
        private string name;
        private string code;

        private void AddPrefixName(bool isMin)
        {
            if (isBase)
            { code = (isMin ? "0" : "1") + code; }
            else
            {
                parent1.AddPrefixName(isMin);
                parent2.AddPrefixName(isMin);
            }
        }

        public HuffmanElement(string name, double weight)
        {
            this.isBase = true;
            this.name = name;
            this.weight = weight;
            this.parent1 = null;
            this.parent2 = null;
            this.code = "";
        }
        public HuffmanElement(HuffmanElement parent1, HuffmanElement parent2)
        {
            this.isBase = false;
            this.weight = parent1.weight + parent2.weight;
            HuffmanElement min = parent1.weight < parent2.weight ? parent1 : parent2;
            HuffmanElement max = parent1.weight >= parent2.weight ? parent1 : parent2;
            min.AddPrefixName(true);
            max.AddPrefixName(false);
            this.parent1 = min;
            this.parent2 = max;
        }

        public string GetName()
        { return name; }
        public string GetCode()
        { return code; }

        public int CompareTo(HuffmanElement other)
        { return other.weight.CompareTo(weight); }
    }
}
