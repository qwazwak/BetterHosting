﻿![Logo of BetterHosting](https://github.com/Qwazwak/BetterHosting/raw/master/Library/logo/logo.png)

# BetterHosting

An unofficial wrapper for [DSharpPlus](https://github.com/DSharpPlus/DSharpPlus), but able to be used in a more standard hosting model.
No relation to [DSharpPlus](https://github.com/DSharpPlus/DSharpPlus)

# Installing

You can install the library from following sources:

1. All Nightly versions are available on [Nuget](https://www.nuget.org/packages/BetterHosting/) as a pre-release. These are cutting-edge versions automatically built from the latest commit in the `master` branch in this repository, and as such always contains the latest changes. If you want to use the latest features on Discord, you should use the nightlies.

   Despite the nature of pre-release software, all changes to the library are held under a level of scrutiny; for this library, unstable does not mean bad quality, rather it means that the API can be subject to change without prior notice (to ease rapid iteration) and that consumers of the library should always remain on the latest version available (to immediately get the latest fixes and improvements). You will usually want to use this version.

2. The latest stable release is always available on [NuGet](https://nuget.org/packages/BetterHosting). Stable versions are released less often, but are guaranteed to not receive any breaking API changes without a major version bump.

   Critical bugfixes in the nightly releases will usually be backported to the latest major stable release, but only after they have passed our soak tests. Additionally, some smaller fixes may be infrastructurally impossible or very difficult to backport without "breaking everything", and as such they will remain only in the nightly release until the next major release. You should evaluate whether or not this version suits your specific needs.

3. The library can be directly referenced from your csproj file. Cloning the repository and referencing the library is as easy as:

    ```
    git clone https://github.com/Qwazwak/BetterHosting.git BetterHosting_Repo
    ```

    Edit MyProject.csproj and add the following line:

    ```xml
    <ProjectReference Include="../BetterHosting_Repo/BetterHosting/BetterHosting.csproj" />
    ```

    This belongs in the ItemGroup tag with the rest of your dependencies. The library should not be in the same directory or subdirectory as your project. This method should only be used if you're making local changes to the library.

## Resources
* Take some reference to the [DSharpPlus library documentation](https://dsharpplus.github.io/DSharpPlus/articles/basics/bot_account.html), but don't treat it as gospel. Use it as API reference.
* For architecture, take a look at any .NET guide using the IHost model, [here is one example from a blog I often reference at my day job.](https://andrewlock.net/exploring-the-dotnet-8-preview-comparing-createbuilder-to-the-new-createslimbuilder-method/).

### Example bots

* [Example by Qwazwak](https://github.com/Qwazwak/BetterHosting) (currently a part of this repo, but eventually Freddy will be split off

# Questions?

I have not setup any chats yet, so lets talk here on GitHub!