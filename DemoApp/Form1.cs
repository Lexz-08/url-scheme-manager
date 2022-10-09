using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows.Forms;
using url_scheme_manager;

namespace DemoApp
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			string[] args = Environment.GetCommandLineArgs().Where((_, index) => index != 0).ToArray();

			schemeInfo = new URLSchemeInfo
			{
				FriendlyName = "URI_Scheme_Demo",
				ProtocolPrefix = "uri-scheme-demo",
				ProgramPath = $"{Application.StartupPath}\\DemoApp.exe"
			};

			RegistryKey rootKey = Registry.ClassesRoot;
			RegistryKey uriKey = rootKey.OpenSubKey(schemeInfo.ProtocolPrefix);

			if (uriKey != null)
			{
				btnAdd.Enabled = false;
				btnRemove.Enabled = true;
			}

			uriKey?.Close();
			rootKey.Close();

			if (args.Length > 0)
			{
				MessageBox.Show(SchemeManager.GetURIInfo(schemeInfo, args[0]), "URL_Scheme_Demo", MessageBoxButtons.OK);

				Timer t = new Timer { Interval = 100 };
				t.Tick += (s, e) =>
				{
					t.Enabled = false;
					Close();
				};
				t.Start();
			}
		}

		private URLSchemeInfo schemeInfo;

		private void AddRegkey(object sender, EventArgs e)
		{
			SchemeManager.AddSchemeInfo(schemeInfo);
			btnAdd.Enabled = false;
			btnRemove.Enabled = true;
		}

		private void RemoveRegKey(object sender, EventArgs e)
		{
			SchemeManager.RemoveSchemeInfo(schemeInfo);
			btnAdd.Enabled = true;
			btnRemove.Enabled = false;
		}
	}
}
