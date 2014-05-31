using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Deserializers;

namespace JustGiving.WP8.Repository
{
    public static class RestSharpExtension
    {
        private static Task<T> ExecuteAsyncTask<T>(this RestClient restClient, IRestRequest request, Func<IRestResponse, T> selector)
        {
            var task = new TaskCompletionSource<T>();            
            var response = restClient.ExecuteAsync(request, r =>
            {
                if (r.ErrorException == null)
                {
                    task.SetResult(selector(r));                    
                }
                else
                {
                    task.SetException(r.ErrorException);
                }
            });

            return task.Task;
        }

        public static Task<string> GetContentAsync(this RestClient restClient, IRestRequest request)
        {
            return restClient.ExecuteAsyncTask(request, r => r.Content);
        }

        public static Task<IRestResponse> GetResponseAsync(this RestClient restClient, IRestRequest request)
        {
            return restClient.ExecuteAsyncTask(request, r => r);
        }
    }
}
