using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R3JsonExtensions
{
    public class BindablePropertyAttribute : Attribute
    {
        public string Name { get; }
        public BindablePropertyAttribute(string name) => Name = name;
    }
}
