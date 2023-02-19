namespace Vanara.PInvoke;

/// <summary>Items from Qwave.dll.</summary>
public static partial class Qwave
{
	/// <summary>Flags associated with the <see cref="AD_GENERAL_PARAMS"/> parameters.</summary>
	[Flags]
	public enum AD_FLAG : uint
	{
		/// <summary>
		/// Indicates the existence of a network element in the data path that does not support QOS control services. When set in a specific
		/// service override, indicates QOS service was not supported on at least one hop.
		/// </summary>
		AD_FLAG_BREAK_BIT = 0x00000001,
	}

	/// <summary>The <c>FilterType</c> enumeration specifies the type of filter used for an RSVP FILTERSPEC.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ne-qossp-filtertype typedef enum { FILTERSPECV4 = 1, FILTERSPECV6,
	// FILTERSPECV6_FLOW, FILTERSPECV4_GPI, FILTERSPECV6_GPI, FILTERSPEC_END } FilterType;
	[PInvokeData("qossp.h", MSDNShortId = "NE:qossp.__unnamed_enum_0")]
	public enum FilterType
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates an IPv4 FILTERSPEC.</para>
		/// </summary>
		FILTERSPECV4 = 1,

		/// <summary>Indicates an IPv6 FILTERSPEC.</summary>
		FILTERSPECV6,

		/// <summary>Indicates IPv6 FILTERSPEC flow information.</summary>
		FILTERSPECV6_FLOW,

		/// <summary>Indicates IPv4 FILTERSPEC general port identifier information.</summary>
		FILTERSPECV4_GPI,

		/// <summary>Indicates IPv6 FILTERSPEC general port identifier information.</summary>
		FILTERSPECV6_GPI,

		/// <summary>Indicates the end of the FILTERSPEC information.</summary>
		FILTERSPEC_END,
	}

	/// <summary>Specifies the RSVP reservation style for a given flow.</summary>
	[PInvokeData("qossp.h")]
	public enum RSVP
	{
		/// <summary>Implements the default reservation style for the computer.</summary>
		RSVP_DEFAULT_STYLE = 0x00000000,

		/// <summary>
		/// Implements the WF RSVP reservation style. RSVP_WILDCARD_STYLE is the default value for multicast receivers and UDP unicast
		/// receivers. Specifying RSVP_WILDCARD_STYLE through RSVP_RESERVE_INFO is useful for overriding the default value
		/// (RSVP_FIXED_FILTER_STYLE) applied to connected unicast receivers.
		/// </summary>
		RSVP_WILDCARD_STYLE = 0x00000001,

		/// <summary>
		/// Implements the Fixed Filter (FF) RSVP reservation style. RSVP_FIXED_FILTER_STYLE is useful for overriding the default style for
		/// multicast receivers or unconnected UDP unicast receivers (RSVP_WILDCARD_STYLE). It may also be used to generate multiple
		/// RSVP_FIXED_FILTER_STLYE reservations in instances where only a single RSVP_FIXED_FILTER_STYLE reservation will be generated by
		/// default, such as with connected unicast receivers.
		/// </summary>
		RSVP_FIXED_FILTER_STYLE = 0x00000002,

		/// <summary>Implements the Shared Explicit (SE) RSVP reservation style.</summary>
		RSVP_SHARED_EXPLICIT_STYLE = 0x00000003,
	}

	/// <summary>
	/// The <c>AD_GENERAL_PARAMS</c> structure contains the General Characterization Parameters contained in the RSVP Adspec object.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-ad_general_params typedef struct _AD_GENERAL_PARAMS { ULONG
	// IntServAwareHopCount; ULONG PathBandwidthEstimate; ULONG MinimumLatency; ULONG PathMTU; ULONG Flags; } AD_GENERAL_PARAMS, *LPAD_GENERAL_PARAMS;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._AD_GENERAL_PARAMS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AD_GENERAL_PARAMS
	{
		/// <summary>Number of hops that conform to Integrated Services (INTSERV) requirements.</summary>
		public uint IntServAwareHopCount;

		/// <summary>Minimum bandwidth available from sender to receiver.</summary>
		public uint PathBandwidthEstimate;

		/// <summary>Sum of the minimum latency of the packet forwarding process in routers, in milliseconds. Can be set to INDETERMINATE_LATENCY.</summary>
		public uint MinimumLatency;

		/// <summary>Maximum Transmission Unit (MTU) for the end-to-end path between sender and receiver that will not incur packet fragmentation.</summary>
		public uint PathMTU;

		/// <summary>
		/// <para>Flags associated with the parameters. The following flag is supported:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>AD_FLAG_BREAK_BIT</c></term>
		/// <term>
		/// Indicates the existence of a network element in the data path that does not support QOS control services. When set in a specific
		/// service override, indicates QOS service was not supported on at least one hop.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public AD_FLAG Flags;
	}

	/// <summary>Specifies guaranteed service, and provides service parameters.</summary>
	[PInvokeData("qossp.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct AD_GUARANTEED
	{
		/// <summary/>
		public uint CTotal;

		/// <summary/>
		public uint DTotal;

		/// <summary/>
		public uint CSum;

		/// <summary/>
		public uint DSum;
	}

	/// <summary>The <c>CONTROL_SERVICE</c> structure contains supported RSVP service types.</summary>
	/// <remarks>
	/// The <c>Length</c> value can be added to the pointer to the structure to obtain the pointer to the next <c>CONTROL_SERVICE</c>
	/// structure in the list, until the <c>NumberOfServices</c> member of the RSVP_ADSPEC structure is exhausted.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-control_service typedef struct _CONTROL_SERVICE { ULONG Length;
	// SERVICETYPE Service; AD_GENERAL_PARAMS Overrides; union { AD_GUARANTEED Guaranteed; PARAM_BUFFER ParamBuffer[1]; }; } CONTROL_SERVICE, *LPCONTROL_SERVICE;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._CONTROL_SERVICE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CONTROL_SERVICE : IVanaraMarshaler
	{
		/// <summary>
		/// <para>The supported service type. Must be one of the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>SERVICETYPE_NOTRAFFIC</c></term>
		/// <term>No data is being sent in this direction.</term>
		/// </item>
		/// <item>
		/// <term><c>SERVICETYPE_BESTEFFORT</c></term>
		/// <term>Best Effort service.</term>
		/// </item>
		/// <item>
		/// <term><c>SERVICETYPE_CONTROLLEDLOAD</c></term>
		/// <term>Controlled Load service.</term>
		/// </item>
		/// <item>
		/// <term><c>SERVICETYPE_GUARANTEED</c></term>
		/// <term>Guaranteed service.</term>
		/// </item>
		/// <item>
		/// <term><c>SERVICETYPE_NETWORK_UNAVAILABLE</c></term>
		/// <term>This service type is used to notify the user that the network is unavailable.</term>
		/// </item>
		/// <item>
		/// <term><c>SERVICETYPE_GENERAL_INFORMATION</c></term>
		/// <term>
		/// This service type corresponds to General Parameters, as defined by IntServ (the Integrated Services Working Group in the IETF).
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>SERVICETYPE_NOCHANGE</c></term>
		/// <term>This specifies that the flow specification contains no changes from the previous specification.</term>
		/// </item>
		/// <item>
		/// <term><c>SERVICETYPE_NONCONFORMING</c></term>
		/// <term>Specifies non-conforming traffic.</term>
		/// </item>
		/// <item>
		/// <term><c>SERVICETYPE_NETWORK_CONTROL</c></term>
		/// <term>Specifies network control traffic.</term>
		/// </item>
		/// <item>
		/// <term><c>SERVICETYPE_QUALITATIVE</c></term>
		/// <term>Qualitative service.</term>
		/// </item>
		/// </list>
		/// </summary>
		public SERVICETYPE Service;

		/// <summary>Specifies overrides to service specifications, expressed in the form of an AD_GENERAL_PARAMS structure.</summary>
		public AD_GENERAL_PARAMS Overrides;

		/// <summary>Specifies guaranteed service, and provides service parameters in the form of an <c>AD_GUARANTEED</c> structure.</summary>
		public AD_GUARANTEED? Guaranteed;

		/// <summary>Describes the buffer used, in the form of a PARAM_BUFFER structure.</summary>
		public PARAM_BUFFER? ParamBuffer;

		SizeT IVanaraMarshaler.GetNativeSize() => Marshal.SizeOf(typeof(ACTUAL));

		SafeAllocatedMemoryHandle IVanaraMarshaler.MarshalManagedToNative(object managedObject)
		{
			if (managedObject is not CONTROL_SERVICE cs)
			{
				throw new InvalidCastException("Only instances of CONTROL_SERVICE can be marshaled.");
			}

			if (!(cs.Guaranteed.HasValue ^ cs.ParamBuffer.HasValue))
			{
				throw new InvalidCastException("Either Guaranteed OR ParamBuffer values must be set, but not both.");
			}

			int bufLen = ParamBuffer.HasValue && ParamBuffer.Value.Buffer is not null ? ParamBuffer.Value.Buffer.Length : 0;
			int len = Marshal.SizeOf(typeof(ACTUAL)) + (ParamBuffer.HasValue ? 8 + bufLen - Marshal.SizeOf(typeof(AD_GUARANTEED)) : 0);
			SafeCoTaskMemHandle ret = new(len);
			ACTUAL native = new() { Length = len, Service = cs.Service, Overrides = Overrides };
			if (Guaranteed.HasValue)
			{
				native.union.Guaranteed = Guaranteed.Value;
			}
			else
			{
				native.union.ParamBuffer = new() { ParameterId = ParamBuffer.Value.ParameterId, Length = 8U + (uint)bufLen };
			}

			ret.Write(native);
			if (bufLen > 0)
			{
				ret.Write(ParamBuffer.Value.Buffer, false, bufOffset);
			}

			return ret;
		}

		private static readonly int bufOffset = Marshal.OffsetOf(typeof(ACTUAL), "union").ToInt32() +
					Marshal.OffsetOf(typeof(UNION.DUMMYBUF), "Buffer").ToInt32();

		object IVanaraMarshaler.MarshalNativeToManaged(IntPtr pNativeData, SizeT allocatedBytes)
		{
			if (pNativeData == IntPtr.Zero || allocatedBytes == 0)
			{
				return null;
			}

			ACTUAL actual = (ACTUAL)Marshal.PtrToStructure(pNativeData, typeof(ACTUAL));
			CONTROL_SERVICE ret = new() { Service = actual.Service, Overrides = actual.Overrides };
			if (actual.Service == SERVICETYPE.SERVICETYPE_GUARANTEED)
			{
				ret.Guaranteed = actual.union.Guaranteed;
			}
			else
			{
				PARAM_BUFFER pb = new() { ParameterId = actual.union.ParamBuffer.ParameterId, Length = actual.union.ParamBuffer.Length };
				pb.Buffer = pNativeData.ToByteArray((int)pb.Length - 8, bufOffset, allocatedBytes);
				ret.ParamBuffer = pb;
			}
			return ret;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct ACTUAL
		{
			public int Length;
			public SERVICETYPE Service;
			public AD_GENERAL_PARAMS Overrides;
			public UNION union;
		}

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public AD_GUARANTEED Guaranteed;

			[FieldOffset(0)]
			public DUMMYBUF ParamBuffer;

			[StructLayout(LayoutKind.Sequential)]
			public struct DUMMYBUF
			{
				/// <summary>Parameter ID, as defined by INTSERV.</summary>
				public uint ParameterId;

				/// <summary>Length of the entire <c>PARAM_BUFFER</c> structure.</summary>
				public uint Length;

				/// <summary>Buffer containing the parameter.</summary>
				public byte Buffer;
			}
		}
	}

	/// <summary>The <c>FLOWDESCRIPTOR</c> structure specifies one or more filters for a given FLOWSPEC.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-flowdescriptor typedef struct _FLOWDESCRIPTOR { FLOWSPEC FlowSpec;
	// ULONG NumFilters; LPRSVP_FILTERSPEC FilterList; } FLOWDESCRIPTOR, *LPFLOWDESCRIPTOR;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._FLOWDESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct FLOWDESCRIPTOR
	{
		/// <summary>Flow specification (FLOWSPEC), provided as a FLOWSPEC structure.</summary>
		public FLOWSPEC FlowSpec;

		/// <summary>Number of filters provided in <c>FilterList</c>.</summary>
		public uint NumFilters;

		/// <summary>Pointer to a <see cref="RSVP_FILTERSPEC"/> structure containing FILTERSPEC information.</summary>
		public IntPtr FilterList;
	}

	/// <summary>
	/// The <c>PARAM_BUFFER</c> structure describes the format of the parameter buffer that can be included in the CONTROL_SERVICE structure.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-param_buffer typedef struct _PARAM_BUFFER { ULONG ParameterId;
	// ULONG Length; UCHAR Buffer[1]; } PARAM_BUFFER, *LPPARAM_BUFFER;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._PARAM_BUFFER")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<PARAM_BUFFER>), nameof(Length))]
	[StructLayout(LayoutKind.Sequential)]
	public struct PARAM_BUFFER
	{
		/// <summary>Parameter ID, as defined by INTSERV.</summary>
		public uint ParameterId;

		/// <summary>Length of the entire <c>PARAM_BUFFER</c> structure.</summary>
		public uint Length;

		/// <summary>Buffer containing the parameter.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public byte[] Buffer;
	}

	/// <summary>
	/// The QOS object <c>QOS_DESTADDR</c> is used during a call to the WSAIoctl (SIO_SET_QOS) function in order to avoid issuing a
	/// <c>connect</c> function call for a sending socket.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-qos_destaddr typedef struct _QOS_DESTADDR { QOS_OBJECT_HDR
	// ObjectHdr; const sockaddr *SocketAddress; struct sockaddr; ULONG SocketAddressLength; } QOS_DESTADDR, *LPQOS_DESTADDR;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._QOS_DESTADDR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QOS_DESTADDR
	{
		/// <summary>The QOS object QOS_OBJECT_HDR. The object type for this QOS object should be <c>QOS_DESTADDR</c>.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>Address of the destination socket <see cref="Ws2_32.SOCKADDR"/>.</summary>
		public IntPtr SocketAddress;

		/// <summary>Length of the <c>SocketAddress</c> structure.</summary>
		public uint SocketAddressLength;
	}

	/// <summary>
	/// The QOS object <c>RSVP_ADSPEC</c> provides a means by which information describing network devices along the data path between sender
	/// and receiver, pertaining to RSVP functionality and available services, is provided or retrieved.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_adspec typedef struct _RSVP_ADSPEC { QOS_OBJECT_HDR ObjectHdr;
	// AD_GENERAL_PARAMS GeneralParams; ULONG NumberOfServices; CONTROL_SERVICE Services[1]; } RSVP_ADSPEC, *LPRSVP_ADSPEC;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_ADSPEC")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<RSVP_ADSPEC>), nameof(NumberOfServices))]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_ADSPEC : IQoSObjectHdr
	{
		/// <summary>The QOS object <c>QOS_OBJECT_HDR</c>.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>
		/// An AD_GENERAL_PARAMS structure that provides general characterization parameters for the flow. Information includes RSVP-enabled
		/// hop count, bandwidth and latency estimates, and the path's MTU.
		/// </summary>
		public AD_GENERAL_PARAMS GeneralParams;

		/// <summary>Provides a count of the number of services available.</summary>
		public uint NumberOfServices;

		/// <summary>
		/// A CONTROL_SERVICE array, its element count based on <c>NumberOfServices</c>, which provides information about the services
		/// available along the data path between the sender and receiver of a given flow.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public CONTROL_SERVICE[] Services;
	}

	/// <summary>The <c>RSVP_FILTERSPEC</c> structure provides RSVP FILTERSPEC information.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_filterspec typedef struct _RSVP_FILTERSPEC { FilterType Type;
	// union { RSVP_FILTERSPEC_V4 FilterSpecV4; RSVP_FILTERSPEC_V6 FilterSpecV6; RSVP_FILTERSPEC_V6_FLOW FilterSpecV6Flow;
	// RSVP_FILTERSPEC_V4_GPI FilterSpecV4Gpi; RSVP_FILTERSPEC_V6_GPI FilterSpecV6Gpi; }; } RSVP_FILTERSPEC, *LPRSVP_FILTERSPEC;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_FILTERSPEC")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_FILTERSPEC
	{
		/// <summary>Specifies the type of FILTERSPEC using the <c>FilterSpec</c> enumeration.</summary>
		public FilterType Type;

		/// <summary>The union of filters.</summary>
		public UNION Union;

		/// <summary>The union of filters.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct UNION
		{
			/// <summary>IPv4 FILTERSPEC information, provided in the form of a RSVP_FILTERSPEC_V4 structure.</summary>
			[FieldOffset(0)]
			public RSVP_FILTERSPEC_V4 FilterSpecV4;

			/// <summary>IPv6 FILTERSPEC information, provided in the form of a RSVP_FILTERSPEC_V6 structure.</summary>
			[FieldOffset(0)]
			public RSVP_FILTERSPEC_V6 FilterSpecV6;

			/// <summary>IPv6 FILTERSPEC flow information, provided in the form of a RSVP_FILTERSPEC_V6_FLOW structure.</summary>
			[FieldOffset(0)]
			public RSVP_FILTERSPEC_V6_FLOW FilterSpecV6Flow;

			/// <summary>IPv4 FILTERSPEC general port ID information, provided in the form of a RSVP_FILTERSPEC_V4_GPI structure.</summary>
			[FieldOffset(0)]
			public RSVP_FILTERSPEC_V4_GPI FilterSpecV4Gpi;

			/// <summary>IPv6 FILTERSPEC general port ID information, provided in the form of a RSVP_FILTERSPEC_V6_GPI structure.</summary>
			[FieldOffset(0)]
			public RSVP_FILTERSPEC_V6_GPI FilterSpecV6Gpi;
		}
	}

	/// <summary>The <c>RSVP_FILTERSPEC_V4</c> structure stores information for a FILTERSPEC on an IPv4 address.</summary>
	/// <remarks>When working with IPv6 addresses, use RSVP_FILTERSPEC_V6.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_filterspec_v4 typedef struct _RSVP_FILTERSPEC_V4 {
	// IN_ADDR_IPV4 Address; USHORT Unused; USHORT Port; } RSVP_FILTERSPEC_V4, *LPRSVP_FILTERSPEC_V4;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_FILTERSPEC_V4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_FILTERSPEC_V4
	{
		/// <summary>IPv4 address for which the FILTERSPEC applies, expressed as an IN_ADDR_IPV4 union.</summary>
		public IN_ADDR_IPV4 Address;

		/// <summary>Reserved. Set to zero.</summary>
		public ushort Unused;

		/// <summary>TCP port of the socket on which the FILTERSPEC applies.</summary>
		public ushort Port;
	}

	/// <summary>The <c>RSVP_FILTERSPEC_V4_GPI</c> structure provides general port identifier information for a given FILTERSPEC.</summary>
	/// <remarks>When working with IPv6 addresses, use RSVP_FILTERSPEC_V6_GPI.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_filterspec_v4_gpi typedef struct _RSVP_FILTERSPEC_V4_GPI {
	// IN_ADDR_IPV4 Address; ULONG GeneralPortId; } RSVP_FILTERSPEC_V4_GPI, *LPRSVP_FILTERSPEC_V4_GPI;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_FILTERSPEC_V4_GPI")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_FILTERSPEC_V4_GPI
	{
		/// <summary>IPv4 address for which the FILTERSPEC general port identifier applies, expressed as an IN_ADDR_IPV4 union.</summary>
		public IN_ADDR_IPV4 Address;

		/// <summary>General Port Identifier for the FILTERSPEC.</summary>
		public uint GeneralPortId;
	}

	/// <summary>The <c>RSVP_FILTERSPEC_V6</c> structure stores information for a FILTERSPEC on an IPv6 address.</summary>
	/// <remarks>When working with IPv4 addresses, use RSVP_FILTERSPEC_V4.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_filterspec_v6 typedef struct _RSVP_FILTERSPEC_V6 {
	// IN_ADDR_IPV6 Address; USHORT UnUsed; USHORT Port; } RSVP_FILTERSPEC_V6, *LPRSVP_FILTERSPEC_V6;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_FILTERSPEC_V6")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_FILTERSPEC_V6
	{
		/// <summary>IPv4 address for which the FILTERSPEC applies, expressed as an IN_ADDR_IPV6 structure.</summary>
		public IN_ADDR_IPV6 Address;

		/// <summary/>
		public ushort UnUsed;

		/// <summary>TCP port of the socket on which the FILTERSPEC applies.</summary>
		public ushort Port;
	}

	/// <summary>The <c>RSVP_FILTERSPEC_V6_FLOW</c> structure provides flow label information for an IPv6 FILTERSPEC.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_filterspec_v6_flow typedef struct _RSVP_FILTERSPEC_V6_FLOW {
	// IN_ADDR_IPV6 Address; UCHAR UnUsed; UCHAR FlowLabel[3]; } RSVP_FILTERSPEC_V6_FLOW, *LPRSVP_FILTERSPEC_V6_FLOW;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_FILTERSPEC_V6_FLOW")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct RSVP_FILTERSPEC_V6_FLOW
	{
		/// <summary>IPv4 address for which the FILTERSPEC flow label applies, expressed as an IN_ADDR_IPV6 structure.</summary>
		public IN_ADDR_IPV6 Address;

		private uint field;

		/// <summary/>
		public byte UnUsed
		{
			get => BitConverter.GetBytes(field)[0];
			set
			{
				byte[] bytes = BitConverter.GetBytes(field);
				bytes[0] = value;
				field = BitConverter.ToUInt32(bytes, 0);
			}
		}

		/// <summary>Label for the flow.</summary>
		public byte[] FlowLabel
		{
			get => BitConverter.GetBytes(field).AsSpan().Slice(1, 3).ToArray();
			set
			{
				if (value is null || value.Length != 3)
				{
					throw new ArgumentException("FlowLabel must be a three byte array.", nameof(value));
				}

				byte[] bytes = BitConverter.GetBytes(field);
				Array.Copy(value, 0, bytes, 1, 3);
				field = BitConverter.ToUInt32(bytes, 0);
			}
		}
	}

	/// <summary>
	/// The <c>RSVP_FILTERSPEC_V6_GPI</c> structure provides general port identifier information for a given FILTERSPEC on an IPv6 address.
	/// </summary>
	/// <remarks>When working with IPv4 addresses, use RSVP_FILTERSPEC_V4_GPI.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_filterspec_v6_gpi typedef struct _RSVP_FILTERSPEC_V6_GPI {
	// IN_ADDR_IPV6 Address; ULONG GeneralPortId; } RSVP_FILTERSPEC_V6_GPI, *LPRSVP_FILTERSPEC_V6_GPI;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_FILTERSPEC_V6_GPI")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_FILTERSPEC_V6_GPI
	{
		/// <summary>IPv4 address for which the FILTERSPEC general port identifier applies, expressed as an IN_ADDR_IPV6 structure.</summary>
		public IN_ADDR_IPV6 Address;

		/// <summary>General Port Identifier for the FILTERSPEC.</summary>
		public uint GeneralPortId;
	}

	/// <summary>The <c>RSVP_POLICY</c> structure stores one or more undefined policy elements.</summary>
	/// <remarks>RSVP transports the data contained in an <c>RSVP_POLICY</c> structure on behalf of the Policy Control component.</remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_policy typedef struct _RSVP_POLICY { USHORT Len; USHORT Type;
	// UCHAR Info[4]; } RSVP_POLICY, *LPRSVP_POLICY;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_POLICY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_POLICY
	{
		/// <summary>Size of the entire element object, in bytes.</summary>
		public ushort Len;

		/// <summary>Type of RSVP policy element in <c>Info</c>.</summary>
		public ushort Type;

		private uint field;

		/// <summary>Policy data, expressed in UCHARs.</summary>
		public byte[] Info
		{
			get => BitConverter.GetBytes(field);
			set
			{
				if (value is null || value.Length != 4)
				{
					throw new ArgumentException("Info must be a four byte array.", nameof(value));
				}

				byte[] bytes = BitConverter.GetBytes(field);
				Array.Copy(value, 0, bytes, 0, 4);
				field = BitConverter.ToUInt32(bytes, 0);
			}
		}
	}

	/// <summary>The <c>RSVP_POLICY_INFO</c> structure stores undefined policy elements retrieved from RSVP.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_policy_info typedef struct _RSVP_POLICY_INFO { QOS_OBJECT_HDR
	// ObjectHdr; ULONG NumPolicyElement; RSVP_POLICY PolicyElement[1]; } RSVP_POLICY_INFO, *LPRSVP_POLICY_INFO;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_POLICY_INFO")]
	[VanaraMarshaler(typeof(SafeAnysizeStructMarshaler<RSVP_POLICY_INFO>), nameof(NumPolicyElement))]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_POLICY_INFO : IQoSObjectHdr
	{
		/// <summary>QOS object header that specifies the size and length of the QOS object.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>Number of policy elements in <c>PolicyElement</c>.</summary>
		public uint NumPolicyElement;

		/// <summary>List of policy elements received, in the form of a RSVP_POLICY structure.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
		public RSVP_POLICY[] PolicyElement;
	}

	/// <summary>
	/// <para>
	/// The QOS object <c>RSVP_RESERVE_INFO</c>, through the ProviderSpecific buffer, enables RSVP behavior for a given flow to be specified
	/// or modified at a granular level, and enables default RSVP style settings for a flow to be overridden. Although
	/// <c>RSVP_RESERVE_INFO</c> is technically a structure, its use within Windows 2000 QOS technology�and especially its required inclusion
	/// of the <c>QOS_OBJECT_HDR</c> as its first member�define it as a QOS object.
	/// </para>
	/// <para><c>Note</c> The RSVP_RESERVE_INFO QOS object is not supported except on Windows 2000.</para>
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_reserve_info typedef struct _RSVP_RESERVE_INFO {
	// QOS_OBJECT_HDR ObjectHdr; ULONG Style; ULONG ConfirmRequest; LPRSVP_POLICY_INFO PolicyElementList; ULONG NumFlowDesc; LPFLOWDESCRIPTOR
	// FlowDescList; } RSVP_RESERVE_INFO, *LPRSVP_RESERVE_INFO;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_RESERVE_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_RESERVE_INFO : IQoSObjectHdr
	{
		/// <summary>The QOS object <c>QOS_OBJECT_HDR</c>.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>
		/// <para>
		/// Specifies the RSVP reservation style for a given flow, and can be used to replace default reservation styles placed on a
		/// particular type of flow. More information about RSVP reservation styles, and the default settings for certain QOS-enabled socket
		/// sessions, can be found under Network-Driven QOS Components. This member can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>RSVP_WILDCARD_SYLE</c></term>
		/// <term>
		/// Implements the WF RSVP reservation style. RSVP_WILDCARD_STYLE is the default value for multicast receivers and UDP unicast
		/// receivers. Specifying RSVP_WILDCARD_STYLE through RSVP_RESERVE_INFO is useful for overriding the default value
		/// (RSVP_FIXED_FILTER_STYLE) applied to connected unicast receivers.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>RSVP_FIXED_FILTER_STYLE</c></term>
		/// <term>
		/// Implements the Fixed Filter (FF) RSVP reservation style. RSVP_FIXED_FILTER_STYLE is useful for overriding the default style for
		/// multicast receivers or unconnected UDP unicast receivers (RSVP_WILDCARD_STYLE). It may also be used to generate multiple
		/// RSVP_FIXED_FILTER_STLYE reservations in instances where only a single RSVP_FIXED_FILTER_STYLE reservation will be generated by
		/// default, such as with connected unicast receivers.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>RSVP_SHARED_EXPLICIT_STYLE</c></term>
		/// <term>Implements the Shared Explicit (SE) RSVP reservation style.</term>
		/// </item>
		/// <item>
		/// <term><c>RSVP_DEFAULT_STYLE</c></term>
		/// <term>Implements the default reservation style for the computer.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> It is important to note that the number of senders included in any individual RSVP_SHARED_EXPLICIT_STYLE reservation
		/// must be less than one hundred senders. If more than one hundred senders attempt to connect to an RSVP_SHARED_EXPLICIT_STYLE
		/// reservation, the one-hundredth (and above) attempt fails without notice.
		/// </para>
		/// </summary>
		public RSVP Style;

		/// <summary>
		/// Can be used by a receiving application to request notification of its reservation request by setting <c>ConfirmRequest</c> to a
		/// nonzero value. Such notification is achieved when RSVP-aware devices in the data path between sender and receiver (or vice-versa)
		/// transmit an RESV CONFIRMATION message toward the requesting node. Note that an RSVP node is not required to automatically
		/// generate RESV CONFIRMATION messages.
		/// </summary>
		public uint ConfirmRequest;

		/// <summary>
		/// Pointer to the set of policy elements. Optional policy information, as provided in an <see cref="RSVP_POLICY_INFO"/> structure.
		/// </summary>
		public IntPtr PolicyElementList;

		/// <summary>Specifies the FLOWDESCRIPTOR count.</summary>
		public uint NumFlowDesc;

		/// <summary>Pointer to the list of <see cref="FLOWDESCRIPTOR"/> s.</summary>
		public IntPtr FlowDescList;
	}

	/// <summary>
	/// The QOS object <c>RSVP_STATUS_INFO</c> provides information regarding the status of RSVP for a given flow, including event
	/// notifications associated with monitoring FD_QOS events, as well as error information. <c>RSVP_STATUS_INFO</c> is useful for storing
	/// RSVP-specific status and error information.
	/// </summary>
	/// <remarks>
	/// When applications register their interest in FD_QOS events (see QOS Events), event and error information is associated with the event
	/// in the form of the QOS structure that is associated with the event. For more detailed information associated with that event,
	/// applications can investigate the <c>RSVP_STATUS_INFO</c> object that is provided in the ProviderSpecific buffer of the
	/// event-associated <c>QOS</c> structure.
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/qossp/ns-qossp-rsvp_status_info typedef struct _RSVP_STATUS_INFO { QOS_OBJECT_HDR
	// ObjectHdr; ULONG StatusCode; ULONG ExtendedStatus1; ULONG ExtendedStatus2; } RSVP_STATUS_INFO, *LPRSVP_STATUS_INFO;
	[PInvokeData("qossp.h", MSDNShortId = "NS:qossp._RSVP_STATUS_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RSVP_STATUS_INFO : IQoSObjectHdr
	{
		/// <summary>The QOS object <c>QOS_OBJECT_HDR</c>.</summary>
		public QOS_OBJECT_HDR ObjectHdr;

		/// <summary>Status information. See Winsock2.h for more information.</summary>
		public uint StatusCode;

		/// <summary>
		/// Mechanism for storing or returning provider-specific status information. The <c>ExtendedStatus1</c> parameter is used for storing
		/// a higher-level, or generalized error code, and is augmented by finer-grained error information provided in ExtendedStatus2.
		/// </summary>
		public uint ExtendedStatus1;

		/// <summary>
		/// Additional mechanism for storing or returning provider-specific status information. Provides finer-grained error information
		/// compared to the generalized error information provided in <c>ExtendedStatus1</c>.
		/// </summary>
		public uint ExtendedStatus2;
	}
}