using System;
using System.Runtime.InteropServices;
using System.IO;

namespace nwzip{
	/// <summary>
	/// Class that helps with creating shortcuts. Everything in this class should be usable by other classes.
	/// </summary>
	public static class shortcutHelper{
		static void blankFunctionTemplate(){

		}
		delegate void blankFunctionTemplateDelegate();
		/// <summary>
		/// Creates a shortcut
		/// </summary>
		/// <param name="pathTo">Shortcut's file opened when double clicked (ie. shortcut's target)</param>
		/// <param name="description">Shortcut's description</param>
		/// <param name="shortcutPath">Path of the shortcut to be saved</param>
		/// <param name="overwrite">Overwrite the shortcut if it exists</param>
		/// <returns>A class (errorReport) which contains error information (integer status, string message)</returns>
		public unsafe static errorReport createShortcut(string pathTo, string description, string shortcutPath, bool overwrite){
			errorReport retVal = new errorReport();
			//retVal = new errorReport(1, "not supported");
			//return retVal;
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
			if(pathTo.Length > MAX_PATH) retVal = new errorReport(1, "Your system does not support this program installing shortcuts.");
			if(description.Length > MAX_PATH) retVal = new errorReport(1, "Your system does not support this program installing shortcuts.");
			if(shortcutPath.Length > MAX_PATH) retVal = new errorReport(1, "Your system does not support this program installing shortcuts.");
			//Create a heap which can execute code (4096 bytes should be large enough)
			void* thrHeap = HeapCreate(0x00040000, 4096, 16384); //HEAP_CREATE_ENABLE_EXECUTE = 0x00040000
			if(thrHeap != (void*)0){
				//Make sure only this thread can use the heap
				HeapLock(thrHeap);
				byte* codeBuffer = (byte*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, 4096); //allocate the buffer in the heap
				byte* pathToCA = (byte*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(byte) * (MAX_PATH + 1)));
				byte* descriptionCA = (byte*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(byte) * (MAX_PATH + 1)));
				byte* shortcutPathCA = (byte*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(byte) * (MAX_PATH + 1)));
				char* ole32dllstr = (char*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(char) * 11));
				byte* ole32coinitstr = (byte*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(byte) * 14));
				byte* ole32cocreastr = (byte*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(byte) * 18));
				byte* ole32couninstr = (byte*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(byte) * 16));
				char* shell32str = (char*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(char) * 13));
				UInt32* resultDW = (UInt32*)HeapAlloc(thrHeap, HEAP_ZERO_MEMORY, (ulong)(sizeof(UInt32)));
				if((codeBuffer != (byte*)0) && (pathToCA != (byte*)0) &&
				   (descriptionCA != (byte*)0) && (shortcutPathCA != (byte*)0) && 
				   (ole32dllstr != (char*)0) && (ole32coinitstr != (byte*)0) &&
				   (ole32cocreastr != (byte*)0) && (ole32couninstr != (byte*)0) &&
				   (resultDW != (UInt32*)0) && (shell32str != (char*)0)){ //note: potential memory leak (if one was not null, but the other was null)
					//copy strings
					for(int i = 0; i < pathTo.Length; ++i){
						pathToCA[i] = unchecked((byte)pathTo[i]); //note: would be bad for unicode username
					}
					for(int i = 0; i < description.Length; ++i){
						descriptionCA[i] = unchecked((byte)description[i]);
					}
					for(int i = 0; i < shortcutPath.Length; ++i){
						shortcutPathCA[i] = unchecked((byte)shortcutPath[i]);
					}
					ole32dllstr[0] = 'o'; //ole32.dll
					ole32dllstr[1] = 'l';
					ole32dllstr[2] = 'e';
					ole32dllstr[3] = '3';
					ole32dllstr[4] = '2';
					ole32dllstr[5] = '.';
					ole32dllstr[6] = 'd';
					ole32dllstr[7] = 'l';
					ole32dllstr[8] = 'l';
					ole32dllstr[9] = '\0';
					
					ole32coinitstr[0]  = (byte)'C'; //CoInitialize
					ole32coinitstr[1]  = (byte)'o';
					ole32coinitstr[2]  = (byte)'I';
					ole32coinitstr[3]  = (byte)'n';
					ole32coinitstr[4]  = (byte)'i';
					ole32coinitstr[5]  = (byte)'t';
					ole32coinitstr[6]  = (byte)'i';
					ole32coinitstr[7]  = (byte)'a';
					ole32coinitstr[8]  = (byte)'l';
					ole32coinitstr[9]  = (byte)'i';
					ole32coinitstr[10] = (byte)'z';
					ole32coinitstr[11] = (byte)'e';
					ole32coinitstr[12] = (byte)'\0';
					
					ole32cocreastr[0]  = (byte)'C'; //CoCreateInstance
					ole32cocreastr[1]  = (byte)'o';
					ole32cocreastr[2]  = (byte)'C';
					ole32cocreastr[3]  = (byte)'r';
					ole32cocreastr[4]  = (byte)'e';
					ole32cocreastr[5]  = (byte)'a';
					ole32cocreastr[6]  = (byte)'t';
					ole32cocreastr[7]  = (byte)'e';
					ole32cocreastr[8]  = (byte)'I';
					ole32cocreastr[9]  = (byte)'n';
					ole32cocreastr[10] = (byte)'s';
					ole32cocreastr[11] = (byte)'t';
					ole32cocreastr[12] = (byte)'a';
					ole32cocreastr[13] = (byte)'n';
					ole32cocreastr[14] = (byte)'c';
					ole32cocreastr[15] = (byte)'e';
					ole32cocreastr[16] = (byte)'\0';
					
					ole32couninstr[0]  = (byte)'C'; //CoUninitialize
					ole32couninstr[1]  = (byte)'o';
					ole32couninstr[2]  = (byte)'U';
					ole32couninstr[3]  = (byte)'n';
					ole32couninstr[4]  = (byte)'i';
					ole32couninstr[5]  = (byte)'n';
					ole32couninstr[6]  = (byte)'i';
					ole32couninstr[7]  = (byte)'t';
					ole32couninstr[8]  = (byte)'i';
					ole32couninstr[9]  = (byte)'a';
					ole32couninstr[10] = (byte)'l';
					ole32couninstr[11] = (byte)'i';
					ole32couninstr[12] = (byte)'z';
					ole32couninstr[13] = (byte)'e';
					ole32couninstr[14] = (byte)'\0';
					
					shell32str[0]  = 's'; //shell32.dll
					shell32str[1]  = 'h';
					shell32str[2]  = 'e';
					shell32str[3]  = 'l';
					shell32str[4]  = 'l';
					shell32str[5]  = '3';
					shell32str[6]  = '2';
					shell32str[7]  = '.';
					shell32str[8]  = 'd';
					shell32str[9]  = 'l';
					shell32str[10] = 'l';
					shell32str[11] = '\0';
					
					//shell32.dll
					void* ole32lib = LoadLibraryW(ole32dllstr);
					void* shell32lib = LoadLibraryW(shell32str);
					if((ole32lib != (void*)0) && (shell32lib != (void*)0)){
						void* CoInitializePtr = GetProcAddress(ole32lib, ole32coinitstr);
						void* CoCreateInstancePtr = GetProcAddress(ole32lib, ole32cocreastr);
						void* CoUninitializePtr = GetProcAddress(ole32lib, ole32couninstr);
						if((CoInitializePtr != (void*)0) && (CoCreateInstancePtr != (void*)0) && (CoUninitializePtr != (void*)0)){
							//set full acess to the code region
							for(int i = 0; i < 4096; ++i){
								codeBuffer[i] = (byte)0x90; //NOP the code
							}
							blankFunctionTemplateDelegate bftd = blankFunctionTemplate;
							IntPtr p_bftd = Marshal.GetFunctionPointerForDelegate(bftd);
							
							//manipulate function pointer's value (to be able to execute the code that will be in the buffer)
							p_bftd = new IntPtr(codeBuffer);
							blankFunctionTemplateDelegate functionX = (blankFunctionTemplateDelegate)Marshal.GetDelegateForFunctionPointer(p_bftd, typeof(blankFunctionTemplateDelegate));
							//functionX is now a function pointer to the buffer
							
							//set *resultDW
							*resultDW = 0;
							
							//place asm code into the buffer
							
							//preserve the registers and the flags
							codeBuffer[0]   = 0x60; //pusha
							
							codeBuffer[1]   = 0x66; //pushf
							codeBuffer[2]   = 0x9C;
							//create a stack frame
							codeBuffer[3]   = 0x55; //push ebp
							
							codeBuffer[4]   = 0x8B; //mov ebp, esp
							codeBuffer[5]   = 0xEC;
							//IPersistFile GUID on stack
							codeBuffer[6]   = 0x68; //push 0x46000000
							codeBuffer[7]   = 0x00;
							codeBuffer[8]   = 0x00;
							codeBuffer[9]   = 0x00;
							codeBuffer[10]  = 0x46;
							
							codeBuffer[11]  = 0x68; //push 0x000000C0
							codeBuffer[12]  = 0xC0;
							codeBuffer[13]  = 0x00;
							codeBuffer[14]  = 0x00;
							codeBuffer[15]  = 0x00;
							
							codeBuffer[16]  = 0x6A; //push 0x00000000
							codeBuffer[17]  = 0x00;
							
							codeBuffer[18]  = 0x68; //push 0x0000010B
							codeBuffer[19]  = 0x0B;
							codeBuffer[20]  = 0x01;
							codeBuffer[21]  = 0x00;
							codeBuffer[22]  = 0x00;
							//IShellLink GUID on stack
							codeBuffer[23]  = 0x68; //push 0x46000000
							codeBuffer[24]  = 0x00;
							codeBuffer[25]  = 0x00;
							codeBuffer[26]  = 0x00;
							codeBuffer[27]  = 0x46;
							
							codeBuffer[28]  = 0x68; //push 0x000000C0
							codeBuffer[29]  = 0xC0;
							codeBuffer[30]  = 0x00;
							codeBuffer[31]  = 0x00;
							codeBuffer[32]  = 0x00;
							
							codeBuffer[33]  = 0x6A; //push 0x00000000
							codeBuffer[34]  = 0x00;
							
							codeBuffer[35]  = 0x68; //push 0x000214EE
							codeBuffer[36]  = 0xEE;
							codeBuffer[37]  = 0x14;
							codeBuffer[38]  = 0x02;
							codeBuffer[39]  = 0x00;
							//push variable (IShellLink* psl) on stack
							codeBuffer[40]  = 0x6A; //push 0x00000000
							codeBuffer[41]  = 0x00;
							//push variable (IPersistFile* psf) on stack
							codeBuffer[42]  = 0x6A; //push 0x00000000
							codeBuffer[43]  = 0x00;
							//push GUID CLSID_ShellLink on stack
							codeBuffer[44]  = 0x68; //push 0x46000000
							codeBuffer[45]  = 0x00;
							codeBuffer[46]  = 0x00;
							codeBuffer[47]  = 0x00;
							codeBuffer[48]  = 0x46;
							
							codeBuffer[49]  = 0x90; //nop
							
							codeBuffer[50]  = 0x68; //push 0x000000C0
							codeBuffer[51]  = 0xC0;
							codeBuffer[52]  = 0x00;
							codeBuffer[53]  = 0x00;
							codeBuffer[54]  = 0x00;
							
							codeBuffer[55]  = 0x6A; //push 0x00000000
							codeBuffer[56]  = 0x00;
							
							codeBuffer[57]  = 0x68; //push 0x00021401
							codeBuffer[58]  = 0x01;
							codeBuffer[59]  = 0x14;
							codeBuffer[60]  = 0x02;
							codeBuffer[61]  = 0x00;
							//Allocate 0x208 bytes on stack (for 260 (0x104) lengh unicode string)
							codeBuffer[62]  = 0x81; //sub esp, 0x208
							codeBuffer[63]  = 0xEC;
							codeBuffer[64]  = 0x08;
							codeBuffer[65]  = 0x02;
							codeBuffer[66]  = 0x00;
							codeBuffer[67]  = 0x00;
							//CoInitialize(null)
							//---
							void** offsetCoInitPtr = &CoInitializePtr;
							//---
							codeBuffer[68]  = 0xB8; //mov eax, offset CoInitializePtr
							codeBuffer[69]  = unchecked((byte)(((uint)offsetCoInitPtr  & 0x000000FF) >>  0));
							codeBuffer[70]  = unchecked((byte)(((uint)offsetCoInitPtr  & 0x0000FF00) >>  8));
							codeBuffer[71]  = unchecked((byte)((((uint)offsetCoInitPtr & 0x00FF0000) >> 15) >> 1));
							codeBuffer[72]  = unchecked((byte)((((uint)offsetCoInitPtr & 0xFF000000) >> 15) >> 9));
							
							codeBuffer[73]  = 0x8B; //mov eax, dword ptr [eax]
							codeBuffer[74]  = 0x00;
							
							codeBuffer[75]  = 0x6A; //push 0x00000000
							codeBuffer[76]  = 0x00;
							
							codeBuffer[77]  = 0xFF; //call eax
							codeBuffer[78]  = 0xD0;
							//error checking
							codeBuffer[79]  = 0x83; //cmp eax, 0x00000000
							codeBuffer[80]  = 0xF8;
							codeBuffer[81]  = 0x00;
							
							codeBuffer[82]  = 0x7C; //jl +0x0000002C+0x00000002
							codeBuffer[83]  = 0x2C;
							//CoCreateInstance(CLSID_ShellLink, null, 0x00000001, IID_IShellLink, &outputInterfacePointer);
							codeBuffer[84]  = 0x8D; //lea eax, dword ptr [ebp-0x00000024]
							codeBuffer[85]  = 0x45;
							codeBuffer[86]  = 0xDC;
							
							codeBuffer[87]  = 0x50; //push eax
							
							codeBuffer[88]  = 0x8D; //lea eax, dword ptr [ebp-0x00000020]
							codeBuffer[89]  = 0x45;
							codeBuffer[90]  = 0xE0;
							
							codeBuffer[91]  = 0x50; //push eax
							
							codeBuffer[92]  = 0x6A; //push 0x00000001
							codeBuffer[93]  = 0x01;
							
							codeBuffer[94]  = 0x6A; //push 0x00000000
							codeBuffer[95]  = 0x00;
							
							codeBuffer[96]  = 0x8D; //lea eax, dword ptr [ebp-0x00000038]
							codeBuffer[97]  = 0x45;
							codeBuffer[98]  = 0xC8;
							
							codeBuffer[99]  = 0x50; //push eax
							//---
							void** offsetCoCreateInstPtr = &CoCreateInstancePtr;
							//---
							codeBuffer[100]  = 0xB8; //mov eax, offset CoCreateInstance
							codeBuffer[101] = unchecked((byte)(((uint)offsetCoCreateInstPtr  & 0x000000FF) >>  0));
							codeBuffer[102] = unchecked((byte)(((uint)offsetCoCreateInstPtr  & 0x0000FF00) >>  8));
							codeBuffer[103] = unchecked((byte)((((uint)offsetCoCreateInstPtr & 0x00FF0000) >> 15) >> 1));
							codeBuffer[104] = unchecked((byte)((((uint)offsetCoCreateInstPtr & 0xFF000000) >> 15) >> 9));
							
							codeBuffer[105] = 0x8B; //mov eax, dword ptr [eax]
							codeBuffer[106] = 0x00;
							
							codeBuffer[107] = 0xFF; //call eax
							codeBuffer[108] = 0xD0;
							//error checking
							codeBuffer[109] = 0x83; //cmp eax, 0x00000000
							codeBuffer[110] = 0xF8;
							codeBuffer[111] = 0x00;
							
							codeBuffer[112] = 0x7C; //jl +0x0000000E+0x00000002
							codeBuffer[113] = 0x0E;
							//sucessfull return
							codeBuffer[114] = 0x83; //add esp, 0x00000038
							codeBuffer[115] = 0xC4;
							codeBuffer[116] = 0x38;
							
							codeBuffer[117] = 0x81; //add esp, 0x00000208
							codeBuffer[118] = 0xC4;
							codeBuffer[119] = 0x08;
							codeBuffer[120] = 0x02;
							codeBuffer[121] = 0x00;
							codeBuffer[122] = 0x00;
							
							codeBuffer[123] = 0x5D; //pop ebp
							
							codeBuffer[124] = 0x66; //popf
							codeBuffer[125] = 0x9D;
							
							codeBuffer[126] = 0x61; //popa
							
							codeBuffer[127] = 0xC3; //ret
							//unsuccessful return
							//---
							void* offsetResult = (void*)&resultDW;
							//---
							codeBuffer[128] = 0xB8; //mov eax, offset result
							codeBuffer[129] = unchecked((byte)(((uint)offsetResult  & 0x000000FF) >>  0));
							codeBuffer[130] = unchecked((byte)(((uint)offsetResult  & 0x0000FF00) >>  8));
							codeBuffer[131] = unchecked((byte)((((uint)offsetResult & 0x00FF0000) >> 15) >> 1));
							codeBuffer[132] = unchecked((byte)((((uint)offsetResult & 0xFF000000) >> 15) >> 9));
							
							codeBuffer[133] = 0xC7; //mov dword ptr [eax], 0x00000001
							codeBuffer[134] = 0x00;
							codeBuffer[135] = 0x01;
							codeBuffer[136] = 0x00;
							codeBuffer[137] = 0x00;
							codeBuffer[138] = 0x00;
							
							codeBuffer[139] = 0x83; //add esp, 0x00000038
							codeBuffer[140] = 0xC4;
							codeBuffer[141] = 0x38;
							
							codeBuffer[142] = 0x81; //add esp, 0x00000208
							codeBuffer[143] = 0xC4;
							codeBuffer[144] = 0x08;
							codeBuffer[145] = 0x02;
							codeBuffer[146] = 0x00;
							codeBuffer[147] = 0x00;
							
							codeBuffer[148] = 0x5D; //pop ebp
							
							codeBuffer[149] = 0x66; //popf
							codeBuffer[150] = 0x9D;
							
							codeBuffer[151] = 0x61; //popa
							
							codeBuffer[152] = 0xC3; //ret
							functionX(); //executes the code in the buffer (it SHOULD only place the return address on the stack (if it was done correctly))
							try{
								uint resultDWDR = *resultDW; //this will not be referancable if failed?
							}catch(Exception ex){
								retVal = new errorReport(unchecked((uint)ex.HResult), "Error while making shortcuts. Try restarting the program. Running it as administrator may also help.");
							}
							
							HeapFree(thrHeap, 0, codeBuffer);
							HeapFree(thrHeap, 0, pathToCA);
							HeapFree(thrHeap, 0, descriptionCA);
							HeapFree(thrHeap, 0, shortcutPathCA);
							HeapFree(thrHeap, 0, ole32dllstr);
							HeapFree(thrHeap, 0, ole32coinitstr);
							HeapFree(thrHeap, 0, ole32cocreastr);
							HeapFree(thrHeap, 0, ole32couninstr);
							HeapFree(thrHeap, 0, shell32str);
							HeapFree(thrHeap, 0, resultDW);
							HeapUnlock(thrHeap);
							HeapDestroy(thrHeap);
						}else{
							HeapFree(thrHeap, 0, codeBuffer);
							HeapFree(thrHeap, 0, pathToCA);
							HeapFree(thrHeap, 0, descriptionCA);
							HeapFree(thrHeap, 0, shortcutPathCA);
							HeapFree(thrHeap, 0, ole32dllstr);
							HeapFree(thrHeap, 0, ole32coinitstr);
							HeapFree(thrHeap, 0, ole32cocreastr);
							HeapFree(thrHeap, 0, ole32couninstr);
							HeapFree(thrHeap, 0, shell32str);
							HeapFree(thrHeap, 0, resultDW);
							HeapUnlock(thrHeap);
							HeapDestroy(thrHeap);
							retVal = new errorReport(GetLastError(),  "Error while making shortcuts. Try restarting the program. Running it as administrator may also help.");
						}
					}else{
						HeapFree(thrHeap, 0, codeBuffer);
						HeapFree(thrHeap, 0, pathToCA);
						HeapFree(thrHeap, 0, descriptionCA);
						HeapFree(thrHeap, 0, shortcutPathCA);
						HeapFree(thrHeap, 0, ole32dllstr);
						HeapFree(thrHeap, 0, ole32coinitstr);
						HeapFree(thrHeap, 0, ole32cocreastr);
						HeapFree(thrHeap, 0, ole32couninstr);
						HeapFree(thrHeap, 0, shell32str);
						HeapFree(thrHeap, 0, resultDW);
						HeapUnlock(thrHeap);
						HeapDestroy(thrHeap);
						retVal = new errorReport(GetLastError(),  "Error while making shortcuts. Try restarting the program. Running it as administrator may also help.");
					}
				}else{
					retVal = new errorReport(GetLastError(),  "Error while making shortcuts. Try restarting the program. Running it as administrator may also help.");
				}
			}else{
				retVal = new errorReport(GetLastError(), "Error while making shortcuts. Try restarting the program. Running it as administrator may also help.");
			}
			return retVal;
		}
		
		//the Heap functions from Kernel32.dll (ie. malloc and free)
		[DllImport("kernel32.dll", EntryPoint="HeapAlloc")]
		public unsafe extern static void* HeapAlloc(void* hHeap, UInt32 dwFlags, ulong dwBytes);
		[DllImport("kernel32.dll", EntryPoint="HeapFree")]
		public unsafe extern static bool HeapFree(void* hHeap, UInt32 dwFlags, void* lpMem);
		[DllImport("kernel32.dll", EntryPoint="HeapCreate", CallingConvention=CallingConvention.Winapi, SetLastError=true)]
		public unsafe extern static void* HeapCreate(UInt32 flOptions, ulong dwInitialSize, ulong dwMaximumSize);
		[DllImport("kernel32.dll", EntryPoint="HeapDestroy", CallingConvention=CallingConvention.Winapi)]
		public unsafe extern static bool HeapDestroy(void* hHeap);
		[DllImport("kernel32.dll", EntryPoint="HeapUnlock", CallingConvention=CallingConvention.Winapi, SetLastError=true)]
		public unsafe extern static bool HeapUnlock(void* hHeap);
		[DllImport("kernel32.dll", EntryPoint="HeapLock", CallingConvention=CallingConvention.Winapi, SetLastError=true)]
		public unsafe extern static bool HeapLock(void* hHeap);

		//misc
		[DllImport("Kernel32.dll", EntryPoint="GetLastError", CallingConvention=CallingConvention.Winapi)]
		public extern static UInt32 GetLastError();
		[DllImport("kernel32.dll", EntryPoint="LoadLibraryW", CharSet=CharSet.Unicode, CallingConvention=CallingConvention.Winapi, SetLastError=true)]
		public extern unsafe static void* LoadLibraryW(char* lpFileName);
		[DllImport("kernel32.dll", EntryPoint="GetProcAddress", CallingConvention=CallingConvention.Winapi, SetLastError=true)]
		public extern unsafe static void* GetProcAddress(void* hModule, byte* lpProcName);
		
		//the structs
		public struct GUID {
			public ulong Data1;
	  		public ushort Data2;
	  		public ushort Data3;
	  		public unsafe fixed byte Data4[8]; //has to be 8 bytes
		}
		
		//constant stuff
		public static readonly UInt32 HEAP_ZERO_MEMORY = 0x00000008;
		public static readonly int MAX_PATH = 260;
		public static readonly UInt32 CLSCTX_INPROC_SERVER = 1;
	}
}
