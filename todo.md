## Starts from here

```c
struct ma_engine
{
    ma_node_graph nodeGraph;                /* An engine is a node graph. It should be able to be plugged into any ma_node_graph API (with a cast) which means this must be the first member of this struct. */
#if !defined(MA_NO_RESOURCE_MANAGER)
    ma_resource_manager* pResourceManager;
#endif
#if !defined(MA_NO_DEVICE_IO)
    ma_device* pDevice;                     /* Optionally set via the config, otherwise allocated by the engine in ma_engine_init(). */
#endif
    ma_log* pLog;
    ma_uint32 sampleRate;
    ma_uint32 listenerCount;
    ma_spatializer_listener listeners[MA_ENGINE_MAX_LISTENERS];
    ma_allocation_callbacks allocationCallbacks;
    ma_bool8 ownsResourceManager;
    ma_bool8 ownsDevice;
    ma_spinlock inlinedSoundLock;               /* For synchronizing access so the inlined sound list. */
    ma_sound_inlined* pInlinedSoundHead;        /* The first inlined sound. Inlined sounds are tracked in a linked list. */
    MA_ATOMIC(4, ma_uint32) inlinedSoundCount;  /* The total number of allocated inlined sound objects. Used for debugging. */
    ma_uint32 gainSmoothTimeInFrames;           /* The number of frames to interpolate the gain of spatialized sounds across. */
    ma_uint32 defaultVolumeSmoothTimeInPCMFrames;
    ma_mono_expansion_mode monoExpansionMode;
    ma_engine_process_proc onProcess;
    void* pProcessUserData;
};
```