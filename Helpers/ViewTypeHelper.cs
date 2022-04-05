using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quick_Translator
{
   public class ViewTypeHelper
    {
        private static Dictionary<int, string> viewTypes = new Dictionary<int, string>
        {
            {0,"Public view" },
            {1,"Advanced Search view" },
            {2,"Associated view" },
            {4,"Quick Find Search view" },
            {8,"Reporting Query" },
            {16,"Outlook offline filter" },
            {64,"Lookup view" },
            {128,"Service Management appointment book view" },
            {256,"Outlook filter" },
            {512,"Address book filter" },
            {1024,"Main application view without a subject" },
            {2048,"Saved query used for workflow templates and email templates." },
            {4096,"A view for a dialog" },
            {8192,"Outlook offline template" },
            {16384,"Custom view" },
            {131072,"Outlook template" }
        };

        public static string GetViewTypeByTypeCode(int viewTypeCode)
        {
            return viewTypes.ContainsKey(viewTypeCode) ? viewTypes[viewTypeCode] : viewTypeCode.ToString();
        }

    }
}
