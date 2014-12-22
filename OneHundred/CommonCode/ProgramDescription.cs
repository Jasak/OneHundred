using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonCode
{
    public class ProgramDescription
    {
        public string Name { get; set; }
        public System.Type Type { get; set; }

        public ProgramDescription()
        {

        }

        public ProgramDescription(System.Type type)
        {
            Name = type.Name;
            Type = type;
        }

        public IProgram CreateNewInstance()
        {
            return Activator.CreateInstance(Type) as IProgram;
        }
    }
}
