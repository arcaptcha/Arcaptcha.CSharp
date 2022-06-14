<h1>Arcaptcha library for .NET</h1>
Arcaptcha for .NET is one of the most popular and well-documented Arcaptcha libraries used by thousands of .NET developers in their ASP.NET web applications. </a>.
<h2>Highlights</h2>
<p>The following are the highlights of the library:</p>
<ul>
    <li>Renders Arcaptcha widget and verifies Arcaptcha response with minimal amount of code</li>
    <li>Provides Arcaptcha web control (ASP.NET Web Forms for .NET Framework 4.5 and above</li>
    <li>Provides HTML helper to quickly render Arcaptcha widget (ASP.NET MVC 5 / ASP.NET Core 3.1 and above)
    <li>One of the most well-documented Arcaptcha libraries in the open source community</li>
</ul>
<h2>How to Use Arcaptcha for .NET: Step-by-Step</h2>
<h3>Creating a Arcaptcha API Key</h3>
<p>Before you can use Arcaptcha in your web application, you must first create a Arcaptcha API key (a pair of site and secret keys). Creating Arcaptcha API key is very straight-forward. Steps are explained <a href="https://arcaptcha.ir/sign-up">here</a></p>
<ol>
    <li>After Signing Up please copy <strong>Site Key</strong> and <strong>Secret Key</strong> which you would need to specify in your application's web.config file.</li>
</ol>
<h3>Installation</h3>
<p>The best and the recommended way to install the latest version of Arcaptcha for .NET is through Nuget. From the <a href="http://docs.nuget.org/consume/package-manager-console">Nuget's Package Manager Console</a> in your Visual Studio .NET IDE, simply execute the following command:</p>
<p>DotNet Framework</p>
<pre><code>PM&gt; Install-Package Arcaptcha.Net</code></pre>
<p>DotNet Core Framework</p>
<pre><code>PM&gt; Install-Package Arcaptcha.NetCore</code></pre>
<h3>Set Configuration</h3>
<p><strong>ASP.NET Web Forms / ASP.NET MVC 5</strong></p>
<p>In the <strong>appSettings</strong> section of your <strong>web.config</strong> file, add the following keys:</p>
<pre><code>&lt;appSettings&gt;
&lt;add key="ArcaptchaSiteKey" value="Your site key" /&gt;
&lt;add key="ArcaptchaSecretKey" value="Your secret key" /&gt;
&lt;add key="ArcaptchaVerificationUrl" value="Arcaptcha Verification URL (https://arcaptcha.co/2/siteverify)" /&gt;
&lt;add key="ArcaptchaWidgetScriptUrl" value="Arcaptcha widget script url (https://widget.arcaptcha.co/2/api.js)" /&gt;
&lt;/appSettings&gt;
</code></pre>
<p><strong>ASP.NET Core</strong></p>
<p>In <strong>appsettings.json</strong>, add the following JSON properties:</p>
<pre><code>"Arcaptcha":{ 
    "SiteKey": "Your site key",
    "SecretKey": "Your secret key",
    "VerificationUrl": "Arcaptcha Verification URL (https://arcaptcha.co/2/siteverify)",
    "WidgetScriptUrl": "Arcaptcha widget script url (https://widget.arcaptcha.co/2/api.js)"
} 
</code></pre>
<p>In the <strong>ConfigureServices</strong> method of the <strong>Startup</strong> class, add the following line of code:</p>
<pre><code class="language-cs">using Arcaptcha.NetCore.Configuration;
...
ArcaptchaConfigurationManager.SetConfiguration(Configuration);</pre></code>
<h3>Render Arcaptcha Widget</h3>
<p>You can either use the Arcaptcha.Net.UI.Controls.ArcaptchaWidget web control (ASP.NET Web Forms) or call the ArcaptchaWidget method of HTML helper (ASP.NET MVC 5 / ASP.NET Core) to render Arcaptcha widget:</p>
<p><strong>ASP.NET Web Forms</strong></p>
<pre><code>&lt;%@ Register Assembly="Arcaptcha.Net" Namespace="Arcaptcha.Net.UI.Controls" TagPrefix="cc1" %&gt;
...
&lt;cc1:ArcaptchaWidget ID="Arcaptcha1" runat="server" /&gt;
</code></pre>
<p><strong>ASP.NET MVC 5</strong></p>
<pre><code>@using Arcaptcha.Net.Mvc;</code></pre>

<p><strong>ASP.NET Core</strong></p>
<pre><code>@using Arcaptcha.NetCore.Mvc;</code></pre>

<p><strong>Both Asp .Net and ASP.NET Core</strong></p>
<pre><code>
...
@Html.ArcaptchaWidget()
</code></pre>

<p>The above code by default renders both the API script as well as the widget. There are times when you want to render the API script and the widget separately such as the need to render multiple widgets on a page. The following is an example of how to achieve this:</p>
<p><strong>ASP.NET Web Forms</strong></p>
<pre><code>&lt;%@ Register Assembly="Arcaptcha.Net" Namespace="Arcaptcha.Net.UI.Controls" TagPrefix="cc1" %&gt;
...
&lt;cc1:ArcaptchaApiScript ID="ArcaptchaApiScript1" runat="server" /&gt;
&lt;cc1:ArcaptchaWidget ID="ArcaptchaWidget1" RenderApiScript="false" runat="server" /&gt;
&lt;cc1:ArcaptchaWidget ID="ArcaptchaWidget2" RenderApiScript="false" runat="server" /&gt;
</code></pre>
<p><strong>ASP.NET MVC 5</strong></p>
<pre><code>@using Arcaptcha.Net.Mvc;</code></pre>

<p><strong>ASP.NET Core</strong></p>
<pre><code>@using Arcaptcha.NetCore.Mvc;</code></pre>

<p><strong>Both Asp .Net and ASP.NET Core</strong></p>
<pre><code>
...
@Html.ArcaptchaApiScript()
@Html.ArcaptchaWidget(rednderApiScript:false)
@Html.ArcaptchaWidget(rednderApiScript:false)
</code></pre>

<h3>Verify Arcaptcha Response</h3>
<p>When your end-user submits the form that contains the Arcaptcha widget, you can easily verify Arcaptcha response with few lines of code:</p>
<p><strong>ASP.NET Web Form</strong></p>
<pre><code class="language-cs">if (String.IsNullOrEmpty(Arcaptcha1.Response))
{
    lblMessage.Text = "Captcha cannot be empty.";
}
else
{
    var result = Arcaptcha1.Verify();
    if (result.Success)
    {
        Response.Redirect("Welcome.aspx");
    }
    else
    {
        lblMessage.Text = "Error(s): Challenge is not solved properly";
    }
}
</code></pre>
<p><strong>ASP.NET MVC 5 </strong></p>
<pre><code class="language-cs">using Arcaptcha.Net.Mvc;</code></pre>
<p><strong>ASP.NET Core</strong></p>
<pre><code class="language-cs">using Arcaptcha.NetCore.Mvc;</code></pre>

<p><strong>Both Asp .Net and ASP.NET Core</strong></p>
<pre><code>
...

if (this.VerifyArcaptchaResponse().Success)
{
ModelState.AddModelError("", "Incorrect captcha answer.");
}

//Or Method Two
ArcaptchaVerificationHelper ArcaptchaHelper = this.GetArcaptchaVerificationHelper();
if (String.IsNullOrEmpty(ArcaptchaHelper.Response))
{
ModelState.AddModelError("", "Captcha answer cannot be empty.");
return View(model);
}
ArcaptchaVerificationResult ArcaptchaResult = ArcaptchaHelper.VerifyArcaptchaResponse();
if (ArcaptchaResult.Success)
{
ModelState.AddModelError("", "Incorrect captcha answer.");
}

</code></pre>

<h2>Attributes</h2>
<p>The attributes are used to control the behavior and appearance of the Arcaptcha widget. They are specified in one of the three ways:</p>
<ul>
    <li>As API parameters (ASP.NET MVC and ASP.NET Core helper methods)</li>
    <li>As properties of a web control (ASP.NET Web Control)</li>
    <li>Configuration (web.config / appsettings.json)
</ul>
<p>Assigning a value through method or property takes precedence over configuration. Of course, you don't need to set any attribute anywhere unless its requried. The following is the entire list of the attributes:</p>
<table>
    <tr>
        <th>Attribute</th>
        <th>Description</th>
        <th>Type</th>
        <th>Values</th>
        <th>Default Value</th>
        <th>Configuration Key</th>
        <th>Required</th>
    </tr>    
    <tr>
        <td><strong>Site Key</strong></td>
        <td>Site key for Arcaptcha. It is required for rendering the widget.</td>
        <td><code>String</code></td>        
        <td><em>The site key associated with the site you register in <a href="https://www.google.com/Arcaptcha/admin">Google Arcaptcha Admin Console</a>.</em></td>
        <td><em>No default value. Must be provided.</em</td>
        <td><code>SiteKey</td>
        <td>Yes</td>
    </tr>    
    <tr>
        <td><strong>Secret Key</strong></td>
        <td>Secret key for the Arcaptcha. It is required for verifying Arcaptcha response.</td>
        <td><code>String</code></td>
        <td><em>The secret key associated with the site you register in <a href="https://www.google.com/Arcaptcha/admin">Google Arcaptcha Admin Console</a>.</em></td>
        <td><em>No default value. Must be provided.</em</td>
        <td><code>SecretKey</td>
        <td>Yes</td>
    </tr>      
    <tr>
        <td><strong>Verification URL</strong></td>
        <td>Arcaptcha URL to be called in back-end and check wether challenge is solved properly or not</td>
        <td><code>String</code></td>
        <td>-</td>
        <td>No default value. Must be provided.</td>
        <td><code>VerificationUrl</td>
        <td>Yes</td>
    </tr>      
    <tr>
        <td><strong>Widget Script URL</strong></td>
        <td>Arcaptcha URL from which front-end scripts are downloaded</td>
        <td><code>String</code></td>
        <td>-</td>
        <td>No default value. Must be provided.</td>
        <td><code>ArcaptchaLanguage</code></td>
        <td>Yes</td>
    </tr>    
</table>
<h2>Tooling</h2>
<p>The current version of the repo is created using <a href="https://visualstudio.microsoft.com/vs/community/">Microsoft Visual Studio 2019 Community Edition</a> with <a href="https://dotnet.microsoft.com/download/dotnet-framework/net45" target="_blank">.NET Framework 4.5</a> and <a href="https://dotnet.microsoft.com/download/dotnet-core/3.1">.NET Core 3.1</a> as compilation targets.
<h2>Issues</h2>
If you find a bug in the library or you have an idea about a new feature, please try to search in the existing list of <a href="https://github.com/masoud-aut-ac/Arcaptcha.CSharp/issues">issues</a>. If the bug or idea is not listed and addressed there, please <a href="https://github.com/masoud-aut-ac/Arcaptcha.CSharp/issues/new">open a new issue</a>.
