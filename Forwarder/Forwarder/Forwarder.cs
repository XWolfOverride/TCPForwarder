﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

//Copyright(c) 2018 Iván Dominguez (XWolf Override)
//
//This software is provided 'as-is', without any express or implied
//warranty.In no event will the authors be held liable for any damages
//arising from the use of this software.
//
//Permission is granted to anyone to use this software for any purpose,
//including commercial applications, and to alter it and redistribute it
//freely, subject to the following restrictions:
//
//1. The origin of this software must not be misrepresented; you must not
//   claim that you wrote the original software.If you use this software
//   in a product, an acknowledgment in the product documentation would be
//   appreciated but is not required.
//2. Altered source versions must be plainly marked as such, and must not be
//   misrepresented as being the original software.
//3. This notice may not be removed or altered from any source distribution.

namespace Forwarder
{
    public class Forwarder
    {
        private bool stop = false;
        private int currentConections;
        private int totalConnections;
        private IPEndPoint local;
        private IPEndPoint remote;
        private Thread listenerThread;

        #region Management
        public void Activate()
        {
            if (listenerThread != null)
                return;
            lock (this)
            {
                stop = false;
            }
            listenerThread = new Thread(Listen);
            listenerThread.Start();
        }

        public void Deactivate()
        {
            if (listenerThread == null)
                return;
            lock (this)
            {
                stop = true;
            }
            listenerThread.Join();
            Message(ForwarderMessage.FromDeactivation());
            listenerThread = null;
        }

        public void SetLocal(string host, string port)
        {
            Local = new IPEndPoint(GetAddress(host), int.Parse(port));
        }

        public void SetRemote(string host, string port)
        {
            Remote = new IPEndPoint(GetAddress(host), int.Parse(port));
        }

        public static IPAddress GetAddress(string host)
        {
            IPAddress address;
            if (!IPAddress.TryParse(host, out address))
            {
                IPHostEntry dest = Dns.GetHostEntry(host);
                if (dest.AddressList.Length > 0)
                {
                    foreach (IPAddress ip in dest.AddressList)
                        if (ip.AddressFamily == AddressFamily.InterNetwork)
                        {
                            address = ip;
                            break;
                        }
                    if (address == null)
                        address = dest.AddressList[0];
                }
                else
                    throw new Exception("Can't resolve '" + host + "'");
            }
            return address;
        }

        private void Message(ForwarderMessage msg)
        {
            WhenMessage?.Invoke(this, msg);
        }

        #endregion

        #region Listener

        private void Listen()
        {
            Thread.CurrentThread.Name = "Listener on " + local;
            bool running = true;
            TcpListener listener = new TcpListener(local);
            try
            {
                listener.Start();
            }
            catch (SocketException ex)
            {
                running = false;
                Message(ForwarderMessage.FromException(ex));
            }
            Message(ForwarderMessage.FromActivation());
            while (running)
            {
                if (!listener.Pending())
                    Thread.Sleep(100);
                else
                    (new Thread(new ParameterizedThreadStart(ProcessLauncher))).Start(listener.AcceptTcpClient());
                lock (this)
                {
                    running = !stop;
                }
            }
            listener.Stop();
            lock (this)
            {
                listenerThread = null;
            }
        }

        private void ProcessLauncher(object o)
        {
            Transmission trans = null;
            lock (this)
            {
                currentConections++;
                totalConnections++;
            }
            try
            {
                using (TcpClient c = (TcpClient)o)
                {
                    TcpProcess prc = new TcpProcess(this, c.Client, remote);
                    prc.Process();
                    trans = prc.Transmission;
                }
            }
            finally
            {
                lock (this)
                {
                    currentConections--;
                }
                if (trans != null)
                    Message(ForwarderMessage.FromEndTransmission(trans));
            }
        }

        #endregion

        #region TCP processor

        private class TcpProcess
        {
            private readonly Forwarder fw;
            private readonly Socket scksrc;
            private readonly Socket sckdst;
            private readonly Transmission trans;

            public TcpProcess(Forwarder forwarder, Socket source, IPEndPoint remote)
            {
                try
                {
                    fw = forwarder;
                    scksrc = source;
                    sckdst = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    trans = new Transmission(scksrc.RemoteEndPoint as IPEndPoint, remote);
                    forwarder.Message(ForwarderMessage.FromNewTransmission(trans));
                    sckdst.Connect(remote);
                }
                catch (Exception ex)
                {
                    forwarder.Message(ForwarderMessage.FromException(ex));
                }
            }

            public void Process()
            {
                bool alive = true;
                int attl = 0;
                Thread.CurrentThread.Name = "Process " + scksrc.LocalEndPoint + " <-> " + sckdst.RemoteEndPoint + " at " + DateTime.Now;
                try
                {
                    while (alive)
                    {
                        bool afetch = false;
                        if (scksrc.Available > 0)
                        {
                            afetch = true;
                            trans.AddUpload(Dump(scksrc, sckdst));
                            fw.Message(ForwarderMessage.FromSendTransmission(trans));
                        }
                        if (sckdst.Available > 0)
                        {
                            afetch = true;
                            trans.AddDownload(Dump(sckdst, scksrc));
                            fw.Message(ForwarderMessage.FromReceiveTransmission(trans));
                        }
                        if (!afetch)
                            Thread.Sleep(50);
                        alive = fw.Active;
                        if (attl++ > 20)
                        {
                            alive = alive && scksrc.IsConnected() && sckdst.IsConnected();
                            attl = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    fw.Message(ForwarderMessage.FromException(ex));
                }
            }

            private static byte[] Dump(Socket sfrom, Socket sto)
            {
                int bsize = sfrom.Available;
                if (bsize == 0)
                    return null;
                byte[] buf = new byte[bsize];
                sfrom.Receive(buf);
                sto.Send(buf);
                return buf;
            }

            public Transmission Transmission => trans;
        }

        #endregion

        public void ResetCounter()
        {
            totalConnections = 0;
        }

        public override string ToString()
        {
            return local + " -> " + remote;
        }

        public bool Active { get { return listenerThread != null; } set { if (value) Activate(); else Deactivate(); } }
        public IPEndPoint Local { get { return local; } set { if (Active) throw new Exception("Can't set when active"); local = value; } }
        public IPEndPoint Remote { get { return remote; } set { if (Active) throw new Exception("Can't set when active"); remote = value; } }
        public int CurrentConnections { get { return currentConections; } }
        public int TotalConnections { get { return totalConnections; } }
        public ForwarderMessageDelegate WhenMessage { get; set; }
    }

    public delegate void ForwarderMessageDelegate(Forwarder sender, ForwarderMessage msg);

    public enum ForwarderMessageType
    {
        ERROR, ACTIVATED, DEACTIVATED, TSTART, TSEND, TRECV, TEND
    }

    public class ForwarderMessage
    {
        private ForwarderMessageType type;
        private string message;
        private Exception exception;
        private Transmission trans;

        private ForwarderMessage()
        {

        }

        public static ForwarderMessage FromException(Exception ex)
        {
            ForwarderMessage fw = new ForwarderMessage
            {
                type = ForwarderMessageType.ERROR,
                message = ex.GetType().Name + ": " + ex.Message,
                exception = ex
            };
            return fw;
        }

        public static ForwarderMessage FromActivation()
        {
            ForwarderMessage fw = new ForwarderMessage
            {
                type = ForwarderMessageType.ACTIVATED,
                message = "Listener enabled"
            };
            return fw;
        }

        public static ForwarderMessage FromDeactivation()
        {
            ForwarderMessage fw = new ForwarderMessage
            {
                type = ForwarderMessageType.DEACTIVATED,
                message = "Listener disabled"
            };
            return fw;
        }

        public static ForwarderMessage FromNewTransmission(Transmission trans)
        {
            ForwarderMessage fw = new ForwarderMessage
            {
                type = ForwarderMessageType.TSTART,
                trans = trans,
                message = "Transmission from " + trans.SourceIP
            };
            return fw;
        }

        public static ForwarderMessage FromSendTransmission(Transmission trans)
        {
            ForwarderMessage fw = new ForwarderMessage
            {
                type = ForwarderMessageType.TSEND,
                trans = trans
            };
            return fw;
        }

        public static ForwarderMessage FromReceiveTransmission(Transmission trans)
        {
            ForwarderMessage fw = new ForwarderMessage
            {
                type = ForwarderMessageType.TRECV,
                trans = trans
            };
            return fw;
        }

        public static ForwarderMessage FromEndTransmission(Transmission trans)
        {
            ForwarderMessage fw = new ForwarderMessage
            {
                type = ForwarderMessageType.TEND,
                trans = trans
            };
            return fw;
        }

        public ForwarderMessageType Type => type;
        public string Message => message;
        public DateTime TimeStamp { get; } = DateTime.Now;
        public Exception Exception => exception;
        public Transmission Transmission => trans;
    }

    public class Transmission
    {
        private readonly IPEndPoint src;
        private readonly IPEndPoint dst;
        private int uploaded;
        private int downloaded;
        private readonly List<Sentence> conversation = new List<Sentence>();

        public Transmission(IPEndPoint src, IPEndPoint dst)
        {
            this.src = src;
            this.dst = dst;
        }

        internal void AddUpload(byte[] b)
        {
            if (b == null)
                return;
            uploaded += b.Length;
            conversation.Add(new Sentence(b, true));
        }

        internal void AddDownload(byte[] b)
        {
            if (b == null)
                return;
            downloaded += b.Length;
            conversation.Add(new Sentence(b, false));
        }

        public void SaveToFile(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            using (ZipArchive za = new ZipArchive(fs, ZipArchiveMode.Create))
            {
                GenerateIndex(za.CreateEntry("Index.ini").Open());
                for (int i = 0; i < conversation.Count; i++)
                    GeneratePart(za.CreateEntry($"Part-{i + 1}.bin").Open(), conversation[i]);
            }
        }

        private void GenerateIndex(Stream s)
        {
            using (s)
            using (StreamWriter sw = new StreamWriter(s, Encoding.UTF8))
            {
                sw.WriteLine("; Transmission index file");
                sw.WriteLine();
                sw.WriteLine($"From={SourceIP}");
                sw.WriteLine($"To={DestinationIP}");
                sw.WriteLine($"Time={Date.ToUniversalTime().ToString("O")}");
                sw.WriteLine($"TotalSent={uploaded}");
                sw.WriteLine($"TotalRecv={downloaded}");
                for (int i = 0; i < conversation.Count; i++)
                {
                    sw.WriteLine();
                    sw.WriteLine($"[Transfer({i + 1})]");
                    Sentence sn = conversation[i];
                    sw.WriteLine($"Time={sn.Time.ToUniversalTime().ToString("O")}");
                    sw.WriteLine("Initiator=" + (sn.FromMe ? "Local" : "Remote"));
                    sw.WriteLine($"Size={sn.Data.Length}");
                    sw.WriteLine($"File=Part-{i + 1}.bin");
                }
            }
        }

        private void GeneratePart(Stream s, Sentence st)
        {
            using (s)
            {
                s.Write(st.Data, 0, st.Data.Length);
            }
        }

        private string GetId()
        {
            return $"{src.Address}({src.Port})-{dst.Address}({dst.Port})@{Date.ToComactString()}";
        }

        public IPEndPoint SourceIP => src;
        public IPEndPoint DestinationIP => dst;
        public object Tag { get; set; }
        public int Uploaded => uploaded;
        public int Downloaded => downloaded;
        public DateTime Date { get; } = DateTime.Now;
        public Sentence[] Conversation => conversation.ToArray();
        public string Id => GetId();
    }

    public class Sentence
    {
        public Sentence(byte[] data, bool me)
        {
            FromMe = me;
            Data = data;
        }

        public bool FromMe { get; }
        public byte[] Data { get; }
        public DateTime Time { get; } = DateTime.Now;
    }
}
