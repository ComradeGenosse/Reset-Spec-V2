using System;
using System.IO;
using System.Windows.Forms;

class Program
{
    static void Main(string[] args)
    {
        // Specify the folder paths and the file names to delete
        string appDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\ProjectMatrix\ProjectSpec5";
        string localAppDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\ProjectMatrix";
        string folderNamePattern = "ProjectSpec*";
        string filePath1 = Path.Combine(appDataFolderPath, "ProjectSpec5.config_backup");
        string filePath2 = Path.Combine(appDataFolderPath, "SpecUser.config_backup");

        if (MessageBox.Show($"This will reset Spec. Are you sure you want to continue?", "Confirm Files and Folders Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        {
            try
            {
                // Delete the specified files if they exist
                if (File.Exists(filePath1))
                {
                    File.Delete(filePath1);
                }

                if (File.Exists(filePath2))
                {
                    File.Delete(filePath2);
                }

                // Delete the folders that match the pattern in %LOCALAPPDATA%\ProjectMatrix
                DirectoryInfo localAppDataRootFolder = new DirectoryInfo(localAppDataFolderPath);
                foreach (DirectoryInfo subFolder in localAppDataRootFolder.GetDirectories(folderNamePattern, SearchOption.TopDirectoryOnly))
                {
                    subFolder.Delete(true);
                }

                Console.WriteLine($"\nFiles and folders have been deleted successfully.");
                MessageBox.Show("You may now open Spec", "Operation Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine($"\nOperation aborted by user.");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
