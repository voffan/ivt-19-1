using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoreport.Services.Errors
{
    class MoneyGivenButDocumentChoosed : Exception
    {
        public MoneyGivenButDocumentChoosed(string message) : base(message) { }
    }

    class DocumentGivenButMoneyChoosed : Exception
    {
        public DocumentGivenButMoneyChoosed(string message) : base(message) { }
    }
}
