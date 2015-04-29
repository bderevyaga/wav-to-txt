using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NAudio.Wave;
using System.IO;

namespace Sig
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WaveFileReader pcm = new WaveFileReader(@"D:\\5.wav"))
            {
                long samplesDesired = pcm.Length;
                byte[] buffer = new byte[samplesDesired];
                int bytesRead = pcm.Read(buffer, 0, buffer.Length);
                int index = 0;
                string path = @"D:\\5.txt";
                FileStream fs = File.Create(path);
                for (int sample = 0; sample < bytesRead / 2; sample++)
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(BitConverter.ToInt16(buffer, index) + "\n");
                    fs.Write(info, 0, info.Length);
                    index += 2;
                }
                fs.Close();
            }
        }
    }
}