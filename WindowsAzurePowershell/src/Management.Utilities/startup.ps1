﻿# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

Write-Host `
"For a list of all Azure cmdlets type 'help azure'.
For Node.js cmdlets type 'help node-dev'.
For PHP cmdlets type 'help php-dev'.
For Python cmdlets type 'help python-dev'."

# Common alias
New-Alias Get-WAPackPublishSettingsFile Get-AzurePublishSettingsFile
New-Alias Get-WAPackSubscription Get-AzureSubscription
New-Alias Import-WAPackPublishSettingsFile Import-AzurePublishSettingsFile
New-Alias Remove-WAPackSubscription Remove-AzureSubscription
New-Alias Select-WAPackSubscription Select-AzureSubscription
New-Alias Set-WAPackSubscription Set-AzureSubscription
New-Alias Show-WAPackPortal Show-AzurePortal
New-Alias Test-WAPackName Test-AzureName
New-Alias Get-WAPackEnvironment  Get-AzureEnvironment

# Websites alias
New-Alias New-WAPackWebsite New-AzureWebsite
New-Alias Get-WAPackWebsite Get-AzureWebsite
New-Alias Set-WAPackWebsite Set-AzureWebsite
New-Alias Remove-WAPackWebsite Remove-AzureWebsite
New-Alias Start-WAPackWebsite Start-AzureWebsite
New-Alias Stop-WAPackWebsite Stop-AzureWebsite
New-Alias Restart-WAPackWebsite Restart-AzureWebsite
New-Alias Show-WAPackWebsite Show-AzureWebsite
New-Alias Get-WAPackWebsiteLog Get-AzureWebsiteLog
New-Alias Save-WAPackWebsiteLog Save-AzureWebsiteLog
New-Alias Get-WAPackWebsiteLocation Get-AzureWebsiteLocation
New-Alias Get-WAPackWebsiteDeployment Get-AzureWebsiteDeployment
New-Alias Restore-WAPackWebsiteDeployment Restore-AzureWebsiteDeployment
New-Alias Enable-WAPackWebsiteApplicationDiagnositc Enable-AzureWebsiteApplicationDiagnositc
New-Alias Disable-AzureWebsiteApplicationDiagnositc Disable-AzureWebsiteApplicationDiagnositc

# Service Bus alias
New-Alias Get-WAPackSBLocation Get-AzureSBLocation
New-Alias Get-WAPackSBNamespace Get-AzureSBNamespace
New-Alias New-WAPackSBNamespace New-AzureSBNamespace
New-Alias Remove-WAPackSBNamespace Remove-AzureSBNamespace