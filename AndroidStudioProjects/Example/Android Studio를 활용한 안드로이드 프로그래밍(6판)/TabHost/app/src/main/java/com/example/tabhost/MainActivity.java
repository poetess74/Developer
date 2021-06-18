package com.example.tabhost;

import android.app.TabActivity;
import android.os.Bundle;
import android.widget.TabHost;

public class MainActivity extends TabActivity {
    //android.app.TabActivity is deprecated as of API 13.

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        TabHost host = getTabHost();

        TabHost.TabSpec song = host.newTabSpec("SONG").setIndicator("음악별");
        song.setContent(R.id.tabSong);
        host.addTab(song);

        TabHost.TabSpec artist = host.newTabSpec("ARTIST").setIndicator("가수별");
        artist.setContent(R.id.tabArtist);
        host.addTab(artist);

        TabHost.TabSpec album = host.newTabSpec("ALBUM").setIndicator("앨범별");
        album.setContent(R.id.tabAlbum);
        host.addTab(album);

        host.setCurrentTab(0);
    }
}