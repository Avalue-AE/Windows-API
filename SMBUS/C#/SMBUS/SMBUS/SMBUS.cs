using System;
using System.Windows.Forms;

using Avalue;

namespace SMBUS
{
    public unsafe partial class SMBUS : Form
    {
        void Log(string text)
        {
            TXB_LOG.AppendText($"{DateTime.Now} {text}\r\n");
        }

        public SMBUS()
        {
            InitializeComponent();

            CBB_RWSIZE_READ.SelectedIndex = 0;
            CBB_RWSIZE_WRITE.SelectedIndex = 0;

            Enabled = AvalueAPI.Start();

            Log($"Avalue API Start: {(Enabled ? "SUCCESS" : "FAIL")}");

            Enabled = AvalueAPI.SMBUS.Init();

            Log($"SMBUS Init: {(Enabled ? "SUCCESS" : "FAIL")}");
        }

        private void SMBUS_FormClosing(object sender, FormClosingEventArgs e)
        {
            AvalueAPI.SMBUS.Disable();
            AvalueAPI.Stop();
        }

        private void BTN_CheckStatus_Click(object sender, EventArgs e)
        {
            Log($"SMBUS Status: {AvalueAPI.SMBUS.Status()}");
        }

        private void BTN_READ_Click(object sender, EventArgs e)
        {
            AvalueAPI.RWSIZE rwsize = (AvalueAPI.RWSIZE)CBB_RWSIZE_READ.SelectedIndex;

            try
            {
                byte address = Convert.ToByte(TXB_ADDRESS_READ.Text, 16);
                byte register = Convert.ToByte(TXB_REGISTER_READ.Text, 16);
                uint data;

                bool read = AvalueAPI.SMBUS.Read(rwsize, address, register, &data);

                Log($"SMBUS Read: {(read ? $"SUCCESS 0x{data:X8}({data})" : "FAIL")}");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }

        private void BTN_WRITE_Click(object sender, EventArgs e)
        {
            AvalueAPI.RWSIZE rwsize = (AvalueAPI.RWSIZE)CBB_RWSIZE_WRITE.SelectedIndex;

            try
            {
                byte address = Convert.ToByte(TXB_ADDRESS_WRITE.Text, 16);
                byte register = Convert.ToByte(TXB_REGISTER_WRITE.Text, 16);
                uint data = Convert.ToUInt32(TXB_DATA_WRITE.Text, 16);

                bool write = AvalueAPI.SMBUS.Write(rwsize, address, register, data);

                Log($"SMBUS Write: {(write ? "SUCCESS" : "FAIL")}");
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
    }
}