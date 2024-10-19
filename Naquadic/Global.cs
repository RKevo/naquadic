#if _WINDOWS
global using Naquadic.Miniaudio.Windows;
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
global using funcs = Naquadic.Miniaudio.Windows.Methods;
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
#elif _LINUX
global using Naquadic.Miniaudio.Linux;
global using funcs = Naquadic.Miniaudio.Linux.Methods;
#endif

global using Naquadic.Common.Spatial;

using System.Runtime.CompilerServices;
[assembly: DisableRuntimeMarshalling]


