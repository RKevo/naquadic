using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Naquadic.Miniaudio.Linux
{
    internal unsafe partial struct ma_device
    {
        public ma_context* pContext;

        public ma_device_type type;

        [NativeTypeName("ma_uint32")]
        public uint sampleRate;

        public ma_atomic_device_state state;

        [NativeTypeName("ma_device_data_proc")]
        public delegate* unmanaged[Cdecl]<ma_device*, void*, void*, uint, void> onData;

        [NativeTypeName("ma_device_notification_proc")]
        public delegate* unmanaged[Cdecl]<ma_device_notification*, void> onNotification;

        [NativeTypeName("ma_stop_proc")]
        public delegate* unmanaged[Cdecl]<ma_device*, void> onStop;

        public void* pUserData;

        [NativeTypeName("ma_mutex")]
        public void* startStopLock;

        [NativeTypeName("ma_event")]
        public void* wakeupEvent;

        [NativeTypeName("ma_event")]
        public void* startEvent;

        [NativeTypeName("ma_event")]
        public void* stopEvent;

        [NativeTypeName("ma_thread")]
        public void* thread;

        public ma_result workResult;

        [NativeTypeName("ma_bool8")]
        public byte isOwnerOfContext;

        [NativeTypeName("ma_bool8")]
        public byte noPreSilencedOutputBuffer;

        [NativeTypeName("ma_bool8")]
        public byte noClip;

        [NativeTypeName("ma_bool8")]
        public byte noDisableDenormals;

        [NativeTypeName("ma_bool8")]
        public byte noFixedSizedCallback;

        public ma_atomic_float masterVolumeFactor;

        public ma_duplex_rb duplexRB;

        [NativeTypeName("__AnonymousRecord_miniaudio_L7741_C5")]
        public _resampling_e__Struct resampling;

        [NativeTypeName("__AnonymousRecord_miniaudio_L7751_C5")]
        public _playback_e__Struct playback;

        [NativeTypeName("__AnonymousRecord_miniaudio_L7777_C5")]
        public _capture_e__Struct capture;

        [NativeTypeName("__AnonymousRecord_miniaudio_L7800_C5")]
        public _Anonymous_e__Union Anonymous;

        [UnscopedRef]
        internal ref _Anonymous_e__Union._wasapi_e__Struct wasapi
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return ref Anonymous.wasapi;
            }
        }

        [UnscopedRef]
        internal ref _Anonymous_e__Union._dsound_e__Struct dsound
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return ref Anonymous.dsound;
            }
        }

        [UnscopedRef]
        internal ref _Anonymous_e__Union._winmm_e__Struct winmm
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return ref Anonymous.winmm;
            }
        }

        [UnscopedRef]
        internal ref _Anonymous_e__Union._jack_e__Struct jack
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return ref Anonymous.jack;
            }
        }

        [UnscopedRef]
        internal ref _Anonymous_e__Union._null_device_e__Struct null_device
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return ref Anonymous.null_device;
            }
        }

        internal unsafe partial struct _resampling_e__Struct
        {
            public ma_resample_algorithm algorithm;

            public ma_resampling_backend_vtable* pBackendVTable;

            public void* pBackendUserData;

            [NativeTypeName("__AnonymousRecord_miniaudio_L7746_C9")]
            public _linear_e__Struct linear;

            internal partial struct _linear_e__Struct
            {
                [NativeTypeName("ma_uint32")]
                public uint lpfOrder;
            }
        }

        internal unsafe partial struct _playback_e__Struct
        {
            public ma_device_id* pID;

            public ma_device_id id;

            [NativeTypeName("char[256]")]
            public _name_e__FixedBuffer name;

            public ma_share_mode shareMode;

            [NativeTypeName("ma_format")]
            public Naquadic.Common.Enums.Format format;

            [NativeTypeName("ma_uint32")]
            public uint channels;

            [NativeTypeName("ma_channel[254]")]
            public _channelMap_e__FixedBuffer channelMap;

            [NativeTypeName("ma_format")]
            public Naquadic.Common.Enums.Format internalFormat;

            [NativeTypeName("ma_uint32")]
            public uint internalChannels;

            [NativeTypeName("ma_uint32")]
            public uint internalSampleRate;

            [NativeTypeName("ma_channel[254]")]
            public _internalChannelMap_e__FixedBuffer internalChannelMap;

            [NativeTypeName("ma_uint32")]
            public uint internalPeriodSizeInFrames;

            [NativeTypeName("ma_uint32")]
            public uint internalPeriods;

            public ma_channel_mix_mode channelMixMode;

            [NativeTypeName("ma_bool32")]
            public uint calculateLFEFromSpatialChannels;

            public ma_data_converter converter;

            public void* pIntermediaryBuffer;

            [NativeTypeName("ma_uint32")]
            public uint intermediaryBufferCap;

            [NativeTypeName("ma_uint32")]
            public uint intermediaryBufferLen;

            public void* pInputCache;

            [NativeTypeName("ma_uint64")]
            public ulong inputCacheCap;

            [NativeTypeName("ma_uint64")]
            public ulong inputCacheConsumed;

            [NativeTypeName("ma_uint64")]
            public ulong inputCacheRemaining;

            [InlineArray(256)]
            public partial struct _name_e__FixedBuffer
            {
                public sbyte e0;
            }

            [InlineArray(254)]
            public partial struct _channelMap_e__FixedBuffer
            {
                public byte e0;
            }

            [InlineArray(254)]
            public partial struct _internalChannelMap_e__FixedBuffer
            {
                public byte e0;
            }
        }

        internal unsafe partial struct _capture_e__Struct
        {
            public ma_device_id* pID;

            public ma_device_id id;

            [NativeTypeName("char[256]")]
            public _name_e__FixedBuffer name;

            public ma_share_mode shareMode;

            [NativeTypeName("ma_format")]
            public Naquadic.Common.Enums.Format format;

            [NativeTypeName("ma_uint32")]
            public uint channels;

            [NativeTypeName("ma_channel[254]")]
            public _channelMap_e__FixedBuffer channelMap;

            [NativeTypeName("ma_format")]
            public Naquadic.Common.Enums.Format internalFormat;

            [NativeTypeName("ma_uint32")]
            public uint internalChannels;

            [NativeTypeName("ma_uint32")]
            public uint internalSampleRate;

            [NativeTypeName("ma_channel[254]")]
            public _internalChannelMap_e__FixedBuffer internalChannelMap;

            [NativeTypeName("ma_uint32")]
            public uint internalPeriodSizeInFrames;

            [NativeTypeName("ma_uint32")]
            public uint internalPeriods;

            public ma_channel_mix_mode channelMixMode;

            [NativeTypeName("ma_bool32")]
            public uint calculateLFEFromSpatialChannels;

            public ma_data_converter converter;

            public void* pIntermediaryBuffer;

            [NativeTypeName("ma_uint32")]
            public uint intermediaryBufferCap;

            [NativeTypeName("ma_uint32")]
            public uint intermediaryBufferLen;

            [InlineArray(256)]
            public partial struct _name_e__FixedBuffer
            {
                public sbyte e0;
            }

            [InlineArray(254)]
            public partial struct _channelMap_e__FixedBuffer
            {
                public byte e0;
            }

            [InlineArray(254)]
            public partial struct _internalChannelMap_e__FixedBuffer
            {
                public byte e0;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        internal partial struct _Anonymous_e__Union
        {
            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L7803_C9")]
            public _wasapi_e__Struct wasapi;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L7844_C9")]
            public _dsound_e__Struct dsound;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L7854_C9")]
            public _winmm_e__Struct winmm;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L7897_C9")]
            public _jack_e__Struct jack;

            [FieldOffset(0)]
            [NativeTypeName("__AnonymousRecord_miniaudio_L7994_C9")]
            public _null_device_e__Struct null_device;

            internal unsafe partial struct _wasapi_e__Struct
            {
                [NativeTypeName("ma_ptr")]
                public void* pAudioClientPlayback;

                [NativeTypeName("ma_ptr")]
                public void* pAudioClientCapture;

                [NativeTypeName("ma_ptr")]
                public void* pRenderClient;

                [NativeTypeName("ma_ptr")]
                public void* pCaptureClient;

                [NativeTypeName("ma_ptr")]
                public void* pDeviceEnumerator;

                public ma_IMMNotificationClient notificationClient;

                [NativeTypeName("ma_handle")]
                public void* hEventPlayback;

                [NativeTypeName("ma_handle")]
                public void* hEventCapture;

                [NativeTypeName("ma_uint32")]
                public uint actualBufferSizeInFramesPlayback;

                [NativeTypeName("ma_uint32")]
                public uint actualBufferSizeInFramesCapture;

                [NativeTypeName("ma_uint32")]
                public uint originalPeriodSizeInFrames;

                [NativeTypeName("ma_uint32")]
                public uint originalPeriodSizeInMilliseconds;

                [NativeTypeName("ma_uint32")]
                public uint originalPeriods;

                public ma_performance_profile originalPerformanceProfile;

                [NativeTypeName("ma_uint32")]
                public uint periodSizeInFramesPlayback;

                [NativeTypeName("ma_uint32")]
                public uint periodSizeInFramesCapture;

                public void* pMappedBufferCapture;

                [NativeTypeName("ma_uint32")]
                public uint mappedBufferCaptureCap;

                [NativeTypeName("ma_uint32")]
                public uint mappedBufferCaptureLen;

                public void* pMappedBufferPlayback;

                [NativeTypeName("ma_uint32")]
                public uint mappedBufferPlaybackCap;

                [NativeTypeName("ma_uint32")]
                public uint mappedBufferPlaybackLen;

                public ma_atomic_bool32 isStartedCapture;

                public ma_atomic_bool32 isStartedPlayback;

                [NativeTypeName("ma_uint32")]
                public uint loopbackProcessID;

                [NativeTypeName("ma_bool8")]
                public byte loopbackProcessExclude;

                [NativeTypeName("ma_bool8")]
                public byte noAutoConvertSRC;

                [NativeTypeName("ma_bool8")]
                public byte noDefaultQualitySRC;

                [NativeTypeName("ma_bool8")]
                public byte noHardwareOffloading;

                [NativeTypeName("ma_bool8")]
                public byte allowCaptureAutoStreamRouting;

                [NativeTypeName("ma_bool8")]
                public byte allowPlaybackAutoStreamRouting;

                [NativeTypeName("ma_bool8")]
                public byte isDetachedPlayback;

                [NativeTypeName("ma_bool8")]
                public byte isDetachedCapture;

                public ma_wasapi_usage usage;

                public void* hAvrtHandle;

                [NativeTypeName("ma_mutex")]
                public void* rerouteLock;
            }

            internal unsafe partial struct _dsound_e__Struct
            {
                [NativeTypeName("ma_ptr")]
                public void* pPlayback;

                [NativeTypeName("ma_ptr")]
                public void* pPlaybackPrimaryBuffer;

                [NativeTypeName("ma_ptr")]
                public void* pPlaybackBuffer;

                [NativeTypeName("ma_ptr")]
                public void* pCapture;

                [NativeTypeName("ma_ptr")]
                public void* pCaptureBuffer;
            }

            internal unsafe partial struct _winmm_e__Struct
            {
                [NativeTypeName("ma_handle")]
                public void* hDevicePlayback;

                [NativeTypeName("ma_handle")]
                public void* hDeviceCapture;

                [NativeTypeName("ma_handle")]
                public void* hEventPlayback;

                [NativeTypeName("ma_handle")]
                public void* hEventCapture;

                [NativeTypeName("ma_uint32")]
                public uint fragmentSizeInFrames;

                [NativeTypeName("ma_uint32")]
                public uint iNextHeaderPlayback;

                [NativeTypeName("ma_uint32")]
                public uint iNextHeaderCapture;

                [NativeTypeName("ma_uint32")]
                public uint headerFramesConsumedPlayback;

                [NativeTypeName("ma_uint32")]
                public uint headerFramesConsumedCapture;

                [NativeTypeName("ma_uint8 *")]
                public byte* pWAVEHDRPlayback;

                [NativeTypeName("ma_uint8 *")]
                public byte* pWAVEHDRCapture;

                [NativeTypeName("ma_uint8 *")]
                public byte* pIntermediaryBufferPlayback;

                [NativeTypeName("ma_uint8 *")]
                public byte* pIntermediaryBufferCapture;

                [NativeTypeName("ma_uint8 *")]
                public byte* _pHeapData;
            }

            internal unsafe partial struct _jack_e__Struct
            {
                [NativeTypeName("ma_ptr")]
                public void* pClient;

                [NativeTypeName("ma_ptr *")]
                public void** ppPortsPlayback;

                [NativeTypeName("ma_ptr *")]
                public void** ppPortsCapture;

                public float* pIntermediaryBufferPlayback;

                public float* pIntermediaryBufferCapture;
            }

            internal unsafe partial struct _null_device_e__Struct
            {
                [NativeTypeName("ma_thread")]
                public void* deviceThread;

                [NativeTypeName("ma_event")]
                public void* operationEvent;

                [NativeTypeName("ma_event")]
                public void* operationCompletionEvent;

                [NativeTypeName("ma_semaphore")]
                public void* operationSemaphore;

                [NativeTypeName("ma_uint32")]
                public uint operation;

                public ma_result operationResult;

                public ma_timer timer;

                public double priorRunTime;

                [NativeTypeName("ma_uint32")]
                public uint currentPeriodFramesRemainingPlayback;

                [NativeTypeName("ma_uint32")]
                public uint currentPeriodFramesRemainingCapture;

                [NativeTypeName("ma_uint64")]
                public ulong lastProcessedFramePlayback;

                [NativeTypeName("ma_uint64")]
                public ulong lastProcessedFrameCapture;

                public ma_atomic_bool32 isStarted;
            }
        }
    }
}
