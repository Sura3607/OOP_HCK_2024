using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi4
{
    public interface ICricle
    {
        float cal_area();
        IPoint GetPoint();
        float GetR();
    }
}
