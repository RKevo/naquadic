namespace Naquadic.Miniaudio.Windows
{
    public partial struct ma_peak_node_config
    {
        public ma_node_config nodeConfig;

        [NativeTypeName("ma_peak_config")]
        public ma_peak2_config peak;
    }
}
