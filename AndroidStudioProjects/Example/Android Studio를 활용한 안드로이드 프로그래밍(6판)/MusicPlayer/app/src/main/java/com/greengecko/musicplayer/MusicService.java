package com.greengecko.musicplayer;

import android.app.Service;
import android.content.Intent;
import android.media.MediaPlayer;
import android.os.IBinder;
import android.util.Log;

public class MusicService extends Service {
    private MediaPlayer mediaPlayer;

    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public int onStartCommand(Intent intent, int flags, int startId) {
        Log.println(Log.INFO, "SERVICE_TEST", "Called onStartCommand(intent, flags, startId) function");
        mediaPlayer = MediaPlayer.create(getApplicationContext(), R.raw.ruinedmylife);
        mediaPlayer.setLooping(true);
        mediaPlayer.start();
        return super.onStartCommand(intent, flags, startId);
    }

    @Override
    public void onDestroy() {
        Log.println(Log.INFO, "SERVICE_TEST", "Called onDestroy() function");
        mediaPlayer.stop();
        mediaPlayer.release();
        super.onDestroy();
    }

    @Override
    public void onCreate() {
        Log.println(Log.INFO, "SERVICE_TEST", "Called onCreate() function");
        super.onCreate();
    }
}
