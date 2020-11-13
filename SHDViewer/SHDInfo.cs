using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace SHDViewer
{
    public class SHDInfo
    {
        private readonly SHADOW_FILE_HEADER_WIN7OR10_X64 _header;
        private Stream _stream;

        public Int32 Signature => _header.dwSignature;
        public Int32 HeaderSize => _header.dwHeaderSize;
        public Int16 Status => _header.wStatus;
        public Int32 JobId => _header.dwJobID;
        public Int64 Priority => _header.dwPriority;

        public string UserName => GetString(_header.offUserName);
        public string NotifyName => GetString(_header.offNotifyName);
        public string DocumentName=> GetString(_header.offDocumentName);

        public string Port => GetString(_header.offPort);
        public string PrinterName => GetString(_header.offPrinterName);

        public string DriverName => GetString(_header.offDriverName);

        public string PrintProcessor => GetString(_header.offPrintProcessor);

        public string DataFormat => GetString(_header.offDataFormat);

        public DateTime SubmitTime => new DateTime(
            _header.wYear, 
            _header.wMonth, 
            _header.wDay, 
            _header.wHour, 
            _header.wMinute, 
            _header.wSecond, 
            _header.wMilliSeconds);

        public Int32 StartTime => _header.dwStartTime;
        public Int32 UntilTime => _header.dwUntilTime;

        public Int32 SpoolSize => _header.dwSPLSize;

        public Int32 PageCount => _header.dwPageCount;

        public Int64 SizeSecurityInfo => _header.qwSizeSecurityInfo;

        public string ComputerName => GetString(_header.offComputername);

        private BinaryReader _binaryReader
            ;


        private string GetString(Int64 offset)
        {
            var builder = new StringBuilder();

            {
                _binaryReader.BaseStream.Seek(offset, SeekOrigin.Begin);

                while (true)
                {
                    var ch = _binaryReader.ReadBytes(2);
                    string str = System.Text.Encoding.Unicode.GetString(ch);

                    if (str == "\0")
                        break;

                    builder.Append(str);
                }
            }

            return builder.ToString();
        }

        //private Int64 GetUserName()
        //{
        //    return GetString()
        //    //byte[] buffer = new byte[1000];
        //    //int size;
        //    //unsafe
        //    //{
        //    //    fixed (byte* p = _buffer)
        //    //    {
        //    //        byte* movedPtr = p + _header.offUserName;
        //    //        size = GetError( ???, movedPtr, _buffer.Length);
        //    //    }
        //    //}
        //    //string result = System.Text.Encoding.Default.GetString(buffer, 0, size);
        //}

        public SHDInfo(SHADOW_FILE_HEADER_WIN7OR10_X64 header, Stream stream)
        {
            _header = header;
            _stream = stream;
            _binaryReader = new BinaryReader(_stream);

            //_stream.Seek(0, SeekOrigin.Begin);

        }
    }
}
