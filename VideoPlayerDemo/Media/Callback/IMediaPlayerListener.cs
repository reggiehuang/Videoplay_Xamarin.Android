using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace VideoPlayerDemo.Media.Callback
{
 
    public interface IMediaPlayerListener
    {
        void Start();

        void Pause();

        int GetDuration();

        int GetCurrentPosition();

        void SeekTo(long pos);

        bool IsPlaying();

        int GetBufferPercentage();

        bool CanPause();
    }
}