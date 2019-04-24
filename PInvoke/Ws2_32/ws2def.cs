using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Ws2_32
	{
		/// <summary>Flags that indicate options used in the GetAddrInfoW function.</summary>
		[PInvokeData("ws2def.h", MSDNShortId = "a4896eac-68ae-4a08-8647-36be65fe4478")]
		[Flags]
		public enum ADDRINFO_FLAGS : uint
		{
			/// <summary>The socket address will be used in a call to the bindfunction.</summary>
			AI_PASSIVE = 0x01,

			/// <summary>The canonical name is returned in the first ai_canonname member.</summary>
			AI_CANONNAME = 0x02,

			/// <summary>The nodename parameter passed to the GetAddrInfoW function must be a numeric string.</summary>
			AI_NUMERICHOST = 0x04,

			/// <summary>Servicename must be a numeric port number.</summary>
			AI_NUMERICSERV = 0x08,

			/// <summary>
			/// If this bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED.
			/// <para>This option is supported on Windows Vista and later.</para>
			/// </summary>
			AI_ALL = 0x0100,

			/// <summary>
			/// The GetAddrInfoW will resolve only if a global address is configured. The IPv6 and IPv4 loopback address is not considered a
			/// valid global address. This option is only supported on Windows Vista and later.
			/// </summary>
			AI_ADDRCONFIG = 0x0400,

			/// <summary>
			/// If the GetAddrInfoW request for an IPv6 addresses fails, a name service request is made for IPv4 addresses and these
			/// addresses are converted to IPv4-mapped IPv6 address format.
			/// <para>This option is supported on Windows Vista and later.</para>
			/// </summary>
			AI_V4MAPPED = 0x0800,

			/// <summary>
			/// The address information can be from a non-authoritative namespace provider.
			/// <para>This option is only supported on Windows Vista and later for the NS_EMAIL namespace.</para>
			/// </summary>
			AI_NON_AUTHORITATIVE = 0x04000,

			/// <summary>
			/// The address information is from a secure channel.
			/// <para>This option is only supported on Windows Vista and later for the NS_EMAIL namespace.</para>
			/// </summary>
			AI_SECURE = 0x08000,

			/// <summary>
			/// The address information is for a preferred name for a user.
			/// <para>This option is only supported on Windows Vista and later for the NS_EMAIL namespace.</para>
			/// </summary>
			AI_RETURN_PREFERRED_NAMES = 0x010000,

			/// <summary>
			/// If a flat name (single label) is specified, GetAddrInfoW will return the fully qualified domain name that the name eventually
			/// resolved to. The fully qualified domain name is returned in the ai_canonname member.
			/// <para>
			/// This is different than AI_CANONNAME bit flag that returns the canonical name registered in DNS which may be different than
			/// the fully qualified domain name that the flat name resolved to.
			/// </para>
			/// <para>
			/// Only one of the AI_FQDN and AI_CANONNAME bits can be set. The GetAddrInfoW function will fail if both flags are present with EAI_BADFLAGS.
			/// </para>
			/// <para>This option is supported on Windows 7, Windows Server 2008 R2, and later.</para>
			/// </summary>
			AI_FQDN = 0x00020000,

			/// <summary>
			/// A hint to the namespace provider that the hostname being queried is being used in a file share scenario. The namespace
			/// provider may ignore this hint.
			/// <para>This option is supported on Windows 7, Windows Server 2008 R2, and later.</para>
			/// </summary>
			AI_FILESERVER = 0x00040000,

			/// <summary>
			/// Disable the automatic International Domain Name encoding using Punycode in the name resolution functions called by the
			/// GetAddrInfoW function.
			/// <para>This option is supported on Windows 8, Windows Server 2012, and later.</para>
			/// </summary>
			AI_DISABLE_IDN_ENCODING = 0x00080000,

			/// <summary>Indicates this is extended ADDRINFOEX(2/..) struct</summary>
			AI_EXTENDED = 0x80000000,

			/// <summary>Request resolution handle</summary>
			AI_RESOLUTION_HANDLE = 0x40000000,
		}

		/// <summary>The <c>addrinfoW</c> structure is used by the GetAddrInfoW function to hold host address information.</summary>
		/// <remarks>
		/// <para>The <c>addrinfoW</c> structure is used by the Unicode GetAddrInfoW function to hold host address information.</para>
		/// <para>The addrinfo structure is ANSI version of this structure used by the ANSI getaddrinfo function.</para>
		/// <para>
		/// Macros in the Ws2tcpip.h header file define a <c>ADDRINFOT</c> structure and a mixed-case function name of <c>GetAddrInfo</c>.
		/// The <c>GetAddrInfo</c> function should be called with the nodename and servname parameters of a pointer of type <c>TCHAR</c> and
		/// the hints and res parameters of a pointer of type <c>ADDRINFOT</c>. When UNICODE or _UNICODE is defined, <c>ADDRINFOT</c> is
		/// defined to the <c>addrinfoW</c> structure and <c>GetAddrInfo</c> is defined to GetAddrInfoW, the Unicode version of this
		/// function. When UNICODE or _UNICODE is not defined, <c>ADDRINFOT</c> is defined to the addrinfo structure and <c>GetAddrInfo</c>
		/// is defined to getaddrinfo, the ANSI version of this function.
		/// </para>
		/// <para>
		/// Upon a successful call to GetAddrInfoW, a linked list of ADDRINFOW structures is returned in the ppResult parameter passed to the
		/// <c>GetAddrInfoW</c> function. The list can be processed by following the pointer provided in the <c>ai_next</c> member of each
		/// returned <c>ADDRINFOW</c> structure until a <c>NULL</c> pointer is encountered. In each returned <c>ADDRINFOW</c> structure, the
		/// <c>ai_family</c>, <c>ai_socktype</c>, and <c>ai_protocol</c> members correspond to respective arguments in a socket or WSASocket
		/// function call. Also, the <c>ai_addr</c> member in each returned <c>ADDRINFOW</c> structure points to a filled-in socket address
		/// structure, the length of which is specified in its <c>ai_addrlen</c> member.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code example shows how to use the <c>addrinfoW</c> structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ws2def/ns-ws2def-addrinfow typedef struct addrinfoW { int ai_flags; int
		// ai_family; int ai_socktype; int ai_protocol; size_t ai_addrlen; PWSTR ai_canonname; struct sockaddr *ai_addr; struct addrinfoW
		// *ai_next; } ADDRINFOW, *PADDRINFOW;
		[PInvokeData("ws2def.h", MSDNShortId = "a4896eac-68ae-4a08-8647-36be65fe4478")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct ADDRINFOW
		{
			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>Flags that indicate options used in the GetAddrInfoW function.</para>
			/// <para>
			/// Supported values for the <c>ai_flags</c> member are defined in the Winsock2.h header file and can be a combination of the
			/// options listed in the following table.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AI_PASSIVE 0x01</term>
			/// <term>The socket address will be used in a call to the bindfunction.</term>
			/// </item>
			/// <item>
			/// <term>AI_CANONNAME 0x02</term>
			/// <term>The canonical name is returned in the first ai_canonname member.</term>
			/// </item>
			/// <item>
			/// <term>AI_NUMERICHOST 0x04</term>
			/// <term>The nodename parameter passed to the GetAddrInfoW function must be a numeric string.</term>
			/// </item>
			/// <item>
			/// <term>AI_ALL 0x0100</term>
			/// <term>
			/// If this bit is set, a request is made for IPv6 addresses and IPv4 addresses with AI_V4MAPPED. This option is supported on
			/// Windows Vista and later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AI_ADDRCONFIG 0x0400</term>
			/// <term>
			/// The GetAddrInfoW will resolve only if a global address is configured. The IPv6 and IPv4 loopback address is not considered a
			/// valid global address. This option is only supported on Windows Vista and later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AI_V4MAPPED 0x0800</term>
			/// <term>
			/// If the GetAddrInfoW request for an IPv6 addresses fails, a name service request is made for IPv4 addresses and these
			/// addresses are converted to IPv4-mapped IPv6 address format. This option is supported on Windows Vista and later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AI_NON_AUTHORITATIVE 0x04000</term>
			/// <term>
			/// The address information can be from a non-authoritative namespace provider. This option is only supported on Windows Vista
			/// and later for the NS_EMAIL namespace.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AI_SECURE 0x08000</term>
			/// <term>
			/// The address information is from a secure channel. This option is only supported on Windows Vista and later for the NS_EMAIL namespace.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AI_RETURN_PREFERRED_NAMES 0x010000</term>
			/// <term>
			/// The address information is for a preferred name for a user. This option is only supported on Windows Vista and later for the
			/// NS_EMAIL namespace.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AI_FQDN 0x00020000</term>
			/// <term>
			/// If a flat name (single label) is specified, GetAddrInfoW will return the fully qualified domain name that the name eventually
			/// resolved to. The fully qualified domain name is returned in the ai_canonname member. This is different than AI_CANONNAME bit
			/// flag that returns the canonical name registered in DNS which may be different than the fully qualified domain name that the
			/// flat name resolved to. Only one of the AI_FQDN and AI_CANONNAME bits can be set. The GetAddrInfoW function will fail if both
			/// flags are present with EAI_BADFLAGS. This option is supported on Windows 7, Windows Server 2008 R2, and later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AI_FILESERVER 0x00040000</term>
			/// <term>
			/// A hint to the namespace provider that the hostname being queried is being used in a file share scenario. The namespace
			/// provider may ignore this hint. This option is supported on Windows 7, Windows Server 2008 R2, and later.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AI_DISABLE_IDN_ENCODING 0x00080000</term>
			/// <term>
			/// Disable the automatic International Domain Name encoding using Punycode in the name resolution functions called by the
			/// GetAddrInfoW function. This option is supported on Windows 8, Windows Server 2012, and later.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ADDRINFO_FLAGS ai_flags;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The address family. Possible values for the address family are defined in the Winsock2.h header file.</para>
			/// <para>
			/// On the Windows SDK released for Windows Vista and later,, the organization of header files has changed and the possible
			/// values for the address family are defined in the Ws2def.h header file. Note that the Ws2def.h header file is automatically
			/// included in Winsock2.h, and should never be used directly.
			/// </para>
			/// <para>
			/// The values currently supported are <c>AF_INET</c> or <c>AF_INET6</c>, which are the Internet address family formats for IPv4
			/// and IPv6. Other options for address family ( <c>AF_NETBIOS</c> for use with NetBIOS, for example) are supported if a Windows
			/// Sockets service provider for the address family is installed. Note that the values for the AF_ address family and PF_
			/// protocol family constants are identical (for example, <c>AF_UNSPEC</c> and <c>PF_UNSPEC</c>), so either constant can be used.
			/// </para>
			/// <para>The following table lists common values for the address family although many other values are possible.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>AF_UNSPEC 0</term>
			/// <term>The address family is unspecified.</term>
			/// </item>
			/// <item>
			/// <term>AF_INET 2</term>
			/// <term>The Internet Protocol version 4 (IPv4) address family.</term>
			/// </item>
			/// <item>
			/// <term>AF_NETBIOS 17</term>
			/// <term>The NetBIOS address family. This address family is only supported if a Windows Sockets provider for NetBIOS is installed.</term>
			/// </item>
			/// <item>
			/// <term>AF_INET6 23</term>
			/// <term>The Internet Protocol version 6 (IPv6) address family.</term>
			/// </item>
			/// <item>
			/// <term>AF_IRDA 26</term>
			/// <term>
			/// The Infrared Data Association (IrDA) address family. This address family is only supported if the computer has an infrared
			/// port and driver installed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>AF_BTH 32</term>
			/// <term>
			/// The Bluetooth address family. This address family is only supported if a Bluetooth adapter is installed on Windows Server
			/// 2003 or later.
			/// </term>
			/// </item>
			/// </list>
			/// </summary>
			public ADDRESS_FAMILY ai_family;

			private ushort pad;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>The socket type. Possible values for the socket type are defined in the Winsock2.h include file.</para>
			/// <para>The following table lists the possible values for the socket type supported for Windows Sockets 2.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SOCK_STREAM 1</term>
			/// <term>
			/// Provides sequenced, reliable, two-way, connection-based byte streams with an OOB data transmission mechanism. Uses the
			/// Transmission Control Protocol (TCP) for the Internet address family (AF_INET or AF_INET6). If the ai_family member is
			/// AF_IRDA, then SOCK_STREAM is the only supported socket type.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_DGRAM 2</term>
			/// <term>
			/// Supports datagrams, which are connectionless, unreliable buffers of a fixed (typically small) maximum length. Uses the User
			/// Datagram Protocol (UDP) for the Internet address family (AF_INET or AF_INET6).
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_RAW 3</term>
			/// <term>
			/// Provides a raw socket that allows an application to manipulate the next upper-layer protocol header. To manipulate the IPv4
			/// header, the IP_HDRINCL socket option must be set on the socket. To manipulate the IPv6 header, the IPV6_HDRINCL socket option
			/// must be set on the socket.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_RDM 4</term>
			/// <term>
			/// Provides a reliable message datagram. An example of this type is the Pragmatic General Multicast (PGM) multicast protocol
			/// implementation in Windows, often referred to as reliable multicast programming.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SOCK_SEQPACKET 5</term>
			/// <term>Provides a pseudo-stream packet based on datagrams.</term>
			/// </item>
			/// </list>
			/// <para>
			/// In Windows Sockets 2, new socket types were introduced. An application can dynamically discover the attributes of each
			/// available transport protocol through the WSAEnumProtocols function. So an application can determine the possible socket type
			/// and protocol options for an address family and use this information when specifying this parameter. Socket type definitions
			/// in the Winsock2.h and Ws2def.h header files will be periodically updated as new socket types, address families, and protocols
			/// are defined.
			/// </para>
			/// <para>In Windows Sockets 1.1, the only possible socket types are <c>SOCK_DATAGRAM</c> and <c>SOCK_STREAM</c>.</para>
			/// </summary>
			public SOCK ai_socktype;

			/// <summary>
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// The protocol type. The possible options are specific to the address family and socket type specified. Possible values for the
			/// <c>ai_protocol</c> are defined in Winsock2.h and the Wsrm.h header files.
			/// </para>
			/// <para>
			/// On the Windows SDK released for Windows Vista and later,, the organization of header files has changed and this member can be
			/// one of the values from the <c>IPPROTO</c> enumeration type defined in the Ws2def.h header file. Note that the Ws2def.h header
			/// file is automatically included in Winsock2.h, and should never be used directly.
			/// </para>
			/// <para>
			/// If a value of 0 is specified for <c>ai_protocol</c>, the caller does not wish to specify a protocol and the service provider
			/// will choose the <c>ai_protocol</c> to use. For protocols other than IPv4 and IPv6, set <c>ai_protocol</c> to zero.
			/// </para>
			/// <para>The following table lists common values for the <c>ai_protocol</c> member although many other values are possible.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>IPPROTO_TCP 6</term>
			/// <term>
			/// The Transmission Control Protocol (TCP). This is a possible value when the ai_family member is AF_INET or AF_INET6 and the
			/// ai_socktype member is SOCK_STREAM.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IPPROTO_UDP 17</term>
			/// <term>
			/// The User Datagram Protocol (UDP). This is a possible value when the ai_family member is AF_INET or AF_INET6 and the type
			/// parameter is SOCK_DGRAM.
			/// </term>
			/// </item>
			/// <item>
			/// <term>IPPROTO_RM 113</term>
			/// <term>
			/// The PGM protocol for reliable multicast. This is a possible value when the ai_family member is AF_INET and the ai_socktype
			/// member is SOCK_RDM. On the Windows SDK released for Windows Vista and later, this value is also called IPPROTO_PGM.
			/// </term>
			/// </item>
			/// </list>
			/// <para>If the <c>ai_family</c> member is <c>AF_IRDA</c>, then the <c>ai_protocol</c> must be 0.</para>
			/// </summary>
			public IPPROTO ai_protocol;

			/// <summary>
			/// <para>Type: <c>size_t</c></para>
			/// <para>The length, in bytes, of the buffer pointed to by the <c>ai_addr</c> member.</para>
			/// </summary>
			public SizeT ai_addrlen;

			/// <summary>
			/// <para>Type: <c>PWSTR</c></para>
			/// <para>The canonical name for the host.</para>
			/// </summary>
			public StrPtrUni ai_canonname;

			/// <summary>
			/// <para>Type: <c>struct sockaddr*</c></para>
			/// <para>
			/// A pointer to a sockaddr structure. The <c>ai_addr</c> member in each returned ADDRINFOW structure points to a filled-in
			/// socket address structure. The length, in bytes, of each returned <c>ADDRINFOW</c> structure is specified in the
			/// <c>ai_addrlen</c> member.
			/// </para>
			/// </summary>
			public IntPtr ai_addr;

			/// <summary>
			/// <para>Type: <c>struct addrinfoW*</c></para>
			/// <para>
			/// A pointer to the next structure in a linked list. This parameter is set to <c>NULL</c> in the last <c>addrinfoW</c> structure
			/// of a linked list.
			/// </para>
			/// </summary>
			public IntPtr ai_next;

			/// <summary>
			/// <para>Type: <c>struct sockaddr*</c></para>
			/// <para>
			/// A pointer to a sockaddr structure. The <c>ai_addr</c> member in each returned ADDRINFOW structure points to a filled-in
			/// socket address structure. The length, in bytes, of each returned <c>ADDRINFOW</c> structure is specified in the
			/// <c>ai_addrlen</c> member.
			/// </para>
			/// </summary>
			public SOCKADDR addr => new SOCKADDR(ai_addr, false, ai_addrlen);
		}

		/// <summary>The SOCKADDR_STORAGE structure is a generic structure that specifies a transport address.</summary>
		/// <remarks>
		/// A WSK application typically does not directly access any of the members of the SOCKADDR_STORAGE structure except for the
		/// <c>ss_family</c> member. Instead, a pointer to a SOCKADDR_STORAGE structure is normally cast to a pointer to the specific
		/// SOCKADDR structure type that corresponds to a particular address family.
		/// </remarks>
		// https://docs.microsoft.com/ja-jp/windows/desktop/api/ws2def/ns-ws2def-sockaddr_storage_lh typedef struct sockaddr_storage {
		// ADDRESS_FAMILY ss_family; CHAR __ss_pad1[_SS_PAD1SIZE]; __int64 __ss_align; CHAR __ss_pad2[_SS_PAD2SIZE]; } SOCKADDR_STORAGE_LH,
		// *PSOCKADDR_STORAGE_LH, *LPSOCKADDR_STORAGE_LH;
		[PInvokeData("ws2def.h", MSDNShortId = "27e56c1a-ce11-4cdb-9be8-25ed2f94fb37")]
		[StructLayout(LayoutKind.Sequential, Pack = 8)]
		public struct SOCKADDR_STORAGE
		{
			/// <summary>
			/// The address family for the transport address. For more information about supported address families, see WSK Address Families.
			/// </summary>
			public ADDRESS_FAMILY ss_family;

			/// <summary>A padding of 6 bytes that puts the <c>__ss_align</c> member on an eight-byte boundary within the structure.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
			public byte[] __ss_pad1;

			/// <summary>A 64-bit value that forces the structure to be 8-byte aligned.</summary>
			public long __ss_align;

			/// <summary>A padding of an additional 112 bytes that brings the total size of the SOCKADDR_STORAGE structure to 128 bytes.</summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 112)]
			public byte[] __ss_pad2;
		}
	}
}