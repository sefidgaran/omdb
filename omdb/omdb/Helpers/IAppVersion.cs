using System;
using System.Collections.Generic;
using System.Text;

namespace omdb.Helpers
{
    public interface IAppVersion
    {
        string GetOS();
        string GetVersion();
        int GetBuild();
    }
}
