using Arcaptcha.NetCore.Configuration;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Arcaptcha.NetCore
{
    /// <summary>
    /// Represents the functionality for verifying user's response to the Arcaptcha challenge.
    /// </summary>
    public class ArcaptchaVerificationHelper
    {
        #region Fields
        private static readonly HttpClient _client;
        #endregion
        #region Constructors

        static ArcaptchaVerificationHelper()
        {
            _client = new HttpClient();
        }
        private ArcaptchaVerificationHelper()
        { }

        /// <summary>
        /// Creates an instance of the <see cref="ArcaptchaVerificationHelper"/> class.
        /// </summary>
        /// <param name="secretKey">Sets the secret key of the Arcapcha verification request.</param>
        /// <param name="siteKey">Sets the site key of the Arcapcha verification request.</param>
        /// <param name="verificationUrl">Sets the verification Url of the Arcapcha verification request.</param>
        internal ArcaptchaVerificationHelper(HttpContext httpContext, string secretKey, string siteKey, string verificationUrl)
        {
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Secret key cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(siteKey))
            {
                throw new InvalidOperationException("Site key cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(verificationUrl))
            {
                throw new InvalidOperationException("Verification URL cannot be null or empty.");
            }

            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            var request = httpContext.Request;


            SecretKey = secretKey;
            SiteKey = siteKey;
            VerificationUrl = verificationUrl.StartsWith("http") ? verificationUrl : "https://" + verificationUrl;
            Response = request.Form["arcaptcha-response"];
        }

        #endregion Constructors

        #region Properties
        /// <summary>
        /// Gets the secret key of the Arcaptcha verification request.
        /// </summary>
        public string SecretKey
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the site key of the Arcaptcha verification request.
        /// </summary>
        public string SiteKey
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the verification URL of the Arcaptcha verification request.
        /// </summary>
        public string VerificationUrl
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the user's response to the Arcaptcha challenge of the Arcaptcha verification request.
        /// </summary>
        public string Response
        {
            get;
            private set;
        }

        #endregion Properties

        #region Public Methods
        /// <summary>
        /// Verifies whether the user's response to the Arcaptcha request is correct.
        /// </summary>
        /// <returns>Returns the result as a value of the <see cref="ArcaptchaVerificationResult"/> enum.</returns>
        public ArcaptchaVerificationResult VerifyArcaptchaResponse()
        {
            string postData = $"{{ \"secret\": \"{SecretKey}\",\"response\":\"{Response}\",\"sitekey\":\"{SiteKey}\"}}";

            var content = new StringContent(postData, Encoding.UTF8, "application/json");

            var result = _client.PostAsync(VerificationUrl, content).Result;

            var resString = result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ArcaptchaVerificationResult>(resString);
        }

        /// <summary>
        /// Verifies whether the user's response to the Arcaptcha request is correct.
        /// </summary>
        /// <returns>Returns the result as a value of the <see cref="ArcaptchaVerificationResult"/> enum.</returns>
        public Task<ArcaptchaVerificationResult> VerifyArcaptchaResponseAsync()
        {
            return Task.Run(() => VerifyArcaptchaResponse());
        }

        #endregion Public Methods

    }
}
