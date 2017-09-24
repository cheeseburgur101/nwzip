using System;
using System.Runtime.InteropServices;
using System.IO;

namespace nwzip{
	/// <summary>
	/// Class that helps with creating shortcuts. Everything in this class should be usable by other classes.
	/// </summary>
	public static class shortcutHelper{
		public unsafe delegate void setPathDelegate(void* a, void* b);
		public unsafe delegate void setDescriptionDelegate(void* a, void* b);
		public unsafe delegate long queryInterfaceDelegate(void* a, void* b, void* c);
		public unsafe delegate long saveDelegate(void* a, void* b, void* c);
		public unsafe delegate void releaseDelegate(void* a);
		/// <summary>
		/// Creates a shortcut
		/// </summary>
		/// <param name="pathTo">Shortcut's file opened when double clicked (ie. shortcut's target)</param>
		/// <param name="description">Shortcut's description</param>
		/// <param name="shortcutPath">Path of the shortcut to be saved</param>
		/// <param name="overwrite">Overwrite the shortcut if it exists</param>
		/// <returns>A class (errorReport) which contains error information (integer status, string message)</returns>
		public unsafe static errorReport createShortcut(string pathTo, string description, string shortcutPath, bool overwrite){
			errorReport retVal = new errorReport(); //initial value of ERROR_SUCCESS
			//handle overwriting
			if(overwrite){
				try{
					if(File.Exists(shortcutPath)){
						File.Delete(shortcutPath);
					}
				}catch(Exception ex){
					retVal = new errorReport(1, ex.Message + "\r\nCould not overwrite the shortcut. Try running the program again as administrator.");
				}
			}else{
				if(File.Exists(shortcutPath)){
					retVal = new errorReport(1, "Can't overwrite the shortcut.");
				}
			}
			//limits of shortcuts
			if(pathTo.Length > MAX_PATH) retVal = new errorReport(1, "Your system does not support this program installing shortcuts.");
			if(description.Length > MAX_PATH) retVal = new errorReport(1, "Your system does not support this program installing shortcuts.");
			if(shortcutPath.Length > MAX_PATH) retVal = new errorReport(1, "Your system does not support this program installing shortcuts.");
			//get heap for later memory allocation
			void* prcHeap = GetProcessHeap();
			char* wsz = (char*)0;
			if(prcHeap != (void*)0) wsz = (char*)HeapAlloc(prcHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(char) * (MAX_PATH + 1))); //allocate space for WCHARs
			if(prcHeap == (void*)0) retVal = new errorReport(1, "Error creating shortcuts. Try restarting the program. Running it as administrator may also help.");
			if(wsz == (char*)0) retVal = new errorReport(1, "Error creating shortcuts. Try restarting the program. Running it as administrator may also help.");
			if(retVal.status == 0){
				if(prcHeap != (void*)0){
					//allocate MAX_PATH+1 bytes of memory then set the pointer to the beginning of that memory
					byte* pathToCA = (byte*)HeapAlloc(prcHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(byte) * (MAX_PATH + 1)));
					byte* descriptionCA = (byte*)HeapAlloc(prcHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(byte) * (MAX_PATH + 1)));
					byte* shortcutPathCA = (byte*)HeapAlloc(prcHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(byte) * (MAX_PATH + 1)));
					if(pathToCA != (byte*)0){
						if(descriptionCA != (byte*)0){
							if(shortcutPathCA != (byte*)0){
								//copy strs
								for(int i = 0; i < pathTo.Length; ++i){
									pathToCA[i] = unchecked((byte)pathTo[i]);
								}
								for(int i = 0; i < description.Length; ++i){
									descriptionCA[i] = unchecked((byte)description[i]);
								}
								for(int i = 0; i < shortcutPath.Length; ++i){
									shortcutPathCA[i] = unchecked((byte)shortcutPath[i]); //note: not good for unicode username users
								}
								long hres = CoInitialize(UIntPtr.Zero);
								if(hres >= 0){ //check if the COM library succeeded to load
									//GUIDs (mingw?), can be found in the registry
								    Guid IID_IPersistFile = new Guid("0000010B-0000-0000-C000-000000000046");
								    Guid IID_IShellLink = new Guid("000214EE-0000-0000-C000-000000000046"); //ANSI (IID_IShellLinkA)
								    Guid CLSID_ShellLink = new Guid("00021401-0000-0000-C000-000000000046");
								
								    //temp Pointers
								    void* eax;
								    void* edx;
								    void* ecx;
								    void* eax1;
								    
								    //CoCreateInstance (create an instance of IShellLink, and set shellLinkInterfacePtr as the pointer to that interface)
									void* shellLinkInterfacePtr;
									hres = CoCreateInstance(&CLSID_ShellLink, null, CLSCTX_INPROC_SERVER, &IID_IShellLink, (void*)&shellLinkInterfacePtr);
									if(hres >= 0){
										
										void* persistFileInterfacePtr;
										//shellLinkInterfacePtr->SetPath(byte*) (shellLinkInterfacePtr = %0, pathToCA = %1)
										eax = shellLinkInterfacePtr; //mov eax, %0
										edx = shellLinkInterfacePtr; //mov edx, %0
										edx = (void*)(*((uint**)edx)); //mov edx, dword ptr [edx]
										edx = unchecked((void*)((byte*)edx + 0x50)); //add edx, 50h
										ecx = (void*)(*((uint**)edx)); //mov ecx, dword ptr [edx]
										edx = (void*)pathToCA; //mov edx, %1
										//push edx
										//push eax
										//call ecx
										setPathDelegate setPath = (setPathDelegate)Marshal.GetDelegateForFunctionPointer(new IntPtr(ecx), typeof(setPathDelegate));
										setPath(eax, edx);
										
										//shellLinkInterfacePtr->SetDescription(byte*) (shellLinkInterfacePtr = %0, descriptionCA = %1)
										eax = shellLinkInterfacePtr; //mov eax, %0
										edx = shellLinkInterfacePtr; //mov edx, %0
										edx = (void*)(*((uint**)edx)); //mov edx, dword ptr [edx]
										edx = unchecked((void*)((byte*)edx + 0x1C)); //add edx, 1Ch
										ecx = (void*)(*((uint**)edx)); //mov ecx, dword ptr [edx]
										edx = descriptionCA; //mov edx, %1
										//push edx
										//push eax
										//call ecx
										setDescriptionDelegate setDescription = (setDescriptionDelegate)Marshal.GetDelegateForFunctionPointer(new IntPtr(ecx), typeof(setDescriptionDelegate));
										setDescription(eax, edx);
										
										//hres = shellLinkInterfacePtr->QueryInterface(Guid*, void*) (shellLinkInterfacePtr = %0, persistFileInterfacePtr = %1, IID_IPersistFile = %2)
										eax = shellLinkInterfacePtr; //mov eax, %0
										ecx = eax; //mov ecx, eax
										eax = shellLinkInterfacePtr; //mov eax, %0
										eax = (void*)(*((uint**)eax)); //mov eax, dword ptr [eax]
										edx = (void*)(*((uint**)eax)); //mov edx, dword ptr [eax]
										eax = (void*)(&persistFileInterfacePtr); //lea eax, [%1]
										eax1 = eax; //push eax ; save it as "eax1" for later use
										eax = (void*)(&IID_IPersistFile); //lea eax, [%2]
										//push eax
										//push ecx
										//call edx
										queryInterfaceDelegate queryInterface = (queryInterfaceDelegate)Marshal.GetDelegateForFunctionPointer(new IntPtr(edx), typeof(queryInterfaceDelegate));
										hres = queryInterface(ecx, eax, eax1);
										if(hres >= 0){
											MultiByteToWideChar(0, 0, shortcutPathCA, -1, wsz, MAX_PATH);
											
											//hres = persistFileInterfacePtr->Save(char*, bool) (persistFileInterfacePtr = %0, wsz = %1)
											eax = persistFileInterfacePtr; //mov eax, %0
											edx = persistFileInterfacePtr; //mov edx, %0
											edx = (void*)(*((uint**)edx)); //mov edx, dword ptr [edx]
											edx = unchecked((void*)((byte*)edx + 0x18)); //add edx, 18h
											ecx = (void*)(*((uint**)edx)); //mov edx, dword ptr [edx]
											//push 1
											edx = (void*)wsz; //mov edx, %1
											//push edx
											//push eax
											//call ecx
											saveDelegate save = (saveDelegate)Marshal.GetDelegateForFunctionPointer(new IntPtr(ecx), typeof(saveDelegate));
											hres = save(eax, edx, (void*)1);
											
											//persistFileInterfacePtr->Release() (persistFileInterfacePtr = %0)
											eax = persistFileInterfacePtr; //mov eax, %0
											edx = eax; //mov edx, eax
											eax = persistFileInterfacePtr; //mov eax, %0
											eax = (void*)(*((uint**)eax)); //mov eax, dword ptr [eax]
											eax = unchecked((void*)((byte*)eax + 0x8)); //add eax, 8
											eax = (void*)(*((uint**)eax)); //mov eax, dword ptr [eax]
											//push edx
											//call eax
											releaseDelegate releasePRF = (releaseDelegate)Marshal.GetDelegateForFunctionPointer(new IntPtr(eax), typeof(releaseDelegate));
											releasePRF(edx);
										}else{
											//could not query the interface
											retVal = new errorReport(unchecked((uint)hres), "Error creating shortcuts. Try restarting the prgraom. Running it as administrator may also help.");
										}
										//shellLinkInterfacePtr->Release() (shellLinkInterfacePtr = %0)
										eax = shellLinkInterfacePtr; //mov eax, %0
										edx = eax; //mov edx, eax
										eax = shellLinkInterfacePtr; //mov eax, %0
										eax = (void*)(*((uint**)eax)); //mov eax, dword ptr [eax]
										eax = unchecked((void*)((byte*)eax + 0x8)); //add eax, 8
										eax = (void*)(*((uint**)eax)); //mov eax, dword ptr [eax]
										//push edx
										//call eax
										releaseDelegate releaseSHL = (releaseDelegate)Marshal.GetDelegateForFunctionPointer(new IntPtr(eax), typeof(releaseDelegate));
										releaseSHL(edx);
									}else{
										//error in CoCreateInstance
										retVal = new errorReport(unchecked((uint)hres), "Error creating shortcuts. Try restarting the prgraom. Running it as administrator may also help.");
									}
									//uninitialize (clean up)
									CoUninitialize();
								}else{
									retVal = new errorReport(unchecked((uint)hres), "Error creating shortcuts. Try restarting the prgraom. Running it as administrator may also help.");
								}
								//free memory
								HeapFree(prcHeap, 0, pathToCA);
								HeapFree(prcHeap, 0, descriptionCA);
								HeapFree(prcHeap, 0, shortcutPathCA);
							}else{
								//wasn't enough memory on heap to allocate shortcutPathCA
								HeapFree(prcHeap, 0, pathToCA);
								HeapFree(prcHeap, 0, descriptionCA);
								retVal = new errorReport(1, "Error creating shortcuts. Try restarting the program. Running it as administrator may also help.");
							}
						}else{
							//wasn't enough memory on heap to allocate descriptionCA
							HeapFree(prcHeap, 0, pathToCA);
							retVal = new errorReport(1, "Error creating shortcuts. Try restarting the program. Running it as administrator may also help.");
						}
					}else{
						//wasn't enough memory on heap to allocate pathToCA
						retVal = new errorReport(1, "Error creating shortcuts. Try restarting the program. Running it as administrator may also help.");
					}
				}else{
					//could not GetProcessHeap()
					retVal = new errorReport(GetLastError(), "Error creating shortcuts. Try restarting the program. Running it as administrator may also help.");
				}
			}
			//free wsz
			if(wsz != (char*)0){
				HeapFree(prcHeap, 0, wsz);
			}
			return retVal;
		}
		
		//the Heap functions from Kernel32.dll (ie. malloc and free)
		[DllImport("kernel32.dll", EntryPoint="GetProcessHeap", SetLastError=true)]
		public unsafe extern static void* GetProcessHeap();
		[DllImport("kernel32.dll", EntryPoint="HeapAlloc")]
		public unsafe extern static void* HeapAlloc(void* hHeap, UInt32 dwFlags, ulong dwBytes);
		[DllImport("kernel32.dll", EntryPoint="HeapFree")]
		public unsafe extern static bool HeapFree(void* hHeap, UInt32 dwFlags, void* lpMem);
		
		//ole32
		[DllImport("ole32.dll", EntryPoint="CoInitialize")]
		public extern static int CoInitialize(UIntPtr reserved);
		[DllImport("ole32.dll", EntryPoint = "CoUninitialize")]
		public extern static void CoUninitialize();
		[DllImport("ole32.dll", EntryPoint = "CoCreateInstance")]
		public extern unsafe static int CoCreateInstance(Guid* rclsid, void* pUnkOuter, UInt32 dwClsContext, Guid* riid, void* ppv);
		
		//misc
		[DllImport("Kernel32.dll", EntryPoint="MultiByteToWideChar")]
		public extern unsafe static int MultiByteToWideChar(uint CodePage, UInt32 dwFlags, byte* lpMultiByteStr, int cbMultiByte, char* lpWideCharStr, int cchWideChar);
		[DllImport("Kernel32.dll", EntryPoint="GetLastError", CallingConvention=CallingConvention.Winapi)]
		public extern static UInt32 GetLastError();

		//constant stuff
		public static readonly UInt32 HEAP_ZERO_MEMORY = 0x00000008;
		public static readonly int MAX_PATH = 260;
		public static readonly UInt32 CLSCTX_INPROC_SERVER = 0x1;
	}
}
