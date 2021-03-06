﻿// ----------------------------------------------------------------------------------
//
// Copyright 2011 Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Management.Websites.Test.UnitTests.Cmdlets
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Management.Services;
    using Management.Test.Stubs;
    using Management.Test.Tests.Utilities;
    using Microsoft.WindowsAzure.Management.Utilities;
    using Model;
    using Utilities;
    using VisualStudio.TestTools.UnitTesting;
    using Websites.Cmdlets;
    using Websites.Services.WebEntities;

    [TestClass]
    public class SetAzureWebsiteTests
    {
        [TestInitialize]
        public void SetupTest()
        {
            GlobalPathInfo.AzureAppDir = Path.Combine(Directory.GetCurrentDirectory(), "Windows Azure Powershell");
            Extensions.CmdletSubscriptionExtensions.SessionManager = new InMemorySessionManager();
        }

        [TestMethod]
        public void SetAzureWebsiteProcess()
        {
            const string websiteName = "website1";
            const string webspaceName = "webspace";

            // Setup
            bool updatedSite = false;
            bool updatedSiteConfig = false;
            SimpleWebsitesManagement channel = new SimpleWebsitesManagement();

            Site site = new Site {Name = websiteName, WebSpace = webspaceName};
            SiteConfig siteConfig = new SiteConfig { NumberOfWorkers = 1};
            channel.GetWebSpacesThunk = ar => new WebSpaces(new List<WebSpace> { new WebSpace { Name = webspaceName } });
            channel.GetSitesThunk = ar => new Sites(new List<Site> { site });
            channel.GetSiteThunk = ar => site;
            channel.GetSiteConfigThunk = ar => siteConfig;
            channel.UpdateSiteConfigThunk = ar =>
            {
                Assert.AreEqual(webspaceName, ar.Values["webspaceName"]);
                SiteConfig website = ar.Values["siteConfig"] as SiteConfig;
                Assert.IsNotNull(website);
                Assert.AreEqual(website.NumberOfWorkers, 3);
                siteConfig.NumberOfWorkers = website.NumberOfWorkers;
                updatedSiteConfig = true;
            };

            channel.UpdateSiteThunk = ar =>
            {
                Assert.AreEqual(webspaceName, ar.Values["webspaceName"]);
                Site website = ar.Values["site"] as Site;
                Assert.IsNotNull(website);
                Assert.AreEqual(websiteName, website.Name);
                Assert.IsTrue(website.HostNames.Any(hostname => hostname.Equals(websiteName + General.AzureWebsiteHostNameSuffix)));
                Assert.IsNotNull(website.HostNames.Any(hostname => hostname.Equals("stuff.com")));
                site.HostNames = website.HostNames;
                updatedSite = true;
            };

            // Test
            SetAzureWebsiteCommand setAzureWebsiteCommand = new SetAzureWebsiteCommand(channel)
            {
                ShareChannel = true,
                CommandRuntime = new MockCommandRuntime(),
                Name = websiteName,
                CurrentSubscription = new SubscriptionData { SubscriptionId = "SetAzureWebSiteTests_SetAzureWebsiteProcess1" },
                NumberOfWorkers = 3
            };

            setAzureWebsiteCommand.ExecuteCommand();
            Assert.IsTrue(updatedSiteConfig);
            Assert.IsFalse(updatedSite);

            // Test updating site only and not configurations
            updatedSite = false;
            updatedSiteConfig = false;
            setAzureWebsiteCommand = new SetAzureWebsiteCommand(channel)
            {
                ShareChannel = true,
                CommandRuntime = new MockCommandRuntime(),
                Name = websiteName,
                CurrentSubscription = new SubscriptionData { SubscriptionId = "SetAzureWebSiteTests_SetAzureWebsiteProcess2" },
                HostNames = new [] { "stuff.com" }
            };

            setAzureWebsiteCommand.ExecuteCommand();
            Assert.IsFalse(updatedSiteConfig);
            Assert.IsTrue(updatedSite);
        }
    }
}
