package com.greengecko.musicplayer;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {
    private Intent intent;
    private Button start, stop;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("서비스 테스트 예제");

        init();
        setAction();
    }

    private void init() {
        intent = new Intent(getApplicationContext(), MusicService.class);

        start = findViewById(R.id.start);
        stop = findViewById(R.id.stop);
    }

    private void setAction() {
        start.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startService(intent);
                Log.println(Log.INFO, "SERVICE_TEST", "Called startService(intent) function");
            }
        });
        stop.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                stopService(intent);
                Log.println(Log.INFO, "SERVICE_TEST", "Called stopService(intent) function");
            }
        });
    }
}