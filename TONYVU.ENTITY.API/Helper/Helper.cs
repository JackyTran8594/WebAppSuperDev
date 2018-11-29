using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TONYVU.ENTITY.API.Helper
{
    public class Helper: IHelper, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public string BuildCode(string strKey,int number)
        {

            try
            {
                var code = strKey + number.ToString();
                return code;
            }
            catch (Exception exception)
            {
                throw new Exception();
            }
        }

        public void UploadFiles()
        {
          
        }

        
    }
}
