﻿using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easynvest.Temperature.ConsoleApp.Arduino
{
    public class SerialPortManager
    {
        private string PortName { get; set; }
        private SerialPort Port { get; set; }
        public SerialPortManager(string port)
        {

            if (Port == null)
            {
                //A porta pode mudar conforme alocação do S.O
                Port = new SerialPort(PortName = port);

                //Essa configuração é padrão para obter os dados da porta serial(no caso do Arduíno)
                Port.BaudRate = 9600;
                Port.Parity = Parity.None;
                Port.StopBits = StopBits.One;
                Port.DataBits = 8;
                Port.Handshake = Handshake.None;
                Port.RtsEnable = true;
            }

        }

        internal void AddDataReceivedHandler(SerialDataReceivedEventHandler serialDataReceivedEventHandler)
        {
            Port.DataReceived += serialDataReceivedEventHandler;
        }

        public void Start()
        {
            if (Port != null)
            {
                Port.Open();
            }
        }
        public void Stop()
        {
            if (Port != null && Port.IsOpen)
            {
                Port.Close();
            }
        }
    }
}
