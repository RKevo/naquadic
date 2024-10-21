rmdir /S /Q "Naquadic/Miniaudio.Windows"
rmdir /S /Q "Naquadic/Miniaudio.Linux"
ClangSharpPInvokeGenerator @generate-win.rsp
ClangSharpPInvokeGenerator @generate-linux.rsp