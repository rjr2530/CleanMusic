using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TagLib;
using System.Runtime.Serialization.Formatters.Binary;

namespace CleanMusic
{
    public partial class Form1 : Form
    {
        DirectoryInfo musicDirectory;

        public Form1()
        {
            InitializeComponent();
        }

        //Opens a dialog to choose a directory
        private void directoryButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = @"C:\";
            dialog.ShowDialog();

            if (!string.IsNullOrEmpty(dialog.SelectedPath))
            {
                musicDirectory = new DirectoryInfo(dialog.SelectedPath);
                directoryLabel.Text = musicDirectory.FullName;
            }           
        }

        private void organizeButton_Click(object sender, EventArgs e)
        {
            if (musicDirectory != null)
            {
                FileInfo[] musicFiles = musicDirectory.GetFiles("*.mp3");

                if(musicFiles.Length > 0)
                {
                    TagLib.File tagFile;
                    DirectoryInfo artistDirectory;
                    DirectoryInfo albumDirectory;

                    foreach(FileInfo track in musicFiles)
                    {
                        tagFile = TagLib.File.Create(track.FullName);
                        
                        CleanTitleData(tagFile);
                        EditFileTags(tagFile);

                        if (!Directory.Exists(Path.Combine(musicDirectory.FullName, ArtistName(tagFile.Tag.FirstPerformer))))
                        {
                            artistDirectory = musicDirectory.CreateSubdirectory(ArtistName(tagFile.Tag.FirstPerformer));
                            System.IO.File.Move(Path.Combine(musicDirectory.FullName, track.Name), Path.Combine(artistDirectory.FullName, track.Name));
                            statusTextBox.AppendText(string.Format("Folder created for: {0}\n\n", ArtistName(tagFile.Tag.FirstPerformer)));
                            statusTextBox.AppendText(string.Format("\"{0}\" moved to {1} folder\n\n", tagFile.Tag.Title.Trim(), ArtistName(tagFile.Tag.FirstPerformer)));

                            if (!string.IsNullOrEmpty(tagFile.Tag.Album))
                            {
                                if (!Directory.Exists(Path.Combine(artistDirectory.FullName, tagFile.Tag.Album)))
                                {
                                    albumDirectory = artistDirectory.CreateSubdirectory(tagFile.Tag.Album);
                                    System.IO.File.Move(Path.Combine(artistDirectory.FullName, track.Name), Path.Combine(albumDirectory.FullName, track.Name));
                                }
                                else
                                {
                                    albumDirectory = (artistDirectory.GetDirectories().Where(x => x.FullName == artistDirectory.FullName + "\\" + tagFile.Tag.Album).First());
                                    System.IO.File.Move(Path.Combine(artistDirectory.FullName, track.Name), Path.Combine(albumDirectory.FullName, track.Name));
                                }
                            }
                        }
                        else
                        {
                            artistDirectory = musicDirectory.GetDirectories().Where(x => x.FullName.Equals(musicDirectory.FullName + "\\" + ArtistName(tagFile.Tag.FirstPerformer))).First();

                            if (!System.IO.File.Exists(Path.Combine(artistDirectory.FullName, track.Name)))
                            {
                                System.IO.File.Move(Path.Combine(musicDirectory.FullName, track.Name), Path.Combine(artistDirectory.FullName, track.Name));
                                statusTextBox.AppendText(string.Format("\"{0}\" moved to {1} folder.\n\n", tagFile.Tag.Title.Trim(), ArtistName(tagFile.Tag.FirstPerformer)));
                            }
                            else
                            {
                                DialogResult result = MessageBox.Show("This file already exists in this directory. Would you like to delete the copy?", "Alert - " + tagFile.Name.Substring(tagFile.Name.LastIndexOf("\\") + 1), MessageBoxButtons.YesNo);

                                if (result == System.Windows.Forms.DialogResult.Yes)
                                    System.IO.File.Delete(tagFile.Name);
                                else
                                    MessageBox.Show("File will remain in the current directory");
                                    continue;
                            }
                            

                            if (!string.IsNullOrEmpty(tagFile.Tag.Album))
                            {
                                if (!Directory.Exists(Path.Combine(artistDirectory.FullName, tagFile.Tag.Album)))
                                {
                                    albumDirectory = artistDirectory.CreateSubdirectory(tagFile.Tag.Album);
                                    System.IO.File.Move(Path.Combine(artistDirectory.FullName, track.Name), Path.Combine(albumDirectory.FullName, track.Name));
                                }
                                else
                                {
                                    albumDirectory = (artistDirectory.GetDirectories().Where(x => x.FullName == artistDirectory.FullName + "\\" + tagFile.Tag.Album).First());
                                    System.IO.File.Move(Path.Combine(artistDirectory.FullName, track.Name), Path.Combine(albumDirectory.FullName, track.Name));
                                }
                            }
                        }
                    }

                    MessageBox.Show("Music is now organized", "Complete");
                }
                else
                {
                   MessageBox.Show("There are no music files in this directory.");
                }
            }
            else
            {
                MessageBox.Show("Select a directory");
            }
         }

        private void CleanTitleData(TagLib.File file)
        {
            if(file.Tag.Title.IndexOfAny(new char[]{'[', '(','-'}) > -1)
            {
                int index = file.Tag.Title.IndexOfAny(new char[]{'[', '(','-'});
                if (index > -1)
                {
                    if(file.Tag.Title.Contains("(f") || file.Tag.Title.Contains(" f") || file.Tag.Title.Contains("(F") || file.Tag.Title.Contains(" F"))
                        return;
                    
                    string newTitle = file.Tag.Title.Substring(0, index);
                    file.Tag.Title = newTitle;
                    file.Save();
                }
            }

        }

        private string ArtistName(string artist)
        {
            string[] words = {" And", " AND", " and", " FT.", " Ft.", " FT", " Ft", " ft", " ft.", " Featuring", " featuring", " feat", " Feat", " FEAT" };

            foreach(string word in words)
            {
                if (artist != null)
                {
                    if (artist.Contains(word))
                    {
                        return artist.Substring(0, artist.IndexOf(word));
                    }
                }
                else
                {
                    artist = "Artist Unknown";
                    return artist;
                }
            }

            return artist;
        }

        EditForm editForm;

        private void EditFileTags(TagLib.File file)
        {
            if(string.IsNullOrEmpty(file.Tag.FirstPerformer) || string.IsNullOrEmpty(file.Tag.Title) || string.IsNullOrEmpty(file.Tag.Album))
            { 
                DialogResult result = MessageBox.Show("The " + (string.IsNullOrEmpty(file.Tag.Title) ? "Title" : "Album name") + " is missing for this track. Would you like to edit?", file.Name.Substring(file.Name.LastIndexOf("\\") + 1), MessageBoxButtons.YesNo);

                if(result == System.Windows.Forms.DialogResult.Yes)
                {
                    editForm = new EditForm(file.Tag.FirstPerformer,file.Tag.Title, file.Tag.Album);
                    editForm.ShowDialog(this);

                    file.Tag.Title = editForm.Title;
                    file.Tag.Album = editForm.Album;
                    file.Save();
                }
            }
        }
    }
}
