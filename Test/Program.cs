using Naquadic.Miniaudio.Windows;

class Program
{
    static void Main(string[] args)
    {
        unsafe
        {
            ma_result result;
            ma_engine engine;

            result = avx2.ma_engine_init(null, &engine);
            if (result != ma_result.MA_SUCCESS)
            {
                Console.WriteLine(result);
            }
        }
    }
}
