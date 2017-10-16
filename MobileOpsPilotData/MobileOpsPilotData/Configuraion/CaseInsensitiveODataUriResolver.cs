using Microsoft.OData.UriParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileOpsPilotData.Configuration
{
    public sealed class CaseInsensitiveODataUriResolver : UnqualifiedODataUriResolver
    {
        public override bool EnableCaseInsensitive { get { return true; } set { } }
    }
}