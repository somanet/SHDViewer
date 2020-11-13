using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SHDViewer
{
    public partial class FrmSHDViewer : Form
    {
        private FileStream _fileStream;

        public FrmSHDViewer()
        {
            InitializeComponent();
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 열기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenSHDFile();
        }

        private void OpenSHDFile()
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Multiselect = false;
                dlg.Filter = "SHD File|*.SHD|All File|*.*";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                if(_fileStream != null)
                    _fileStream.Close();

                _fileStream = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

                ReadSHDFile();
            }

        }

        private void ReadSHDFile()
        {
            var header = GetX64Header(_fileStream);

            var info = new SHDInfo(header, _fileStream);

            propertyGrid1.SelectedObject = info;


        }


        private SHADOW_FILE_HEADER_WIN7OR10_X64 GetX64Header(FileStream fileStream)
        {
            SHADOW_FILE_HEADER_WIN7OR10_X64 header;
            byte[] buffer = new byte[fileStream.Length];

            fileStream.Read(buffer, 0, (int)fileStream.Length);

            unsafe
            {
                fixed (byte* ptr = buffer)
                {
                    header = (SHADOW_FILE_HEADER_WIN7OR10_X64)Marshal.PtrToStructure((IntPtr)ptr, typeof(SHADOW_FILE_HEADER_WIN7OR10_X64));
                }
            }

            return header;

        }
        private SHADOW_FILE_HEADER_WIN7OR10_X32 GetX32Header(byte[] buffer)
        {
            SHADOW_FILE_HEADER_WIN7OR10_X32 header;
            unsafe
            {
                fixed (byte* ptr = buffer)
                {
                    header = (SHADOW_FILE_HEADER_WIN7OR10_X32)Marshal.PtrToStructure((IntPtr)ptr, typeof(SHADOW_FILE_HEADER_WIN7OR10_X32));
                }
            }

            return header;

        }


        private void FrmSHDViewer_Shown(object sender, EventArgs e)
        {
            OpenSHDFile();
        }
    }
}
