using Microsoft.Win32;
using System;
using System.Linq;
using System.Web;

namespace url_scheme_manager
{
	/// <summary>
	/// Manages uri-schemes in the Windows Registry for the current device.
	/// </summary>
	public static class SchemeManager
	{
		/// <summary>
		/// Adds the provided scheme info to the Windows Registry.
		/// </summary>
		/// <param name="SchemeInfo">The scheme-info representing the custom uri-scheme.</param>
		public static void AddSchemeInfo(URLSchemeInfo SchemeInfo)
		{
			RegistryKey rootKey = Registry.ClassesRoot;
			RegistryKey uriKey = rootKey.CreateSubKey(SchemeInfo.ProtocolPrefix);

			uriKey.SetValue("", $"URL:{SchemeInfo.FriendlyName}");
			uriKey.SetValue("URL Protocol", "");

			uriKey.CreateSubKey("shell")
				.CreateSubKey("open")
				.CreateSubKey("command")
				.SetValue("", $"\"{SchemeInfo.ProgramPath}\" \"%1\"");

			uriKey.Close();
			rootKey.Close();
		}

		/// <summary>
		/// Removes the specified scheme info from the Windows Registry.
		/// </summary>
		/// <param name="SchemeInfo">The scheme-info representing the custom uri-scheme.</param>
		public static void RemoveSchemeInfo(URLSchemeInfo SchemeInfo)
		{
			RegistryKey rootKey = Registry.ClassesRoot;
			RegistryKey uriKey = rootKey.OpenSubKey(SchemeInfo.ProtocolPrefix, true);

			if (uriKey == null)
			{
				rootKey.Close();
				return;
			}

			if (uriKey.GetValue("").ToString() == $"URL:{SchemeInfo.FriendlyName}" &&
				uriKey.GetValue("URL Protocol").ToString() == "" &&
				uriKey.OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue("").ToString() == $"\"{SchemeInfo.ProgramPath}\" \"%1\"")
			{
				uriKey.DeleteSubKeyTree("shell", true);
				rootKey.DeleteSubKey(SchemeInfo.ProtocolPrefix, true);
			}

			rootKey.Close();
		}

		/// <summary>
		/// Checks for the specified scheme info in the Windows Registry.
		/// </summary>
		/// <param name="SchemeInfo">The scheme-info representing the custom uri-scheme.</param>
		public static bool CheckForSchemeInfo(URLSchemeInfo SchemeInfo)
		{
			RegistryKey rootKey = Registry.ClassesRoot;
			RegistryKey uriKey = rootKey.OpenSubKey(SchemeInfo.ProtocolPrefix);
			bool result = false;

			if (rootKey == null || uriKey == null) result = false;

			if (uriKey != null &&
				uriKey.GetValue("").ToString() == $"URL:{SchemeInfo.FriendlyName}" &&
				uriKey.GetValue("URL Protocol").ToString() == "" &&
				uriKey.OpenSubKey("shell").OpenSubKey("open").OpenSubKey("command").GetValue("").ToString() == SchemeInfo.ProgramPath)
				result = true;

			uriKey?.Close();
			rootKey.Close();

			return result;
		}

		/// <summary>
		/// Removes the protocol-prefix from the custom uri-scheme cli-argument provided.
		/// </summary>
		/// <param name="SchemeInfo">The custom uri-scheme containing the info required to reformat the provided custom uri-scheme cli-argument.</param>
		/// <param name="URIArgument">The custom uri-scheme cli-argument passed to the environment cli-arguments of the opened program.</param>
		/// <returns>The custom uri-scheme cli-argument without the protocol prefix.</returns>
		public static string GetURIInfo(URLSchemeInfo SchemeInfo, string URIArgument)
		{
			string url = Uri.UnescapeDataString(URIArgument.Replace(SchemeInfo.ProtocolPrefix + "://", ""));
			
			if (url.Last() == '/')
				url = url.Substring(0, url.Length - 1);

			return url;
		}
	}
}
