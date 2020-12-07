using System.Net;

namespace RiscSegPre.Site.Extentions.Menssagem
{
    public static class ToastrDialogType
    {
        public static HttpStatusCode Sucess = HttpStatusCode.OK;
        public static HttpStatusCode Warning = HttpStatusCode.NotFound;
        public static HttpStatusCode Error = HttpStatusCode.NotImplemented;
        public static HttpStatusCode Info = HttpStatusCode.EarlyHints;
    }
}
