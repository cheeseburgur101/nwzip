/*
 * Created by SharpDevelop.
 * User: nrgil
 * Date: 2018-10-02
 * Time: 12:27 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace nwzip
{
	/// <summary>
	/// Description of File.
	/// </summary>
	public class File
	{
		// Common variables
		public string fileTypeName;
		public string fileType;
		Metadata metadata;
		
		// Local variables
		public string localPath;
		public bool isLocal;
		
		// Archive variables
		public string archivePath;
		public bool isArchived;
		public int archiveOffset;
		public int dataLength;
		
		/// <summary>
		/// Create a File object from a file on the local filesystem
		/// </summary>
		public File(string file)
		{
			this.localPath = file;
			this.isLocal = true;
		}
		
		public File(){
			// do nothing
		}
		
		public byte[] getRaw(){
			// If the file is local, load it's contents and return it
			// Else get the data from the archive offset
			byte[] data;
			if(this.isLocal){
				data = System.IO.File.ReadAllBytes(this.localPath);
			}else{
				data = new byte[this.dataLength];
				FileStream fr = System.IO.File.OpenRead(archivePath);
				int result = fr.Read(data, this.archiveOffset, this.dataLength);
				if(result!=this.dataLength){
					// Something went wrong.
					return null;
				}
			}
			return data;
		}
		
		
	}
}
