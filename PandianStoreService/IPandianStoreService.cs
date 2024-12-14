using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PandianStoreService
{
    [ServiceContract]
    public interface IPandianStoreService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "getService/{str_PageName}/{str_param}",
                BodyStyle = WebMessageBodyStyle.Wrapped)]
        string GetServiceCall(string str_PageName, string str_param);

        [WebInvoke(Method = "POST", ResponseFormat = WebMessageFormat.Json, UriTemplate = "PostService/",
                BodyStyle = WebMessageBodyStyle.Wrapped)]
        string PostServiceCall(string str_PageName, string str_param);

    }
}
