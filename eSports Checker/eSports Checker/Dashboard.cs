using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Diagnostics;
using System.Threading;
using System.Management;
using System.IO;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace eSports_Checker
{
    public partial class Dashboard : Form
    {
      
        
        public Dashboard()

        {
            InitializeComponent();
           
           

        }
        public static string Nickname { get; set; }
        public static string unid { get; set; }

       public string emailNicmake = Nickname;

        private void D_1_TextChanged(object sender, EventArgs e)
        {

        }

        private void D_2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Reporting has begun!");
            label8.Text = "ON";
            label8.ForeColor = System.Drawing.Color.ForestGreen;
            ProCollectHardware.ComputerInfo();
            Prodate.ServerHardware();
            CheatModeOn();
            ButtonCheatOn();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
           
            CheatModeOff();
            label8.Text = "OFF";
            label8.ForeColor = System.Drawing.Color.Red;
            ButtonCheatOff();
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Logoutcheck();
           
        }


        private void Logoutcheck()
        {
           if (Start.Enabled == false)
            {
                MessageBox.Show("Please stop reporting!");
            }

           else
            {
                this.Hide();
                var Auth = new Auth();
                Auth.Closed += (s, args) => this.Close();
                Auth.Show();
            }
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loopcheatmethod()
        {
            while(true)
            {
                if (Start.Enabled == true)
                {
                    break;
                }

                else if (Start.Enabled == false)
                    Methodcall.AntiCheatSystem();
               
              
            }
        }

        // Fix this issue

        private dynamic threader;


       private void executethread()
        {
            threader = new Thread(new ThreadStart(loopcheatmethod));
        }


        private void CheatModeOn()
        {
            executethread();
            threader.Start();
        }

        private void CheatModeOff()
        {


            threader.Abort();
            MessageBox.Show("Reporting has stopped!!");
        }

        private void ButtonCheatOn()
        {
            Start.Enabled = false;
            Stop.Enabled = true;
        }

        private void ButtonCheatOff()
        {
            Start.Enabled = true;
            Stop.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            label5.Text = Auth.nickname;
            label6.Text = Auth.propass;
            Stop.Enabled = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }

    class ProCollectList
    {
        private static string Systemlist1 = "";
        private static string List = "";

        private void ApplicationList()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process p in processes)
            {
                if (!String.IsNullOrEmpty(p.MainWindowTitle))
                {

                    Systemlist1 = (p.MainWindowTitle);
                }
            }
        }





        // Get process information

        private static void ApplicationList1()
        {
            List = "";
            List = "Process.Running" + "," + "Process ID" + "," + "Responsive" + "," + "Active Windows" + Environment.NewLine;
            Process[] runningProcs = Process.GetProcesses();
            Array.Sort(runningProcs, delegate (Process p1, Process p2)
            {
                return p1.ProcessName.CompareTo(p2.ProcessName);
            });
            foreach (Process process in runningProcs)
            {

                List += process.ProcessName + "," + process.Id + "," + process.Responding + "," + process.MainWindowTitle + Environment.NewLine;

            }

        }

        public static string InfoA = Path.Combine(Path.GetTempPath(), "infolistpro.csv");

        private static void ApplicationList2()
        {
            System.IO.File.WriteAllText(InfoA, List);

        }

        public static void Processinformation()
        {

            ApplicationList1();
            ApplicationList2();

        }

    }

    public class ProCollectScreen
    {

        public static string InfoB = Path.Combine(Path.GetTempPath(), "process.Jpeg"); //This save the screenshot to a particulat location on the hard drive

        public static void ScreenShot()
        {

            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); // Sets the max length and width which the screen shall take 
            Graphics g = Graphics.FromImage(bitmap); //Creates a new object from the image
            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size); // I have no idea what this does :D
            bitmap.Save(InfoB, System.Drawing.Imaging.ImageFormat.Jpeg); //Saves the image in the location specified above.
        }

    }


    public class ProCollectHardware
    {

        public static string GetBoardMaker()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_BaseBoard");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return wmi.GetPropertyValue("Manufacturer").ToString();
                }

                catch { }

            }
            return "Board Maker: Unknown";

        }

        string BoardMaker = GetBoardMaker();


        public static String GetProcessorId()
        {

            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            String Id = String.Empty;
            foreach (ManagementObject mo in moc)
            {

                Id = mo.Properties["processorID"].Value.ToString();
                break;
            }
            return Id;

        }

        public static string GetMACAddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            string MACAddress = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                if (MACAddress == String.Empty)
                {
                    if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                }
                mo.Dispose();
            }

            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
        }


        public static string Ipinfo()
        {
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        public static String GetComputerName()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            String info = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                info = (string)mo["Name"];
                //mo.Properties["Name"].Value.ToString();
                //break;
            }
            return info;
        }

        public static string GetPhysicalMemory()
        {
            ManagementScope oMs = new ManagementScope();
            ObjectQuery oQuery = new ObjectQuery("SELECT Capacity FROM Win32_PhysicalMemory");
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            ManagementObjectCollection oCollection = oSearcher.Get();
            long MemSize = 0;
            long mCap = 0;
            // In case more than one Memory sticks are installed
            foreach (ManagementObject obj in oCollection)
            {
                mCap = Convert.ToInt64(obj["Capacity"]);
                MemSize += mCap;
            }
            MemSize = (MemSize / 1024) / 1024;
            return MemSize.ToString() + "MB";
        }

        public static string GetCPUManufacturer()
        {
            string cpuMan = String.Empty;
            ManagementClass mgmt = new ManagementClass("Win32_Processor");
            ManagementObjectCollection objCol = mgmt.GetInstances();
            foreach (ManagementObject obj in objCol)
            {
                if (cpuMan == String.Empty)
                {
                    // only return manufacturer from first CPU
                    cpuMan = obj.Properties["Name"].Value.ToString();
                }
            }
            return cpuMan;
        }

        public static string GetMotherboardManufacturer()
        {
            string mobo = String.Empty;
            ManagementClass mgmt = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection objCol = mgmt.GetInstances();
            foreach (ManagementObject obj in objCol)
            {
                if (mobo == String.Empty)
                {
                    // only return manufacturer from first CPU
                    mobo = obj.Properties["Model"].Value.ToString();
                }
            }
            return mobo;
        }

        public static string HardwareInformation = "";
        public static string HardwareInformationServer = "";
        public static void ComputerInfo()
        {
            string ProcessorID = "Processor Id = " + GetProcessorId();//
            string Manufacture = "BoardMaker = " + GetBoardMaker();
            string MACAddress = "MACAddress = " + GetMACAddress();
            string IpAdresss = "IpAddress = " + Ipinfo();
            string ComputerName = "Computer Name = " + GetComputerName();
            string ram = "Total Memory Installed = " + GetPhysicalMemory(); // 
            string cpu = "CPU Model = " + GetCPUManufacturer(); //
            string motherboardid = "Motherboard ID = " + GetMotherboardManufacturer(); //

            HardwareInformation = "";
            HardwareInformation += "Computer Hardware Information" + Environment.NewLine + Environment.NewLine + Environment.OSVersion + Environment.NewLine + motherboardid + Environment.NewLine +
                cpu + Environment.NewLine + ram + Environment.NewLine + ComputerName + Environment.NewLine + ProcessorID + Environment.NewLine + Manufacture + Environment.NewLine +
               Environment.NewLine + Environment.NewLine + "Computer Network Information" + Environment.NewLine + Environment.NewLine + MACAddress + Environment.NewLine + IpAdresss;

            HardwareInformationServer = "";
            HardwareInformationServer += "Computer Hardware Information <br> <br>" + Environment.OSVersion + "<br>" + motherboardid + "<br>" +
                cpu + "<br>" + ram + "<br>" + ComputerName + "<br>" + ProcessorID + "<br>" + Manufacture + "<br>" +
              "<br>" + "<br>" + "Computer Network Information" + "<br>" + "<br>" + MACAddress + "<br>" + IpAdresss;

        }
    }


    public class ProSend
    {
        public static void MailSystem()
        {
            try
            {
                MailAddress to = new MailAddress(" esportsVerifierProLeague@outlook.com");
                MailAddress from = new MailAddress("anticheatProLeague@gmail.com");
                MailMessage mail = new MailMessage(from, to);
                mail.Body = ProCollectHardware.HardwareInformation;
                mail.Subject = Auth.nickname;
                Attachment data = new Attachment(ProCollectList.InfoA, MediaTypeNames.Application.Octet);
                mail.Attachments.Add(data);
                Attachment data1 = new Attachment(ProCollectScreen.InfoB, MediaTypeNames.Image.Jpeg);
                mail.Attachments.Add(data1);
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential(
                "an", "an");
                smtp.EnableSsl = true;
                smtp.Send(mail);
                mail.Dispose();
                System.Threading.Thread.Sleep(10);
            }
         

            catch (Exception e)
            {

            }
        }
    }


    public static class Methodcall
    {
        public static void AntiCheatSystem()
        {
            ProCollectList.Processinformation();
            ProCollectScreen.ScreenShot();
            Prodate.Server();
            ProSend.MailSystem();
            GC.Collect();
        }
    }

    public class Prodate
    {

        public static void Server()
        {
            byte[] rawData = File.ReadAllBytes(ProCollectScreen.InfoB);
            FileInfo info = new FileInfo(ProCollectScreen.InfoB);
            int fileSize = Convert.ToInt32(info.Length);

            byte[] rawData1 = File.ReadAllBytes(ProCollectList.InfoA);
            FileInfo infolist = new FileInfo(ProCollectList.InfoA);

       

            using (MySqlConnection connection = new MySqlConnection("gu_eApp;PASSWORD=honestplay;SslMode=none;"))
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = " UPDATE `Login` SET `Images`= ?rawData, eSportsTimeOn=CURRENT_TIMESTAMP, eSportsCheckerOn='1', csvinfo=?rawData1 WHERE nickname = @nickname;";
                    MySqlParameter fileContentParameter = new MySqlParameter("?rawData", MySqlDbType.Blob, rawData.Length);
                    MySqlParameter fileContentParameter1 = new MySqlParameter("?rawData1", MySqlDbType.Blob, rawData1.Length);

                    command.Parameters.AddWithValue("@nickname", Auth.nickname);
                    fileContentParameter.Value = rawData;
                    fileContentParameter1.Value = rawData1;
                    command.Parameters.Add(fileContentParameter);
                    command.Parameters.Add(fileContentParameter1);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }

        public static void ServerHardware()
        {
           
            //Convert text to byte(error) Fix it
          
            byte[] rawData2 = Encoding.UTF8.GetBytes(ProCollectHardware.HardwareInformationServer);


            using (MySqlConnection connection = new MySqlConnection(""))
            {
                using (MySqlCommand command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = " UPDATE `Login` SET `hardwareinfo`= ?rawData, eSportsTimeOn=CURRENT_TIMESTAMP, eSportsCheckerOn='1' WHERE nickname = @nickname;";
                    MySqlParameter fileContentParameter = new MySqlParameter("?rawData", MySqlDbType.Blob, rawData2.Length);

                    command.Parameters.AddWithValue("@nickname", Auth.nickname);
                    fileContentParameter.Value = rawData2;
                    command.Parameters.Add(fileContentParameter);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                }
            }
        }


    }



}
