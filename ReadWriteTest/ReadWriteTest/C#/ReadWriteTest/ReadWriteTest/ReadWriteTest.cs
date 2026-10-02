using System;
using System.Windows.Forms;

using Avalue;

namespace ReadWriteTest
{
    public partial class ReadWriteTest : Form
    {
        void Log(string text)
        {
            TXB_LOG.AppendText($"{DateTime.Now} {text}\r\n");
        }

        public ReadWriteTest()
        {
            InitializeComponent();

            CBB_ACCESS_READ.SelectedIndex = 0;
            CBB_ACCESS_WRITE.SelectedIndex = 0;
            CBB_RWSIZE_READ.SelectedIndex = 0;
            CBB_RWSIZE_WRITE.SelectedIndex = 0;

            Enabled = AvalueAPI.Start();

            Log($"Avalue API Start: {(Enabled ? "SUCCESS" : "FAIL")}");
        }

        private void ReadWriteTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            AvalueAPI.Stop();
        }

        private void BTN_READ_Click(object sender, EventArgs e)
        {
            AvalueAPI.ACCESS access = (AvalueAPI.ACCESS)CBB_ACCESS_READ.SelectedIndex;
            AvalueAPI.RWSIZE rwsize = (AvalueAPI.RWSIZE)CBB_RWSIZE_READ.SelectedIndex;

            try
            {
                uint command = Convert.ToUInt32(TXB_COMMAND_READ.Text, 16);

                uint read = AvalueAPI.Read(access, rwsize, command);

                Log($"Avalue API Read: 0x{read:X}");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void BTN_WRITE_Click(object sender, EventArgs e)
        {
            AvalueAPI.ACCESS access = (AvalueAPI.ACCESS)CBB_ACCESS_WRITE.SelectedIndex;
            AvalueAPI.RWSIZE rwsize = (AvalueAPI.RWSIZE)CBB_RWSIZE_WRITE.SelectedIndex;

            try
            {
                uint command = Convert.ToUInt32(TXB_COMMAND_WRITE.Text, 16);
                uint data = Convert.ToUInt32(TXB_DATA_WRITE.Text, 16);

                bool write = AvalueAPI.Write(access, rwsize, command, data);

                Log($"Avalue API Write: {(write ? "SUCCESS" : "FAIL")}");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
    }
}