using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using Microsoft.Owin;
using Umbraco.Web.WebApi;

namespace Umbraco.RestApi.Controllers
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class DynamicCorsAttribute : Attribute, ICorsPolicyProvider
    {
        /// <summary>
        /// Gets the <see cref="T:System.Web.Cors.CorsPolicy"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="T:System.Web.Cors.CorsPolicy"/>.
        /// </returns>
        /// <param name="request">The request.</param><param name="cancellationToken">The cancellation token.</param>
        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Task.FromResult(UmbracoRestApiOptionsInstance.Options.CorsPolicy);
        }
    }
}