using System;
using System.Runtime.InteropServices;

namespace SHDViewer
{
    //#define SHD_SIGNATURE_WIN98    $0000494B //Windows 98
    //#define SHD_SIGNATURE_WINNT    $00004966 //Windows NT
    //#define SHD_SIGNATURE_WIN2000  $00004967 //Win2000/XP 
    //#define SHD_SIGNATURE_WIN2003  $00004968 //Windows 2003

    //#define SHD_SIGNATURE_WIN7 $00004968
    //#define SHD_SIGNATURE_WIN10 $00005123

    public struct SHADOW_FILE_HEADER_WIN7OR10_X64
    {
        public /*DWORD*/ Int32 dwSignature;        //SHD_SIGNATURE_WIN2000
        public /*DWORD*/ Int32 dwHeaderSize;
        public /*WORD*/ Int16 wStatus;
        public /*WORD*/ Int16 wUnknown1;
        public /*DWORD*/ Int32 dwJobID;
        public /*QWORD*/ Int64 dwPriority;
        public /*QWORD*/ Int64 offUserName;        //Offset of WideChar+0
        public /*QWORD*/ Int64 offNotifyName;      //Offset of WideChar+0
        public /*QWORD*/ Int64 offDocumentName;    //Offset of WideChar+0
        public /*QWORD*/ Int64 offPort;            //Offset of WideChar+0
        public /*QWORD*/ Int64 offPrinterName;     //Offset of WideChar+0
        public /*QWORD*/ Int64 offDriverName;      //Offset of WideChar+0
        public /*QWORD*/ Int64 offDevMode;         //Offset of DEVMODE
                                                   //Note that the dmCopies in this structure will hold
                                                   //the wrong value when the Microsoft Word multiple 
                                                   //copies bug occurs.
                                                   //In this case use the dmCopies from the SPL file
        public /*QWORD*/ Int64 offPrintProcessor;  //Offset of WideChar+0
        public /*QWORD*/ Int64 offDataFormat;      //Offset of WideChar+0
        public /*DWORD*/ Int32 dwUnknown2;
        public /*DWORD*/ Int32 dwUnknown9;

        public /*WORD*/ Int16 wYear;

        /* SYSTEMTIME*/
        //SYSTEMTIME stSubmitTime;
        public /*WORD*/ Int16 wMonth;
        public /*WORD*/ Int16 wDayOfWeek;
        public /*WORD*/ Int16 wDay;
        public /*WORD*/ Int16 wHour;
        public /*WORD*/ Int16 wMinute;
        public /*WORD*/ Int16 wSecond;
        public /*WORD*/ Int16 wMilliSeconds;
        /* End of SYSTEMTIME*/


        public /*DWORD*/ Int32 dwStartTime;
        public /*DWORD*/ Int32 dwUntilTime;
        public /*DWORD*/ Int32 dwSPLSize;
        public /*DWORD*/ Int32 dwPageCount;
        public /*QWORD*/ Int64 qwSizeSecurityInfo; //Size of SecurityInfo
        public /*QWORD*/ Int64 offSecurityInfo;    //Offset of SECURITY_DESCRIPTOR
        public /*DWORD*/ Int32 dwUnknown3;
        public /*DWORD*/ Int32 dwUnknown4;
        public /*QWORD*/ Int64 dwUnknown5;
        public /*QWORD*/ Int64 offComputername;    //Offset of WideChar+0
        public /*QWORD*/ Int64 dwUnknown7;
        public /*QWORD*/ Int64 offSID;          //Size of SPL File
    }; 


    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 1)]
    public struct SHADOW_FILE_HEADER_WIN7OR10_X32
    {
        /*DWORD*/ Int32 dwSignature;
        /*DWORD*/ Int32 dwHeaderSize;
        /*WORD*/ Int16 wStatus;
        /*WORD*/ Int16 wUnknown1;
        /*DWORD*/ Int32 dwJobID;
        /*DWORD*/ Int32 dwPriority;
        /*DWORD*/ Int32 offUserName;        //Offset of WideChar+0
        /*DWORD*/ Int32 offNotifyName;      //Offset of WideChar+0
        /*DWORD*/ Int32 offDocumentName;    //Offset of WideChar+0
        /*DWORD*/ Int32 offPort;            //Offset of WideChar+0
        /*DWORD*/ Int32 offPrinterName;     //Offset of WideChar+0
        /*DWORD*/ Int32 offDriverName;      //Offset of WideChar+0
        /*DWORD*/ Int32 offDevMode;         //Offset of DEVMODE
                                  //Note that the dmCopies in this structure will hold
                                  //the wrong value when the Microsoft Word multiple 
                                  //copies bug occurs.
                                  //In this case use the dmCopies from the SPL file
        /*DWORD*/ Int32 offPrintProcessor;  //Offset of WideChar+0
        /*DWORD*/ Int32 offDataFormat;      //Offset of WideChar+0
        /*DWORD*/ Int32 dwUnknown2;


        /*WORD*/ Int16 wYear;

        /* SYSTEMTIME*/
        //SYSTEMTIME stSubmitTime;
        /*WORD*/ Int16 wMonth;
        /*WORD*/ Int16 wDayOfWeek;
        /*WORD*/ Int16 wDay;
        /*WORD*/ Int16 wHour;
        /*WORD*/ Int16 wMinute;
        /*WORD*/ Int16 wSecond;
        /*WORD*/ Int16 wMilliSeconds;
        /* End of SYSTEMTIME*/


        /*DWORD*/ Int32 dwStartTime;
        /*DWORD*/ Int32 dwUntilTime;
        /*DWORD*/ Int32 dwSPLSize;
        /*DWORD*/ Int32 dwPageCount;
        /*DWORD*/ Int32 qwSizeSecurityInfo; //Size of SecurityInfo
        /*DWORD*/ Int32 offSecurityInfo;    //Offset of SECURITY_DESCRIPTOR
        /*DWORD*/ Int32 dwUnknown3;
        /*DWORD*/ Int32 dwUnknown4;
        /*DWORD*/ Int32 dwUnknown5;
        /*DWORD*/ Int32 offComputername;    //Offset of WideChar+0
        /*DWORD*/ Int32 dwSPLSize2;
        /*DWORD*/ Int32 offSID;
    }
}
