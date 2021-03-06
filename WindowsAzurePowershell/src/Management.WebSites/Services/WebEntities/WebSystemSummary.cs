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

namespace Microsoft.WindowsAzure.Management.Websites.Services.WebEntities
{
    using System.Runtime.Serialization;
    using Utilities;

    /// <summary>
    /// Class that represents a Web System summary.
    /// </summary>
    [DataContract(Namespace = UriElements.ServiceNamespace)]
    public class WebSystemSummary
    {
        /// <summary>
        /// Number of web workers
        /// </summary>
        [DataMember]
        public int NumberOfWebWorkers { get; set; }

        /// <summary>
        /// Number of publishers
        /// </summary>
        [DataMember]
        public int NumberOfPublishers { get; set; }

        /// <summary>
        /// Number of load balancers
        /// </summary>
        [DataMember]
        public int NumberOfLoadBalancers { get; set; }

        /// <summary>
        /// Number of controllers
        /// </summary>
        [DataMember]
        public int NumberOfControllers { get; set; }

        /// <summary>
        /// Number of active websites
        /// </summary>
        [DataMember]
        public int NumberOfActiveWebsites { get; set; }

    }
}
