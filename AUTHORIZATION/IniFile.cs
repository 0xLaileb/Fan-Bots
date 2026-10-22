using System.Runtime.InteropServices;
using System.Text;

/// <summary>
/// INI class for working with ini files [v0.2] 
/// (github.com/0xLaileb/IniFile)
/// </summary>
public class IniFile
{
    private readonly string FileName; //Initialization file name.
    /// <param name="FileName">Initialization file name.</param>
    public IniFile(string FileName = null) => this.FileName = new System.IO.FileInfo(FileName).FullName.ToString();

    #region KERNEL32
    /// <summary>
    /// WritePrivateProfileString writes string values to INI files. 
    /// The function can also be used to write numeric values passed as strings (for example: "1"). 
    /// If the file you are writing to does not exist, it is created. 
    /// Sections, keys and key values are created the same way. 
    /// Note that INI file support in Windows exists only for compatibility; use the system registry to store information.
    /// </summary>
    /// 
    /// <param name="lpAppName">
    /// INI file section name.
    /// </param>
    /// <param name="lpKeyName">
    /// Key name.
    /// </param>
    /// <param name="lpString">
    /// String value to write.
    /// </param>
    /// <param name="lpFileName">
    /// INI file name.
    /// </param>
    /// 
    /// <returns>
    /// The function returns 0 on failure and a nonzero value on success.
    /// </returns>
    [DllImport("kernel32", CharSet = CharSet.Auto)]
    private static extern long WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

    /// <summary>
    /// GetPrivateProfileString reads string values from INI files. 
    /// The parameters passed to the function determine the value to read. 
    /// </summary>
    /// 
    /// <param name="lpAppName">
    /// Name of the section that contains the key name. 
    /// If this parameter is NULL, GetPrivateProfileString copies all section names in the file to the supplied buffer.
    /// </param>
    /// <param name="lpKeyName">
    /// Name of the key whose associated string is to be retrieved. 
    /// If this parameter is NULL, all key names in the section specified by lpAppName are copied to the buffer specified by lpReturnedString.
    /// </param>
    /// <param name="lpDefault">
    /// Default string. If the lpKeyName key cannot be found in the initialization file, 
    /// GetPrivateProfileString copies the default string to the lpReturnedString buffer.
    /// If this parameter is NULL, the default is an empty string "".
    /// Avoid specifying a default string with trailing blank characters. The function inserts a null character in the lpReturnedString buffer to strip any trailing blanks.
    /// </param>
    /// <param name="lpReturnedString">
    /// Buffer that receives the retrieved string.
    /// </param>
    /// <param name="nSize">
    /// Size of the buffer pointed to by lpReturnedString, in characters.
    /// </param>
    /// <param name="lpFileName">
    /// Name of the initialization file. If this parameter does not contain a full path to the file, the system searches for the file in the Windows directory.
    /// </param>
    /// 
    /// <returns>
    /// The function returns the number of characters copied to lpReturnedString. 
    /// On success, the string read from the INI file is placed in lpReturnedString. 
    /// Otherwise, lpReturnedString receives the string given as lpDefault. 
    /// </returns>
    [DllImport("kernel32", CharSet = CharSet.Auto)]
    private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

    /// <summary>
    /// GetPrivateProfileInt reads the integer value of the given key from an ini file.
    /// </summary>
    /// 
    /// <param name="lpAppName">
    /// Section in which the key is searched.
    /// </param>
    /// <param name="lpKeyName">
    /// Key whose value is requested.
    /// </param>
    /// <param name="nDefault">
    /// Default value if the given key is not found.
    /// </param>
    /// <param name="lpFileName">
    /// Path to the ini file. If no path is specified, the file is searched for in the Windows directory.
    /// </param>
    /// 
    /// <returns>
    /// On success, the function returns the key value. 
    /// If the value does not exist or is not a number, the value given as nDefault is returned. 
    /// If the value is not a valid integer, only its numeric prefix is returned (for example: 10apples = 10).
    /// </returns>
    [DllImport("kernel32", CharSet = CharSet.Auto)]
    private static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

    /// <summary>
    /// GetPrivateProfileSection retrieves all keys and values of the given section of an initialization file.
    /// </summary>
    /// 
    /// <param name="lpAppName">
    /// Name of the section in the initialization file.
    /// </param>
    /// <param name="lpReturnedString">
    /// Buffer that receives the key name and value pairs of the named section. 
    /// The buffer is filled with one or more null-terminated strings; the last string is followed by a second null character.
    /// </param>
    /// <param name="nSize">
    /// Size of the buffer pointed to by lpReturnedString, in characters.
    /// </param>
    /// <param name="lpFileName">
    /// Name of the initialization file.
    /// </param>
    /// 
    /// <returns>
    /// The return value is the number of characters copied to the buffer, not including the terminating null character. 
    /// If the buffer is too small to hold all key name and value pairs of the named section, the return value is nSize minus two.
    /// </returns>
    [DllImport("kernel32", CharSet = CharSet.Auto)]
    private static extern int GetPrivateProfileSection(string lpAppName, System.IntPtr lpReturnedString, int nSize, string lpFileName);

    /// <summary>
    /// GetPrivateProfileSectionNames retrieves the names of all sections in an initialization file.
    /// </summary>
    /// 
    /// <param name="lpReturnedString">
    /// Buffer that receives the section names of the named file. 
    /// The buffer is filled with one or more null-terminated strings; the last string is followed by a second null character.
    /// </param>
    /// <param name="nSize">
    /// Size of the buffer pointed to by lpszReturnBuffer, in characters.
    /// </param>
    /// <param name="lpFileName">
    /// Name of the initialization file. If this parameter is NULL, the function searches the Win.ini file.
    /// </param>
    /// 
    /// <returns>
    /// The return value is the number of characters copied to the buffer, not including the terminating null character. 
    /// If the buffer is too small to hold all section names of the given file, the return value is the size given by nSize minus two.
    /// </returns>
    [DllImport("kernel32", CharSet = CharSet.Auto)]
    private static extern int GetPrivateProfileSectionNames(System.IntPtr lpReturnedString, int nSize, string lpFileName);

    #endregion

    #region TOOLS
    /// <summary>
    /// Write writes string values to ini files. 
    /// The function can also be used to write numeric values passed as strings (for example: "1"). 
    /// If the file you are writing to does not exist, it is created. 
    /// Sections, keys and key values are created the same way. 
    /// Note that ini file support in Windows exists only for compatibility; use the system registry to store information.
    /// </summary>
    /// 
    /// <param name="Section">
    /// Ini file section name.
    /// </param>
    /// <param name="Key">
    /// Key name.
    /// </param>
    /// <param name="Value">
    /// String value to write.
    /// </param>
    /// 
    /// <returns>
    /// The function returns 0 on failure and a nonzero value on success.
    /// </returns>
    public void Write(string Key, string Value, string Section = null) => WritePrivateProfileString(Section, Key, Value, FileName);

    /// <summary>
    /// ReadString reads string values from ini files. 
    /// The parameters passed to the function determine the value to read. 
    /// </summary>
    /// 
    /// <param name="Key">
    /// Name of the key whose associated string is to be retrieved. 
    /// If this parameter is null, all key names in the section given by Section are returned.
    /// </param>
    /// <param name="Default">
    /// If Key cannot be found in the initialization file, Default is returned.
    /// </param>
    /// <param name="Section">
    /// Name of the section that contains the key name. 
    /// If this parameter is null, ReadString returns all section names in the file.
    /// </param>
    /// 
    /// <returns>
    /// The function always returns a string.
    /// On success, the string read from the INI file is returned. 
    /// Otherwise, the string given as Default is returned. 
    /// </returns>
    public string ReadString(string Key, string Section = null, int Size = 255, string Default = "")
    {
        StringBuilder tmp = new StringBuilder(Size); //Create the buffer that receives the value.
        GetPrivateProfileString(Section, Key, Default, tmp, Size, FileName);
        return tmp.ToString();
    }

    /// <summary>
    /// ReadInt reads the numeric value of the given key from an ini file.
    /// </summary>
    /// 
    /// <param name="Section">
    /// Section in which the key is searched.
    /// </param>
    /// <param name="Key">
    /// Key whose value is requested.
    /// </param>
    /// <param name="Default">
    /// Default value if the given key is not found.
    /// </param>
    /// 
    /// <returns>
    /// On success, the function returns the key value. 
    /// If the value does not exist or is not a number, the value given as Default is returned. 
    /// If the value is not a valid integer, only its numeric prefix is returned (for example: 10apples = 10).
    /// </returns>
    public int ReadInt(string Key, string Section = null, int Default = -1) => GetPrivateProfileInt(Section, Key, Default, FileName);

    /// <summary>
    /// ReadBool reads the boolean value of the given key from an ini file.
    /// </summary>
    /// 
    /// <param name="Key">
    /// Key whose value is requested.
    /// </param>
    /// <param name="Section">
    /// Section in which the key is searched.
    /// </param>
    /// 
    /// <returns>
    /// On success, the function returns the key value (true or false) if it was found.
    /// </returns>
    public bool ReadBool(string Key, string Section = null, int Size = 255)
    {
        StringBuilder tmp = new StringBuilder(Size); //Create the buffer that receives the value.
        GetPrivateProfileString(Section, Key, "", tmp, Size, FileName);
        return System.Convert.ToBoolean(tmp.ToString());
    }

    /// <summary>
    /// GetAllDataSection retrieves all keys and values of the given section of the initialization file.
    /// </summary>
    /// 
    /// <param name="Section">
    /// Name of the section in the initialization file.
    /// </param>
    /// 
    /// <returns>
    /// An array of the retrieved strings.
    /// </returns>
    public string[] GetAllDataSection(string Section, int Size = 255)
    {
        System.IntPtr pMem = Marshal.AllocHGlobal(4096 * sizeof(char));
        string temp = string.Empty;

        int count = GetPrivateProfileSection(Section, pMem, Size * sizeof(char), FileName) - 1;
        if (count > 0) temp = Marshal.PtrToStringUni(pMem, count);
        Marshal.FreeHGlobal(pMem);

        return temp.Split('\0');
    }

    /// <summary>
    /// GetAllSections retrieves the names of all sections in the initialization file.
    /// </summary>
    /// 
    /// <returns>
    /// An array of the retrieved strings.
    /// </returns>
    public string[] GetAllSections(int Size = 255)
    {
        System.IntPtr pMem = Marshal.AllocHGlobal(4096 * sizeof(char));
        string temp = string.Empty;

        int count = GetPrivateProfileSectionNames(pMem, Size * sizeof(char), FileName) - 1;
        if (count > 0) temp = Marshal.PtrToStringUni(pMem, count);
        Marshal.FreeHGlobal(pMem);

        return temp.Split('\0');
    }

    /// <summary>
    /// DeleteKey deletes the given key in the given section.
    /// </summary>
    /// 
    /// <param name="Key">
    /// Name of the key to delete.
    /// </param>
    /// <param name="Section">
    /// Name of the section that contains the key name.
    /// </param>
    public void DeleteKey(string Key, string Section = null) => Write(Key, null, Section);

    /// <summary>
    /// DeleteSection deletes the given section.
    /// </summary>
    /// 
    /// <param name="Section">
    /// Name of the section to delete.
    /// </param>
    public void DeleteSection(string Section = null) => Write(null, null, Section);

    /// <summary>
    /// KeyExists reads the key in the given section and checks whether it has a value.
    /// </summary>
    /// 
    /// <param name="Key">
    /// Name of the key whose value is checked (value.Length > 0)
    /// </param>
    /// <param name="Section">
    /// Name of the section that contains Key.
    /// </param>
    /// 
    /// <returns>
    /// Returns true if the key has a value; otherwise, false.
    /// </returns>
    public bool KeyExists(string Key, string Section = null) => ReadString(Key, Section).Length > 0;
    #endregion
}
