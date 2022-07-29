using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrnlAPI;

namespace AWE
{
    internal class Krnl
    {
        KrnlApi krnlApi = new KrnlApi();
        
        internal static void start();
        {
            KrnlApi.intialize();
            krnlApi.RemoveInstaller = false
        }
    }
}
