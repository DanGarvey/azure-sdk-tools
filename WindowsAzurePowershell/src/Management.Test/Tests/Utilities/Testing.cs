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

namespace Microsoft.WindowsAzure.Management.Test.Tests.Utilities
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Various utilities and helpers to facilitate testing.
    /// </summary>
    /// <remarks>
    /// The name is a compromise for something that pops up easily in
    /// intellisense when using MSTest.
    /// </remarks>
    internal static class Testing
    {
        /// <summary>
        /// Ensure an action throws a specific type of Exception.
        /// </summary>
        /// <typeparam name="T">Expected exception type.</typeparam>
        /// <param name="action">
        /// The action that should throw when executed.
        /// </param>
        public static void AssertThrows<T>(Action action)
            where T : Exception
        {
            Debug.Assert(action != null);
            
            try
            {
                action();
                Assert.Fail("No exception was thrown!");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(T));
            }
        }

        /// <summary>
        /// Ensure an action throws a specific type of Exception.
        /// </summary>
        /// <typeparam name="T">Expected exception type.</typeparam>
        /// <param name="action">
        /// The action that should throw when executed.
        /// </param>
        /// <param name="expectedMessage">
        /// Expected exception message.
        /// </param>
        public static void AssertThrows<T>(Action action, string expectedMessage)
            where T : Exception
        {
            Debug.Assert(action != null);

            try
            {
                action();
                Assert.Fail("No exception was thrown!");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(T));
                Assert.AreEqual(ex.Message, expectedMessage);
            }
        }
        
        /// <summary>
        /// Ensure an action throws a specific type of Exception.
        /// </summary>
        /// <typeparam name="T">Expected exception type.</typeparam>
        /// <param name="action">
        /// The action that should throw when executed.
        /// </param>
        /// <param name="verification">
        /// Additional verification to perform on the exception.
        /// </param>
        public static void AssertThrows<T>(Action action, Action<T> verification)
            where T : Exception
        {
            Debug.Assert(action != null);
            Debug.Assert(verification != null);
            
            try
            {
                action();
                Assert.Fail("No exception was thrown!");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(T));
                verification(ex as T);
            }
        }
        
        /// <summary>
        /// Get the path to a file included in the test project as something to
        /// be copied on Deployment (see Local.testsettings > Deployment for
        /// examples).
        /// </summary>
        /// <param name="relativePath">Relative path to the resource.</param>
        /// <returns>Path to the resource.</returns>
        public static string GetTestResourcePath(string relativePath)
        {
            string path = Path.Combine(Environment.CurrentDirectory, relativePath);
            Assert.IsTrue(File.Exists(path));
            return path;
        }
    }
}
