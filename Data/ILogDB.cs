using Model;
using System.Collections.Generic;

namespace Data
{
    public interface ILogDB
    {
        void Insert(string msg);
        List<Log> Select();
    }
}
