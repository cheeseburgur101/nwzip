/*
 * Created by SharpDevelop.
 * User: binary
 * Date: 6/4/2017
 * Time: 11:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Runtime.InteropServices;

namespace nwzip{
	/// <summary>
	/// Class that helps with creating shortcuts. Everything in this class should be usable by other classes.
	/// </summary>
	public static class shortcutHelper{
		//all the functions imported from Win32
		[DllImport("Ole32.dll", EntryPoint = "CoInitialize")]
		public extern static long CoInitialize(UIntPtr reserved);
		[DllImport("Ole32.dll", EntryPoint = "CoUninitialize")]
		public extern static void CoUnitialize();
		[DllImport("Ole32.dll", EntryPoint = "CoCreateInstance")]
		//NOTE: This Windows API function has been warped to serve the purposes that createShortcut
		//needs it for. This function will not work for any other purposes unless the proper
		//declaration of the function is put into the place of this declaration of the function.
		public extern unsafe static long CoCreateInstance(GUID* rclsid, UIntPtr pUnkOuter, UInt32 dwClsContext, GUID* riid, UIntPtr ppv);
		
		
		//the structs and other declarations
		public struct GUID {
			public ulong Data1;
	  		public ushort Data2;
	  		public ushort Data3;
	  		public unsafe fixed byte Data4[8]; //has to be 8 bytes
		}
		public struct SHITEMID {
			public ushort cb;
			public unsafe fixed byte abID[1];
		}
		public struct ITEMIDLIST {
			public SHITEMID mkid;
		}
		public struct SFILETIME {
			public UInt32 dwLowDateTime;
			public UInt32 dwHighDateTime;
		}
		public struct WIN32_FIND_DATA {
			public UInt32 dwFileAttributes;
			public SFILETIME ftCreationTime;
			public SFILETIME ftLastAccessTime;
			public SFILETIME ftLastWriteTime;
			public UInt32 nFileSizeHigh;
			public UInt32 nFileSizeLow;
			public UInt32 dwReserved0;
			public UInt32 dwReserved1;
			public unsafe fixed byte cFileName[260];
			public unsafe fixed byte cAlternateFileName[14];
		}
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("000214F9-0000-0000-C000-000000000046")]
		public unsafe interface IShellLinkW{
			long GetArguments(out byte* pszArgs, int cchMaxPath);
			long GetDescription(out byte* pszName, int cchMaxName);
			long GetHotkey(ushort* pwHotKey);
			long GetIconLocation(out byte* pszIconPath, int cchIconPath, int* piIcon);
			long GetIDList(out ITEMIDLIST** ppidl);
			long GetPath(out byte* pszFile, int cchMaxPath, out WIN32_FIND_DATA* pfd, UInt32 fFlags);
			long GetShowCmd(int* piShowCmd);
			long GetWorkingDirectory(out byte* pszDir, int cchMaxPath);
			long Resolve(UIntPtr hwnd, UInt32 fFlags);
			long SetArguments(string pszArgs);
			long SetDescription(string pszName);
			long SetHotkey(ushort wHotkey);
			long SetIconLocation(string pszIconPath, int iIcon);
			long SetIDList(ITEMIDLIST* pidl);
			long SetPath(string pszFile);
			long SetRelativePath(string pszPathRel, UInt32 dwReserved);
			long SetShowCmd(int iShowCmd);
			long SetWorkingDirectory(string pszDir);
			//should be in IUnknown?
			long QueryInterface(GUID* riid, UIntPtr ppvObject);
			
			void Release();
		}
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010C-0000-0000-C000-000000000046")]
		public interface IPersist{
			unsafe long GetClassID(GUID* pClassID);
		}
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010B-0000-0000-C000-000000000046")]
		public unsafe interface IPersistFile : IPersist{
			long GetCurFile(out byte* ppszFileName);
			long IsDirty();
			long Load(string pszFileName, UInt32 dwMode);
			long Save(string pszFileName, bool fRemember);
			long SaveCompleted(string pszFileName);
			//should be in IUnknown?
			void Release();
		}
		/// <summary>
		/// The function which creates shortcuts
		/// </summary>
		/// <param name="pathTo">Path to the file the shortcut is a shortcut to</param>
		/// <param name="description">Description of the shortcut</param>
		/// <param name="shortcutPath">Path to where the shortcut file (.lnk) is created</param>
		public unsafe static errorReport createShortcut(string pathTo, string description, string shortcutPath){
			//the error information about the function
			errorReport returnValue = new errorReport();
			//TODO remove below line when function is ready (the interface managed type error must be eliminated, otherwise a dll must be created (in C++) and extracted to serve the purpose of this function)
			return new errorReport(1, "Creating shortcuts has not been added to the installer yet.");
			//initialize COM library on this thread
			long HRESULT_CoInit = CoInitialize(UIntPtr.Zero);
			if((HRESULT_CoInit == 0) || (HRESULT_CoInit == 1)){ //including S_OK and S_FALSE
				//CLSID_ShellLink GUID (as declared on mingw windows api)
				byte[] clsid_data4 = {0xc0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46};
				GUID CLSID_ShellLink;
				CLSID_ShellLink.Data1 = 0x00021401;
				CLSID_ShellLink.Data2 = 0x0000;
				CLSID_ShellLink.Data3 = 0x0000;
				for(int i = 0; i < clsid_data4.Length; ++i){
					CLSID_ShellLink.Data4[i] = clsid_data4[i];
				}
				//IID_IShellLink GUID (as declared on mingw windows api)
				byte[] IID_IShellLinkA_data4 = {0xc0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46};
				GUID IID_IShellLinkA;
				IID_IShellLinkA.Data1 = 0x000214ee;
				IID_IShellLinkA.Data2 = 0x0000;
				IID_IShellLinkA.Data3 = 0x0000;
				for(int i = 0; i < IID_IShellLinkA_data4.Length; ++i){
					IID_IShellLinkA.Data4[i] = IID_IShellLinkA_data4[i];
				}
				//CoCreateInstance (have to find a way to make interface unmanaged for this to work)
				//long HRESULT_CoCI;
				//IShellLinkW* psl;
				//0x1 = CLSCTX_INPROC_SERVER
				//HRESULT_CoCI = CoCreateInstance(&CLSID_ShellLink, UIntPtr.Zero, 0x1, &IID_IShellLinkA, new UIntPtr(&psl));
				//if(SUCCEEDED(HRESULT_CoCI)){
					//IPersistFile* ppf;
					//psl->SetPath(pathTo);
					//psl->SetDescription(description);
					//long HRESULT_QInterface = psl->QueryInterface(IID_IPersistFile, (UIntPtr)&ppf);
					//if(SUCCEEDED(HRESULT_QInterface)){
						//char wsz; TODO (size must be 260), char in C# is already unicode
						//MultiByteToWideChar(CP_ACP, 0, shortcutPath, -1, wsz, 260);
						//long HRESULT_save = ppf->Save(wsz, true);
						//ppf->Release();
					//}
					//psl->Release(); TODO
				//}
				
				//frees the resources used
				CoUnitialize();
			}
			//return hres TODO
			return returnValue;
		}
		
		public static bool SUCCEEDED(long hr){
			return (hr >= 0);
		}
	}
}
