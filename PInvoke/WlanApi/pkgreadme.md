﻿![Vanara](https://raw.githubusercontent.com/dahall/Vanara/master/docs/icons/VanaraHeading.png)
### **Vanara.PInvoke.WlanApi NuGet Package**
[![Version](https://img.shields.io/nuget/v/Vanara.PInvoke.WlanApi?label=NuGet&style=flat-square)](https://github.com/dahall/Vanara/releases)
[![Build status](https://img.shields.io/appveyor/build/dahall/vanara?label=AppVeyor%20build&style=flat-square)](https://ci.appveyor.com/project/dahall/vanara)

PInvoke API (methods, structures and constants imported from Windows WlanApi.dll.

### **What is Vanara?**

[Vanara](https://github.com/dahall/Vanara) is a community project that contains various .NET assemblies which have P/Invoke functions, interfaces, enums and structures from Windows libraries. Each assembly is associated with one or a few tightly related libraries.

### **Issues?**

First check if it's already fixed by trying the [AppVeyor build](https://ci.appveyor.com/nuget/vanara-prerelease).
If you're still running into problems, file an [issue](https://github.com/dahall/Vanara/issues).

### **Included in Vanara.PInvoke.WlanApi**

Functions | Enumerations | Structures | Interfaces
--- | --- | --- | ---
WFDCancelOpenSession WFDCloseHandle WFDOpenHandle WFDOpenLegacySession WFDStartOpenSession WFDUpdateDeviceVisibility WlanAllocateMemory WlanCloseHandle WlanConnect WlanDeleteProfile WlanDeviceServiceCommand WlanDisconnect WlanEnumInterfaces WlanExtractPsdIEDataList WlanFreeMemory WlanGetAvailableNetworkList WlanGetFilterList WlanGetInterfaceCapability WlanGetNetworkBssList WlanGetProfile WlanGetProfileCustomUserData WlanGetProfileList WlanGetSecuritySettings WlanGetSupportedDeviceServices WlanHostedNetworkForceStart WlanHostedNetworkForceStop WlanHostedNetworkInitSettings WlanHostedNetworkQueryProperty WlanHostedNetworkQuerySecondaryKey WlanHostedNetworkQueryStatus WlanHostedNetworkRefreshSecuritySettings WlanHostedNetworkSetProperty WlanHostedNetworkSetSecondaryKey WlanHostedNetworkStartUsing WlanHostedNetworkStopUsing WlanIhvControl WlanOpenHandle WlanQueryAutoConfigParameter WlanQueryInterface WlanReasonCodeToString WlanRegisterDeviceServiceNotification WlanRegisterNotification WlanRegisterVirtualStationNotification WlanRenameProfile WlanSaveTemporaryProfile WlanScan WlanSetAutoConfigParameter WlanSetFilterList WlanSetInterface WlanSetProfile WlanSetProfileCustomUserData WlanSetProfileEapUserData WlanSetProfileEapXmlUserData WlanSetProfileList WlanSetProfilePosition WlanSetPsdIEDataList WlanSetSecuritySettings WlanUIEditProfile  | DOT11_ADHOC_AUTH_ALGORITHM DOT11_ADHOC_CIPHER_ALGORITHM DOT11_ADHOC_CONNECT_FAIL_REASON DOT11_ADHOC_NETWORK_CONNECTION_STATUS ONEX_AUTH_IDENTITY ONEX_AUTH_MODE ONEX_AUTH_RESTART_REASON ONEX_AUTH_STATUS ONEX_EAP_METHOD_BACKEND_SUPPORT ONEX_NOTIFICATION_TYPE ONEX_REASON_CODE ONEX_SUPPLICANT_MODE DOT11_AUTH_ALGORITHM DOT11_BSS_TYPE DOT11_CIPHER_ALGORITHM DOT11_OPERATION_MODE DOT11_PHY_TYPE DOT11_RADIO_STATE WL_DISPLAY_PAGES WLAN_ACCCESS WLAN_ADHOC_NETWORK_STATE WLAN_AUTOCONF_OPCODE WLAN_AVAILABLE_NETWORK_FLAGS WLAN_CONNECTION_FLAGS WLAN_CONNECTION_MODE WLAN_CONNECTION_NOTIFICATION WLAN_FILTER_LIST_TYPE WLAN_HOSTED_NETWORK_NOTIFICATION_CODE WLAN_HOSTED_NETWORK_OPCODE WLAN_HOSTED_NETWORK_PEER_AUTH_STATE WLAN_HOSTED_NETWORK_REASON WLAN_HOSTED_NETWORK_STATE WLAN_IHV_CONTROL_TYPE WLAN_INTERFACE_STATE WLAN_INTERFACE_TYPE WLAN_INTF_OPCODE WLAN_NOTIFICATION_ACM WLAN_NOTIFICATION_MSM WLAN_NOTIFICATION_SOURCE WLAN_OPCODE_VALUE_TYPE WLAN_POWER_SETTING WLAN_PROFILE_FLAGS WLAN_REASON_CODE WLAN_SECURABLE_OBJECT WLAN_SET_EAPHOST               | ONEX_AUTH_PARAMS ONEX_CONNECTION_PROFILE ONEX_EAP_ERROR ONEX_RESULT_UPDATE_DATA ONEX_STATUS ONEX_USER_INFO ONEX_VARIABLE_BLOB HWFDSERVICE HWFDSESSION HWLANSESSION DOT11_AUTH_CIPHER_PAIR DOT11_BSSID_LIST DOT11_COUNTRY_OR_REGION_STRING DOT11_MAC_ADDRESS DOT11_NETWORK DOT11_SSID EAP_METHOD_TYPE EAP_TYPE NDIS_OBJECT_HEADER WLAN_ASSOCIATION_ATTRIBUTES WLAN_AUTH_CIPHER_PAIR_LIST WLAN_AVAILABLE_NETWORK WLAN_BSS_ENTRY WLAN_CONNECTION_ATTRIBUTES WLAN_CONNECTION_NOTIFICATION_DATA WLAN_CONNECTION_PARAMETERS WLAN_COUNTRY_OR_REGION_STRING_LIST WLAN_DEVICE_SERVICE_NOTIFICATION_DATA WLAN_HOSTED_NETWORK_CONNECTION_SETTINGS WLAN_HOSTED_NETWORK_DATA_PEER_STATE_CHANGE WLAN_HOSTED_NETWORK_PEER_STATE WLAN_HOSTED_NETWORK_RADIO_STATE WLAN_HOSTED_NETWORK_SECURITY_SETTINGS WLAN_HOSTED_NETWORK_STATE_CHANGE WLAN_INTERFACE_INFO WLAN_MAC_FRAME_STATISTICS WLAN_MSM_NOTIFICATION_DATA WLAN_NOTIFICATION_DATA WLAN_PHY_FRAME_STATISTICS WLAN_PHY_RADIO_STATE WLAN_PROFILE_INFO WLAN_RADIO_STATE WLAN_RATE_SET WLAN_RAW_DATA WLAN_RAW_DATA_LIST WLAN_SECURITY_ATTRIBUTES WLAN_STATISTICS DOT11_NETWORK_LIST WLAN_AVAILABLE_NETWORK_LIST WLAN_BSS_LIST WLAN_DEVICE_SERVICE_GUID_LIST WLAN_HOSTED_NETWORK_STATUS WLAN_INTERFACE_CAPABILITY WLAN_INTERFACE_INFO_LIST WLAN_PROFILE_INFO_LIST WLAN_RAW_DATA_INFO    | IDot11AdHocInterface IDot11AdHocInterfaceNotificationSink IDot11AdHocManager IDot11AdHocManagerNotificationSink IDot11AdHocNetwork IDot11AdHocNetworkNotificationSink IDot11AdHocSecuritySettings IEnumDot11AdHocInterfaces IEnumDot11AdHocNetworks IEnumDot11AdHocSecuritySettings                                                 