using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi3
{
    public abstract class Vector
    {
        private float x;
        private float y;
        private float z;
        
        public abstract Vector Sum(Vector vt);
        public abstract string GetInfo();
        public abstract void ShowInfo();
        public abstract bool Orth(Vector vt);
    }
}
