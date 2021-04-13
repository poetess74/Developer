package com.example.automatedgallery;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ViewFlipper;

public class MainActivity extends AppCompatActivity {
    Button start, stop;
    ViewFlipper flipper;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        start = findViewById(R.id.btnStart);
        stop = findViewById(R.id.btnStop);

        flipper = findViewById(R.id.viewFlipper1);
        flipper.setFlipInterval(1000);

        start.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                flipper.startFlipping();
            }
        });

        stop.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                flipper.stopFlipping();
            }
        });
    }
}