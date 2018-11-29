using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Helper
{
    public interface IHelper : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        string BuildCode(string strkey, int number);
    }




}
