# Cake.AWS.CloudFront
Cake Build addon for managing Amazon CloudFront CDN

[![Build status](https://ci.appveyor.com/api/projects/status/4ymtu0it99v31726?svg=true)](https://ci.appveyor.com/project/PhillipSharpe/cake-aws-s3)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)



## Implemented functionality

* Create Invalidation



## Referencing

[![NuGet Version](http://img.shields.io/nuget/v/Cake.AWS.CloudFront.svg?style=flat)](https://www.nuget.org/packages/Cake.AWS.CloudFront/) [![NuGet Downloads](http://img.shields.io/nuget/dt/Cake.AWS.CloudFront.svg?style=flat)](https://www.nuget.org/packages/Cake.AWS.CloudFront/)

Cake.AWS.CloudFront is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.AWS.CloudFront
```

or directly in your build script via a cake addin:

```csharp
#addin "Cake.AWS.CloudFront"
```



## Usage

```csharp
#addin "Cake.AWS.CloudFront"

Task("Invalidate-Object")
    .Description("Invalidates a CloudFront object")
    .Does(() =>
{
    CreateInvalidation("distributionId", "item", new CloudFrontSettings()
    {
        AccessKey = "blah",
        SecretKey = "blah",

        Region = RegionEndpoint.EUWest1
    });
});

RunTarget("Invalidate-Object");
```



## Example

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.AWS.CloudFront/blob/master/test/build.cake)
