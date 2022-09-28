using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundCheck
{
    public partial class Form1 : Form
    {

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            outputDevice.Dispose();
            outputDevice = null;
            
        }
        private void OnButtonStopClick(object sender, EventArgs args)
        {
            outputDevice?.Stop();
        }
        private void OnButtonPlayClick(object sender, EventArgs args)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                OpenFileDialog dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var audioOne = new AudioFileReader(@"C:\Users\hallocol\source\repos\SoundCheck\SoundCheck\casetteSound.mp3");
                    audioFile = new AudioFileReader(dialog.FileName);
                    outputDevice.Init(audioOne);
                    outputDevice.Play();
                  
                }
                outputDevice.Init(audioFile);
                outputDevice.Play();
            }
            else
            {
                outputDevice.Play();
            }
           
        }
    }
    public class Sounds
    {
        public void PlaySounds()
        {
            
        }
    }
}
