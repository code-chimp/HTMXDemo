# The nAHA Stack
## ASP.NET, HTMX, and Alpine.js

A mostly derivative work by a lesser member of the family of great coding apes - or my personal riff on the excellent [AHA Stack](https://ahastack.dev/) by [Flavio][flav].

### The idea

The goal is to create a fairly realistic example of a current Razor Pages application and
progressively enhance the frontend performance with a combination of **[HTMX][htmx]** and **[Alpine.js][alp]**.

### Why "nAHA"?

1. [Flavio][flav] already coined the term **"The AHA Stack"**, [in early January of 2024](https://flaviocopes.com/the-aha-stack/), for his novel combination of **[Astro](https://astro.build)**, **[HTMX][htmx]** and **[Alpine.js][alp]**.
2. The OG .NET community's habit of slapping an "n" in front of everything and calling it <b>Product<sup>tm</sup></b>

### Prerequisites

- [libman](https://learn.microsoft.com/en-us/aspnet/core/client-side/libman/libman-cli) - improved client-side library management for ASP.NET Core

### Start with a standard ASP.NET Razor Pages project

1. Cleanup the starter template
   1. Remove `app.UseHttpsRedirection();` from **Program.cs** - let the server handle it
   2. Likewise remove the **https** profile from `$ProjectRoot/Properties/launchSettings.json` 
   3. While we are in **launchSettings** change the default port to **5000**
   4. Remove the partial `$ProjectRoot/Pages/Shared/_ValidationScriptsPartial.cshtml` (YAGNI)
   5. From `$ProjectRoot/wwwroot/lib` remove all **jQuery** and **Bootstrap** folders
      - We will be using the latest **Bootstrap** via **NuGet**
      - jQuery functionality will be replaced by the combination of **[htmx][htmx]** and **[Alpine.js][alp]**
2. Install **NuGet** packages
   - Alpine.TagHelpers
   - Htmx
   - Htmx.TagHelpers
3. Update `$ProjectRoot/Pages/_ViewImports.cshtml` to include the new tag helpers
   ```csharp
   @addTagHelper *, Alpine.TagHelpers
   @addTagHelper *, Htmx.TagHelpers
   ```
4. Add additional client-side libraries with [libman](https://devblogs.microsoft.com/dotnet/library-manager-client-side-content-manager-for-web-apps/)
   - Accept the default cdn, **cdnjs**
   - Accept the default destination, **wwwroot/lib**
     ```powershell
     libman init
     libman install alpinejs
     libman install bootstrap
     libman install font-awesome
     libman install htmx
     ```
5. Update `$ProjectRoot/Pages/_Layout.cshtml` - correct links and add resources
   - In the **head** section fix bootstrap link, add font-awesome link, and add a section for head-scripts (primarily for Alpine.js)
     ```csharp
     ...
     <head>
         <meta charset="utf-8"/>
         <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
         <title>@ViewData["Title"] - nAHA Demo</title>
         <link rel="stylesheet" href="~/lib/bootstrap/css/bootstrap.min.css"/>
         <link rel="stylesheet" href="~/lib/font-awesome/css/all.min.css"/>
         <link rel="stylesheet" href="~/css/site.css" asp-append-version="true"/>
         @await RenderSectionAsync("Head", required: false)
     </head>
     ...
     ```
   - At the bottom of the **body** section, remove **jQuery** and **site.js** scripts
   - Fix the **bootstrap** JavaScript bundle script tag, and add the **htmx** script tag
     ```csharp
     ...
     <script src="~/lib/bootstrap/js/bootstrap.bundle.min.js"></script>
     <script src="~/lib/htmx/htmx.min.js"></script>
     @await RenderSectionAsync("Scripts", required: false)
     </body>
     </html>
     ```
6. Grab a [Bootstrap template](https://getbootstrap.com/docs/5.3/examples/) to start, and modify the `$ProjectRoot/Pages/_Layout.cshtml` markup to match


# Reference

- [htmx][htmx] - htmx homepage
- [Hypermedia Systems](https://hypermedia.systems/book/contents/) - A book about HTMX
- [HTMX for ASP.NET Core Developers](https://www.youtube.com/watch?v=uS6m37jhdqM) - JetBrains' multipart HTMX tutorialº
- [Alpine.js Tutorial](https://thevalleyofcode.com/alpine/) - A tutorial on how to enable clientside functionality with Alpine.js
- [The AHA Stack](https://ahastack.dev/) - The original AHA Stack by Flavio



[alp]: https://alpinejs.dev/ "Alpine.js homepage"
[flav]: https://flaviocopes.com/ "Flavio helps people learn to code"
[htmx]: https://htmx.org/ "htmx homepage"
