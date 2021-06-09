using AutoUpdaterDotNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace kitchen_client_update
{
    class Program
    {
        private static void 更新(string title, string url, string version)
        {
            AutoUpdater.CheckForUpdateEvent += (UpdateInfoEventArgs args) =>
            {
                MessageBoxResult dialogResult;
                if (args.Error == null)
                {
                    args.InstalledVersion = new Version(version);
                    if (args.InstalledVersion >= new Version(args.CurrentVersion))
                    {
                        return;
                    }
                    if (args.Mandatory.Value)
                    {
                        dialogResult = MessageBox.Show($"程序最新版本为{args.CurrentVersion}。您使用的{args.InstalledVersion}版本过旧。可能会无法使用。点确定更新程序。", "强制更新", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    }
                    else
                    {
                        dialogResult = MessageBox.Show($"程序最新版本为{args.CurrentVersion}。您使用的{args.InstalledVersion}版本过旧。是否更新。", "更新", MessageBoxButton.YesNo,
                        MessageBoxImage.Information);
                    }

                    if (dialogResult.Equals(MessageBoxResult.Yes) || dialogResult.Equals(MessageBoxResult.OK))
                    {
                        try
                        {
                            if (AutoUpdater.DownloadUpdate(args))
                            {
                                Console.Write("exit");
                            }
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show($"更新出错：{exception.Message}，请联系相关人员");
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"更新检测出错：{args.Error.Message}，请联系相关人员");
                }
            };
            AutoUpdater.AppTitle = title;
            AutoUpdater.Synchronous = true;
            AutoUpdater.AppCastURL = url;
            AutoUpdater.Start();
        }
        static void Main(string[] args)
        {
            if (args.Length >= 3)
            {
                更新(args[0], args[1], args[3]);
            }
        }
    }
}
