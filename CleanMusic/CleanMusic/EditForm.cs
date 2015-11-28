using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TagLib;

namespace CleanMusic
{
    public partial class EditForm : Form
    {
        public string Title { get; private set; }
        public string Album { get; private set; }
        public string Artist { get; private set; }

        public EditForm(string artist, string title, string album)
        {
            InitializeComponent();
            Title = title;
            Album = album;
            Artist = artist;

            artistTxtBox.Text = Artist;
            titleTxtBox.Text = Title;
            albumTxtBox.Text = Album;
            saveButton.Enabled = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(titleTxtBox.Text))
            {
                Title = titleTxtBox.Text;
            }

            if (!string.IsNullOrEmpty(albumTxtBox.Text)) 
            {
                Album = albumTxtBox.Text;
            }
            
            if(string.IsNullOrEmpty(Album) && string.IsNullOrEmpty(Title))
            {
                MessageBox.Show("There were no changes made.");
                return;
            }
            else
            {
                MessageBox.Show("Changes have been saved.");
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void titleTxtBox_TextChanged(object sender, EventArgs e)
        {
            if(Title != titleTxtBox.Text)
            {
                saveButton.Enabled = true;
            }
        }

        private void albumTxtBox_TextChanged(object sender, EventArgs e)
        {
            if (Album != albumTxtBox.Text)
                saveButton.Enabled = true;
        }
    }
}
