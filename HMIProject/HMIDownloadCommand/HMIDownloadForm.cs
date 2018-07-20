using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
/**
 * @mainpage HMI Download Form 
 */
namespace HMIProject
{
    public partial class HMIDownloadForm : Form
    {
        public enum FileType { XML, PNG, JPG, SVG, GIF }
        public static String OutputPath;
        public static String ipAddress = "10.128.1.4";
        public static int portNumber = 1235;
        Socket client;



        private int CompareLayer(GUIO a, GUIO b)
        {
            if (Int32.Parse(a.layer) > Int32.Parse(b.layer))
                return -1;
            else if (Int32.Parse(a.layer) >= Int32.Parse(b.layer))
                return 0;
            else
                return 1;
        }

        private int ComparePage(HMIProject.Page a, HMIProject.Page b)
        {
            if (Int32.Parse(a.number) > Int32.Parse(b.number))
                return 1;
            else if (Int32.Parse(a.number) == Int32.Parse(b.number))
                return 0;
            else
                return -1;
        }

        public HMIDownloadForm()
        {
            InitializeComponent();
            OutputPath = @"c:\xmlTest\";
            textBox1.Text = ipAddress;
            textBox2.Text = portNumber.ToString();
        }

        public HMIDownloadForm(string outputPath)
        {
            InitializeComponent();
            OutputPath = @"c:\xmlTest\";
            textBox1.Text = ipAddress;
            textBox2.Text = portNumber.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Project));

                TextWriter writer = new StreamWriter(HMIProjectNode.currentProjectDirectory+@"\bin\output.xml");

                Project project = new Project(HMIProjectNode.currentProjectName);

                List<HMIEditorPane> paneList = StaticMethods.hmIEditorPaneList;
                List<Page> pageList = new List<Page>();
                foreach (HMIEditorPane pane in paneList)
                {
                    pane.thisPage.guioGroup.Clear();
                    pageList.Add(pane.thisPage);
                    pane.GUIOList.Sort(CompareLayer);
                    foreach (GUIO pageguio in pane.GUIOList)
                    {
                        pane.thisPage.guioGroup.Add(pageguio);
                    }
                }
                pageList.Sort(ComparePage);
                project.GVariableGroup = new List<GVariable>();

       
                foreach (GVariable gvar in GViewDlg.MList)
                {
                    project.GVariableGroup.Add(gvar);
                }
                
                List<ConditionEvent> ceList = new List<ConditionEvent>();
                foreach (ConditionEvent ce in StaticMethods.condtionEventList)
                {

                    ceList.Add(ce.conditionEventTransmissionFormat());
                }

                project.ConditionEventGroup = ceList;

                project.pageGroup = pageList;

                // Serializes the purchase order, and closes the TextWriter.
                serializer.Serialize(writer, project);
                writer.Close();

                IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(ipAddress), portNumber); // IP 및 port 설정
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ipep);
                label3.Text = "Socket connect";
                FileInfo xmlFileInfo = new FileInfo(HMIProjectNode.currentProjectDirectory + @"\bin\output.xml");

                DirectoryInfo directoryInfo = new DirectoryInfo(HMIProjectNode.currentProjectDirectory);
                FileInfo[] pngFileInfo = directoryInfo.GetFiles("*.png");
                FileInfo[] jpgFileInfo = directoryInfo.GetFiles("*.jpg");
                FileInfo[] svgFileInfo = directoryInfo.GetFiles("*.svg");
                FileInfo[] gifFileInfo = directoryInfo.GetFiles("*.gif");

                int TNOFile = 1 + pngFileInfo.Length + jpgFileInfo.Length + svgFileInfo.Length + gifFileInfo.Length;
                
                String xmlFileName = "output";
                byte[] sendBytes;
                string[] pngFileName = new string[pngFileInfo.Length];
                string[] jpgFileName = new string[jpgFileInfo.Length];
                string[] svgFileName = new string[svgFileInfo.Length];
                string[] gifFileName = new string[gifFileInfo.Length];

                byte[] xmlFileNameSize = { (byte) xmlFileName.Length };
                byte[] pngFileNameSize = new byte[pngFileInfo.Length];
                byte[] jpgFileNameSize = new byte[jpgFileInfo.Length];
                byte[] svgFileNameSize = new byte[svgFileInfo.Length];
                byte[] gifFileNameSize = new byte[gifFileInfo.Length];

                long xmlFileSize = xmlFileInfo.Length;
                long[] pngFileSize = new long[pngFileInfo.Length];
                long[] jpgFileSize = new long[jpgFileInfo.Length];
                long[] svgFileSize = new long[svgFileInfo.Length];
                long[] gifFileSize = new long[gifFileInfo.Length];

                byte[] xmlFileType = { (byte)FileType.XML };
                byte[] pngFileType = new byte[pngFileInfo.Length];
                byte[] jpgFileType = new byte[jpgFileInfo.Length];
                byte[] svgFileType = new byte[svgFileInfo.Length];
                byte[] gifFileType = new byte[gifFileInfo.Length];

                for (int i = 0; i < pngFileInfo.Length; i++)
                {
                    pngFileName[i] = Path.GetFileNameWithoutExtension(pngFileInfo[i].FullName);
                    pngFileNameSize[i] = (byte)pngFileName[i].Length;
                    pngFileSize[i] = pngFileInfo[i].Length;
                    pngFileType[i] = (int)FileType.PNG;
                }
                for (int i = 0; i < jpgFileInfo.Length; i++)
                {
                    jpgFileName[i] = Path.GetFileNameWithoutExtension(jpgFileInfo[i].FullName);
                    jpgFileNameSize[i] = (byte)jpgFileName[i].Length;
                    jpgFileSize[i] = jpgFileInfo[i].Length;
                    jpgFileType[i] = (int)FileType.JPG;
                }
                for (int i = 0; i < svgFileInfo.Length; i++)
                {
                    svgFileName[i] = Path.GetFileNameWithoutExtension(svgFileInfo[i].FullName);
                    svgFileNameSize[i] = (byte)svgFileName[i].Length;
                    svgFileSize[i] = svgFileInfo[i].Length;
                    svgFileType[i] = (int)FileType.SVG;
                }
                for (int i = 0; i < gifFileInfo.Length; i++)
                {
                    gifFileName[i] = Path.GetFileNameWithoutExtension(gifFileInfo[i].FullName);
                    gifFileNameSize[i] = (byte)gifFileName[i].Length;
                    gifFileSize[i] = gifFileInfo[i].Length;
                    gifFileType[i] = (int)FileType.GIF;
                }



                sendBytes = BitConverter.GetBytes(TNOFile);
                client.Send(sendBytes);
                sendBytes = xmlFileNameSize;
                client.Send(sendBytes);
                if (pngFileInfo.Length > 0)
                {
                    sendBytes = pngFileNameSize;
                    client.Send(sendBytes);
                }
                if (jpgFileInfo.Length > 0)
                {
                    sendBytes = jpgFileNameSize;
                    client.Send(sendBytes);
                }
                if (svgFileInfo.Length > 0)
                {
                    sendBytes = svgFileNameSize;
                    client.Send(sendBytes);
                }
                if (gifFileInfo.Length > 0)
                {
                    sendBytes = gifFileNameSize;
                    client.Send(sendBytes);
                }

                sendBytes = BitConverter.GetBytes(xmlFileSize);
                client.Send(sendBytes);
                for (int i = 0; i < pngFileInfo.Length; i++)
                {
                    sendBytes = BitConverter.GetBytes(pngFileSize[i]);
                    client.Send(sendBytes);
                }
                for (int i = 0; i < jpgFileInfo.Length; i++)
                {
                    sendBytes = BitConverter.GetBytes(jpgFileSize[i]);
                    client.Send(sendBytes);
                }
                for (int i = 0; i < svgFileInfo.Length; i++)
                {
                    sendBytes = BitConverter.GetBytes(svgFileSize[i]);
                    client.Send(sendBytes);
                }
                for (int i = 0; i < gifFileInfo.Length; i++)
                {
                    sendBytes = BitConverter.GetBytes(gifFileSize[i]);
                    client.Send(sendBytes);
                }

                sendBytes = Encoding.Default.GetBytes(xmlFileName);
                client.Send(sendBytes);
                for (int i = 0; i < pngFileInfo.Length; i++)
                {
                    sendBytes = Encoding.Default.GetBytes(pngFileName[i]);
                    client.Send(sendBytes);
                }
                for (int i = 0; i < jpgFileInfo.Length; i++)
                {
                    sendBytes = Encoding.Default.GetBytes(jpgFileName[i]);
                    client.Send(sendBytes);
                }
                for (int i = 0; i < svgFileInfo.Length; i++)
                {
                    sendBytes = Encoding.Default.GetBytes(svgFileName[i]);
                    client.Send(sendBytes);
                }
                for (int i = 0; i < gifFileInfo.Length; i++)
                {
                    sendBytes = Encoding.Default.GetBytes(gifFileName[i]);
                    client.Send(sendBytes);
                }

                sendBytes = xmlFileType;
                client.Send(sendBytes);
                if (pngFileInfo.Length > 0)
                {
                    client.Send(pngFileType);
                }
                if (jpgFileInfo.Length > 0)
                {
                    client.Send(jpgFileType);
                }
                if (svgFileInfo.Length > 0)
                {
                    client.Send(svgFileType);
                }
                if (gifFileInfo.Length > 0)
                {
                    client.Send(gifFileType);
                }

                MemoryStream ms;
                BinaryWriter bw;
                byte[] b;

                ms = new MemoryStream();
                bw = new BinaryWriter(ms);
                b = File.ReadAllBytes(xmlFileInfo.FullName);
                bw.Write(b);
                bw.Close();
                b = ms.ToArray();
                ms.Dispose();
                
                System.Threading.Thread.Sleep(100);
                client.BeginSend(b, 0, b.Length, SocketFlags.None, sendCallBack, null);
                
                for (int i = 0; i < pngFileInfo.Length; i++)
                {
                    ms = new MemoryStream();
                    bw = new BinaryWriter(ms);
                    b = File.ReadAllBytes(pngFileInfo[i].FullName);
                    bw.Write(b);
                    bw.Close();
                    b = ms.ToArray();
                    ms.Dispose();

                    System.Threading.Thread.Sleep(100);
                    client.BeginSend(b, 0, b.Length, SocketFlags.None, sendCallBack, null);
                }
                for (int i = 0; i < jpgFileInfo.Length; i++)
                {
                    ms = new MemoryStream();
                    bw = new BinaryWriter(ms);
                    b = File.ReadAllBytes(jpgFileInfo[i].FullName);
                    bw.Write(b);
                    bw.Close();
                    b = ms.ToArray();
                    ms.Dispose();

                    System.Threading.Thread.Sleep(100);
                    client.BeginSend(b, 0, b.Length, SocketFlags.None, sendCallBack, null);
                }
                for (int i = 0; i < svgFileInfo.Length; i++)
                {
                    ms = new MemoryStream();
                    bw = new BinaryWriter(ms);
                    b = File.ReadAllBytes(svgFileInfo[i].FullName);
                    bw.Write(b);
                    bw.Close();
                    b = ms.ToArray();
                    ms.Dispose();

                    System.Threading.Thread.Sleep(100);
                    client.BeginSend(b, 0, b.Length, SocketFlags.None, sendCallBack, null);
                }
                for (int i = 0; i < gifFileInfo.Length; i++)
                {
                    ms = new MemoryStream();
                    bw = new BinaryWriter(ms);
                    b = File.ReadAllBytes(gifFileInfo[i].FullName);
                    bw.Write(b);
                    bw.Close();
                    b = ms.ToArray();
                    ms.Dispose();

                    System.Threading.Thread.Sleep(100);
                    client.BeginSend(b, 0, b.Length, SocketFlags.None, sendCallBack, null);
                }

                client.Close();

                label3.Text = ("완료되었습니다...");
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                MessageBox.Show("전송 실패");
            }
        }

        public delegate void OnSendEventHandler(HMIDownloadForm sender, int sent);
        public event OnSendEventHandler OnSend;

        public void sendCallBack(IAsyncResult ar)
        {
            try
            {
                int sent = client.EndSend(ar);

                if (OnSend != null)
                {
                    OnSend(this, sent);
                }
            }
            catch (Exception ex)
            {
               System.Diagnostics.Trace.WriteLine(string.Format("SEND ERROR\n{0}", ex.Message));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ipAddress = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                portNumber = Int32.Parse(textBox2.Text);
            }
            catch(Exception ex)
            {
                label3.Text = ("Port 번호에 1000~65535 사이의 값을 입력해주세요.");
            }
        }
    }
}
