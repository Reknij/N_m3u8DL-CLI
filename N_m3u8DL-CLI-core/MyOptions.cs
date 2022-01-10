using CommandLine;
using CommandLine.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_m3u8DL_CLI_core
{
    internal class MyOptions
    {
        [Value(0, Hidden = true, MetaName = "Input Source", HelpText = "Help_input", ResourceType = typeof(stringscore))]
        public string? Input { get; set; }

        [Option("workDir", HelpText = "Help_workDir", ResourceType = typeof(stringscore))]
        public string? WorkDir { get; set; }

        [Option("saveName", HelpText = "Help_saveName", ResourceType = typeof(stringscore))]
        public string SaveName { get; set; } = "";

        [Option("baseUrl", HelpText = "Help_baseUrl", ResourceType = typeof(stringscore))]
        public string? BaseUrl { get; set; }

        [Option("headers", HelpText = "Help_headers", ResourceType = typeof(stringscore))]
        public string Headers { get; set; } = "";

        [Option("maxThreads", Default = 32U, HelpText = "Help_maxThreads", ResourceType = typeof(stringscore))]
        public uint MaxThreads { get; set; }

        [Option("minThreads", Default = 16U, HelpText = "Help_minThreads", ResourceType = typeof(stringscore))]
        public uint MinThreads { get; set; }

        [Option("retryCount", Default = 15U, HelpText = "Help_retryCount", ResourceType = typeof(stringscore))]
        public uint RetryCount { get; set; }

        [Option("timeOut", Default = 10U, HelpText = "Help_timeOut", ResourceType = typeof(stringscore))]
        public uint TimeOut { get; set; }

        [Option("muxSetJson", HelpText = "Help_muxSetJson", ResourceType = typeof(stringscore))]
        public string? MuxSetJson { get; set; }

        [Option("useKeyFile", HelpText = "Help_useKeyFile", ResourceType = typeof(stringscore))]
        public string? UseKeyFile { get; set; }

        [Option("useKeyBase64", HelpText = "Help_useKeyBase64", ResourceType = typeof(stringscore))]
        public string? UseKeyBase64 { get; set; }

        [Option("useKeyIV", HelpText = "Help_useKeyIV", ResourceType = typeof(stringscore))]
        public string? UseKeyIV { get; set; }

        [Option("downloadRange", HelpText = "Help_downloadRange", ResourceType = typeof(stringscore))]
        public string? DownloadRange { get; set; }

        [Option("liveRecDur", HelpText = "Help_liveRecDur", ResourceType = typeof(stringscore))]
        public string? LiveRecDur { get; set; }

        [Option("stopSpeed", HelpText = "Help_stopSpeed", ResourceType = typeof(stringscore))]
        public long StopSpeed { get; set; } = 0L;

        [Option("maxSpeed", HelpText = "Help_maxSpeed", ResourceType = typeof(stringscore))]
        public long MaxSpeed { get; set; } = 0L;

        [Option("proxyAddress", HelpText = "Help_proxyAddress", ResourceType = typeof(stringscore))]
        public string? ProxyAddress { get; set; }

        [Option("enableDelAfterDone", HelpText = "Help_enableDelAfterDone", ResourceType = typeof(stringscore))]
        public bool EnableDelAfterDone { get; set; }

        [Option("enableMuxFastStart", HelpText = "Help_enableMuxFastStart", ResourceType = typeof(stringscore))]
        public bool EnableMuxFastStart { get; set; }

        [Option("enableBinaryMerge", HelpText = "Help_enableBinaryMerge", ResourceType = typeof(stringscore))]
        public bool EnableBinaryMerge { get; set; }

        [Option("enableParseOnly", HelpText = "Help_enableParseOnly", ResourceType = typeof(stringscore))]
        public bool EnableParseOnly { get; set; }

        [Option("enableAudioOnly", HelpText = "Help_enableAudioOnly", ResourceType = typeof(stringscore))]
        public bool EnableAudioOnly { get; set; }

        [Option("disableDateInfo", HelpText = "Help_disableDateInfo", ResourceType = typeof(stringscore))]
        public bool DisableDateInfo { get; set; }

        [Option("disableIntegrityCheck", HelpText = "Help_disableIntegrityCheck", ResourceType = typeof(stringscore))]
        public bool DisableIntegrityCheck { get; set; }

        [Option("noMerge", HelpText = "Help_noMerge", ResourceType = typeof(stringscore))]
        public bool NoMerge { get; set; }

        [Option("noProxy", HelpText = "Help_noProxy", ResourceType = typeof(stringscore))]
        public bool NoProxy { get; set; }

    }
}
