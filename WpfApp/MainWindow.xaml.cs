using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.Helper;

namespace WpfApp
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 从vantage获取当前局域网的可能作为服务器的列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_fetch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.Items.Clear();

            List<Columns> lists = GetLocalServerList();
            lists.ForEach((x)=> { AddRow(x); });
        }

        public List<Columns> GetLocalServerList()
        {
            List<Columns> result = new List<Columns>(10);

            //%AppData%是windows的一个环境变量，SpecialFolder枚举可获取更多类似的路径
            //https://www.cnblogs.com/minamiko/archive/2011/12/25/2300798.html 
            string configPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            configPath += @"\Autodesk\3dsMax\2019 - 64bit\ENU\en-US\plugcfg\vray_dr.cfg";
            FileHelper.CheckFile(configPath);
            string config = FileHelper.ReadFile(configPath);

            string[] paras = config.Split('\n', '\r');
            List<string> rows = new List<string>();
            foreach (string item in paras)
            {
                if (item.StartsWith("restart_servers")) { break; }
                rows.Add(item);
            }

            foreach (string item in rows)
            {
                string pattern = @"^(?<hostName>[\w\W]*)[ ](?<flag>[\w\W]*)[ ](?<portNum>[\w\W]*)$";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(item);
                if (match.Success)
                {
                    string hostName = match.Groups["hostName"].ToString();
                    string flag = match.Groups["flag"].ToString();
                    string portNum = match.Groups["portNum"].ToString();
                    result.Add(new Columns() { hostName = hostName, portRange = portNum, isExistInServerList = true });
                }
            }
            return result;
        }

        public bool WriteConfigFile(List<string> ipAddress)
        {
            bool result = true;

            string configPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            configPath += @"\Autodesk\3dsMax\2019 - 64bit\ENU\en-US\plugcfg\vray_dr.cfg";

            string content = "";
            ipAddress.ForEach((x)=> {
                content += x;
                content += " 1 20204\n";
            });
            result = FileHelper.WriteFileToFileStartPos(content, configPath);

            return result;
        }

        public void AddRow(Columns col)
        {
            dataGrid.CanUserAddRows = true;
            dataGrid.Items.Add(col);
            dataGrid.CanUserAddRows = false;
        }

        private void Button_check_Click(object sender, RoutedEventArgs e)
        {
            WriteConfigFile(new List<string>() { "aabc","dfada"});
        }
    }

    public class Columns
    {
        public string hostName { get; set; }
        public string portRange { get; set; }
        public string ipAddress { get; set; }
        public string resolveStatus { get; set; }
        public bool isExistInServerList { get; set; }
        public string serverStatus { get; set; }
    }
}
