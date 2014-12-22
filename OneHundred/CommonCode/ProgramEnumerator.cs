using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonCode
{
    public class ProgramEnumerator : IEnumerable<ProgramDescription>
    {
        List<ProgramDescription> _programs;

        public ProgramEnumerator()
        {
            _programs = new List<ProgramDescription>();

            //var type = typeof(IProgram);
            // This does not work, since not needed assemblies are not loaded
            // create that list manually
            //_programs = AppDomain.BuildManager.GetReferencedAssemblies()
            //            .SelectMany(s => s.GetTypes())
            //            .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
            //            .Select(x => new ProgramDescription() {
            //                Name = x.Name,
            //                Type = x.GetType()
            //            }).ToList();
        }

        public ProgramEnumerator(IEnumerable<System.Type> types)
            : this()
        {
            foreach(System.Type type in types)
                _programs.Add(new ProgramDescription(type));
        }

        public ProgramDescription this[int i]
        {
            get
            {
                return _programs[i];
            }

            set
            {
                _programs[i] = value;
            }
        }

        public IEnumerator<ProgramDescription> GetEnumerator()
        {
            return _programs.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerator)_programs.GetEnumerator());
        }
    }
}
