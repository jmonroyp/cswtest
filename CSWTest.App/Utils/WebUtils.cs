using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CSWTest.App.Utils
{
    public static class WebUtils
    {
        public static string GetB64File(HttpPostedFileBase file)
        {
            try
            {
                byte[] data;
                using (Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    data = memoryStream.ToArray();
                }

                return data != null ? System.Convert.ToBase64String(data) : null;
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}