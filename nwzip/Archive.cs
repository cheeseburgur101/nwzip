using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
namespace nwzip
{
	/// <summary>
	/// Description of Archive.
	/// </summary>
	public class Archive
	{
		
		private List<File> files;
		public string path;
		public bool encrypted;
		public int encryptionMethod;
		
		/// <summary>
		/// Creates an empty archive object (i.e. when using File > New)
		/// </summary>
		public Archive()
		{
			files = new List<File>();
		}

		/// <summary>
		/// Loads an archive object from a file
		/// </summary>
		public Archive(String file){
			files = new List<File>();
			this.loadFrom(file);
		}
		
		public List<File> getFiles(){
			return this.files;
		}
		
		public int saveTo(string path){
			return 0;
		}
		
		public int loadFrom(string path){
			// Load first bytes from file to get archive metadata
			this.path = path;
			FileStream fs = System.IO.File.OpenRead(path);
			int metadataLength = (int)fs.ReadByte();
			byte[] archiveMetadata = new byte[metadataLength];
			// the first byte represents the length of the metadata
			int result = fs.Read(archiveMetadata, 0, metadataLength);
			
			// Iterate over metadata
			for(int i = 0; i < archiveMetadata.Length; i++){
				byte b = archiveMetadata[i];
				switch(b){
					case (byte)'e':
						// Encryption settings
						// Length: 2 ('e' + setting)
						if(archiveMetadata[i+1]!=0){
							this.encrypted = true;
							this.encryptionMethod = archiveMetadata[i+1];
						}else{
							this.encrypted = false;
						}
						i++;
						break;
				}
			}
			
			// Continue loading files
			fs.Position = metadataLength+1;
			int hb;
			while((hb = fs.ReadByte())!=-1){
				int lb = fs.ReadByte();
				int fileLength = 256*hb+lb;
				
				File f = new File();
				byte[] data = new byte[fileLength];
				fs.Read(data, 0, fileLength);
				for(int i = 0; i < data.Length; i++){
					byte b = data[i];
					switch(b){
						case (byte)'p':
							// Path of the file inside the archive.
							// format: 'p' + (length) + data
							int pLength = data[i+1];
							f.archivePath = Encoding.UTF8.GetString(data.Skip(i+2).Take(pLength).ToArray());
							i+=1+pLength;
							break;
					}
				}
				files.Add(f);
				//fs.Position += fileLength;
			}
			fs.Close();
			return 0;
		}
		
		public byte[] getRaw(int offset, int length){
			byte[] buffer = new byte[length];
			FileStream fs = System.IO.File.OpenRead(path);
			fs.Read(buffer, offset-1, length);
			fs.Close();
			return buffer;
		}
	}
}
