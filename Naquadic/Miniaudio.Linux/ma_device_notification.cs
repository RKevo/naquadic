using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Linux
{
    public unsafe partial struct ma_device_notification
    {
        public ma_device* pDevice;

        public ma_device_notification_type type;

        [NativeTypeName("__AnonymousRecord_miniaudio_L6737_C5")]
        public _data_e__Union data;

        [StructLayout(LayoutKind.Explicit)]
        public partial struct _data_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L6739_C9")]
            public _started_e__Struct started;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L6743_C9")]
            public _stopped_e__Struct stopped;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L6747_C9")]
            public _rerouted_e__Struct rerouted;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L6751_C9")]
            public _interruption_e__Struct interruption;

            public partial struct _started_e__Struct
            {
                public int _unused;
            }

            public partial struct _stopped_e__Struct
            {
                public int _unused;
            }

            public partial struct _rerouted_e__Struct
            {
                public int _unused;
            }

            public partial struct _interruption_e__Struct
            {
                public int _unused;
            }
        }
    }
}
