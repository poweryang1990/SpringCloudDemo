using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EurekaClient.Net.AppInfo;
using EurekaClient.Net.Util;
using Newtonsoft.Json;

namespace EurekaClient.Net.Transport
{
    public class EurekaHttpClient : IEurekaHttpClient
    {

        private string _serviceUrl;
        private IDictionary<string, string> _headers;

        private IEurekaClientConfig _config;

        protected HttpClient _client;


        public EurekaHttpClient(IEurekaClientConfig config, IDictionary<string, string> headers=null)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _headers = headers;
            _serviceUrl= MakeServiceUrl(_config.EurekaServerServiceUrls);
        }

      

        public async Task<EurekaHttpResponse> RegisterAsync(InstanceInfo info)
        {
            var client = GetHttpClient(_config);
            var requestUri = GetRequestUri(_serviceUrl + "apps/" + Uri.EscapeDataString(info.AppName));
            var request = GetRequestMessage(HttpMethod.Post, requestUri);

            request.Content = GetRequestContent(new JsonInstanceInfoRoot(info.ToJsonInstance()));

            using (HttpResponseMessage response = await client.SendAsync(request))
            {
                Trace.TraceInformation("RegisterAsync {0}, status: {1}", requestUri.ToString(), response.StatusCode);
                EurekaHttpResponse resp = new EurekaHttpResponse(response.StatusCode)
                {
                    Headers = response.Headers
                };
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    var jsonError = await response.Content.ReadAsStringAsync();
                    Trace.TraceInformation($"Something goes wrong in registering: {jsonError}");
                }

                return resp;
            }
        }


        public async Task<EurekaHttpResponse> CancelAsync(string appName, string id)
        {
            if (string.IsNullOrEmpty(appName))
            {
                throw new ArgumentException(nameof(appName));
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id));
            }

            HttpClient client = GetHttpClient(_config);
            var requestUri = GetRequestUri(_serviceUrl + "apps/" + Uri.EscapeDataString(appName)+ "/" + Uri.EscapeDataString(id));
            var request = GetRequestMessage(HttpMethod.Delete, requestUri);

            try
            {
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    Trace.TraceInformation("CancelAsync {0}, status: {1}", requestUri.ToString(), response.StatusCode);
                    EurekaHttpResponse resp = new EurekaHttpResponse(response.StatusCode)
                    {
                        Headers = response.Headers
                    };
                    return resp;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("CancelAsync Exception: {0}", e);
                throw;
            }
            finally
            {
                DisposeHttpClient(client);
            }
        }

        public async Task<EurekaHttpResponse<InstanceInfo>> SendHeartBeatAsync(string appName, string id, InstanceInfo info, InstanceStatus overriddenStatus)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            if (string.IsNullOrEmpty(appName))
            {
                throw new ArgumentException(nameof(appName));
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id));
            }

            var queryArgs = new Dictionary<string, string>()
            {
                { "status", info.Status.ToString() },
                { "lastDirtyTimestamp", DateTimeConversions.ToJavaMillis(new DateTime(info.LastDirtyTimestamp, DateTimeKind.Utc)).ToString() }
            };

            if (overriddenStatus != InstanceStatus.UNKNOWN)
            {
                queryArgs.Add("overriddenstatus", overriddenStatus.ToString());
            }

            HttpClient client = GetHttpClient(_config);
            var requestUri = GetRequestUri(_serviceUrl + "apps/" + Uri.EscapeDataString(info.AppName) + "/" + Uri.EscapeDataString(id), queryArgs);
            var request = GetRequestMessage(HttpMethod.Put, requestUri);

          
            try
            {
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    Stream stream = await response.Content.ReadAsStreamAsync();
                    JsonInstanceInfo jinfo = JsonInstanceInfo.Deserialize(stream);

                    InstanceInfo infoResp = null;
                    if (jinfo != null)
                    {
                        infoResp = InstanceInfo.FromJsonInstance(jinfo);
                    }

                    Trace.TraceInformation(
                        "SendHeartbeatAsync {0}, status: {1}, instanceInfo: {2}",
                        requestUri.ToString(),
                        response.StatusCode,
                        (infoResp != null) ? infoResp.ToString() : "null");
                    EurekaHttpResponse<InstanceInfo> resp = new EurekaHttpResponse<InstanceInfo>(response.StatusCode, infoResp)
                    {
                        Headers = response.Headers
                    };
                    return resp;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("SendHeartbeatAsync Exception: {0}", e);
                throw;
            }
            finally
            {
                DisposeHttpClient(client);
            }
        }

        public async Task<EurekaHttpResponse> StatusUpdateAsync(string appName, string id, InstanceStatus newStatus, InstanceInfo info)
        {
            if (string.IsNullOrEmpty(appName))
            {
                throw new ArgumentException(nameof(appName));
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id));
            }

            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            var queryArgs = new Dictionary<string, string>()
            {
                { "value", newStatus.ToString() },
                { "lastDirtyTimestamp", DateTimeConversions.ToJavaMillis(new DateTime(info.LastDirtyTimestamp, DateTimeKind.Utc)).ToString() }
            };

            HttpClient client = GetHttpClient(_config);
            var requestUri = GetRequestUri(_serviceUrl + "apps/" + Uri.EscapeDataString(appName) + "/" + Uri.EscapeDataString(id) + "/status", queryArgs);
            var request = GetRequestMessage(HttpMethod.Put, requestUri);


            try
            {
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    Trace.TraceInformation("StatusUpdateAsync {0}, status: {1}", requestUri.ToString(), response.StatusCode);
                    EurekaHttpResponse resp = new EurekaHttpResponse(response.StatusCode)
                    {
                        Headers = response.Headers
                    };
                    return resp;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("StatusUpdateAsync Exception: {0}", e);
                throw;
            }
            finally
            {
                DisposeHttpClient(client);
            }
        }

        public async Task<EurekaHttpResponse> DeleteStatusOverrideAsync(string appName, string id, InstanceInfo info)
        {
            if (string.IsNullOrEmpty(appName))
            {
                throw new ArgumentException(nameof(appName));
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id));
            }

            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            var queryArgs = new Dictionary<string, string>()
            {
                { "lastDirtyTimestamp", DateTimeConversions.ToJavaMillis(new DateTime(info.LastDirtyTimestamp, DateTimeKind.Utc)).ToString() }
            };

            HttpClient client = GetHttpClient(_config);
            var requestUri = GetRequestUri(_serviceUrl + "apps/" + Uri.EscapeDataString(appName) + "/" + Uri.EscapeDataString(id) + "/status", queryArgs);
            var request = GetRequestMessage(HttpMethod.Delete, requestUri);

            
            try
            {
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    Trace.TraceInformation("DeleteStatusOverrideAsync {0}, status: {1}", requestUri.ToString(), response.StatusCode);
                    EurekaHttpResponse resp = new EurekaHttpResponse(response.StatusCode)
                    {
                        Headers = response.Headers
                    };
                    return resp;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("DeleteStatusOverrideAsync Exception: {0}", e);
                throw;
            }
            finally
            {
                DisposeHttpClient(client);
            }
        }

        public async Task<EurekaHttpResponse<Applications>> GetApplicationsAsync(ISet<string> regions = null)
        {
            return await DoGetApplicationsAsync("apps/", regions);
        }

        public async Task<EurekaHttpResponse<Applications>> GetDeltaAsync(ISet<string> regions = null)
        {
            return await DoGetApplicationsAsync("apps/delta", regions);
        }

        public async Task<EurekaHttpResponse<Applications>> GetVipAsync(string vipAddress, ISet<string> regions = null)
        {
            if (string.IsNullOrEmpty(vipAddress))
            {
                throw new ArgumentException(nameof(vipAddress));
            }

            return await DoGetApplicationsAsync("vips/" + vipAddress, regions);
        }

        public async Task<EurekaHttpResponse<Applications>> GetSecureVipAsync(string secureVipAddress, ISet<string> regions = null)
        {
            if (string.IsNullOrEmpty(secureVipAddress))
            {
                throw new ArgumentException(nameof(secureVipAddress));
            }

            return await DoGetApplicationsAsync("vips/" + secureVipAddress, regions);
        }

        public async Task<EurekaHttpResponse<Application>> GetApplicationAsync(string appName)
        {
            if (string.IsNullOrEmpty(appName))
            {
                throw new ArgumentException(nameof(appName));
            }

            HttpClient client = GetHttpClient(_config);
            var requestUri = GetRequestUri(_serviceUrl + "apps/" + Uri.EscapeDataString(appName));
            var request = GetRequestMessage(HttpMethod.Get, requestUri);
            try
            {
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    Stream stream = await response.Content.ReadAsStreamAsync();
                    JsonApplicationRoot jroot = JsonApplicationRoot.Deserialize(stream);

                    Application appResp = null;
                    if (jroot != null)
                    {
                        appResp = Application.FromJsonApplication(jroot.Application);
                    }

                    Trace.TraceInformation(
                        "GetApplicationAsync {0}, status: {1}, application: {2}",
                        requestUri.ToString(),
                        response.StatusCode,
                        (appResp != null) ? appResp.ToString() : "null");
                    EurekaHttpResponse<Application> resp = new EurekaHttpResponse<Application>(response.StatusCode, appResp)
                    {
                        Headers = response.Headers
                    };
                    return resp;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("GetApplicationAsync Exception: {0}", e);
                throw;
            }
            finally
            {
                DisposeHttpClient(client);
            }
        }

        public async Task<EurekaHttpResponse<InstanceInfo>> GetInstanceAsync(string appName, string id)
        {
            if (string.IsNullOrEmpty(appName))
            {
                throw new ArgumentException(nameof(appName));
            }

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id));
            }

            return await DoGetInstanceAsync("apps/" + Uri.EscapeDataString(appName) + "/" + Uri.EscapeDataString(id));
        }

        public async Task<EurekaHttpResponse<InstanceInfo>> GetInstanceAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(nameof(id));
            }

            return await DoGetInstanceAsync("instances/" + Uri.EscapeDataString(id));
        }

  

        protected  async Task<EurekaHttpResponse<InstanceInfo>> DoGetInstanceAsync(string path)
        {
            var requestUri = GetRequestUri(_serviceUrl + path);
            var request = GetRequestMessage(HttpMethod.Get, requestUri);
            HttpClient client = GetHttpClient(_config);
            try
            {
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    Stream stream = await response.Content.ReadAsStreamAsync();
                    JsonInstanceInfoRoot jroot = JsonInstanceInfoRoot.Deserialize(stream);

                    InstanceInfo infoResp = null;
                    if (jroot != null)
                    {
                        infoResp = InstanceInfo.FromJsonInstance(jroot.Instance);
                    }

                    Trace.TraceInformation("DoGetInstanceAsync {0}, status: {1}, instanceInfo: {2}",requestUri.ToString(),response.StatusCode,(infoResp != null) ? infoResp.ToString() : "null");
                    EurekaHttpResponse<InstanceInfo> resp = new EurekaHttpResponse<InstanceInfo>(response.StatusCode, infoResp)
                    {
                        Headers = response.Headers
                    };
                    return resp;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("DoGetInstanceAsync Exception: {0}", e);
                throw;
            }
            finally
            {
                DisposeHttpClient(client);
            }
        }

        protected  async Task<EurekaHttpResponse<Applications>> DoGetApplicationsAsync(string path, ISet<string> regions)
        {
            string regionParams = CommaDelimit(regions);

            var queryArgs = new Dictionary<string, string>();
            if (regionParams != null)
            {
                queryArgs.Add("regions", regionParams);
            }

            HttpClient client = GetHttpClient(_config);
            var requestUri = GetRequestUri(_serviceUrl + path, queryArgs);
            var request = GetRequestMessage(HttpMethod.Get, requestUri);



            try
            {
                using (HttpResponseMessage response = await client.SendAsync(request))
                {
                    Stream stream = await response.Content.ReadAsStreamAsync();
                    JsonApplicationsRoot jroot = JsonApplicationsRoot.Deserialize(stream);

                    Applications appsResp = null;
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        if (jroot != null)
                        {
                            appsResp = Applications.FromJsonApplications(jroot.Applications);
                        }
                    }

                    Trace.TraceInformation( "DoGetApplicationsAsync {0}, status: {1}, applications: {2}",requestUri.ToString(),(appsResp != null) ? appsResp.ToString() : "null");
                    EurekaHttpResponse<Applications> resp = new EurekaHttpResponse<Applications>(response.StatusCode, appsResp)
                    {
                        Headers = response.Headers
                    };
                    return resp;
                }
            }
            catch (Exception e)
            {
                Trace.TraceError("DoGetApplicationsAsync Exception: {0}", e);
                throw;
            }
            finally
            {
                DisposeHttpClient(client);
            }
        }
        private  HttpClient GetHttpClient(IEurekaClientConfig config)
        {
            if (_client != null)
            {
                return _client;
            }

            return new HttpClient();
        }

        private string MakeServiceUrl(string eurekaServerUrls)
        {
            var url = new Uri(eurekaServerUrls).ToString();
            if (url[url.Length - 1] != '/')
            {
                url = url + '/';
            }

            return url;
        }

        private HttpRequestMessage GetRequestMessage(HttpMethod method, string requestUri)
        {
            var request = new HttpRequestMessage(method, requestUri);
            if (_headers!=null&&_headers.Count>0)
            {
                foreach (var header in _headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            request.Headers.Add("Accept", "application/json");
            return request;
        }

        private string GetRequestUri(string baseUri, IDictionary<string, string> queryValues = null)
        {
            string uri = baseUri;
            if (queryValues != null)
            {
                StringBuilder sb = new StringBuilder();
                string sep = "?";
                foreach (var kvp in queryValues)
                {
                    sb.Append(sep + kvp.Key + "=" + kvp.Value);
                    sep = "&";
                }

                uri = uri + sb.ToString();
            }

            return uri;
        }

        private HttpContent GetRequestContent(object toSerialize)
        {
            try
            {
                string json = JsonConvert.SerializeObject(toSerialize);
                Trace.TraceInformation("GetRequestContent generated JSON: {0}", json);
                return new StringContent(json, Encoding.UTF8, "application/json");
            }
            catch (Exception e)
            {
                Trace.TraceError("GetRequestContent Exception: {0}", e);
            }

            return new StringContent(string.Empty, Encoding.UTF8, "application/json");
        }
        private  void DisposeHttpClient(HttpClient client)
        {
            if (client == null)
            {
                return;
            }

            if (_client != client)
            {
                client.Dispose();
            }
        }

        private static string CommaDelimit(ICollection<string> toJoin)
        {
            if (toJoin == null || toJoin.Count == 0)
            {
                return null;
            }

            StringBuilder sb = new StringBuilder();
            string sep = string.Empty;
            foreach (var value in toJoin)
            {
                sb.Append(sep);
                sb.Append(value);
                sep = ",";
            }

            return sb.ToString();
        }

    }
}
