# Cake.AWS.CloudFront
Cake Build addin for managing Amazon CloudFront CDN

[![Build status](https://ci.appveyor.com/api/projects/status/6b4ondpwl7unxrau?svg=true)](https://ci.appveyor.com/project/SharpeRAD/cake-aws-cloudfront)

[![cakebuild.net](https://img.shields.io/badge/WWW-cakebuild.net-blue.svg)](http://cakebuild.net/)

[![Join the chat at https://gitter.im/cake-build/cake](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/cake-build/cake)



## Table of contents

1. [Implemented functionality](https://github.com/SharpeRAD/Cake.AWS.CloudFront#implemented-functionality)
2. [Referencing](https://github.com/SharpeRAD/Cake.AWS.CloudFront#referencing)
3. [Usage](https://github.com/SharpeRAD/Cake.AWS.CloudFront#usage)
4. [Example](https://github.com/SharpeRAD/Cake.AWS.CloudFront#example)
5. [Plays well with](https://github.com/SharpeRAD/Cake.AWS.CloudFront#plays-well-with)
6. [License](https://github.com/SharpeRAD/Cake.AWS.CloudFront#license)
7. [Share the love](https://github.com/SharpeRAD/Cake.AWS.CloudFront#share-the-love)



## Implemented functionality

* Create Invalidation



## Referencing

[![NuGet Version](http://img.shields.io/nuget/v/Cake.AWS.CloudFront.svg?style=flat)](https://www.nuget.org/packages/Cake.AWS.CloudFront/)

Cake.AWS.CloudFront is available as a nuget package from the package manager console:

```csharp
Install-Package Cake.AWS.CloudFront
```

or directly in your build script via a cake addin directive:

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

A complete Cake example can be found [here](https://github.com/SharpeRAD/Cake.AWS.CloudFront/blob/master/test/build.cake).



## Plays well with

If your CloudFront distributions are linked to S3 buckets its worth checking out [Cake.AWS.S3](https://github.com/SharpeRAD/Cake.AWS.S3).

If your looking for a way to trigger cake tasks based on windows events or at scheduled intervals then check out [CakeBoss](https://github.com/SharpeRAD/CakeBoss).



## License

Copyright (c) 2015 - 2016 Phillip Sharpe

Cake.AWS.CloudFront is provided as-is under the MIT license. For more information see [LICENSE](https://github.com/SharpeRAD/Cake.AWS.CloudFront/blob/master/LICENSE).



## Share the love

If this project helps you in anyway then please :star: the repository.
