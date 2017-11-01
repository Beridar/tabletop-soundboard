﻿using NAudio.Vorbis;
using NAudio.Wave;

namespace Soundboard
{
    public interface IOggPlayer : IPlayer
    {
    }

    public class OggPlayer : Player, IOggPlayer
    {
        public void LoadFile(string filename)
        {
            Dispose();

            reader = new VorbisWaveReader(filename);
            player = new WaveOutEvent();
        }
    }
}