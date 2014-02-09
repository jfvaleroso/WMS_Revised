using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Globalization;
using System.Web.Helpers;
using WMS.Core.Helper.Common;

namespace WMS.Web.Helper
{
    public class CryptoValueProvider :  IValueProvider
    {
        RouteData routeData = null;
        Dictionary<string, string> dictionary = new Dictionary<string,string>();

        public CryptoValueProvider(RouteData routeData)
        {
            this.routeData = routeData;
        }

        public bool ContainsPrefix(string prefix)
        {
            var data = this.routeData.Values[prefix];
            if (data == null)
            {
                return false;
            }
            else
            {
                this.dictionary.Add(prefix, Base.Decrypt(data.ToString()));
            }
            return this.dictionary.ContainsKey(prefix);
        }

        public ValueProviderResult GetValue(string key)
        {
            ValueProviderResult result=null;
            if (this.dictionary.ContainsKey(key))
            {
                result = new ValueProviderResult(this.dictionary[key],
                this.dictionary[key], CultureInfo.CurrentCulture);
            }
                   
            return result;
        }
    }
}