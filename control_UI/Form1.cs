using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace Test
{
    public partial class Form1 : Form
    {
        string nhan = String.Empty;

        byte slaveAddress = 1;
        byte functionCode = 0x10;
        ushort startAddress = 0;
        ushort numberOfPoints = 2;
        byte byteCount = 4;
        ushort data1 = 0;
        ushort data2 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cboPort.Items.AddRange(ports);
            cboPort.SelectedIndex = 0;
            btnClose.Enabled = false;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = false ;
            btnClose.Enabled = true ;
            try
            {
                serialPort1.PortName = cboPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(cboBaud.Text);
                serialPort1.Open();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private byte[] StringToByteArray(string hex)
        {
            hex = hex.Replace(" ", ""); // Loại bỏ khoảng trắng nếu có
            int numberChars = hex.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            btnOpen.Enabled = true;
            btnClose.Enabled = false;
            try
            {
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    byte[] receivedBytes = ReadFromSerialPort();

                    // Hiển thị chuỗi hex trong TextBox
                    txtReceive.Text = this.Display(receivedBytes);
                    txtCRCReceive.Text = string.Format("{0:X2} {1:X2}", receivedBytes[receivedBytes.Length - 2], receivedBytes[receivedBytes.Length - 1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private byte[] ReadFromSerialPort()
        {
            // Khởi tạo một buffer để lưu dữ liệu đọc được
            byte[] buffer = new byte[serialPort1.BytesToRead];

            // Đọc dữ liệu từ cổng serial và lưu vào buffer
            serialPort1.Read(buffer, 0, buffer.Length);

            return buffer;
        }

        // Phương thức chuyển đổi mảng byte thành chuỗi hex


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
                serialPort1.Close();
        }

        private void btnOn_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        data1 = 1;
                        byte[] frame = this.PresetMultipleRegisters(data1, data2);

                        txtCRCSend.Text = string.Format("{0:X2} {1:X2}", frame[frame.Length - 2], frame[frame.Length - 1]);
                        txtMessage.Text = this.Display(frame);

                        // Di chuyển con trỏ về cuối TextBox
                        txtMessage.SelectionStart = txtMessage.TextLength;

                        // Tập trung vào TextBox
                        txtMessage.Focus();

                        serialPort1.Write(frame, 0, frame.Length);
                        System.Threading.Thread.Sleep(100);

                        byte[] receivedBytes = ReadFromSerialPort();

                        // Hiển thị chuỗi hex trong TextBox
                        txtReceive.Text = this.Display(receivedBytes);
                        txtCRCReceive.Text = string.Format("{0:X2} {1:X2}", receivedBytes[receivedBytes.Length - 2], receivedBytes[receivedBytes.Length - 1]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOFF_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        data1 = 0;

                        byte[] frame = this.PresetMultipleRegisters(data1, data2);

                        txtCRCSend.Text = string.Format("{0:X2} {1:X2}", frame[frame.Length - 2], frame[frame.Length - 1]);
                        txtMessage.Text = this.Display(frame);

                        // Di chuyển con trỏ về cuối TextBox
                        txtMessage.SelectionStart = txtMessage.TextLength;

                        // Tập trung vào TextBox
                        txtMessage.Focus();

                        serialPort1.Write(frame, 0, frame.Length);
                        System.Threading.Thread.Sleep(100);
                        byte[] receivedBytes = ReadFromSerialPort();

                        // Hiển thị chuỗi hex trong TextBox
                        txtReceive.Text = this.Display(receivedBytes);
                        txtCRCReceive.Text = string.Format("{0:X2} {1:X2}", receivedBytes[receivedBytes.Length - 2], receivedBytes[receivedBytes.Length - 1]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            nhan = serialPort1.ReadExisting();
            // ham ngat trong c#
            this.Invoke(new EventHandler(DoUpdate));
        }
        private void DoUpdate(object sender, EventArgs e)
        {
            if (nhan.Length > 0)
            {
                Invoke(new MethodInvoker(() => txtReceive.Text = nhan));
            }
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnCaculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1.IsOpen)
                {
                    // Lấy dữ liệu hex từ TextBox
                    string hexData = txtMessage.Text;

                    // Chuyển đổi chuỗi hex thành mảng byte
                    byte[] byteArray = StringToByteArray(hexData);

                    byte[] frame = this.ReadHoldingRegisters(byteArray);

                    txtCRCSend.Text = string.Format("{0:X2} {1:X2}", frame[frame.Length - 2], frame[frame.Length - 1]);
                    txtMessage.Text = this.Display(frame);

                    // Di chuyển con trỏ về cuối TextBox
                    txtMessage.SelectionStart = txtMessage.TextLength;

                    // Tập trung vào TextBox
                    txtMessage.Focus();

                    serialPort1.Write(frame, 0, frame.Length);
                    System.Threading.Thread.Sleep(100);
                    byte[] receivedBytes = ReadFromSerialPort();

                    // Hiển thị chuỗi hex trong TextBox
                    txtReceive.Text = this.Display(receivedBytes);
                    txtCRCReceive.Text = string.Format("{0:X2} {1:X2}", receivedBytes[receivedBytes.Length - 2], receivedBytes[receivedBytes.Length - 1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCRCReceive_TextChanged(object sender, EventArgs e)
        {

        }
        private byte[] ReadHoldingRegisters(byte[] byteArray)
        {
            byte[] frame = new byte[8];
            for(int i = 0; i<6; i++)
            {
                frame[i]= byteArray[i];
            }
            byte[] crc = this.CaculateCRC(frame);
            frame[6] = crc[0];
            frame[7] = crc[1];
            return frame;
        }

        private byte[] PresetMultipleRegisters(ushort data1, ushort data2)
        {
            byte[] frame = new byte[13];
            frame[0] = slaveAddress;
            frame[1] = functionCode;
            frame[2] = (byte)(startAddress >> 8);
            frame[3] = (byte)startAddress;
            frame[4] = (byte)(numberOfPoints >> 8);
            frame[5] = (byte)numberOfPoints;
            frame[6] = byteCount;
            frame[7] = (byte)(data1 >> 8);
            frame[8] = (byte)data1;
            frame[9] = (byte)(data2 >> 8);
            frame[10] = (byte)data2;
            byte[] crc = this.CaculateCRC(frame);
            frame[11] = crc[0];
            frame[12] = crc[1];
            return frame;
        }

        private byte[] CaculateCRC(byte[] frame)
        {
            byte[] result = new byte[2];
            ushort CRCFull = 0xFFFF;
            char CRCLSB;
            for (int i = 0; i < frame.Length - 2; i++)
            {
                CRCFull = (ushort)(CRCFull ^ frame[i]);

                for (int j = 0; j < 8; j++)
                {
                    CRCLSB = (char)(CRCFull & 0x0001);
                    CRCFull = (ushort)((CRCFull >> 1) & 0x7FFF);

                    if (CRCLSB == 1)
                    {
                        CRCFull = (ushort)(CRCFull ^ 0xA001);
                    }
                }
            }
            result[1] = (byte)((CRCFull >> 8) & 0xFF);
            result[0] = (byte)(CRCFull & 0xFF);
            return result;
        }

        private string Display(byte[] frame)
        {
            string result = string.Empty;
            foreach (byte item in frame)
            {
                result += string.Format("{0:X2} ", item);
            }
            return result;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnON1_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        data2 = 1;
                        byte[] frame = this.PresetMultipleRegisters(data1, data2);

                        txtCRCSend.Text = string.Format("{0:X2} {1:X2}", frame[frame.Length - 2], frame[frame.Length - 1]);
                        txtMessage.Text = this.Display(frame);

                        // Di chuyển con trỏ về cuối TextBox
                        txtMessage.SelectionStart = txtMessage.TextLength;

                        // Tập trung vào TextBox
                        txtMessage.Focus();

                        serialPort1.Write(frame, 0, frame.Length);
                        System.Threading.Thread.Sleep(100);
                        byte[] receivedBytes = ReadFromSerialPort();

                        // Hiển thị chuỗi hex trong TextBox
                        txtReceive.Text = this.Display(receivedBytes);
                        txtCRCReceive.Text = string.Format("{0:X2} {1:X2}", receivedBytes[receivedBytes.Length - 2], receivedBytes[receivedBytes.Length - 1]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnOFF1_Click_1(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        data2 = 0;

                        byte[] frame = this.PresetMultipleRegisters(data1, data2);

                        txtCRCSend.Text = string.Format("{0:X2} {1:X2}", frame[frame.Length - 2], frame[frame.Length - 1]);
                        txtMessage.Text = this.Display(frame);

                        // Di chuyển con trỏ về cuối TextBox
                        txtMessage.SelectionStart = txtMessage.TextLength;

                        // Tập trung vào TextBox
                        txtMessage.Focus();

                        serialPort1.Write(frame, 0, frame.Length);
                        System.Threading.Thread.Sleep(100);
                        byte[] receivedBytes = ReadFromSerialPort();

                        // Hiển thị chuỗi hex trong TextBox
                        txtReceive.Text = this.Display(receivedBytes);
                        txtCRCReceive.Text = string.Format("{0:X2} {1:X2}", receivedBytes[receivedBytes.Length - 2], receivedBytes[receivedBytes.Length - 1]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
