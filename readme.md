![cover](https://dka575ofm4ao0.cloudfront.net/assets/pages/front-facing/contact/logo_on_light-96a80116859e63816abaebc51a42f110.png)
---
[![release 1.0.0](http://img.shields.io/badge/release-1.0.0-green.svg)](https://github.com/TaskForce47/arma2net-statuspage-io-plugin/releases/)
[![download 11 kb](http://img.shields.io/badge/download-11%20kb-blue.svg)](https://github.com/TaskForce47/arma2net-statuspage-io-plugin/releases/download/1.0/StatusPageIO.dll)
[![license GPLv3](http://img.shields.io/badge/license-GPLv3-red.svg)](http://www.gnu.de/documents/gpl.de.html)

# arma2net-statuspage-io-plugin

A arma2net plugin that allows you to stream data to [statuspage.io](https://www.statuspage.io/)

Through [HttpClient](http://msdn.microsoft.com/library/system.net.http.httpclient.aspx) and the [StatusPage.io metric API](http://doers.statuspage.io/api/v1/metrics/) can arma2net-statuspage-io-plugin stream Information to [statuspage.io](https://www.statuspage.io/).

E.g. Adding this line will Stream data to StatusPage.io 
```
StatusPageIO ["50","test"]
```

---
# Instructions

1. Download arma2net [here](https://bitbucket.org/Scott_NZ/arma2net/overview)
2. Install the dependencies of arma2net
3. Download arma2net-statuspage-io-plugin [here](https://github.com/TaskForce47/arma2net-statuspage-io-plugin/releases/)
4. Put the StatusPageIO.dll in @Arma2NET\AddIns\StatusPageio\
5. Start your server and run the plugin once it will generate a configfile. See below:
>     <?xml version="1.0" encoding="utf-8"?>
>     <StatusPageIOConfigurationList xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
>      <Configurations>
>       <StatusPageIOConfiguration>
>        <ApiKey>f8qhkhb0htxeq2zlvs8fnc2ngbjgxvhtgioxhvafe7q82rgl1oo1wsgjq8pgihbf</ApiKey>
>        <PageId>hp70fhj5gmyv</PageId>
>        <MetricId>6ehcxbf18iw4</MetricId>
>        <BaseUri>https://api.statuspage.io/v1</BaseUri>
>        <Identifier>test</Identifier>
>       </StatusPageIOConfiguration>
>      </Configurations>
>     </StatusPageIOConfigurationList>


# Roadamp

- we will see what comes next. :)

# Version 1.0.0

[12.12.2014] Initial release.

# Next features

Request them [here](https://github.com/TaskForce47/arma2net-statuspage-io-plugin/issues) !